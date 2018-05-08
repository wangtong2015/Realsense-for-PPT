using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealSenseProject
{
    public class HandsRecognition
    {
        byte[] LUT;
        private MainForm form;
        private bool _disconnected = false;
        //Queue containing depth image - for synchronization purposes
        private Queue<PXCMImage> m_images;
        private const int NumberOfFramesToDelay = 3;
        private int _framesCounter = 0;
        private float _maxRange;
        public enum Hand { LeftHand, RightHand, BothHands };

        class GestureDetect
        {
            [DllImport("Kernel32.dll")]
            private static extern bool QueryPerformanceCounter(out long data);
            [DllImport("Kernel32.dll")]
            private static extern bool QueryPerformanceFrequency(out long data);

            private string gesture;
            long last, freq;
            public Action handler;
            
            Hand handType;
            public GestureDetect()
            {
                gesture = null;
                handType = Hand.LeftHand;
                QueryPerformanceFrequency(out freq);
                QueryPerformanceCounter(out last);
                handler = new Action(() => { });
            }

            public void Check(string currentGesture, Hand _handType, int timeInterval)
            {
                if (currentGesture == gesture && ((handType == Hand.BothHands) || (handType) == _handType))
                {
                    long now;
                    QueryPerformanceCounter(out now);
                    if ((now - last) >= (freq) * timeInterval)
                    {
                        handler();
                        last = now;
                    }
                }
            }

            public string Gesture
            {
                get
                {
                    return gesture;
                }
                set
                {
                    gesture = value;
                }
            }
            public Hand HandType
            {
                get
                {
                    return handType;
                }
                set
                {
                    handType = value;
                }
            }
        }
        private GestureDetect NextPageGesture;
        private GestureDetect PreviousPageGesture;
        private GestureDetect FirstPageGesture;
        private GestureDetect EndPageGesture;
        public HandsRecognition(MainForm form)
        {
            m_images = new Queue<PXCMImage>();
            this.form = form;
            LUT = Enumerable.Repeat((byte)0, 256).ToArray();
            LUT[255] = 1;
            NextPageGesture = new GestureDetect();
            PreviousPageGesture = new GestureDetect();
            FirstPageGesture = new GestureDetect();
            EndPageGesture = new GestureDetect();

        }

        /* Checking if sensor device connect or not */
        private bool DisplayDeviceConnection(bool state)
        {
            if (state)
            {
                if (!_disconnected) form.UpdateStatus("Device Disconnected");
                _disconnected = true;
            }
            else
            {
                if (_disconnected) form.UpdateStatus("Device Reconnected");
                _disconnected = false;
            }
            return _disconnected;
        }

        /* Displaying current frame gestures */
        private void DisplayGesture(PXCMHandData handAnalysis, int frameNumber)
        {

            int firedGesturesNumber = handAnalysis.QueryFiredGesturesNumber();
            string gestureStatusLeft = string.Empty;
            string gestureStatusRight = string.Empty;
            if (firedGesturesNumber == 0)
            {

                return;
            }

            for (int i = 0; i < firedGesturesNumber; i++)
            {
                PXCMHandData.GestureData gestureData;
                if (handAnalysis.QueryFiredGestureData(i, out gestureData) == pxcmStatus.PXCM_STATUS_NO_ERROR)
                {
                    PXCMHandData.IHand handData;
                    if (handAnalysis.QueryHandDataById(gestureData.handId, out handData) != pxcmStatus.PXCM_STATUS_NO_ERROR)
                        return;

                    PXCMHandData.BodySideType bodySideType = handData.QueryBodySide();
                    if (bodySideType == PXCMHandData.BodySideType.BODY_SIDE_LEFT)
                    {
                        gestureStatusLeft += "Left Hand Gesture: " + gestureData.name;
                        NextPageGesture.Check(gestureData.name,Hand.LeftHand,form.GetInterval());
                        PreviousPageGesture.Check(gestureData.name,Hand.LeftHand,form.GetInterval());
                        FirstPageGesture.Check(gestureData.name, Hand.LeftHand, form.GetInterval());
                        EndPageGesture.Check(gestureData.name, Hand.LeftHand, form.GetInterval());
                    }
                    else if (bodySideType == PXCMHandData.BodySideType.BODY_SIDE_RIGHT)
                    {
                        gestureStatusRight += "Right Hand Gesture: " + gestureData.name;
                        NextPageGesture.Check(gestureData.name, Hand.RightHand, form.GetInterval());
                        PreviousPageGesture.Check(gestureData.name, Hand.RightHand, form.GetInterval());
                        FirstPageGesture.Check(gestureData.name, Hand.RightHand, form.GetInterval());
                        EndPageGesture.Check(gestureData.name, Hand.RightHand, form.GetInterval());
                    }

                    

                }

            }
            if (gestureStatusLeft == String.Empty)
                form.UpdateInfo("Frame " + frameNumber + ") " + gestureStatusRight + "\n", Color.SeaGreen);
            else
                form.UpdateInfo("Frame " + frameNumber + ") " + gestureStatusLeft + ", " + gestureStatusRight + "\n", Color.SeaGreen);

        }

        /* Displaying Depth/Mask Images - for depth image only we use a delay of NumberOfFramesToDelay to sync image with tracking */
        private unsafe void DisplayPicture(PXCMImage depth, PXCMHandData handAnalysis)
        {
            if (depth == null)
                return;

            PXCMImage image = depth;

            //Mask Image
            if (form.GetLabelmapState())
            {
                Bitmap labeledBitmap = null;
                try
                {
                    labeledBitmap = new Bitmap(image.info.width, image.info.height, PixelFormat.Format32bppRgb);
                }
                catch (Exception)
                {
                    image.Dispose();
                    return;
                }

                for (int j = 0; j < handAnalysis.QueryNumberOfHands(); j++)
                {
                    int id;
                    PXCMImage.ImageData data;

                    handAnalysis.QueryHandId(PXCMHandData.AccessOrderType.ACCESS_ORDER_BY_TIME, j, out id);
                    //Get hand by time of appearance
                    PXCMHandData.IHand handData;
                    handAnalysis.QueryHandData(PXCMHandData.AccessOrderType.ACCESS_ORDER_BY_TIME, j, out handData);
                    if (handData != null &&
                        (handData.QuerySegmentationImage(out image) >= pxcmStatus.PXCM_STATUS_NO_ERROR))
                    {
                        if (image.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_Y8,
                            out data) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
                        {
                            Rectangle rect = new Rectangle(0, 0, image.info.width, image.info.height);

                            BitmapData bitmapdata = labeledBitmap.LockBits(rect, ImageLockMode.ReadWrite, labeledBitmap.PixelFormat);
                            byte* numPtr = (byte*)bitmapdata.Scan0; //dst
                            byte* numPtr2 = (byte*)data.planes[0]; //row
                            int imagesize = image.info.width * image.info.height;
                            byte num2 = (byte)handData.QueryBodySide();

                            byte tmp = 0;
                            for (int i = 0; i < imagesize; i++, numPtr += 4, numPtr2++)
                            {
                                tmp = (byte)(LUT[numPtr2[0]] * num2 * 100);
                                numPtr[0] = (Byte)(tmp | numPtr[0]);
                                numPtr[1] = (Byte)(tmp | numPtr[1]);
                                numPtr[2] = (Byte)(tmp | numPtr[2]);
                                numPtr[3] = 0xff;
                            }

                            bool isError = false;

                            try
                            {
                                labeledBitmap.UnlockBits(bitmapdata);
                            }
                            catch (Exception)
                            {
                                isError = true;
                            }
                            try
                            {
                                image.ReleaseAccess(data);
                            }
                            catch (Exception)
                            {
                                isError = true;
                            }

                            if (isError)
                            {
                                labeledBitmap.Dispose();
                                image.Dispose();
                                return;
                            }

                        }
                    }
                }
                if (labeledBitmap != null)
                {
                    form.DisplayBitmap(labeledBitmap);
                    labeledBitmap.Dispose();
                }
                image.Dispose();

            }//end label image

            //Depth Image
            else
            {
                //collecting 3 images inside a queue and displaying the oldest image
                PXCMImage.ImageInfo info;
                PXCMImage image2;

                info = image.QueryInfo();
                image2 = form.g_session.CreateImage(info);
                image2.CopyImage(image);
                m_images.Enqueue(image2);
                if (m_images.Count == NumberOfFramesToDelay)
                {
                    Bitmap depthBitmap;
                    try
                    {
                        depthBitmap = new Bitmap(image.info.width, image.info.height, PixelFormat.Format32bppRgb);
                    }
                    catch (Exception)
                    {
                        image.Dispose();
                        PXCMImage queImage = m_images.Dequeue();
                        queImage.Dispose();
                        return;
                    }

                    PXCMImage.ImageData data3;
                    PXCMImage image3 = m_images.Dequeue();
                    if (image3.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_DEPTH, out data3) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
                    {
                        float fMaxValue = _maxRange;
                        byte cVal;

                        Rectangle rect = new Rectangle(0, 0, image.info.width, image.info.height);
                        BitmapData bitmapdata = depthBitmap.LockBits(rect, ImageLockMode.ReadWrite, depthBitmap.PixelFormat);

                        byte* pDst = (byte*)bitmapdata.Scan0;
                        short* pSrc = (short*)data3.planes[0];
                        int size = image.info.width * image.info.height;

                        for (int i = 0; i < size; i++, pSrc++, pDst += 4)
                        {
                            cVal = (byte)((*pSrc) / fMaxValue * 255);
                            if (cVal != 0)
                                cVal = (byte)(255 - cVal);

                            pDst[0] = cVal;
                            pDst[1] = cVal;
                            pDst[2] = cVal;
                            pDst[3] = 255;
                        }
                        try
                        {
                            depthBitmap.UnlockBits(bitmapdata);
                        }
                        catch (Exception)
                        {
                            image3.ReleaseAccess(data3);
                            depthBitmap.Dispose();
                            image3.Dispose();
                            return;
                        }

                        form.DisplayBitmap(depthBitmap);
                        image3.ReleaseAccess(data3);
                    }
                    depthBitmap.Dispose();
                    image3.Dispose();
                }
            }
        }



        /* Displaying current frames hand joints */
        private void DisplayJoints(PXCMHandData handOutput, long timeStamp = 0)
        {
            if (form.GetJointsState() || form.GetSkeletonState())
            {
                //Iterate hands
                PXCMHandData.JointData[][] nodes = new PXCMHandData.JointData[][] { new PXCMHandData.JointData[0x20], new PXCMHandData.JointData[0x20] };
                int numOfHands = handOutput.QueryNumberOfHands();
                for (int i = 0; i < numOfHands; i++)
                {
                    //Get hand by time of appearence
                    //PXCMHandAnalysis.HandData handData = new PXCMHandAnalysis.HandData();
                    PXCMHandData.IHand handData;
                    if (handOutput.QueryHandData(PXCMHandData.AccessOrderType.ACCESS_ORDER_BY_TIME, i, out handData) == pxcmStatus.PXCM_STATUS_NO_ERROR)
                    {
                        if (handData != null)
                        {
                            //Iterate Joints
                            for (int j = 0; j < 0x20; j++)
                            {
                                PXCMHandData.JointData jointData;
                                handData.QueryTrackedJoint((PXCMHandData.JointType)j, out jointData);
                                nodes[i][j] = jointData;

                            } // end iterating over joints
                        }
                    }
                } // end itrating over hands

                form.DisplayJoints(nodes, numOfHands);
            }
            else
            {
                form.DisplayJoints(null, 0);
            }
        }

        /* Displaying current frame alerts */
        private void DisplayAlerts(PXCMHandData handAnalysis, int frameNumber)
        {
            bool isChanged = false;
            string sAlert = "Alert: ";
            for (int i = 0; i < handAnalysis.QueryFiredAlertsNumber(); i++)
            {
                PXCMHandData.AlertData alertData;
                if (handAnalysis.QueryFiredAlertData(i, out alertData) != pxcmStatus.PXCM_STATUS_NO_ERROR)
                    continue;

                //See PXCMHandAnalysis.AlertData.AlertType for all available alerts
                switch (alertData.label)
                {
                    case PXCMHandData.AlertType.ALERT_HAND_DETECTED:
                        {

                            sAlert += "Hand Detected, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_NOT_DETECTED:
                        {

                            sAlert += "Hand Not Detected, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_CALIBRATED:
                        {

                            sAlert += "Hand Calibrated, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_NOT_CALIBRATED:
                        {

                            sAlert += "Hand Not Calibrated, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_INSIDE_BORDERS:
                        {

                            sAlert += "Hand Inside Border, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_OUT_OF_BORDERS:
                        {

                            sAlert += "Hand Out Of Borders, ";
                            isChanged = true;
                            break;
                        }
                }
            }
            if (isChanged)
            {
                form.UpdateInfo("Frame " + frameNumber + ") " + sAlert + "\n", Color.RoyalBlue);
            }


        }

        public static pxcmStatus OnNewFrame(Int32 mid, PXCMBase module, PXCMCapture.Sample sample)
        {
            return pxcmStatus.PXCM_STATUS_NO_ERROR;
        }





        /* Using PXCMSenseManager to handle data */
        public void SimplePipeline()
        {
            form.UpdateInfo(String.Empty, Color.Black);
            bool liveCamera = false;

            bool flag = true;
            PXCMSenseManager instance = null;
            _disconnected = false;
            instance = form.g_session.CreateSenseManager();
            if (instance == null)
            {
                form.UpdateStatus("Failed creating SenseManager");
                return;
            }

            if (form.GetRecordState())
            {
                instance.captureManager.SetFileName(form.GetFileName(), true);
                PXCMCapture.DeviceInfo info;
                if (form.Devices.TryGetValue(form.GetCheckedDevice(), out info))
                {
                    instance.captureManager.FilterByDeviceInfo(info);
                }

            }
            else if (form.GetPlaybackState())
            {
                instance.captureManager.SetFileName(form.GetFileName(), false);
                instance.captureManager.SetRealtime(false);
            }
            else
            {
                PXCMCapture.DeviceInfo info;
                if (String.IsNullOrEmpty(form.GetCheckedDevice()))
                {
                    form.UpdateStatus("Device Failure");
                    return;
                }

                if (form.Devices.TryGetValue(form.GetCheckedDevice(), out info))
                {
                    instance.captureManager.FilterByDeviceInfo(info);
                }

                liveCamera = true;
            }
            /* Set Module */
            pxcmStatus status = instance.EnableHand(form.GetCheckedModule());
            PXCMHandModule handAnalysis = instance.QueryHand();

            if (status != pxcmStatus.PXCM_STATUS_NO_ERROR || handAnalysis == null)
            {
                form.UpdateStatus("Failed Loading Module");
                return;
            }

            PXCMSenseManager.Handler handler = new PXCMSenseManager.Handler();
            handler.onModuleProcessedFrame = new PXCMSenseManager.Handler.OnModuleProcessedFrameDelegate(OnNewFrame);


            PXCMHandConfiguration handConfiguration = handAnalysis.CreateActiveConfiguration();
            PXCMHandData handData = handAnalysis.CreateOutput();

            if (handConfiguration == null)
            {
                form.UpdateStatus("Failed Create Configuration");
                return;
            }
            if (handData == null)
            {
                form.UpdateStatus("Failed Create Output");
                return;
            }

            if (form.getInitGesturesFirstTime() == false)
            {
                int totalNumOfGestures = handConfiguration.QueryGesturesTotalNumber();
                if (totalNumOfGestures > 0)
                {
                    this.form.UpdateGesturesToList("", 0);
                    for (int i = 0; i < totalNumOfGestures; i++)
                    {
                        string gestureName = string.Empty;
                        if (handConfiguration.QueryGestureNameByIndex(i, out gestureName) ==
                            pxcmStatus.PXCM_STATUS_NO_ERROR)
                        {
                            this.form.UpdateGesturesToList(gestureName, i + 1);
                        }


                    }
                    form.setInitGesturesFirstTime(true);
                    form.UpdateGesturesListSize();
                }
            }


            FPSTimer timer = new FPSTimer(form);
            form.UpdateStatus("Init Started");
            if (handAnalysis != null && instance.Init(handler) == pxcmStatus.PXCM_STATUS_NO_ERROR)
            {

                PXCMCapture.DeviceInfo dinfo;

                PXCMCapture.Device device = instance.captureManager.device;
                if (device != null)
                {
                    pxcmStatus result = device.QueryDeviceInfo(out dinfo);
                    if (result == pxcmStatus.PXCM_STATUS_NO_ERROR && dinfo != null && dinfo.model == PXCMCapture.DeviceModel.DEVICE_MODEL_IVCAM)
                    {
                        device.SetDepthConfidenceThreshold(1);
                        device.SetMirrorMode(PXCMCapture.Device.MirrorMode.MIRROR_MODE_DISABLED);
                        device.SetIVCAMFilterOption(6);
                    }

                    _maxRange = device.QueryDepthSensorRange().max;

                }


                if (handConfiguration != null)
                {
                    handConfiguration.EnableAllAlerts();
                    handConfiguration.EnableSegmentationImage(true);

                    handConfiguration.ApplyChanges();
                    handConfiguration.Update();
                }

                form.UpdateStatus("Streaming");
                int frameCounter = 0;
                int frameNumber = 0;
                string nextPageGesture, previousPageGesture, firstPageGesture, endPageGesture;
                HandsRecognition.Hand nextHand,previousHand, firstHand, endHand;
                
                while (!form.stop)
                {
                    form.GetHandType(out nextHand, out previousHand, out firstHand, out endHand);
                    form.GetGestureName(out nextPageGesture, out previousPageGesture, out firstPageGesture, out endPageGesture);
                    handConfiguration.DisableAllGestures();
                    if (string.IsNullOrEmpty(nextPageGesture) == false && handConfiguration.IsGestureEnabled(nextPageGesture) == false)
                    {
                        handConfiguration.EnableGesture(nextPageGesture, true);
                        NextPageGesture.Gesture = nextPageGesture;
                        NextPageGesture.handler = form.NextPage;
                        NextPageGesture.HandType = nextHand;
                    }
                    if (string.IsNullOrEmpty(previousPageGesture) == false && handConfiguration.IsGestureEnabled(previousPageGesture) == false)
                    {
                        handConfiguration.EnableGesture(previousPageGesture, true);
                        PreviousPageGesture.Gesture = previousPageGesture;
                        PreviousPageGesture.handler = form.PreviousPage;
                        PreviousPageGesture.HandType = previousHand;
                    }
                    if (string.IsNullOrEmpty(firstPageGesture) == false && handConfiguration.IsGestureEnabled(firstPageGesture) == false)
                    {
                        handConfiguration.EnableGesture(firstPageGesture, true);
                        FirstPageGesture.Gesture = firstPageGesture;
                        FirstPageGesture.handler = form.FirstPage;
                        FirstPageGesture.HandType = firstHand;
                    }
                    if (string.IsNullOrEmpty(endPageGesture) == false && handConfiguration.IsGestureEnabled(endPageGesture) == false)
                    {
                        handConfiguration.EnableGesture(endPageGesture, true);
                        EndPageGesture.Gesture = endPageGesture;
                        EndPageGesture.handler = form.EndPage;
                        EndPageGesture.HandType = endHand;
                    }
                    handConfiguration.ApplyChanges();
                    if (instance.AcquireFrame(true) < pxcmStatus.PXCM_STATUS_NO_ERROR)
                    {
                        break;
                    }

                    frameCounter++;

                    if (!DisplayDeviceConnection(!instance.IsConnected()))
                    {

                        if (handData != null)
                        {
                            handData.Update();
                        }

                        PXCMCapture.Sample sample = instance.QueryHandSample();
                        if (sample != null && sample.depth != null)
                        {
                            DisplayPicture(sample.depth, handData);

                            if (handData != null)
                            {
                                frameNumber = liveCamera ? frameCounter : instance.captureManager.QueryFrameIndex();

                                DisplayJoints(handData);
                                DisplayGesture(handData, frameNumber);
                                DisplayAlerts(handData, frameNumber);
                            }
                            form.UpdatePanel();
                        }
                        timer.Tick();
                    }
                    instance.ReleaseFrame();
                }

                // Clean Up
                if (handData != null) handData.Dispose();
                if (handConfiguration != null) handConfiguration.Dispose();
            }
            else
            {
                form.UpdateStatus("Init Failed");
                flag = false;
            }
            foreach (PXCMImage pxcmImage in m_images)
            {
                pxcmImage.Dispose();
            }



            instance.Close();
            instance.Dispose();
            if (flag)
            {
                form.UpdateStatus("Stopped");
            }
        }
    }
}
