namespace ArtificialIntelligence.DataMining
{
    partial class DataMiningForm
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
            dataList = new ListView();
            openDataButton = new Button();
            ofd = new OpenFileDialog();
            classifyButton = new Button();
            neighborsCountNumeric = new NumericUpDown();
            neighborsCountLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)neighborsCountNumeric).BeginInit();
            SuspendLayout();
            // 
            // dataList
            // 
            dataList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataList.AutoArrange = false;
            dataList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            dataList.Location = new Point(12, 12);
            dataList.MultiSelect = false;
            dataList.Name = "dataList";
            dataList.Size = new Size(507, 426);
            dataList.TabIndex = 0;
            dataList.UseCompatibleStateImageBehavior = false;
            dataList.View = View.Details;
            // 
            // openDataButton
            // 
            openDataButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openDataButton.Location = new Point(568, 12);
            openDataButton.Name = "openDataButton";
            openDataButton.Size = new Size(179, 59);
            openDataButton.TabIndex = 1;
            openDataButton.Text = "Open Data File";
            openDataButton.UseVisualStyleBackColor = true;
            // 
            // ofd
            // 
            ofd.Filter = "Comma Seperated Values file|*.csv";
            ofd.FileOk += LoadDataFile;
            // 
            // classifyButton
            // 
            classifyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            classifyButton.Enabled = false;
            classifyButton.Location = new Point(568, 379);
            classifyButton.Name = "classifyButton";
            classifyButton.Size = new Size(179, 59);
            classifyButton.TabIndex = 1;
            classifyButton.Text = "Classify Data";
            classifyButton.UseVisualStyleBackColor = true;
            classifyButton.Click += Classify;
            // 
            // neighborsCountNumeric
            // 
            neighborsCountNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            neighborsCountNumeric.Enabled = false;
            neighborsCountNumeric.Location = new Point(568, 143);
            neighborsCountNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            neighborsCountNumeric.Name = "neighborsCountNumeric";
            neighborsCountNumeric.Size = new Size(179, 27);
            neighborsCountNumeric.TabIndex = 2;
            neighborsCountNumeric.TextAlign = HorizontalAlignment.Center;
            neighborsCountNumeric.UpDownAlign = LeftRightAlignment.Left;
            neighborsCountNumeric.Value = new decimal(new int[] { 5, 0, 0, 0 });
            neighborsCountNumeric.ValueChanged += ChangeNearestNeighborsCount;
            // 
            // neighborsCountLabel
            // 
            neighborsCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            neighborsCountLabel.AutoSize = true;
            neighborsCountLabel.Location = new Point(568, 120);
            neighborsCountLabel.Name = "neighborsCountLabel";
            neighborsCountLabel.Size = new Size(179, 20);
            neighborsCountLabel.TabIndex = 3;
            neighborsCountLabel.Text = "Nearest Neighbors Count:";
            // 
            // DataMiningForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(neighborsCountLabel);
            Controls.Add(neighborsCountNumeric);
            Controls.Add(classifyButton);
            Controls.Add(openDataButton);
            Controls.Add(dataList);
            Name = "DataMiningForm";
            Text = "DataMiningForm";
            ((System.ComponentModel.ISupportInitialize)neighborsCountNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView dataList;
        private Button openDataButton;
        private OpenFileDialog ofd;
        private Button classifyButton;
        private NumericUpDown neighborsCountNumeric;
        private Label neighborsCountLabel;
    }
}