using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;

namespace RealSenseProject
{
    public class PPT
    {
        Application pptAPP;
        Presentation pptPre;
        Slides slides;
        SlideShowSettings slideShow;
        String fileName;
        public PPT(String _filename)
        {
            this.fileName = _filename;
            pptAPP = new Application();
            pptAPP.Visible = MsoTriState.msoTrue;
            pptPre = pptAPP.Presentations.Open(_filename, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
            slideShow = pptPre.SlideShowSettings;
            slideShow.Run();
            

        }


        public void FirstPage()
        {
            pptPre.SlideShowWindow.View.First();
        }

        public void NextPage()
        {
            pptPre.SlideShowWindow.View.Next();
        }

        public void PreviousPage()
        {
            pptPre.SlideShowWindow.View.Previous();
        }

        public void LastPage()
        {
            pptPre.SlideShowWindow.View.Last();
        }
    }
}
