namespace BitClean
{
	partial class MainWindow
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadImageMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveImageMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bitCleanMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
			this.diagnosticsMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
			this.plotsMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripText = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(800, 723);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.White;
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuStripItem,
            this.imageMenuStripItem,
            this.diagnosticsMenuStripItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileMenuStripItem
			// 
			this.fileMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageMenuStripItem,
            this.saveImageMenuStripItem});
			this.fileMenuStripItem.Name = "fileMenuStripItem";
			this.fileMenuStripItem.Size = new System.Drawing.Size(37, 20);
			this.fileMenuStripItem.Text = "File";
			// 
			// loadImageMenuStripItem
			// 
			this.loadImageMenuStripItem.Name = "loadImageMenuStripItem";
			this.loadImageMenuStripItem.Size = new System.Drawing.Size(136, 22);
			this.loadImageMenuStripItem.Text = "Load Image";
			this.loadImageMenuStripItem.Click += new System.EventHandler(this.LoadImageFile_Click);
			// 
			// saveImageMenuStripItem
			// 
			this.saveImageMenuStripItem.Name = "saveImageMenuStripItem";
			this.saveImageMenuStripItem.Size = new System.Drawing.Size(136, 22);
			this.saveImageMenuStripItem.Text = "Save Image";
			this.saveImageMenuStripItem.Click += new System.EventHandler(this.SaveImageFile_Click);
			// 
			// imageMenuStripItem
			// 
			this.imageMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitCleanMenuStripItem});
			this.imageMenuStripItem.Name = "imageMenuStripItem";
			this.imageMenuStripItem.Size = new System.Drawing.Size(52, 20);
			this.imageMenuStripItem.Text = "Image";
			// 
			// bitCleanMenuStripItem
			// 
			this.bitCleanMenuStripItem.Name = "bitCleanMenuStripItem";
			this.bitCleanMenuStripItem.Size = new System.Drawing.Size(121, 22);
			this.bitCleanMenuStripItem.Text = "Bit Clean";
			this.bitCleanMenuStripItem.Click += new System.EventHandler(this.BitCleanImage_Click);
			// 
			// diagnosticsMenuStripItem
			// 
			this.diagnosticsMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportMenuStripItem,
            this.plotsMenuStripItem});
			this.diagnosticsMenuStripItem.Name = "diagnosticsMenuStripItem";
			this.diagnosticsMenuStripItem.Size = new System.Drawing.Size(80, 20);
			this.diagnosticsMenuStripItem.Text = "Diagnostics";
			// 
			// exportMenuStripItem
			// 
			this.exportMenuStripItem.Name = "exportMenuStripItem";
			this.exportMenuStripItem.Size = new System.Drawing.Size(157, 22);
			this.exportMenuStripItem.Text = "Export to XML...";
			this.exportMenuStripItem.Click += new System.EventHandler(this.ExportDiagnostics_Click);
			// 
			// plotsMenuStripItem
			// 
			this.plotsMenuStripItem.Name = "plotsMenuStripItem";
			this.plotsMenuStripItem.Size = new System.Drawing.Size(157, 22);
			this.plotsMenuStripItem.Text = "Plots";
			this.plotsMenuStripItem.Click += new System.EventHandler(this.Plots_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.toolStripText});
			this.statusStrip1.Location = new System.Drawing.Point(0, 701);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(800, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// progressBar
			// 
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// toolStripText
			// 
			this.toolStripText.BackColor = System.Drawing.Color.Transparent;
			this.toolStripText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripText.Name = "toolStripText";
			this.toolStripText.Size = new System.Drawing.Size(16, 17);
			this.toolStripText.Text = "...";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(800, 723);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.pictureBox1);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainWindow";
			this.Text = "BitClean - Prototype";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBox1;

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileMenuStripItem;
		private System.Windows.Forms.ToolStripMenuItem loadImageMenuStripItem;
		private System.Windows.Forms.ToolStripMenuItem saveImageMenuStripItem;

		private System.Windows.Forms.ToolStripMenuItem imageMenuStripItem;
		private System.Windows.Forms.ToolStripMenuItem bitCleanMenuStripItem;

		private System.Windows.Forms.ToolStripMenuItem diagnosticsMenuStripItem;
		private System.Windows.Forms.ToolStripMenuItem exportMenuStripItem;
		private System.Windows.Forms.ToolStripMenuItem plotsMenuStripItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar progressBar;
		private System.Windows.Forms.ToolStripStatusLabel toolStripText;
	}
}

