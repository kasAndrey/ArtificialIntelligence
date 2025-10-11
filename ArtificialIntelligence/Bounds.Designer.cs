namespace ArtificialIntelligence.Misc
{
    partial class Bounds
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
            cornerXNumeric = new NumericUpDown();
            cornerYLabel = new Label();
            cornerYNumeric = new NumericUpDown();
            cornerXLabel = new Label();
            topCornerGroupBox = new GroupBox();
            sizeGroupBox = new GroupBox();
            widthNumeric = new NumericUpDown();
            heightLabel = new Label();
            widthLabel = new Label();
            heightNumeric = new NumericUpDown();
            closeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cornerXNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cornerYNumeric).BeginInit();
            topCornerGroupBox.SuspendLayout();
            sizeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)widthNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)heightNumeric).BeginInit();
            SuspendLayout();
            // 
            // cornerXNumeric
            // 
            cornerXNumeric.DecimalPlaces = 1;
            cornerXNumeric.Location = new Point(8, 50);
            cornerXNumeric.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            cornerXNumeric.Name = "cornerXNumeric";
            cornerXNumeric.Size = new Size(95, 27);
            cornerXNumeric.TabIndex = 0;
            // 
            // cornerYLabel
            // 
            cornerYLabel.AutoSize = true;
            cornerYLabel.Location = new Point(121, 27);
            cornerYLabel.Name = "cornerYLabel";
            cornerYLabel.Size = new Size(20, 20);
            cornerYLabel.TabIndex = 1;
            cornerYLabel.Text = "Y:";
            // 
            // cornerYNumeric
            // 
            cornerYNumeric.DecimalPlaces = 1;
            cornerYNumeric.Location = new Point(121, 50);
            cornerYNumeric.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            cornerYNumeric.Name = "cornerYNumeric";
            cornerYNumeric.Size = new Size(95, 27);
            cornerYNumeric.TabIndex = 0;
            // 
            // cornerXLabel
            // 
            cornerXLabel.AutoSize = true;
            cornerXLabel.Location = new Point(8, 27);
            cornerXLabel.Name = "cornerXLabel";
            cornerXLabel.Size = new Size(21, 20);
            cornerXLabel.TabIndex = 1;
            cornerXLabel.Text = "X:";
            // 
            // topCornerGroupBox
            // 
            topCornerGroupBox.Controls.Add(cornerXNumeric);
            topCornerGroupBox.Controls.Add(cornerYLabel);
            topCornerGroupBox.Controls.Add(cornerXLabel);
            topCornerGroupBox.Controls.Add(cornerYNumeric);
            topCornerGroupBox.Location = new Point(12, 12);
            topCornerGroupBox.Name = "topCornerGroupBox";
            topCornerGroupBox.Size = new Size(245, 89);
            topCornerGroupBox.TabIndex = 2;
            topCornerGroupBox.TabStop = false;
            topCornerGroupBox.Text = "Top Left Corner Coordinates";
            // 
            // sizeGroupBox
            // 
            sizeGroupBox.Controls.Add(widthNumeric);
            sizeGroupBox.Controls.Add(heightLabel);
            sizeGroupBox.Controls.Add(widthLabel);
            sizeGroupBox.Controls.Add(heightNumeric);
            sizeGroupBox.Location = new Point(12, 107);
            sizeGroupBox.Name = "sizeGroupBox";
            sizeGroupBox.Size = new Size(245, 89);
            sizeGroupBox.TabIndex = 3;
            sizeGroupBox.TabStop = false;
            sizeGroupBox.Text = "Size";
            // 
            // widthNumeric
            // 
            widthNumeric.DecimalPlaces = 1;
            widthNumeric.Location = new Point(8, 50);
            widthNumeric.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            widthNumeric.Name = "widthNumeric";
            widthNumeric.Size = new Size(95, 27);
            widthNumeric.TabIndex = 0;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Location = new Point(121, 27);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(57, 20);
            heightLabel.TabIndex = 1;
            heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Location = new Point(8, 27);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new Size(52, 20);
            widthLabel.TabIndex = 1;
            widthLabel.Text = "Width:";
            // 
            // heightNumeric
            // 
            heightNumeric.DecimalPlaces = 1;
            heightNumeric.Location = new Point(121, 50);
            heightNumeric.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            heightNumeric.Name = "heightNumeric";
            heightNumeric.Size = new Size(95, 27);
            heightNumeric.TabIndex = 0;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(133, 202);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(121, 29);
            closeButton.TabIndex = 4;
            closeButton.Text = "Save and Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += SaveValuesAndClose;
            // 
            // Bounds
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 237);
            Controls.Add(closeButton);
            Controls.Add(sizeGroupBox);
            Controls.Add(topCornerGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(284, 284);
            MinimizeBox = false;
            MinimumSize = new Size(284, 250);
            Name = "Bounds";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Bounds {function}";
            ((System.ComponentModel.ISupportInitialize)cornerXNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)cornerYNumeric).EndInit();
            topCornerGroupBox.ResumeLayout(false);
            topCornerGroupBox.PerformLayout();
            sizeGroupBox.ResumeLayout(false);
            sizeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)widthNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)heightNumeric).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown cornerXNumeric;
        private Label cornerYLabel;
        private NumericUpDown cornerYNumeric;
        private Label cornerXLabel;
        private GroupBox topCornerGroupBox;
        private GroupBox sizeGroupBox;
        private NumericUpDown widthNumeric;
        private Label heightLabel;
        private Label widthLabel;
        private NumericUpDown heightNumeric;
        private Button closeButton;
    }
}