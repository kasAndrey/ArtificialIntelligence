namespace ArtificialIntelligence
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ContainerForForms = new GroupBox();
            buttonsPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // ContainerForForms
            // 
            ContainerForForms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ContainerForForms.Location = new Point(14, 99);
            ContainerForForms.Margin = new Padding(3, 4, 3, 4);
            ContainerForForms.Name = "ContainerForForms";
            ContainerForForms.Padding = new Padding(3, 4, 3, 4);
            ContainerForForms.Size = new Size(804, 477);
            ContainerForForms.TabIndex = 0;
            ContainerForForms.TabStop = false;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonsPanel.AutoScroll = true;
            buttonsPanel.Location = new Point(14, 16);
            buttonsPanel.Margin = new Padding(3, 4, 3, 4);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(804, 75);
            buttonsPanel.TabIndex = 1;
            buttonsPanel.WrapContents = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 593);
            Controls.Add(buttonsPanel);
            Controls.Add(ContainerForForms);
            MinimumSize = new Size(820, 624);
            Name = "MainWindow";
            Text = "AI LabWorks";
            ResumeLayout(false);
        }

        #endregion

        private GroupBox ContainerForForms;
        private FlowLayoutPanel buttonsPanel;
    }
}