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
            spawnOption = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)formulaImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)generationEntitiesCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)crossingoverPossibility).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mutationPossibility).BeginInit();
            SuspendLayout();
            // 
            // formulaImage
            // 
            formulaImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            formulaImage.Location = new Point(594, 202);
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
            startButton.Location = new Point(616, 363);
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
            findMinimumButton.Location = new Point(616, 301);
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
            functions.Location = new Point(594, 168);
            functions.Name = "functions";
            functions.Size = new Size(194, 28);
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
            plot.Size = new Size(519, 410);
            plot.SizeMode = PictureBoxSizeMode.StretchImage;
            plot.TabIndex = 7;
            plot.TabStop = false;
            // 
            // generationEntitiesCountLabel
            // 
            generationEntitiesCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            generationEntitiesCountLabel.AutoSize = true;
            generationEntitiesCountLabel.Location = new Point(553, 21);
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
            crossingoverPossibilityLabel.Location = new Point(553, 54);
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
            mutationPossibilityLabel.Location = new Point(553, 87);
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
            mutationPossibility.Location = new Point(725, 85);
            mutationPossibility.Maximum = new decimal(new int[] { 10, 0, 0, 65536 });
            mutationPossibility.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            mutationPossibility.Name = "mutationPossibility";
            mutationPossibility.Size = new Size(63, 27);
            mutationPossibility.TabIndex = 17;
            mutationPossibility.Value = new decimal(new int[] { 25, 0, 0, 131072 });
            // 
            // spawnOption
            // 
            spawnOption.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            spawnOption.AutoSize = true;
            spawnOption.Checked = true;
            spawnOption.CheckState = CheckState.Checked;
            spawnOption.Location = new Point(549, 127);
            spawnOption.Name = "spawnOption";
            spawnOption.RightToLeft = RightToLeft.Yes;
            spawnOption.Size = new Size(239, 24);
            spawnOption.TabIndex = 19;
            spawnOption.Text = "Spawn Random To Const Count";
            spawnOption.UseVisualStyleBackColor = true;
            // 
            // GeneticAlgorithmForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(spawnOption);
            Controls.Add(mutationPossibilityLabel);
            Controls.Add(mutationPossibility);
            Controls.Add(crossingoverPossibilityLabel);
            Controls.Add(crossingoverPossibility);
            Controls.Add(generationEntitiesCountLabel);
            Controls.Add(generationEntitiesCount);
            Controls.Add(formulaImage);
            Controls.Add(resultLabel);
            Controls.Add(startButton);
            Controls.Add(findMinimumButton);
            Controls.Add(functions);
            Controls.Add(plot);
            Name = "GeneticAlgorithmForm";
            Text = "Genetic Algorithm";
            ((System.ComponentModel.ISupportInitialize)formulaImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)plot).EndInit();
            ((System.ComponentModel.ISupportInitialize)generationEntitiesCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)crossingoverPossibility).EndInit();
            ((System.ComponentModel.ISupportInitialize)mutationPossibility).EndInit();
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
        private CheckBox spawnOption;
    }
}