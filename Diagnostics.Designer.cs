namespace BitClean
{
	partial class Diagnostics
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.obj_tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_avg_hue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_density = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_edge_ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_neighbors = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_neighbor_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tagHorizontal = new System.Windows.Forms.RadioButton();
			this.ChartOptions = new System.Windows.Forms.GroupBox();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.VerticalAxis = new System.Windows.Forms.GroupBox();
			this.totneighborVertical = new System.Windows.Forms.RadioButton();
			this.edgeratioVertical = new System.Windows.Forms.RadioButton();
			this.densityVertical = new System.Windows.Forms.RadioButton();
			this.avghueVertical = new System.Windows.Forms.RadioButton();
			this.sizeVertical = new System.Windows.Forms.RadioButton();
			this.tagVertical = new System.Windows.Forms.RadioButton();
			this.HorizontalAxis = new System.Windows.Forms.GroupBox();
			this.totneighborHorizontal = new System.Windows.Forms.RadioButton();
			this.edgeratioHorizontal = new System.Windows.Forms.RadioButton();
			this.densityHorizontal = new System.Windows.Forms.RadioButton();
			this.avghueHorizontal = new System.Windows.Forms.RadioButton();
			this.sizeHorizontal = new System.Windows.Forms.RadioButton();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.ChartOptions.SuspendLayout();
			this.VerticalAxis.SuspendLayout();
			this.HorizontalAxis.SuspendLayout();
			this.SuspendLayout();

			#region menu
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(849, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadXMLToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			#region file menu item
			// 
			// loadXMLToolStripMenuItem
			// 
			this.loadXMLToolStripMenuItem.Name = "loadXMLToolStripMenuItem";
			this.loadXMLToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.loadXMLToolStripMenuItem.Text = "Load XML...";
			this.loadXMLToolStripMenuItem.Click += new System.EventHandler(this.LoadXML_Click);
			#endregion
			#endregion

			#region data grid
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.obj_tag,
            this.obj_size,
            this.obj_avg_hue,
            this.obj_density,
            this.obj_edge_ratio,
            this.obj_neighbors,
            this.obj_neighbor_count});
			this.dataGridView1.Location = new System.Drawing.Point(0, 27);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(582, 483);
			this.dataGridView1.TabIndex = 7;
			// 
			// obj_tag
			// 
			this.obj_tag.HeaderText = "tag";
			this.obj_tag.Name = "obj_tag";
			this.obj_tag.Width = 50;
			// 
			// obj_size
			// 
			this.obj_size.HeaderText = "size";
			this.obj_size.Name = "obj_size";
			this.obj_size.Width = 50;
			// 
			// obj_avg_hue
			// 
			this.obj_avg_hue.HeaderText = "average hue";
			this.obj_avg_hue.Name = "obj_avg_hue";
			// 
			// obj_density
			// 
			this.obj_density.HeaderText = "density";
			this.obj_density.Name = "obj_density";
			this.obj_density.Width = 75;
			// 
			// obj_edge_ratio
			// 
			this.obj_edge_ratio.HeaderText = "edge ratio";
			this.obj_edge_ratio.Name = "obj_edge_ratio";
			this.obj_edge_ratio.Width = 80;
			// 
			// obj_neighbors
			// 
			this.obj_neighbors.HeaderText = "neighbors";
			this.obj_neighbors.Name = "obj_neighbors";
			this.obj_neighbors.Width = 80;
			// 
			// obj_neighbor_count
			// 
			this.obj_neighbor_count.HeaderText = "total neighbors";
			this.obj_neighbor_count.Name = "obj_neighbor_count";
			this.obj_neighbor_count.Width = 80;
			#endregion

			#region chart options
			// 
			// ChartOptions
			// 
			this.ChartOptions.Controls.Add(this.GenerateButton);
			this.ChartOptions.Controls.Add(this.VerticalAxis);
			this.ChartOptions.Controls.Add(this.HorizontalAxis);
			this.ChartOptions.Location = new System.Drawing.Point(604, 50);
			this.ChartOptions.Name = "ChartOptions";
			this.ChartOptions.Size = new System.Drawing.Size(229, 389);
			this.ChartOptions.TabIndex = 9;
			this.ChartOptions.TabStop = false;
			this.ChartOptions.Text = "Chart Options";
			// 
			// GenerateButton
			// 
			this.GenerateButton.Location = new System.Drawing.Point(6, 188);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(78, 31);
			this.GenerateButton.TabIndex = 11;
			this.GenerateButton.Text = "Generate";
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateChart_Click);

			#region vertical axis
			// 
			// VerticalAxis
			// 
			this.VerticalAxis.Controls.Add(this.totneighborVertical);
			this.VerticalAxis.Controls.Add(this.edgeratioVertical);
			this.VerticalAxis.Controls.Add(this.densityVertical);
			this.VerticalAxis.Controls.Add(this.avghueVertical);
			this.VerticalAxis.Controls.Add(this.sizeVertical);
			this.VerticalAxis.Controls.Add(this.tagVertical);
			this.VerticalAxis.Location = new System.Drawing.Point(115, 19);
			this.VerticalAxis.Name = "VerticalAxis";
			this.VerticalAxis.Size = new System.Drawing.Size(103, 163);
			this.VerticalAxis.TabIndex = 10;
			this.VerticalAxis.TabStop = false;
			this.VerticalAxis.Text = "vertical axis";
			// 
			// totneighborVertical
			// 
			this.totneighborVertical.AutoSize = true;
			this.totneighborVertical.Location = new System.Drawing.Point(6, 134);
			this.totneighborVertical.Name = "totneighborVertical";
			this.totneighborVertical.Size = new System.Drawing.Size(94, 17);
			this.totneighborVertical.TabIndex = 14;
			this.totneighborVertical.TabStop = true;
			this.totneighborVertical.Text = "total neighbors";
			this.totneighborVertical.UseVisualStyleBackColor = true;
			// 
			// edgeratioVertical
			// 
			this.edgeratioVertical.AutoSize = true;
			this.edgeratioVertical.Location = new System.Drawing.Point(6, 111);
			this.edgeratioVertical.Name = "edgeratioVertical";
			this.edgeratioVertical.Size = new System.Drawing.Size(72, 17);
			this.edgeratioVertical.TabIndex = 13;
			this.edgeratioVertical.TabStop = true;
			this.edgeratioVertical.Text = "edge ratio";
			this.edgeratioVertical.UseVisualStyleBackColor = true;
			// 
			// densityVertical
			// 
			this.densityVertical.AutoSize = true;
			this.densityVertical.Location = new System.Drawing.Point(6, 88);
			this.densityVertical.Name = "densityVertical";
			this.densityVertical.Size = new System.Drawing.Size(58, 17);
			this.densityVertical.TabIndex = 12;
			this.densityVertical.TabStop = true;
			this.densityVertical.Text = "density";
			this.densityVertical.UseVisualStyleBackColor = true;
			// 
			// avghueVertical
			// 
			this.avghueVertical.AutoSize = true;
			this.avghueVertical.Location = new System.Drawing.Point(6, 65);
			this.avghueVertical.Name = "avghueVertical";
			this.avghueVertical.Size = new System.Drawing.Size(85, 17);
			this.avghueVertical.TabIndex = 11;
			this.avghueVertical.TabStop = true;
			this.avghueVertical.Text = "average hue";
			this.avghueVertical.UseVisualStyleBackColor = true;
			// 
			// sizeVertical
			// 
			this.sizeVertical.AutoSize = true;
			this.sizeVertical.Location = new System.Drawing.Point(6, 42);
			this.sizeVertical.Name = "sizeVertical";
			this.sizeVertical.Size = new System.Drawing.Size(43, 17);
			this.sizeVertical.TabIndex = 10;
			this.sizeVertical.TabStop = true;
			this.sizeVertical.Text = "size";
			this.sizeVertical.UseVisualStyleBackColor = true;
			// 
			// tagVertical
			// 
			this.tagVertical.AutoSize = true;
			this.tagVertical.Location = new System.Drawing.Point(6, 19);
			this.tagVertical.Name = "tagVertical";
			this.tagVertical.Size = new System.Drawing.Size(40, 17);
			this.tagVertical.TabIndex = 8;
			this.tagVertical.TabStop = true;
			this.tagVertical.Text = "tag";
			this.tagVertical.UseVisualStyleBackColor = true;
			#endregion

			#region horizontal axis
			// 
			// HorizontalAxis
			// 
			this.HorizontalAxis.Controls.Add(this.totneighborHorizontal);
			this.HorizontalAxis.Controls.Add(this.edgeratioHorizontal);
			this.HorizontalAxis.Controls.Add(this.densityHorizontal);
			this.HorizontalAxis.Controls.Add(this.avghueHorizontal);
			this.HorizontalAxis.Controls.Add(this.sizeHorizontal);
			this.HorizontalAxis.Controls.Add(this.tagHorizontal);
			this.HorizontalAxis.Location = new System.Drawing.Point(6, 19);
			this.HorizontalAxis.Name = "HorizontalAxis";
			this.HorizontalAxis.Size = new System.Drawing.Size(103, 163);
			this.HorizontalAxis.TabIndex = 9;
			this.HorizontalAxis.TabStop = false;
			this.HorizontalAxis.Text = "horizontal axis";
			// 
			// totneighborHorizontal
			// 
			this.totneighborHorizontal.AutoSize = true;
			this.totneighborHorizontal.Location = new System.Drawing.Point(6, 134);
			this.totneighborHorizontal.Name = "totneighborHorizontal";
			this.totneighborHorizontal.Size = new System.Drawing.Size(94, 17);
			this.totneighborHorizontal.TabIndex = 14;
			this.totneighborHorizontal.TabStop = true;
			this.totneighborHorizontal.Text = "total neighbors";
			this.totneighborHorizontal.UseVisualStyleBackColor = true;
			// 
			// edgeratioHorizontal
			// 
			this.edgeratioHorizontal.AutoSize = true;
			this.edgeratioHorizontal.Location = new System.Drawing.Point(6, 111);
			this.edgeratioHorizontal.Name = "edgeratioHorizontal";
			this.edgeratioHorizontal.Size = new System.Drawing.Size(72, 17);
			this.edgeratioHorizontal.TabIndex = 13;
			this.edgeratioHorizontal.TabStop = true;
			this.edgeratioHorizontal.Text = "edge ratio";
			this.edgeratioHorizontal.UseVisualStyleBackColor = true;
			// 
			// densityHorizontal
			// 
			this.densityHorizontal.AutoSize = true;
			this.densityHorizontal.Location = new System.Drawing.Point(6, 88);
			this.densityHorizontal.Name = "densityHorizontal";
			this.densityHorizontal.Size = new System.Drawing.Size(58, 17);
			this.densityHorizontal.TabIndex = 12;
			this.densityHorizontal.TabStop = true;
			this.densityHorizontal.Text = "density";
			this.densityHorizontal.UseVisualStyleBackColor = true;
			// 
			// avghueHorizontal
			// 
			this.avghueHorizontal.AutoSize = true;
			this.avghueHorizontal.Location = new System.Drawing.Point(6, 65);
			this.avghueHorizontal.Name = "avghueHorizontal";
			this.avghueHorizontal.Size = new System.Drawing.Size(85, 17);
			this.avghueHorizontal.TabIndex = 11;
			this.avghueHorizontal.TabStop = true;
			this.avghueHorizontal.Text = "average hue";
			this.avghueHorizontal.UseVisualStyleBackColor = true;
			// 
			// sizeHorizontal
			// 
			this.sizeHorizontal.AutoSize = true;
			this.sizeHorizontal.Location = new System.Drawing.Point(6, 42);
			this.sizeHorizontal.Name = "sizeHorizontal";
			this.sizeHorizontal.Size = new System.Drawing.Size(43, 17);
			this.sizeHorizontal.TabIndex = 10;
			this.sizeHorizontal.TabStop = true;
			this.sizeHorizontal.Text = "size";
			this.sizeHorizontal.UseVisualStyleBackColor = true;
			// 
			// tagHorizontal
			// 
			this.tagHorizontal.AutoSize = true;
			this.tagHorizontal.Location = new System.Drawing.Point(6, 19);
			this.tagHorizontal.Name = "tagHorizontal";
			this.tagHorizontal.Size = new System.Drawing.Size(40, 17);
			this.tagHorizontal.TabIndex = 8;
			this.tagHorizontal.TabStop = true;
			this.tagHorizontal.Text = "tag";
			this.tagHorizontal.UseVisualStyleBackColor = true;
			#endregion
			#endregion
			// 
			// Diagnostics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(849, 609);
			this.Controls.Add(this.ChartOptions);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Diagnostics";
			this.Text = "Diagnostics";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ChartOptions.ResumeLayout(false);
			this.VerticalAxis.ResumeLayout(false);
			this.VerticalAxis.PerformLayout();
			this.HorizontalAxis.ResumeLayout(false);
			this.HorizontalAxis.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadXMLToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_tag;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_size;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_avg_hue;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_density;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_edge_ratio;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_neighbors;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_neighbor_count;
		private System.Windows.Forms.RadioButton tagHorizontal;
		private System.Windows.Forms.GroupBox ChartOptions;
		private System.Windows.Forms.GroupBox HorizontalAxis;
		private System.Windows.Forms.RadioButton sizeHorizontal;
		private System.Windows.Forms.RadioButton totneighborHorizontal;
		private System.Windows.Forms.RadioButton edgeratioHorizontal;
		private System.Windows.Forms.RadioButton densityHorizontal;
		private System.Windows.Forms.RadioButton avghueHorizontal;
		private System.Windows.Forms.GroupBox VerticalAxis;
		private System.Windows.Forms.RadioButton totneighborVertical;
		private System.Windows.Forms.RadioButton edgeratioVertical;
		private System.Windows.Forms.RadioButton densityVertical;
		private System.Windows.Forms.RadioButton avghueVertical;
		private System.Windows.Forms.RadioButton sizeVertical;
		private System.Windows.Forms.RadioButton tagVertical;
		private System.Windows.Forms.Button GenerateButton;
	}
}