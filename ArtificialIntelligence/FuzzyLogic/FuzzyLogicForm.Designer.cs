namespace ArtificialIntelligence.FuzzyLogic
{
    partial class FuzzyLogicForm
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
            mapPictureBox = new PictureBox();
            loadMapButton = new Button();
            ofd = new OpenFileDialog();
            generateRandomMap = new Button();
            launchRobot = new Button();
            ((System.ComponentModel.ISupportInitialize)mapPictureBox).BeginInit();
            SuspendLayout();
            // 
            // mapPictureBox
            // 
            mapPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mapPictureBox.BackColor = Color.White;
            mapPictureBox.BorderStyle = BorderStyle.FixedSingle;
            mapPictureBox.Location = new Point(12, 12);
            mapPictureBox.Name = "mapPictureBox";
            mapPictureBox.Size = new Size(426, 426);
            mapPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            mapPictureBox.TabIndex = 0;
            mapPictureBox.TabStop = false;
            mapPictureBox.Click += PictureBoxClick;
            mapPictureBox.Resize += OnPictureBoxResize;
            // 
            // loadMapButton
            // 
            loadMapButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            loadMapButton.Location = new Point(616, 12);
            loadMapButton.Name = "loadMapButton";
            loadMapButton.Size = new Size(172, 62);
            loadMapButton.TabIndex = 1;
            loadMapButton.Text = "Load Map";
            loadMapButton.UseVisualStyleBackColor = true;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            ofd.Filter = "Map files (.map)|*.map";
            // 
            // generateRandomMap
            // 
            generateRandomMap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            generateRandomMap.Location = new Point(616, 80);
            generateRandomMap.Name = "generateRandomMap";
            generateRandomMap.Size = new Size(172, 62);
            generateRandomMap.TabIndex = 1;
            generateRandomMap.Text = "Generate Random Map";
            generateRandomMap.UseVisualStyleBackColor = true;
            generateRandomMap.Click += GenerateRandomMapButton;
            // 
            // launchRobot
            // 
            launchRobot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            launchRobot.Enabled = false;
            launchRobot.Location = new Point(616, 148);
            launchRobot.Name = "launchRobot";
            launchRobot.Size = new Size(172, 62);
            launchRobot.TabIndex = 1;
            launchRobot.Text = "Launch Robot";
            launchRobot.UseVisualStyleBackColor = true;
            // 
            // FuzzyLogicForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(launchRobot);
            Controls.Add(generateRandomMap);
            Controls.Add(loadMapButton);
            Controls.Add(mapPictureBox);
            Name = "FuzzyLogicForm";
            Text = "FuzzyLogicForm";
            ((System.ComponentModel.ISupportInitialize)mapPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox mapPictureBox;
        private Button loadMapButton;
        private OpenFileDialog ofd;
        private Button generateRandomMap;
        private Button launchRobot;
    }
}