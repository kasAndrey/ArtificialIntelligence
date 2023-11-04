namespace ArtificialIntelligence.GeneticAlgorithm
{
    partial class GeneticAlgorithmForm
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
            formulaImage = new PictureBox();
            resultLabel = new Label();
            startButton = new Button();
            findMinimumButton = new Button();
            functions = new ComboBox();
            plot = new PictureBox();
            generationEntitiesCountLabel = new Label();
            generationEntitiesCount = new NumericUpDown();
            crossingoverPossibilityLabel = new Label();
            crossingoverPossibility = new NumericUpDown();
            mutationPossibilityLabel = new Label();
            mutationPossibility = new NumericUpDown();
            populationValue = new NumericUpDown();
            populationLabel = new Label();
            codingTypeComboBox = new ComboBox();
            codingTypeLabel = new Label();
            functionLabel = new Label();
            boundsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)formulaImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)generationEntitiesCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)crossingoverPossibility).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mutationPossibility).BeginInit();
            ((System.ComponentModel.ISupportInitialize)populationValue).BeginInit();
            SuspendLayout();
            // 
            // formulaImage
            // 
            formulaImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            formulaImage.Location = new Point(507, 234);
            formulaImage.Name = "formulaImage";
            formulaImage.Size = new Size(194, 51);
            formulaImage.SizeMode = PictureBoxSizeMode.Zoom;
            formulaImage.TabIndex = 12;
            formulaImage.TabStop = false;
            // 
            // resultLabel
            // 
            resultLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(13, 422);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(56, 20);
            resultLabel.TabIndex = 11;
            resultLabel.Text = "Result: ";
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            startButton.Location = new Point(578, 363);
            startButton.Name = "startButton";
            startButton.Size = new Size(141, 56);
            startButton.TabIndex = 9;
            startButton.Text = "Start Simulation";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += Start;
            // 
            // findMinimumButton
            // 
            findMinimumButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            findMinimumButton.Location = new Point(578, 301);
            findMinimumButton.Name = "findMinimumButton";
            findMinimumButton.Size = new Size(141, 56);
            findMinimumButton.TabIndex = 10;
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
            functions.Location = new Point(507, 200);
            functions.Name = "functions";
            functions.Size = new Size(139, 28);
            functions.TabIndex = 8;
            functions.Text = "Function 1";
            functions.SelectedValueChanged += SetFunction;
            // 
            // plot
            // 
            plot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            plot.BackColor = Color.White;
            plot.BorderStyle = BorderStyle.FixedSingle;
            plot.Location = new Point(11, 9);
            plot.Name = "plot";
            plot.Size = new Size(490, 410);
            plot.SizeMode = PictureBoxSizeMode.StretchImage;
            plot.TabIndex = 7;
            plot.TabStop = false;
            // 
            // generationEntitiesCountLabel
            // 
            generationEntitiesCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            generationEntitiesCountLabel.AutoSize = true;
            generationEntitiesCountLabel.Location = new Point(507, 21);
            generationEntitiesCountLabel.Name = "generationEntitiesCountLabel";
            generationEntitiesCountLabel.Size = new Size(144, 20);
            generationEntitiesCountLabel.TabIndex = 14;
            generationEntitiesCountLabel.Text = "Initial Entities Count:";
            // 
            // generationEntitiesCount
            // 
            generationEntitiesCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            generationEntitiesCount.Location = new Point(725, 19);
            generationEntitiesCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            generationEntitiesCount.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            generationEntitiesCount.Name = "generationEntitiesCount";
            generationEntitiesCount.Size = new Size(63, 27);
            generationEntitiesCount.TabIndex = 13;
            generationEntitiesCount.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // crossingoverPossibilityLabel
            // 
            crossingoverPossibilityLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            crossingoverPossibilityLabel.AutoSize = true;
            crossingoverPossibilityLabel.Location = new Point(507, 54);
            crossingoverPossibilityLabel.Name = "crossingoverPossibilityLabel";
            crossingoverPossibilityLabel.Size = new Size(166, 20);
            crossingoverPossibilityLabel.TabIndex = 16;
            crossingoverPossibilityLabel.Text = "Crossingover Possibility:";
            // 
            // crossingoverPossibility
            // 
            crossingoverPossibility.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            crossingoverPossibility.DecimalPlaces = 2;
            crossingoverPossibility.Increment = new decimal(new int[] { 2, 0, 0, 131072 });
            crossingoverPossibility.Location = new Point(725, 52);
            crossingoverPossibility.Maximum = new decimal(new int[] { 10, 0, 0, 65536 });
            crossingoverPossibility.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            crossingoverPossibility.Name = "crossingoverPossibility";
            crossingoverPossibility.Size = new Size(63, 27);
            crossingoverPossibility.TabIndex = 15;
            crossingoverPossibility.Value = new decimal(new int[] { 9, 0, 0, 65536 });
            // 
            // mutationPossibilityLabel
            // 
            mutationPossibilityLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mutationPossibilityLabel.AutoSize = true;
            mutationPossibilityLabel.Location = new Point(507, 120);
            mutationPossibilityLabel.Name = "mutationPossibilityLabel";
            mutationPossibilityLabel.Size = new Size(141, 20);
            mutationPossibilityLabel.TabIndex = 18;
            mutationPossibilityLabel.Text = "Mutation Possibility:";
            // 
            // mutationPossibility
            // 
            mutationPossibility.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mutationPossibility.DecimalPlaces = 2;
            mutationPossibility.Increment = new decimal(new int[] { 2, 0, 0, 131072 });
            mutationPossibility.Location = new Point(725, 118);
            mutationPossibility.Maximum = new decimal(new int[] { 10, 0, 0, 65536 });
            mutationPossibility.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            mutationPossibility.Name = "mutationPossibility";
            mutationPossibility.Size = new Size(63, 27);
            mutationPossibility.TabIndex = 17;
            mutationPossibility.Value = new decimal(new int[] { 25, 0, 0, 131072 });
            // 
            // populationValue
            // 
            populationValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            populationValue.DecimalPlaces = 2;
            populationValue.Increment = new decimal(new int[] { 2, 0, 0, 131072 });
            populationValue.Location = new Point(725, 85);
            populationValue.Maximum = new decimal(new int[] { 10, 0, 0, 65536 });
            populationValue.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            populationValue.Name = "populationValue";
            populationValue.Size = new Size(63, 27);
            populationValue.TabIndex = 17;
            populationValue.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // populationLabel
            // 
            populationLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            populationLabel.AutoSize = true;
            populationLabel.Location = new Point(507, 87);
            populationLabel.Name = "populationLabel";
            populationLabel.Size = new Size(212, 20);
            populationLabel.TabIndex = 18;
            populationLabel.Text = "Population Crossingover Value:";
            // 
            // codingTypeComboBox
            // 
            codingTypeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            codingTypeComboBox.DisplayMember = "Binary";
            codingTypeComboBox.FormattingEnabled = true;
            codingTypeComboBox.Items.AddRange(new object[] { "Binary", "Real" });
            codingTypeComboBox.Location = new Point(652, 200);
            codingTypeComboBox.Name = "codingTypeComboBox";
            codingTypeComboBox.Size = new Size(136, 28);
            codingTypeComboBox.TabIndex = 8;
            codingTypeComboBox.Text = "Binary";
            codingTypeComboBox.SelectedIndexChanged += SetCodingType;
            codingTypeComboBox.SelectedValueChanged += SetFunction;
            // 
            // codingTypeLabel
            // 
            codingTypeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            codingTypeLabel.Location = new Point(652, 166);
            codingTypeLabel.Name = "codingTypeLabel";
            codingTypeLabel.Size = new Size(136, 25);
            codingTypeLabel.TabIndex = 19;
            codingTypeLabel.Text = "Coding Type";
            codingTypeLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // functionLabel
            // 
            functionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            functionLabel.Location = new Point(507, 166);
            functionLabel.Name = "functionLabel";
            functionLabel.Size = new Size(139, 25);
            functionLabel.TabIndex = 19;
            functionLabel.Text = "Function";
            functionLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // boundsButton
            // 
            boundsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            boundsButton.Location = new Point(707, 234);
            boundsButton.Name = "boundsButton";
            boundsButton.Size = new Size(81, 51);
            boundsButton.TabIndex = 10;
            boundsButton.Text = "Modify Bounds";
            boundsButton.UseVisualStyleBackColor = true;
            // 
            // GeneticAlgorithmForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(functionLabel);
            Controls.Add(codingTypeLabel);
            Controls.Add(populationLabel);
            Controls.Add(mutationPossibilityLabel);
            Controls.Add(populationValue);
            Controls.Add(mutationPossibility);
            Controls.Add(crossingoverPossibilityLabel);
            Controls.Add(crossingoverPossibility);
            Controls.Add(generationEntitiesCountLabel);
            Controls.Add(generationEntitiesCount);
            Controls.Add(formulaImage);
            Controls.Add(resultLabel);
            Controls.Add(startButton);
            Controls.Add(boundsButton);
            Controls.Add(findMinimumButton);
            Controls.Add(codingTypeComboBox);
            Controls.Add(functions);
            Controls.Add(plot);
            Name = "GeneticAlgorithmForm";
            Text = "Genetic Algorithm";
            ((System.ComponentModel.ISupportInitialize)formulaImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)plot).EndInit();
            ((System.ComponentModel.ISupportInitialize)generationEntitiesCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)crossingoverPossibility).EndInit();
            ((System.ComponentModel.ISupportInitialize)mutationPossibility).EndInit();
            ((System.ComponentModel.ISupportInitialize)populationValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox formulaImage;
        private Label resultLabel;
        private Button startButton;
        private Button findMinimumButton;
        private ComboBox functions;
        private PictureBox plot;
        private Label generationEntitiesCountLabel;
        private NumericUpDown generationEntitiesCount;
        private Label crossingoverPossibilityLabel;
        private NumericUpDown crossingoverPossibility;
        private Label mutationPossibilityLabel;
        private NumericUpDown mutationPossibility;
        private NumericUpDown populationValue;
        private Label populationLabel;
        private ComboBox codingTypeComboBox;
        private Label codingTypeLabel;
        private Label functionLabel;
        private Button boundsButton;
    }
}