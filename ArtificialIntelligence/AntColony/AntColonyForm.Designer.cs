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
            evapLabel = new Label();
            evapTrackBar = new TrackBar();
            evapNumeric = new NumericUpDown();
            pherStrengthLabel = new Label();
            pherStrengthTrackBar = new TrackBar();
            pherStrengthNumeric = new NumericUpDown();
            nextAntButton = new Button();
            resultLabel = new Label();
            maxRepeatsNumeric = new NumericUpDown();
            maxRepeatsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)evapTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)evapNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pherStrengthTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pherStrengthNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxRepeatsNumeric).BeginInit();
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
            alphaTrackBar.AutoSize = false;
            alphaTrackBar.LargeChange = 50;
            alphaTrackBar.Location = new Point(521, 44);
            alphaTrackBar.Maximum = 500;
            alphaTrackBar.Name = "alphaTrackBar";
            alphaTrackBar.Size = new Size(175, 35);
            alphaTrackBar.SmallChange = 10;
            alphaTrackBar.TabIndex = 2;
            alphaTrackBar.TickFrequency = 100;
            alphaTrackBar.Value = 200;
            alphaTrackBar.Scroll += ValueChanged;
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
            alphaNumeric.ValueChanged += ValueChanged;
            // 
            // pdwLabel
            // 
            pdwLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pdwLabel.AutoSize = true;
            pdwLabel.Location = new Point(521, 87);
            pdwLabel.Name = "pdwLabel";
            pdwLabel.Size = new Size(152, 20);
            pdwLabel.TabIndex = 0;
            pdwLabel.Text = "Path Distance Weight:";
            // 
            // betaTrackBar
            // 
            betaTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betaTrackBar.AutoSize = false;
            betaTrackBar.LargeChange = 50;
            betaTrackBar.Location = new Point(521, 110);
            betaTrackBar.Maximum = 500;
            betaTrackBar.Name = "betaTrackBar";
            betaTrackBar.Size = new Size(175, 35);
            betaTrackBar.SmallChange = 10;
            betaTrackBar.TabIndex = 2;
            betaTrackBar.TickFrequency = 100;
            betaTrackBar.Value = 75;
            betaTrackBar.Scroll += ValueChanged;
            // 
            // betaNumeric
            // 
            betaNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betaNumeric.DecimalPlaces = 2;
            betaNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            betaNumeric.Location = new Point(704, 110);
            betaNumeric.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            betaNumeric.Name = "betaNumeric";
            betaNumeric.Size = new Size(66, 27);
            betaNumeric.TabIndex = 3;
            betaNumeric.Value = new decimal(new int[] { 75, 0, 0, 131072 });
            betaNumeric.ValueChanged += ValueChanged;
            // 
            // startStopButton
            // 
            startStopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            startStopButton.Enabled = false;
            startStopButton.Location = new Point(589, 314);
            startStopButton.Name = "startStopButton";
            startStopButton.Size = new Size(120, 60);
            startStopButton.TabIndex = 4;
            startStopButton.Tag = "Start";
            startStopButton.Text = "Start";
            startStopButton.UseVisualStyleBackColor = true;
            startStopButton.Click += InitializeACO;
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
            ogfd.FileOk += OnFileSelected;
            // 
            // evapLabel
            // 
            evapLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            evapLabel.AutoSize = true;
            evapLabel.Location = new Point(521, 151);
            evapLabel.Name = "evapLabel";
            evapLabel.Size = new Size(126, 20);
            evapLabel.TabIndex = 0;
            evapLabel.Text = "Evaporation Rate:";
            // 
            // evapTrackBar
            // 
            evapTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            evapTrackBar.AutoSize = false;
            evapTrackBar.LargeChange = 25;
            evapTrackBar.Location = new Point(521, 174);
            evapTrackBar.Maximum = 100;
            evapTrackBar.Name = "evapTrackBar";
            evapTrackBar.Size = new Size(175, 35);
            evapTrackBar.SmallChange = 10;
            evapTrackBar.TabIndex = 2;
            evapTrackBar.TickFrequency = 25;
            evapTrackBar.Value = 27;
            evapTrackBar.Scroll += ValueChanged;
            // 
            // evapNumeric
            // 
            evapNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            evapNumeric.DecimalPlaces = 2;
            evapNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            evapNumeric.Location = new Point(704, 174);
            evapNumeric.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            evapNumeric.Name = "evapNumeric";
            evapNumeric.Size = new Size(66, 27);
            evapNumeric.TabIndex = 3;
            evapNumeric.Value = new decimal(new int[] { 27, 0, 0, 131072 });
            evapNumeric.ValueChanged += ValueChanged;
            // 
            // pherStrengthLabel
            // 
            pherStrengthLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pherStrengthLabel.AutoSize = true;
            pherStrengthLabel.Location = new Point(521, 212);
            pherStrengthLabel.Name = "pherStrengthLabel";
            pherStrengthLabel.Size = new Size(148, 20);
            pherStrengthLabel.TabIndex = 0;
            pherStrengthLabel.Text = "Pheromone Strength:";
            // 
            // pherStrengthTrackBar
            // 
            pherStrengthTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pherStrengthTrackBar.AutoSize = false;
            pherStrengthTrackBar.LargeChange = 50;
            pherStrengthTrackBar.Location = new Point(521, 235);
            pherStrengthTrackBar.Maximum = 500;
            pherStrengthTrackBar.Minimum = 100;
            pherStrengthTrackBar.Name = "pherStrengthTrackBar";
            pherStrengthTrackBar.Size = new Size(175, 35);
            pherStrengthTrackBar.SmallChange = 10;
            pherStrengthTrackBar.TabIndex = 2;
            pherStrengthTrackBar.TickFrequency = 100;
            pherStrengthTrackBar.Value = 100;
            pherStrengthTrackBar.Scroll += ValueChanged;
            // 
            // pherStrengthNumeric
            // 
            pherStrengthNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pherStrengthNumeric.DecimalPlaces = 2;
            pherStrengthNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            pherStrengthNumeric.Location = new Point(704, 235);
            pherStrengthNumeric.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            pherStrengthNumeric.Name = "pherStrengthNumeric";
            pherStrengthNumeric.Size = new Size(66, 27);
            pherStrengthNumeric.TabIndex = 3;
            pherStrengthNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            pherStrengthNumeric.ValueChanged += ValueChanged;
            // 
            // nextAntButton
            // 
            nextAntButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nextAntButton.Location = new Point(589, 380);
            nextAntButton.Name = "nextAntButton";
            nextAntButton.Size = new Size(120, 40);
            nextAntButton.TabIndex = 4;
            nextAntButton.Tag = "Start";
            nextAntButton.Text = "Next Ant";
            nextAntButton.UseVisualStyleBackColor = true;
            nextAntButton.Visible = false;
            nextAntButton.Click += NextAnt;
            // 
            // resultLabel
            // 
            resultLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(143, 390);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(155, 20);
            resultLabel.TabIndex = 6;
            resultLabel.Text = "Result: no information";
            // 
            // maxRepeatsNumeric
            // 
            maxRepeatsNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maxRepeatsNumeric.Location = new Point(715, 277);
            maxRepeatsNumeric.Name = "maxRepeatsNumeric";
            maxRepeatsNumeric.Size = new Size(55, 27);
            maxRepeatsNumeric.TabIndex = 3;
            maxRepeatsNumeric.Value = new decimal(new int[] { 5, 0, 0, 0 });
            maxRepeatsNumeric.ValueChanged += ValueChanged;
            // 
            // maxRepeatsLabel
            // 
            maxRepeatsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maxRepeatsLabel.AutoSize = true;
            maxRepeatsLabel.Location = new Point(521, 279);
            maxRepeatsLabel.Name = "maxRepeatsLabel";
            maxRepeatsLabel.Size = new Size(185, 20);
            maxRepeatsLabel.TabIndex = 7;
            maxRepeatsLabel.Text = "Maximum Same Iterations:";
            // 
            // AntColonyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 433);
            Controls.Add(maxRepeatsLabel);
            Controls.Add(resultLabel);
            Controls.Add(loadGraphButton);
            Controls.Add(nextAntButton);
            Controls.Add(startStopButton);
            Controls.Add(maxRepeatsNumeric);
            Controls.Add(pherStrengthNumeric);
            Controls.Add(evapNumeric);
            Controls.Add(betaNumeric);
            Controls.Add(pherStrengthTrackBar);
            Controls.Add(alphaNumeric);
            Controls.Add(evapTrackBar);
            Controls.Add(pherStrengthLabel);
            Controls.Add(betaTrackBar);
            Controls.Add(evapLabel);
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
            ((System.ComponentModel.ISupportInitialize)evapTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)evapNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)pherStrengthTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pherStrengthNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxRepeatsNumeric).EndInit();
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
        private Label evapLabel;
        private TrackBar evapTrackBar;
        private NumericUpDown evapNumeric;
        private Label pherStrengthLabel;
        private TrackBar pherStrengthTrackBar;
        private NumericUpDown pherStrengthNumeric;
        private Button nextAntButton;
        private Label resultLabel;
        private NumericUpDown maxRepeatsNumeric;
        private Label maxRepeatsLabel;
    }
}