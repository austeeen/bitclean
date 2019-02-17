namespace bitmapproto
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripFile = new System.Windows.Forms.ToolStripDropDownButton();
			this.loadImageFile = new System.Windows.Forms.ToolStripMenuItem();
			this.saveImageFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripImage = new System.Windows.Forms.ToolStripDropDownButton();
			this.setUpImage = new System.Windows.Forms.ToolStripMenuItem();
			this.bitCleanImage = new System.Windows.Forms.ToolStripMenuItem();
			this.toolDiagnostics = new System.Windows.Forms.ToolStripDropDownButton();
			this.exportAllDiagnostics = new System.Windows.Forms.ToolStripMenuItem();
			this.exportNonWhiteDiagnostics = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(8, 28);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(778, 683);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFile,
            this.toolStripImage,
            this.toolDiagnostics});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 25);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
			// 
			// toolStripFile
			// 
			this.toolStripFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageFile,
            this.saveImageFile});
			this.toolStripFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFile.Image")));
			this.toolStripFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripFile.Name = "toolStripFile";
			this.toolStripFile.Size = new System.Drawing.Size(38, 22);
			this.toolStripFile.Text = "File";
			// 
			// loadImageFile
			// 
			this.loadImageFile.Name = "loadImageFile";
			this.loadImageFile.Size = new System.Drawing.Size(100, 22);
			this.loadImageFile.Text = "Load";
			this.loadImageFile.Click += new System.EventHandler(this.loadImageFile_Click);
			// 
			// saveImageFile
			// 
			this.saveImageFile.Name = "saveImageFile";
			this.saveImageFile.Size = new System.Drawing.Size(100, 22);
			this.saveImageFile.Text = "Save";
			this.saveImageFile.Click += new System.EventHandler(this.saveImageFile_Click);
			// 
			// toolStripImage
			// 
			this.toolStripImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUpImage,
            this.bitCleanImage});
			this.toolStripImage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripImage.Image")));
			this.toolStripImage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripImage.Name = "toolStripImage";
			this.toolStripImage.Size = new System.Drawing.Size(53, 22);
			this.toolStripImage.Text = "Image";
			// 
			// setUpImage
			// 
			this.setUpImage.Name = "setUpImage";
			this.setUpImage.Size = new System.Drawing.Size(121, 22);
			this.setUpImage.Text = "Set Up";
			this.setUpImage.Click += new System.EventHandler(this.setUpImage_Click);
			// 
			// bitCleanImage
			// 
			this.bitCleanImage.Name = "bitCleanImage";
			this.bitCleanImage.Size = new System.Drawing.Size(121, 22);
			this.bitCleanImage.Text = "Bit Clean";
			this.bitCleanImage.Click += new System.EventHandler(this.bitCleanImage_Click);
			// 
			// toolDiagnostics
			// 
			this.toolDiagnostics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolDiagnostics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllDiagnostics,
            this.exportNonWhiteDiagnostics});
			this.toolDiagnostics.Image = ((System.Drawing.Image)(resources.GetObject("toolDiagnostics.Image")));
			this.toolDiagnostics.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolDiagnostics.Name = "toolDiagnostics";
			this.toolDiagnostics.Size = new System.Drawing.Size(81, 22);
			this.toolDiagnostics.Text = "Diagnostics";
			// 
			// exportAllDiagnostics
			// 
			this.exportAllDiagnostics.Name = "exportAllDiagnostics";
			this.exportAllDiagnostics.Size = new System.Drawing.Size(169, 22);
			this.exportAllDiagnostics.Text = "Export All";
			this.exportAllDiagnostics.Click += new System.EventHandler(this.exportAllDiagnostics_Click);
			// 
			// exportNonWhiteDiagnostics
			// 
			this.exportNonWhiteDiagnostics.Name = "exportNonWhiteDiagnostics";
			this.exportNonWhiteDiagnostics.Size = new System.Drawing.Size(169, 22);
			this.exportNonWhiteDiagnostics.Text = "Export Non-White";
			this.exportNonWhiteDiagnostics.Click += new System.EventHandler(this.exportNonWhiteDiagnostics_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 723);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton toolDiagnostics;
		private System.Windows.Forms.ToolStripMenuItem exportAllDiagnostics;
		private System.Windows.Forms.ToolStripMenuItem exportNonWhiteDiagnostics;

		private System.Windows.Forms.ToolStripDropDownButton toolStripFile;
		private System.Windows.Forms.ToolStripMenuItem loadImageFile;
		private System.Windows.Forms.ToolStripMenuItem saveImageFile;

		private System.Windows.Forms.ToolStripDropDownButton toolStripImage;
		private System.Windows.Forms.ToolStripMenuItem setUpImage;
		private System.Windows.Forms.ToolStripMenuItem bitCleanImage;
	}
}

