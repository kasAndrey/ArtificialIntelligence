namespace ArtificialIntelligence.AntColony
{
    partial class AntColonyForm
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
            plwLabel = new Label();
            graphPictureBox = new PictureBox();
            alphaTrackBar = new TrackBar();
            alphaNumeric = new NumericUpDown();
            pdwLabel = new Label();
            betaTrackBar = new TrackBar();
            betaNumeric = new NumericUpDown();
            startStopButton = new Button();
            loadGraphButton = new Button();
            ogfd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaNumeric).BeginInit();
            SuspendLayout();
            // 
            // plwLabel
            // 
            plwLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            plwLabel.AutoSize = true;
            plwLabel.Location = new Point(521, 9);
            plwLabel.Name = "plwLabel";
            plwLabel.Size = new Size(177, 20);
            plwLabel.TabIndex = 0;
            plwLabel.Text = "Pheromone Level Weight:";
            // 
            // graphPictureBox
            // 
            graphPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            graphPictureBox.BackColor = Color.White;
            graphPictureBox.BorderStyle = BorderStyle.FixedSingle;
            graphPictureBox.Location = new Point(10, 10);
            graphPictureBox.Name = "graphPictureBox";
            graphPictureBox.Size = new Size(500, 360);
            graphPictureBox.TabIndex = 1;
            graphPictureBox.TabStop = false;
            // 
            // alphaTrackBar
            // 
            alphaTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            alphaTrackBar.LargeChange = 50;
            alphaTrackBar.Location = new Point(521, 44);
            alphaTrackBar.Maximum = 500;
            alphaTrackBar.Name = "alphaTrackBar";
            alphaTrackBar.Size = new Size(177, 56);
            alphaTrackBar.SmallChange = 10;
            alphaTrackBar.TabIndex = 2;
            alphaTrackBar.TickFrequency = 100;
            alphaTrackBar.Value = 200;
            alphaTrackBar.Scroll += alphaChanged;
            // 
            // alphaNumeric
            // 
            alphaNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            alphaNumeric.DecimalPlaces = 2;
            alphaNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            alphaNumeric.Location = new Point(704, 44);
            alphaNumeric.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            alphaNumeric.Name = "alphaNumeric";
            alphaNumeric.Size = new Size(66, 27);
            alphaNumeric.TabIndex = 3;
            alphaNumeric.Value = new decimal(new int[] { 2, 0, 0, 0 });
            alphaNumeric.ValueChanged += alphaChanged;
            // 
            // pdwLabel
            // 
            pdwLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pdwLabel.AutoSize = true;
            pdwLabel.Location = new Point(521, 109);
            pdwLabel.Name = "pdwLabel";
            pdwLabel.Size = new Size(152, 20);
            pdwLabel.TabIndex = 0;
            pdwLabel.Text = "Path Distance Weight:";
            // 
            // betaTrackBar
            // 
            betaTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betaTrackBar.LargeChange = 50;
            betaTrackBar.Location = new Point(521, 144);
            betaTrackBar.Maximum = 500;
            betaTrackBar.Name = "betaTrackBar";
            betaTrackBar.Size = new Size(177, 56);
            betaTrackBar.SmallChange = 10;
            betaTrackBar.TabIndex = 2;
            betaTrackBar.TickFrequency = 100;
            betaTrackBar.Value = 75;
            betaTrackBar.Scroll += betaChanged;
            // 
            // betaNumeric
            // 
            betaNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betaNumeric.DecimalPlaces = 2;
            betaNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            betaNumeric.Location = new Point(704, 144);
            betaNumeric.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            betaNumeric.Name = "betaNumeric";
            betaNumeric.Size = new Size(66, 27);
            betaNumeric.TabIndex = 3;
            betaNumeric.Value = new decimal(new int[] { 75, 0, 0, 131072 });
            betaNumeric.ValueChanged += betaChanged;
            // 
            // startStopButton
            // 
            startStopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            startStopButton.Enabled = false;
            startStopButton.Location = new Point(590, 218);
            startStopButton.Name = "startStopButton";
            startStopButton.Size = new Size(120, 60);
            startStopButton.TabIndex = 4;
            startStopButton.Text = "Start";
            startStopButton.UseVisualStyleBackColor = true;
            // 
            // loadGraphButton
            // 
            loadGraphButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            loadGraphButton.Location = new Point(10, 380);
            loadGraphButton.Margin = new Padding(10);
            loadGraphButton.Name = "loadGraphButton";
            loadGraphButton.Size = new Size(120, 40);
            loadGraphButton.TabIndex = 5;
            loadGraphButton.Text = "Load Graph";
            loadGraphButton.UseVisualStyleBackColor = true;
            // 
            // ogfd
            // 
            ogfd.Filter = "Graph files (*.csv)|*.csv";
            // 
            // AntColonyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 433);
            Controls.Add(loadGraphButton);
            Controls.Add(startStopButton);
            Controls.Add(betaNumeric);
            Controls.Add(alphaNumeric);
            Controls.Add(betaTrackBar);
            Controls.Add(alphaTrackBar);
            Controls.Add(pdwLabel);
            Controls.Add(graphPictureBox);
            Controls.Add(plwLabel);
            MinimumSize = new Size(800, 480);
            Name = "AntColonyForm";
            Text = "AntColonyFormcs";
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)betaNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label plwLabel;
        private PictureBox graphPictureBox;
        private TrackBar alphaTrackBar;
        private NumericUpDown alphaNumeric;
        private Label pdwLabel;
        private TrackBar betaTrackBar;
        private NumericUpDown betaNumeric;
        private Button startStopButton;
        private Button loadGraphButton;
        private OpenFileDialog ogfd;
    }
}