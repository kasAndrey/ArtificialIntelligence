namespace ArtificialIntelligence.ParticleSworm
{
    partial class ParticleSwormForm
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
            plot = new PictureBox();
            particleCount = new NumericUpDown();
            particleCountLabel = new Label();
            functions = new ComboBox();
            startButton = new Button();
            resultLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)plot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)particleCount).BeginInit();
            SuspendLayout();
            // 
            // plot
            // 
            plot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            plot.BackColor = Color.White;
            plot.BorderStyle = BorderStyle.FixedSingle;
            plot.Location = new Point(10, 8);
            plot.Name = "plot";
            plot.Size = new Size(461, 367);
            plot.TabIndex = 0;
            plot.TabStop = false;
            // 
            // particleCount
            // 
            particleCount.Location = new Point(703, 21);
            particleCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            particleCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            particleCount.Name = "particleCount";
            particleCount.Size = new Size(85, 27);
            particleCount.TabIndex = 1;
            particleCount.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // particleCountLabel
            // 
            particleCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            particleCountLabel.AutoSize = true;
            particleCountLabel.Location = new Point(594, 23);
            particleCountLabel.Name = "particleCountLabel";
            particleCountLabel.Size = new Size(103, 20);
            particleCountLabel.TabIndex = 2;
            particleCountLabel.Text = "Particle Count:";
            // 
            // functions
            // 
            functions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            functions.DisplayMember = "Function 1";
            functions.FormattingEnabled = true;
            functions.Items.AddRange(new object[] { "Function 1", "Function 2", "Function 3", "Function 4", "Function 5" });
            functions.Location = new Point(594, 65);
            functions.Name = "functions";
            functions.Size = new Size(194, 28);
            functions.TabIndex = 3;
            functions.Text = "Function 1";
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            startButton.Location = new Point(621, 108);
            startButton.Name = "startButton";
            startButton.Size = new Size(141, 56);
            startButton.TabIndex = 4;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            // 
            // resultLabel
            // 
            resultLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(12, 395);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(56, 20);
            resultLabel.TabIndex = 5;
            resultLabel.Text = "Result: ";
            // 
            // ParticleSwormForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(resultLabel);
            Controls.Add(startButton);
            Controls.Add(functions);
            Controls.Add(particleCountLabel);
            Controls.Add(particleCount);
            Controls.Add(plot);
            Name = "ParticleSwormForm";
            Text = "ParticleSwormForm";
            ((System.ComponentModel.ISupportInitialize)plot).EndInit();
            ((System.ComponentModel.ISupportInitialize)particleCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox plot;
        private NumericUpDown particleCount;
        private Label particleCountLabel;
        private ComboBox functions;
        private Button startButton;
        private Label resultLabel;
    }
}