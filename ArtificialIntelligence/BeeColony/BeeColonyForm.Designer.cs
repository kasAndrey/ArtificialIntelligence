namespace ArtificialIntelligence.BeeColony
{
    partial class BeeColonyForm
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
            functionLabel = new Label();
            iterationsLabel = new Label();
            iterationsValue = new NumericUpDown();
            formulaImage = new PictureBox();
            resultLabel = new Label();
            startButton = new Button();
            boundsButton = new Button();
            findMinimumButton = new Button();
            functions = new ComboBox();
            plot = new PictureBox();
            beesCountLabel = new Label();
            beesCount = new NumericUpDown();
            tempLabel = new Label();
            initialTemperature = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)iterationsValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)formulaImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beesCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)initialTemperature).BeginInit();
            SuspendLayout();
            // 
            // functionLabel
            // 
            functionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            functionLabel.Location = new Point(508, 199);
            functionLabel.Name = "functionLabel";
            functionLabel.Size = new Size(75, 25);
            functionLabel.TabIndex = 29;
            functionLabel.Text = "Function:";
            functionLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // iterationsLabel
            // 
            iterationsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iterationsLabel.AutoSize = true;
            iterationsLabel.Location = new Point(508, 84);
            iterationsLabel.Name = "iterationsLabel";
            iterationsLabel.Size = new Size(106, 20);
            iterationsLabel.TabIndex = 28;
            iterationsLabel.Text = "Max Iterations:";
            // 
            // iterationsValue
            // 
            iterationsValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iterationsValue.Location = new Point(726, 82);
            iterationsValue.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            iterationsValue.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            iterationsValue.Name = "iterationsValue";
            iterationsValue.Size = new Size(63, 27);
            iterationsValue.TabIndex = 27;
            iterationsValue.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // formulaImage
            // 
            formulaImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            formulaImage.Location = new Point(508, 234);
            formulaImage.Name = "formulaImage";
            formulaImage.Size = new Size(194, 51);
            formulaImage.SizeMode = PictureBoxSizeMode.Zoom;
            formulaImage.TabIndex = 26;
            formulaImage.TabStop = false;
            // 
            // resultLabel
            // 
            resultLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(14, 422);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(56, 20);
            resultLabel.TabIndex = 25;
            resultLabel.Text = "Result: ";
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            startButton.Location = new Point(579, 363);
            startButton.Name = "startButton";
            startButton.Size = new Size(141, 56);
            startButton.TabIndex = 22;
            startButton.Text = "Start Simulation";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += Start;
            // 
            // boundsButton
            // 
            boundsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            boundsButton.Location = new Point(708, 234);
            boundsButton.Name = "boundsButton";
            boundsButton.Size = new Size(81, 51);
            boundsButton.TabIndex = 23;
            boundsButton.Text = "Modify Bounds";
            boundsButton.UseVisualStyleBackColor = true;
            // 
            // findMinimumButton
            // 
            findMinimumButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            findMinimumButton.Location = new Point(579, 301);
            findMinimumButton.Name = "findMinimumButton";
            findMinimumButton.Size = new Size(141, 56);
            findMinimumButton.TabIndex = 24;
            findMinimumButton.Text = "Find Minimum Immediately";
            findMinimumButton.UseVisualStyleBackColor = true;
            findMinimumButton.Click += FindMinimumValue;
            // 
            // functions
            // 
            functions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            functions.DisplayMember = "Function 1";
            functions.FormattingEnabled = true;
            functions.Items.AddRange(new object[] { "Function 1", "Function 2", "Function 3", "Function 4", "Function 5" });
            functions.Location = new Point(589, 200);
            functions.Name = "functions";
            functions.Size = new Size(200, 28);
            functions.TabIndex = 21;
            functions.Text = "Function 1";
            functions.SelectedIndexChanged += SetFunction;
            // 
            // plot
            // 
            plot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            plot.BackColor = Color.White;
            plot.BorderStyle = BorderStyle.FixedSingle;
            plot.Location = new Point(12, 9);
            plot.Name = "plot";
            plot.Size = new Size(490, 410);
            plot.SizeMode = PictureBoxSizeMode.StretchImage;
            plot.TabIndex = 20;
            plot.TabStop = false;
            // 
            // beesCountLabel
            // 
            beesCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            beesCountLabel.AutoSize = true;
            beesCountLabel.Location = new Point(508, 18);
            beesCountLabel.Name = "beesCountLabel";
            beesCountLabel.Size = new Size(86, 20);
            beesCountLabel.TabIndex = 28;
            beesCountLabel.Text = "Bees Count:";
            // 
            // beesCount
            // 
            beesCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            beesCount.Location = new Point(726, 16);
            beesCount.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            beesCount.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            beesCount.Name = "beesCount";
            beesCount.Size = new Size(63, 27);
            beesCount.TabIndex = 27;
            beesCount.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // tempLabel
            // 
            tempLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tempLabel.AutoSize = true;
            tempLabel.Location = new Point(508, 51);
            tempLabel.Name = "tempLabel";
            tempLabel.Size = new Size(137, 20);
            tempLabel.TabIndex = 28;
            tempLabel.Text = "Initial Temperature:";
            // 
            // initialTemperature
            // 
            initialTemperature.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            initialTemperature.Location = new Point(726, 49);
            initialTemperature.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            initialTemperature.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            initialTemperature.Name = "initialTemperature";
            initialTemperature.Size = new Size(63, 27);
            initialTemperature.TabIndex = 27;
            initialTemperature.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // BeeColonyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(functionLabel);
            Controls.Add(tempLabel);
            Controls.Add(beesCountLabel);
            Controls.Add(iterationsLabel);
            Controls.Add(initialTemperature);
            Controls.Add(beesCount);
            Controls.Add(iterationsValue);
            Controls.Add(formulaImage);
            Controls.Add(resultLabel);
            Controls.Add(startButton);
            Controls.Add(boundsButton);
            Controls.Add(findMinimumButton);
            Controls.Add(functions);
            Controls.Add(plot);
            Name = "BeeColonyForm";
            Text = "BeeColonyForm";
            ((System.ComponentModel.ISupportInitialize)iterationsValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)formulaImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)plot).EndInit();
            ((System.ComponentModel.ISupportInitialize)beesCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)initialTemperature).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label functionLabel;
        private Label iterationsLabel;
        private NumericUpDown iterationsValue;
        private PictureBox formulaImage;
        private Label resultLabel;
        private Button startButton;
        private Button boundsButton;
        private Button findMinimumButton;
        private ComboBox functions;
        private PictureBox plot;
        private Label beesCountLabel;
        private NumericUpDown beesCount;
        private Label tempLabel;
        private NumericUpDown initialTemperature;
    }
}