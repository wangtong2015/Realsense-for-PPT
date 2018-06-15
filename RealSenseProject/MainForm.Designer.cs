namespace RealSenseProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Live = new System.Windows.Forms.ToolStripMenuItem();
            this.Playback = new System.Windows.Forms.ToolStripMenuItem();
            this.Record = new System.Windows.Forms.ToolStripMenuItem();
            this.Joints = new System.Windows.Forms.CheckBox();
            this.Depth = new System.Windows.Forms.RadioButton();
            this.Labelmap = new System.Windows.Forms.RadioButton();
            this.Skeleton = new System.Windows.Forms.CheckBox();
            this.Status2 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Scale2 = new System.Windows.Forms.CheckBox();
            this.Panel2 = new System.Windows.Forms.PictureBox();
            this.Mirror = new System.Windows.Forms.CheckBox();
            this.GestureBox_1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFPS = new System.Windows.Forms.Label();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.Hand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonPPT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GestureBox_2 = new System.Windows.Forms.ComboBox();
            this.GestureBox_3 = new System.Windows.Forms.ComboBox();
            this.GestureBox_4 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HandBox_1 = new System.Windows.Forms.ComboBox();
            this.HandBox_2 = new System.Windows.Forms.ComboBox();
            this.HandBox_3 = new System.Windows.Forms.ComboBox();
            this.HandBox_4 = new System.Windows.Forms.ComboBox();
            this.MainMenu.SuspendLayout();
            this.Status2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Start.Location = new System.Drawing.Point(847, 101);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(80, 35);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(847, 167);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(80, 35);
            this.Stop.TabIndex = 3;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(92, 32);
            this.sourceToolStripMenuItem.Text = "Device";
            // 
            // moduleToolStripMenuItem
            // 
            this.moduleToolStripMenuItem.Name = "moduleToolStripMenuItem";
            this.moduleToolStripMenuItem.Size = new System.Drawing.Size(102, 32);
            this.moduleToolStripMenuItem.Text = "Module";
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceToolStripMenuItem,
            this.moduleToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(1305, 36);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Live,
            this.Playback,
            this.Record});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(83, 32);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // Live
            // 
            this.Live.Checked = true;
            this.Live.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Live.Name = "Live";
            this.Live.Size = new System.Drawing.Size(191, 34);
            this.Live.Text = "Live";
            this.Live.Click += new System.EventHandler(this.Live_Click);
            // 
            // Playback
            // 
            this.Playback.Name = "Playback";
            this.Playback.Size = new System.Drawing.Size(191, 34);
            this.Playback.Text = "Playback";
            this.Playback.Click += new System.EventHandler(this.Playback_Click);
            // 
            // Record
            // 
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(191, 34);
            this.Record.Text = "Record";
            this.Record.Click += new System.EventHandler(this.Record_Click);
            // 
            // Joints
            // 
            this.Joints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Joints.AutoSize = true;
            this.Joints.Checked = true;
            this.Joints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Joints.Location = new System.Drawing.Point(1102, 173);
            this.Joints.Name = "Joints";
            this.Joints.Size = new System.Drawing.Size(102, 25);
            this.Joints.TabIndex = 19;
            this.Joints.Text = "Joints";
            this.Joints.UseVisualStyleBackColor = true;
            // 
            // Depth
            // 
            this.Depth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Depth.AutoSize = true;
            this.Depth.Checked = true;
            this.Depth.Location = new System.Drawing.Point(1103, 43);
            this.Depth.Name = "Depth";
            this.Depth.Size = new System.Drawing.Size(90, 25);
            this.Depth.TabIndex = 20;
            this.Depth.TabStop = true;
            this.Depth.Text = "Depth";
            this.Depth.UseVisualStyleBackColor = true;
            // 
            // Labelmap
            // 
            this.Labelmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Labelmap.AutoSize = true;
            this.Labelmap.Location = new System.Drawing.Point(1102, 74);
            this.Labelmap.Name = "Labelmap";
            this.Labelmap.Size = new System.Drawing.Size(178, 25);
            this.Labelmap.TabIndex = 21;
            this.Labelmap.Text = "Labeled Image";
            this.Labelmap.UseVisualStyleBackColor = true;
            // 
            // Skeleton
            // 
            this.Skeleton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Skeleton.AutoSize = true;
            this.Skeleton.Checked = true;
            this.Skeleton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Skeleton.Location = new System.Drawing.Point(1102, 204);
            this.Skeleton.Name = "Skeleton";
            this.Skeleton.Size = new System.Drawing.Size(124, 25);
            this.Skeleton.TabIndex = 23;
            this.Skeleton.Text = "Skeleton";
            this.Skeleton.UseVisualStyleBackColor = true;
            // 
            // Status2
            // 
            this.Status2.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.Status2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.Status2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Status2.Location = new System.Drawing.Point(0, 527);
            this.Status2.Name = "Status2";
            this.Status2.Size = new System.Drawing.Size(1305, 33);
            this.Status2.TabIndex = 25;
            this.Status2.Text = "Status2";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(42, 28);
            this.StatusLabel.Text = "OK";
            // 
            // Scale2
            // 
            this.Scale2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Scale2.AutoSize = true;
            this.Scale2.Checked = true;
            this.Scale2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Scale2.Location = new System.Drawing.Point(1102, 111);
            this.Scale2.Name = "Scale2";
            this.Scale2.Size = new System.Drawing.Size(91, 25);
            this.Scale2.TabIndex = 26;
            this.Scale2.Text = "Scale";
            this.Scale2.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackgroundImage = global::RealSenseProject.Properties.Resources._4aaddb3230afea7d9f03771009c09aafd6a2075a;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.ErrorImage = null;
            this.Panel2.InitialImage = null;
            this.Panel2.Location = new System.Drawing.Point(377, 105);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(400, 401);
            this.Panel2.TabIndex = 27;
            this.Panel2.TabStop = false;
            // 
            // Mirror
            // 
            this.Mirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Mirror.AutoSize = true;
            this.Mirror.Checked = true;
            this.Mirror.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Mirror.Location = new System.Drawing.Point(1102, 142);
            this.Mirror.Name = "Mirror";
            this.Mirror.Size = new System.Drawing.Size(102, 25);
            this.Mirror.TabIndex = 30;
            this.Mirror.Text = "Mirror";
            this.Mirror.UseVisualStyleBackColor = true;
            // 
            // GestureBox_1
            // 
            this.GestureBox_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GestureBox_1.FormattingEnabled = true;
            this.GestureBox_1.Location = new System.Drawing.Point(1008, 244);
            this.GestureBox_1.Name = "GestureBox_1";
            this.GestureBox_1.Size = new System.Drawing.Size(121, 29);
            this.GestureBox_1.TabIndex = 35;
            this.GestureBox_1.SelectedIndexChanged += new System.EventHandler(this.nextGestureBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(876, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 35);
            this.label2.TabIndex = 38;
            this.label2.Text = "J";
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Location = new System.Drawing.Point(460, 360);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(0, 21);
            this.labelFPS.TabIndex = 39;
            // 
            // infoTextBox
            // 
            this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextBox.Location = new System.Drawing.Point(12, 39);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(346, 475);
            this.infoTextBox.TabIndex = 40;
            this.infoTextBox.Text = "";
            // 
            // Hand
            // 
            this.Hand.Location = new System.Drawing.Point(1004, 142);
            this.Hand.Name = "Hand";
            this.Hand.Size = new System.Drawing.Size(70, 23);
            this.Hand.TabIndex = 41;
            this.Hand.Text = "Hand:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1004, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 42;
            this.label1.Text = "Panel:";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(498, 31);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(256, 21);
            this.Title.TabIndex = 43;
            this.Title.Text = "王童小组的Realsense展示";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 21);
            this.label3.TabIndex = 44;
            this.label3.Text = "王童、任达伟、单昭";
            // 
            // ButtonPPT
            // 
            this.ButtonPPT.Location = new System.Drawing.Point(847, 35);
            this.ButtonPPT.Name = "ButtonPPT";
            this.ButtonPPT.Size = new System.Drawing.Size(80, 35);
            this.ButtonPPT.TabIndex = 45;
            this.ButtonPPT.Text = "PPT";
            this.ButtonPPT.UseVisualStyleBackColor = true;
            this.ButtonPPT.Click += new System.EventHandler(this.ButtonPPT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(876, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 21);
            this.label4.TabIndex = 46;
            this.label4.Text = "K";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(876, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 21);
            this.label5.TabIndex = 47;
            this.label5.Text = "L";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(876, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 21);
            this.label6.TabIndex = 48;
            this.label6.Text = "U";
            // 
            // GestureBox_2
            // 
            this.GestureBox_2.FormattingEnabled = true;
            this.GestureBox_2.Location = new System.Drawing.Point(1008, 293);
            this.GestureBox_2.Name = "GestureBox_2";
            this.GestureBox_2.Size = new System.Drawing.Size(121, 29);
            this.GestureBox_2.TabIndex = 49;
            this.GestureBox_2.SelectedIndexChanged += new System.EventHandler(this.upGestureBox_SelectedIndexChanged);
            // 
            // GestureBox_3
            // 
            this.GestureBox_3.FormattingEnabled = true;
            this.GestureBox_3.Location = new System.Drawing.Point(1008, 346);
            this.GestureBox_3.Name = "GestureBox_3";
            this.GestureBox_3.Size = new System.Drawing.Size(121, 29);
            this.GestureBox_3.TabIndex = 50;
            this.GestureBox_3.SelectedIndexChanged += new System.EventHandler(this.firstGestureBox_SelectedIndexChanged);
            // 
            // GestureBox_4
            // 
            this.GestureBox_4.FormattingEnabled = true;
            this.GestureBox_4.Location = new System.Drawing.Point(1008, 390);
            this.GestureBox_4.Name = "GestureBox_4";
            this.GestureBox_4.Size = new System.Drawing.Size(121, 29);
            this.GestureBox_4.TabIndex = 51;
            this.GestureBox_4.SelectedIndexChanged += new System.EventHandler(this.endGestureBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(810, 441);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 21);
            this.label7.TabIndex = 52;
            this.label7.Text = "Time interval(s)";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(1008, 441);
            this.numericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(120, 31);
            this.numericUpDown.TabIndex = 53;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // HandBox_1
            // 
            this.HandBox_1.DisplayMember = "0";
            this.HandBox_1.FormattingEnabled = true;
            this.HandBox_1.Items.AddRange(new object[] {
            "left_hand",
            "right_hand",
            "both_hands"});
            this.HandBox_1.Location = new System.Drawing.Point(1153, 244);
            this.HandBox_1.Name = "HandBox_1";
            this.HandBox_1.Size = new System.Drawing.Size(121, 29);
            this.HandBox_1.TabIndex = 54;
            this.HandBox_1.Text = "left_hand";
            this.HandBox_1.SelectedIndexChanged += new System.EventHandler(this.NextHandBox_SelectedIndexChanged);
            // 
            // HandBox_2
            // 
            this.HandBox_2.FormattingEnabled = true;
            this.HandBox_2.Items.AddRange(new object[] {
            "left_hand",
            "right_hand",
            "both_hands"});
            this.HandBox_2.Location = new System.Drawing.Point(1153, 296);
            this.HandBox_2.Name = "HandBox_2";
            this.HandBox_2.Size = new System.Drawing.Size(121, 29);
            this.HandBox_2.TabIndex = 55;
            this.HandBox_2.Text = "left_hand";
            this.HandBox_2.SelectedIndexChanged += new System.EventHandler(this.PreviousHandBox_SelectedIndexChanged);
            // 
            // HandBox_3
            // 
            this.HandBox_3.FormattingEnabled = true;
            this.HandBox_3.Items.AddRange(new object[] {
            "left_hand",
            "right_hand",
            "both_hands"});
            this.HandBox_3.Location = new System.Drawing.Point(1153, 346);
            this.HandBox_3.Name = "HandBox_3";
            this.HandBox_3.Size = new System.Drawing.Size(121, 29);
            this.HandBox_3.TabIndex = 56;
            this.HandBox_3.Text = "right_hand";
            this.HandBox_3.SelectedIndexChanged += new System.EventHandler(this.FirstHandBox_SelectedIndexChanged);
            // 
            // HandBox_4
            // 
            this.HandBox_4.FormattingEnabled = true;
            this.HandBox_4.Items.AddRange(new object[] {
            "left_hand",
            "right_hand",
            "both_hands"});
            this.HandBox_4.Location = new System.Drawing.Point(1153, 390);
            this.HandBox_4.Name = "HandBox_4";
            this.HandBox_4.Size = new System.Drawing.Size(121, 29);
            this.HandBox_4.TabIndex = 57;
            this.HandBox_4.Text = "right_hand";
            this.HandBox_4.SelectedIndexChanged += new System.EventHandler(this.EndHandBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1305, 560);
            this.Controls.Add(this.HandBox_4);
            this.Controls.Add(this.HandBox_3);
            this.Controls.Add(this.HandBox_2);
            this.Controls.Add(this.HandBox_1);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GestureBox_4);
            this.Controls.Add(this.GestureBox_3);
            this.Controls.Add(this.GestureBox_2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ButtonPPT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hand);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.labelFPS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GestureBox_1);
            this.Controls.Add(this.Mirror);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Scale2);
            this.Controls.Add(this.Status2);
            this.Controls.Add(this.Skeleton);
            this.Controls.Add(this.Labelmap);
            this.Controls.Add(this.Depth);
            this.Controls.Add(this.Joints);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Intel(R) RealSense(TM) SDK: Hands Viewer";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Status2.ResumeLayout(false);
            this.Status2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moduleToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.CheckBox Joints;
        private System.Windows.Forms.RadioButton Depth;
        private System.Windows.Forms.RadioButton Labelmap;
        private System.Windows.Forms.CheckBox Skeleton;
        private System.Windows.Forms.StatusStrip Status2;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.CheckBox Scale2;
        private System.Windows.Forms.PictureBox Panel2;
        private System.Windows.Forms.CheckBox Mirror;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Live;
        private System.Windows.Forms.ToolStripMenuItem Playback;
        private System.Windows.Forms.ToolStripMenuItem Record;
        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.RichTextBox infoTextBox;
        private System.Windows.Forms.Label Hand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonPPT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox GestureBox_2;
        private System.Windows.Forms.ComboBox GestureBox_3;
        private System.Windows.Forms.ComboBox GestureBox_4;
        private System.Windows.Forms.ComboBox GestureBox_1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown; // 记录连续两次触发的设置时长
        private System.Windows.Forms.ComboBox HandBox_1;
        private System.Windows.Forms.ComboBox HandBox_2;
        private System.Windows.Forms.ComboBox HandBox_3;
        private System.Windows.Forms.ComboBox HandBox_4;
    }
}

