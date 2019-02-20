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
			this.PixelPropertiesCheckList = new System.Windows.Forms.CheckedListBox();
			this.IncludeOptionsGroup = new System.Windows.Forms.GroupBox();
			this.ConfidencePropertiesCheckList = new System.Windows.Forms.CheckedListBox();
			this.PixelPropertiesLabel = new System.Windows.Forms.Label();
			this.ConfidencePropertiesLabel = new System.Windows.Forms.Label();
			this.ExportButton = new System.Windows.Forms.Button();
			this.IncludeOptionsGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// PixelPropertiesCheckList
			// 
			this.PixelPropertiesCheckList.FormattingEnabled = true;
			this.PixelPropertiesCheckList.Items.AddRange(new object[] {
            "White Pixels",
            "Integer Values",
            "RGB Values",
            "Indexes"});
			this.PixelPropertiesCheckList.Location = new System.Drawing.Point(6, 41);
			this.PixelPropertiesCheckList.Name = "PixelPropertiesCheckList";
			this.PixelPropertiesCheckList.Size = new System.Drawing.Size(113, 64);
			this.PixelPropertiesCheckList.TabIndex = 0;
			// 
			// IncludeOptionsGroup
			// 
			this.IncludeOptionsGroup.Controls.Add(this.ConfidencePropertiesCheckList);
			this.IncludeOptionsGroup.Controls.Add(this.PixelPropertiesLabel);
			this.IncludeOptionsGroup.Controls.Add(this.ConfidencePropertiesLabel);
			this.IncludeOptionsGroup.Controls.Add(this.PixelPropertiesCheckList);
			this.IncludeOptionsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.IncludeOptionsGroup.Location = new System.Drawing.Point(0, 0);
			this.IncludeOptionsGroup.Name = "IncludeOptionsGroup";
			this.IncludeOptionsGroup.Size = new System.Drawing.Size(178, 210);
			this.IncludeOptionsGroup.TabIndex = 2;
			this.IncludeOptionsGroup.TabStop = false;
			this.IncludeOptionsGroup.Text = "Include Options:";
			// 
			// ConfidencePropertiesCheckList
			// 
			this.ConfidencePropertiesCheckList.FormattingEnabled = true;
			this.ConfidencePropertiesCheckList.Items.AddRange(new object[] {
            "Structure or Dust",
            "Total Size",
            "Average Hue",
            "Value Density",
            "Edge Ratio"});
			this.ConfidencePropertiesCheckList.Location = new System.Drawing.Point(6, 124);
			this.ConfidencePropertiesCheckList.Name = "ConfidencePropertiesCheckList";
			this.ConfidencePropertiesCheckList.Size = new System.Drawing.Size(120, 79);
			this.ConfidencePropertiesCheckList.TabIndex = 3;
			// 
			// PixelPropertiesLabel
			// 
			this.PixelPropertiesLabel.AutoSize = true;
			this.PixelPropertiesLabel.Location = new System.Drawing.Point(6, 25);
			this.PixelPropertiesLabel.Name = "PixelPropertiesLabel";
			this.PixelPropertiesLabel.Size = new System.Drawing.Size(82, 13);
			this.PixelPropertiesLabel.TabIndex = 2;
			this.PixelPropertiesLabel.Text = "Pixel Properties:";
			// 
			// ConfidencePropertiesLabel
			// 
			this.ConfidencePropertiesLabel.AutoSize = true;
			this.ConfidencePropertiesLabel.Location = new System.Drawing.Point(6, 108);
			this.ConfidencePropertiesLabel.Name = "ConfidencePropertiesLabel";
			this.ConfidencePropertiesLabel.Size = new System.Drawing.Size(114, 13);
			this.ConfidencePropertiesLabel.TabIndex = 1;
			this.ConfidencePropertiesLabel.Text = "Confidence Properties:";
			// 
			// ExportButton
			// 
			this.ExportButton.Location = new System.Drawing.Point(49, 228);
			this.ExportButton.Name = "ExportButton";
			this.ExportButton.Size = new System.Drawing.Size(75, 23);
			this.ExportButton.TabIndex = 3;
			this.ExportButton.Text = "Export";
			this.ExportButton.UseVisualStyleBackColor = true;
			this.ExportButton.Click += new System.EventHandler(this.exportButton_Click);
			// 
			// Diagnostics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(178, 265);
			this.Controls.Add(this.ExportButton);
			this.Controls.Add(this.IncludeOptionsGroup);
			this.Name = "Diagnostics";
			this.Text = "Diagnostics";
			this.IncludeOptionsGroup.ResumeLayout(false);
			this.IncludeOptionsGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckedListBox PixelPropertiesCheckList;
		private System.Windows.Forms.GroupBox IncludeOptionsGroup;
		private System.Windows.Forms.Label ConfidencePropertiesLabel;
		private System.Windows.Forms.CheckedListBox ConfidencePropertiesCheckList;
		private System.Windows.Forms.Label PixelPropertiesLabel;
		private System.Windows.Forms.Button ExportButton;
	}
}