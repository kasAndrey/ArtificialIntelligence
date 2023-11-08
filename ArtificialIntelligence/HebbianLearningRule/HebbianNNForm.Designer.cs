namespace ArtificialIntelligence.HebbianLearningRule
{
    partial class HebbianNNForm
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
            uiTextOutput = new Label();
            referenceImagesButton = new Button();
            outputImage = new PictureBox();
            inputImage = new PictureBox();
            outputImageDescription = new Label();
            inputImageDescription = new Label();
            openFileButton = new Button();
            ofd1 = new OpenFileDialog();
            ofd2 = new OpenFileDialog();
            imagesLoadedLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)outputImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
            SuspendLayout();
            // 
            // uiTextOutput
            // 
            uiTextOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiTextOutput.BackColor = Color.White;
            uiTextOutput.BorderStyle = BorderStyle.Fixed3D;
            uiTextOutput.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextOutput.Location = new Point(20, 369);
            uiTextOutput.Margin = new Padding(10);
            uiTextOutput.Name = "uiTextOutput";
            uiTextOutput.Size = new Size(760, 60);
            uiTextOutput.TabIndex = 9;
            uiTextOutput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // referenceImagesButton
            // 
            referenceImagesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            referenceImagesButton.Location = new Point(650, 45);
            referenceImagesButton.Margin = new Padding(3, 4, 3, 4);
            referenceImagesButton.Name = "referenceImagesButton";
            referenceImagesButton.Size = new Size(130, 50);
            referenceImagesButton.TabIndex = 8;
            referenceImagesButton.Text = "Set Reference Images";
            referenceImagesButton.UseVisualStyleBackColor = true;
            // 
            // outputImage
            // 
            outputImage.BackColor = Color.White;
            outputImage.BorderStyle = BorderStyle.FixedSingle;
            outputImage.Location = new Point(330, 45);
            outputImage.Margin = new Padding(3, 4, 3, 4);
            outputImage.Name = "outputImage";
            outputImage.Size = new Size(300, 300);
            outputImage.TabIndex = 6;
            outputImage.TabStop = false;
            // 
            // inputImage
            // 
            inputImage.BackColor = Color.White;
            inputImage.BorderStyle = BorderStyle.FixedSingle;
            inputImage.Location = new Point(20, 45);
            inputImage.Margin = new Padding(3, 4, 3, 4);
            inputImage.Name = "inputImage";
            inputImage.Size = new Size(300, 300);
            inputImage.TabIndex = 7;
            inputImage.TabStop = false;
            // 
            // outputImageDescription
            // 
            outputImageDescription.AutoSize = true;
            outputImageDescription.Location = new Point(330, 21);
            outputImageDescription.Name = "outputImageDescription";
            outputImageDescription.Size = new Size(110, 20);
            outputImageDescription.TabIndex = 4;
            outputImageDescription.Text = "Recognized As:";
            // 
            // inputImageDescription
            // 
            inputImageDescription.AutoSize = true;
            inputImageDescription.Location = new Point(20, 21);
            inputImageDescription.Name = "inputImageDescription";
            inputImageDescription.Size = new Size(108, 20);
            inputImageDescription.TabIndex = 5;
            inputImageDescription.Text = "Loaded Image:";
            // 
            // openFileButton
            // 
            openFileButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openFileButton.Enabled = false;
            openFileButton.Location = new Point(650, 103);
            openFileButton.Margin = new Padding(3, 4, 3, 4);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(130, 50);
            openFileButton.TabIndex = 8;
            openFileButton.Text = "Open Image";
            openFileButton.UseVisualStyleBackColor = true;
            // 
            // ofd1
            // 
            ofd1.Filter = "Images (*.bmp)|*.bmp";
            ofd1.FileOk += OnFileSelected;
            // 
            // ofd2
            // 
            ofd2.Filter = "Images (*.bmp)|*.bmp";
            ofd2.Multiselect = true;
            ofd2.FileOk += SetReferenceImages;
            // 
            // imagesLoadedLabel
            // 
            imagesLoadedLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            imagesLoadedLabel.BackColor = Color.White;
            imagesLoadedLabel.BorderStyle = BorderStyle.FixedSingle;
            imagesLoadedLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            imagesLoadedLabel.ForeColor = Color.Red;
            imagesLoadedLabel.Location = new Point(650, 279);
            imagesLoadedLabel.Name = "imagesLoadedLabel";
            imagesLoadedLabel.Size = new Size(130, 66);
            imagesLoadedLabel.TabIndex = 4;
            imagesLoadedLabel.Text = "Images Loaded";
            imagesLoadedLabel.TextAlign = ContentAlignment.MiddleCenter;
            imagesLoadedLabel.Visible = false;
            // 
            // HebbianNNForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uiTextOutput);
            Controls.Add(openFileButton);
            Controls.Add(referenceImagesButton);
            Controls.Add(outputImage);
            Controls.Add(inputImage);
            Controls.Add(imagesLoadedLabel);
            Controls.Add(outputImageDescription);
            Controls.Add(inputImageDescription);
            Name = "HebbianNNForm";
            Text = "HebbianNNForm";
            ((System.ComponentModel.ISupportInitialize)outputImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label uiTextOutput;
        private Button referenceImagesButton;
        private PictureBox outputImage;
        private PictureBox inputImage;
        private Label outputImageDescription;
        private Label inputImageDescription;
        private OpenFileDialog ofd1;
        private OpenFileDialog ofd2;
        private Button openFileButton;
        private Label imagesLoadedLabel;
    }
}