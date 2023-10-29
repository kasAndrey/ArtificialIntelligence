namespace ArtificialIntelligence.SimulatedAnnealing
{
    partial class SimulatedAnnealingForm
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
            nextButton = new Button();
            ofd = new OpenFileDialog();
            resultLabel = new Label();
            loadGraphButton = new Button();
            graphPictureBox = new PictureBox();
            findSolution = new Button();
            initializeNewButton = new Button();
            temperatureLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).BeginInit();
            SuspendLayout();
            // 
            // nextButton
            // 
            nextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nextButton.Enabled = false;
            nextButton.Location = new Point(515, 281);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(120, 50);
            nextButton.TabIndex = 2;
            nextButton.Text = "Next Iteration";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += NextIteration;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            ofd.FileOk += OnFileSelected;
            // 
            // resultLabel
            // 
            resultLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(145, 410);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(155, 20);
            resultLabel.TabIndex = 9;
            resultLabel.Text = "Result: no information";
            // 
            // loadGraphButton
            // 
            loadGraphButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            loadGraphButton.Location = new Point(12, 400);
            loadGraphButton.Margin = new Padding(10);
            loadGraphButton.Name = "loadGraphButton";
            loadGraphButton.Size = new Size(120, 40);
            loadGraphButton.TabIndex = 8;
            loadGraphButton.Text = "Load Graph";
            loadGraphButton.UseVisualStyleBackColor = true;
            // 
            // graphPictureBox
            // 
            graphPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            graphPictureBox.BackColor = Color.White;
            graphPictureBox.BorderStyle = BorderStyle.FixedSingle;
            graphPictureBox.Location = new Point(12, 12);
            graphPictureBox.Name = "graphPictureBox";
            graphPictureBox.Size = new Size(491, 375);
            graphPictureBox.TabIndex = 7;
            graphPictureBox.TabStop = false;
            // 
            // findSolution
            // 
            findSolution.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            findSolution.Enabled = false;
            findSolution.Location = new Point(515, 337);
            findSolution.Name = "findSolution";
            findSolution.Size = new Size(120, 50);
            findSolution.TabIndex = 2;
            findSolution.Text = "Find Solution";
            findSolution.UseVisualStyleBackColor = true;
            findSolution.Click += FindSolution;
            // 
            // initializeNewButton
            // 
            initializeNewButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            initializeNewButton.Enabled = false;
            initializeNewButton.Location = new Point(515, 12);
            initializeNewButton.Name = "initializeNewButton";
            initializeNewButton.Size = new Size(120, 50);
            initializeNewButton.TabIndex = 2;
            initializeNewButton.Text = "Initialize Algorithm";
            initializeNewButton.UseVisualStyleBackColor = true;
            initializeNewButton.Click += InitializeNew;
            // 
            // temperatureLabel
            // 
            temperatureLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            temperatureLabel.AutoSize = true;
            temperatureLabel.Location = new Point(515, 249);
            temperatureLabel.Name = "temperatureLabel";
            temperatureLabel.Size = new Size(61, 20);
            temperatureLabel.TabIndex = 10;
            temperatureLabel.Text = "Temp: 0";
            temperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // SimulatedAnnealingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 450);
            Controls.Add(temperatureLabel);
            Controls.Add(resultLabel);
            Controls.Add(loadGraphButton);
            Controls.Add(graphPictureBox);
            Controls.Add(findSolution);
            Controls.Add(initializeNewButton);
            Controls.Add(nextButton);
            Name = "SimulatedAnnealingForm";
            Text = "SimulatedAnnealingForm";
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button nextButton;
        private OpenFileDialog ofd;
        private Label resultLabel;
        private Button loadGraphButton;
        private PictureBox graphPictureBox;
        private Button findSolution;
        private Button initializeNewButton;
        private Label temperatureLabel;
    }
}