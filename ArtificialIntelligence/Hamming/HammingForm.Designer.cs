namespace ArtificialIntelligence.Hamming
{
    partial class HammingForm
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
            inputImageDescription = new Label();
            inputImage = new PictureBox();
            outputImageDescription = new Label();
            outputImage = new PictureBox();
            openFileButton = new Button();
            uiTextOutput = new Label();
            ofd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)outputImage).BeginInit();
            SuspendLayout();
            // 
            // inputImageDescription
            // 
            inputImageDescription.AutoSize = true;
            inputImageDescription.Location = new Point(10, 12);
            inputImageDescription.Name = "inputImageDescription";
            inputImageDescription.Size = new Size(108, 20);
            inputImageDescription.TabIndex = 0;
            inputImageDescription.Text = "Loaded Image:";
            // 
            // inputImage
            // 
            inputImage.BackColor = Color.White;
            inputImage.BorderStyle = BorderStyle.FixedSingle;
            inputImage.Location = new Point(10, 36);
            inputImage.Margin = new Padding(3, 4, 3, 4);
            inputImage.Name = "inputImage";
            inputImage.Size = new Size(300, 300);
            inputImage.TabIndex = 1;
            inputImage.TabStop = false;
            // 
            // outputImageDescription
            // 
            outputImageDescription.AutoSize = true;
            outputImageDescription.Location = new Point(320, 12);
            outputImageDescription.Name = "outputImageDescription";
            outputImageDescription.Size = new Size(110, 20);
            outputImageDescription.TabIndex = 0;
            outputImageDescription.Text = "Recognized As:";
            // 
            // outputImage
            // 
            outputImage.BackColor = Color.White;
            outputImage.BorderStyle = BorderStyle.FixedSingle;
            outputImage.Location = new Point(320, 36);
            outputImage.Margin = new Padding(3, 4, 3, 4);
            outputImage.Name = "outputImage";
            outputImage.Size = new Size(300, 300);
            outputImage.TabIndex = 1;
            outputImage.TabStop = false;
            // 
            // openFileButton
            // 
            openFileButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openFileButton.Location = new Point(640, 36);
            openFileButton.Margin = new Padding(3, 4, 3, 4);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(130, 50);
            openFileButton.TabIndex = 2;
            openFileButton.Text = "Open Image";
            openFileButton.UseVisualStyleBackColor = true;
            // 
            // uiTextOutput
            // 
            uiTextOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiTextOutput.BackColor = Color.White;
            uiTextOutput.BorderStyle = BorderStyle.Fixed3D;
            uiTextOutput.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextOutput.Location = new Point(10, 360);
            uiTextOutput.Margin = new Padding(10);
            uiTextOutput.Name = "uiTextOutput";
            uiTextOutput.Size = new Size(760, 60);
            uiTextOutput.TabIndex = 3;
            uiTextOutput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ofd
            // 
            ofd.Filter = "Images (*.bmp)|*.bmp";
            ofd.FileOk += OnFileSelected;
            // 
            // HammingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 404);
            ControlBox = false;
            Controls.Add(uiTextOutput);
            Controls.Add(openFileButton);
            Controls.Add(outputImage);
            Controls.Add(inputImage);
            Controls.Add(outputImageDescription);
            Controls.Add(inputImageDescription);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(800, 480);
            Name = "HammingForm";
            ShowIcon = false;
            Text = "Hamming Neural Network";
            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)outputImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label inputImageDescription;
        private PictureBox inputImage;
        private Label outputImageDescription;
        private PictureBox outputImage;
        private Button openFileButton;
        private Label uiTextOutput;
        private OpenFileDialog ofd;
    }
}