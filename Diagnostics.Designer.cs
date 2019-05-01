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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.objectsDataGrid = new System.Windows.Forms.DataGridView();
			this.obj_tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_decision = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_avg_hue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_density = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_edge_ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.obj_neighbor_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.brain_output = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tagHorizontal = new System.Windows.Forms.RadioButton();
			this.ChartOptions = new System.Windows.Forms.GroupBox();
			this.LogisticParameters = new System.Windows.Forms.Button();
			this.dataTransformsGroup = new System.Windows.Forms.GroupBox();
			this.squareData = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.funcOccur = new System.Windows.Forms.RadioButton();
			this.funcLogistic = new System.Windows.Forms.RadioButton();
			this.funcNone = new System.Windows.Forms.RadioButton();
			this.displayGroup = new System.Windows.Forms.GroupBox();
			this.displayStructure = new System.Windows.Forms.CheckBox();
			this.displayDust = new System.Windows.Forms.CheckBox();
			this.ThinkButton = new System.Windows.Forms.Button();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.VerticalAxis = new System.Windows.Forms.GroupBox();
			this.neuralVertical = new System.Windows.Forms.RadioButton();
			this.totneighborVertical = new System.Windows.Forms.RadioButton();
			this.edgeratioVertical = new System.Windows.Forms.RadioButton();
			this.densityVertical = new System.Windows.Forms.RadioButton();
			this.avghueVertical = new System.Windows.Forms.RadioButton();
			this.sizeVertical = new System.Windows.Forms.RadioButton();
			this.tagVertical = new System.Windows.Forms.RadioButton();
			this.HorizontalAxis = new System.Windows.Forms.GroupBox();
			this.neuralHorizontal = new System.Windows.Forms.RadioButton();
			this.totneighborHorizontal = new System.Windows.Forms.RadioButton();
			this.edgeratioHorizontal = new System.Windows.Forms.RadioButton();
			this.densityHorizontal = new System.Windows.Forms.RadioButton();
			this.avghueHorizontal = new System.Windows.Forms.RadioButton();
			this.sizeHorizontal = new System.Windows.Forms.RadioButton();
			this.totalStatisticsDataGrid = new System.Windows.Forms.DataGridView();
			this.ColumnAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnMean = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dustStatisticsDataGrid = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.structureStatisticsDataGrid = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.labelTotalStatistics = new System.Windows.Forms.Label();
			this.labelDustStatistics = new System.Windows.Forms.Label();
			this.labelStructureStatistics = new System.Windows.Forms.Label();
			this.LogisticParametersGroup = new System.Windows.Forms.GroupBox();
			this.SizeParameterLabel = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objectsDataGrid)).BeginInit();
			this.ChartOptions.SuspendLayout();
			this.dataTransformsGroup.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.displayGroup.SuspendLayout();
			this.VerticalAxis.SuspendLayout();
			this.HorizontalAxis.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.totalStatisticsDataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dustStatisticsDataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.structureStatisticsDataGrid)).BeginInit();
			this.LogisticParametersGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1238, 24);
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
			// 
			// loadXMLToolStripMenuItem
			// 
			this.loadXMLToolStripMenuItem.Name = "loadXMLToolStripMenuItem";
			this.loadXMLToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.loadXMLToolStripMenuItem.Text = "Load XML...";
			this.loadXMLToolStripMenuItem.Click += new System.EventHandler(this.LoadXML_Click);
			// 
			// objectsDataGrid
			// 
			this.objectsDataGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.objectsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.objectsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.objectsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.obj_tag,
            this.obj_decision,
            this.obj_size,
            this.obj_avg_hue,
            this.obj_density,
            this.obj_edge_ratio,
            this.obj_neighbor_count,
            this.brain_output});
			this.objectsDataGrid.Dock = System.Windows.Forms.DockStyle.Left;
			this.objectsDataGrid.Location = new System.Drawing.Point(0, 24);
			this.objectsDataGrid.Name = "objectsDataGrid";
			this.objectsDataGrid.Size = new System.Drawing.Size(699, 585);
			this.objectsDataGrid.TabIndex = 7;
			// 
			// obj_tag
			// 
			this.obj_tag.HeaderText = "TAG";
			this.obj_tag.Name = "obj_tag";
			this.obj_tag.Width = 40;
			// 
			// obj_decision
			// 
			this.obj_decision.HeaderText = "DECISION";
			this.obj_decision.Name = "obj_decision";
			this.obj_decision.Width = 70;
			// 
			// obj_size
			// 
			this.obj_size.HeaderText = "SIZE";
			this.obj_size.Name = "obj_size";
			this.obj_size.Width = 70;
			// 
			// obj_avg_hue
			// 
			this.obj_avg_hue.HeaderText = "AVG HUE";
			this.obj_avg_hue.Name = "obj_avg_hue";
			this.obj_avg_hue.Width = 60;
			// 
			// obj_density
			// 
			this.obj_density.HeaderText = "DENSITY";
			this.obj_density.Name = "obj_density";
			this.obj_density.Width = 60;
			// 
			// obj_edge_ratio
			// 
			this.obj_edge_ratio.HeaderText = "EDGE RATIO";
			this.obj_edge_ratio.Name = "obj_edge_ratio";
			this.obj_edge_ratio.Width = 80;
			// 
			// obj_neighbor_count
			// 
			this.obj_neighbor_count.HeaderText = "NEIGHBOR";
			this.obj_neighbor_count.Name = "obj_neighbor_count";
			this.obj_neighbor_count.Width = 80;
			// 
			// brain_output
			// 
			this.brain_output.HeaderText = "NET OUTPUT";
			this.brain_output.Name = "brain_output";
			this.brain_output.Width = 80;
			// 
			// tagHorizontal
			// 
			this.tagHorizontal.AutoSize = true;
			this.tagHorizontal.Checked = true;
			this.tagHorizontal.Location = new System.Drawing.Point(6, 19);
			this.tagHorizontal.Name = "tagHorizontal";
			this.tagHorizontal.Size = new System.Drawing.Size(40, 17);
			this.tagHorizontal.TabIndex = 8;
			this.tagHorizontal.TabStop = true;
			this.tagHorizontal.Tag = "TAG";
			this.tagHorizontal.Text = "tag";
			this.tagHorizontal.UseVisualStyleBackColor = true;
			// 
			// ChartOptions
			// 
			this.ChartOptions.Controls.Add(this.LogisticParameters);
			this.ChartOptions.Controls.Add(this.dataTransformsGroup);
			this.ChartOptions.Controls.Add(this.groupBox1);
			this.ChartOptions.Controls.Add(this.displayGroup);
			this.ChartOptions.Controls.Add(this.ThinkButton);
			this.ChartOptions.Controls.Add(this.GenerateButton);
			this.ChartOptions.Controls.Add(this.VerticalAxis);
			this.ChartOptions.Controls.Add(this.HorizontalAxis);
			this.ChartOptions.Location = new System.Drawing.Point(705, 27);
			this.ChartOptions.Name = "ChartOptions";
			this.ChartOptions.Size = new System.Drawing.Size(229, 414);
			this.ChartOptions.TabIndex = 9;
			this.ChartOptions.TabStop = false;
			this.ChartOptions.Text = "Chart Options";
			// 
			// LogisticParameters
			// 
			this.LogisticParameters.Location = new System.Drawing.Point(148, 341);
			this.LogisticParameters.Name = "LogisticParameters";
			this.LogisticParameters.Size = new System.Drawing.Size(75, 49);
			this.LogisticParameters.TabIndex = 16;
			this.LogisticParameters.Text = "Compute Logistic Parameters";
			this.LogisticParameters.UseVisualStyleBackColor = true;
			this.LogisticParameters.Click += new System.EventHandler(this.ComputeParameters_Click);
			// 
			// dataTransformsGroup
			// 
			this.dataTransformsGroup.Controls.Add(this.squareData);
			this.dataTransformsGroup.Location = new System.Drawing.Point(14, 291);
			this.dataTransformsGroup.Name = "dataTransformsGroup";
			this.dataTransformsGroup.Size = new System.Drawing.Size(200, 44);
			this.dataTransformsGroup.TabIndex = 16;
			this.dataTransformsGroup.TabStop = false;
			this.dataTransformsGroup.Text = "Data Transforms";
			// 
			// squareData
			// 
			this.squareData.AutoSize = true;
			this.squareData.Location = new System.Drawing.Point(6, 19);
			this.squareData.Name = "squareData";
			this.squareData.Size = new System.Drawing.Size(64, 17);
			this.squareData.TabIndex = 14;
			this.squareData.Text = "squared";
			this.squareData.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.funcOccur);
			this.groupBox1.Controls.Add(this.funcLogistic);
			this.groupBox1.Controls.Add(this.funcNone);
			this.groupBox1.Location = new System.Drawing.Point(6, 206);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(123, 84);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Function Type";
			// 
			// funcOccur
			// 
			this.funcOccur.AutoSize = true;
			this.funcOccur.Enabled = false;
			this.funcOccur.Location = new System.Drawing.Point(6, 64);
			this.funcOccur.Name = "funcOccur";
			this.funcOccur.Size = new System.Drawing.Size(76, 17);
			this.funcOccur.TabIndex = 16;
			this.funcOccur.Text = "occurence";
			this.funcOccur.UseVisualStyleBackColor = true;
			// 
			// funcLogistic
			// 
			this.funcLogistic.AutoSize = true;
			this.funcLogistic.Location = new System.Drawing.Point(6, 41);
			this.funcLogistic.Name = "funcLogistic";
			this.funcLogistic.Size = new System.Drawing.Size(57, 17);
			this.funcLogistic.TabIndex = 1;
			this.funcLogistic.Text = "logistic";
			this.funcLogistic.UseVisualStyleBackColor = true;
			// 
			// funcNone
			// 
			this.funcNone.AutoSize = true;
			this.funcNone.Checked = true;
			this.funcNone.Location = new System.Drawing.Point(6, 19);
			this.funcNone.Name = "funcNone";
			this.funcNone.Size = new System.Drawing.Size(49, 17);
			this.funcNone.TabIndex = 0;
			this.funcNone.TabStop = true;
			this.funcNone.Text = "none";
			this.funcNone.UseVisualStyleBackColor = true;
			// 
			// displayGroup
			// 
			this.displayGroup.Controls.Add(this.displayStructure);
			this.displayGroup.Controls.Add(this.displayDust);
			this.displayGroup.Location = new System.Drawing.Point(137, 206);
			this.displayGroup.Name = "displayGroup";
			this.displayGroup.Size = new System.Drawing.Size(81, 67);
			this.displayGroup.TabIndex = 14;
			this.displayGroup.TabStop = false;
			this.displayGroup.Text = "Filter";
			// 
			// displayStructure
			// 
			this.displayStructure.AutoSize = true;
			this.displayStructure.Checked = true;
			this.displayStructure.CheckState = System.Windows.Forms.CheckState.Checked;
			this.displayStructure.Location = new System.Drawing.Point(6, 42);
			this.displayStructure.Name = "displayStructure";
			this.displayStructure.Size = new System.Drawing.Size(67, 17);
			this.displayStructure.TabIndex = 14;
			this.displayStructure.Text = "structure";
			this.displayStructure.UseVisualStyleBackColor = true;
			// 
			// displayDust
			// 
			this.displayDust.AutoSize = true;
			this.displayDust.Checked = true;
			this.displayDust.CheckState = System.Windows.Forms.CheckState.Checked;
			this.displayDust.Location = new System.Drawing.Point(6, 19);
			this.displayDust.Name = "displayDust";
			this.displayDust.Size = new System.Drawing.Size(46, 17);
			this.displayDust.TabIndex = 13;
			this.displayDust.Text = "dust";
			this.displayDust.UseVisualStyleBackColor = true;
			// 
			// ThinkButton
			// 
			this.ThinkButton.Location = new System.Drawing.Point(75, 341);
			this.ThinkButton.Name = "ThinkButton";
			this.ThinkButton.Size = new System.Drawing.Size(67, 49);
			this.ThinkButton.TabIndex = 12;
			this.ThinkButton.Text = "Compute Neural Output";
			this.ThinkButton.UseVisualStyleBackColor = true;
			this.ThinkButton.Click += new System.EventHandler(this.Think_Click);
			// 
			// GenerateButton
			// 
			this.GenerateButton.Location = new System.Drawing.Point(6, 341);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(63, 43);
			this.GenerateButton.TabIndex = 11;
			this.GenerateButton.Text = "Generate Chart";
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateChart_Click);
			// 
			// VerticalAxis
			// 
			this.VerticalAxis.Controls.Add(this.neuralVertical);
			this.VerticalAxis.Controls.Add(this.totneighborVertical);
			this.VerticalAxis.Controls.Add(this.edgeratioVertical);
			this.VerticalAxis.Controls.Add(this.densityVertical);
			this.VerticalAxis.Controls.Add(this.avghueVertical);
			this.VerticalAxis.Controls.Add(this.sizeVertical);
			this.VerticalAxis.Controls.Add(this.tagVertical);
			this.VerticalAxis.Location = new System.Drawing.Point(115, 19);
			this.VerticalAxis.Name = "VerticalAxis";
			this.VerticalAxis.Size = new System.Drawing.Size(103, 181);
			this.VerticalAxis.TabIndex = 10;
			this.VerticalAxis.TabStop = false;
			this.VerticalAxis.Text = "vertical axis";
			// 
			// neuralVertical
			// 
			this.neuralVertical.AutoSize = true;
			this.neuralVertical.Location = new System.Drawing.Point(6, 157);
			this.neuralVertical.Name = "neuralVertical";
			this.neuralVertical.Size = new System.Drawing.Size(73, 17);
			this.neuralVertical.TabIndex = 16;
			this.neuralVertical.Tag = "NET OUTPUT";
			this.neuralVertical.Text = "net output";
			this.neuralVertical.UseVisualStyleBackColor = true;
			// 
			// totneighborVertical
			// 
			this.totneighborVertical.AutoSize = true;
			this.totneighborVertical.Location = new System.Drawing.Point(6, 134);
			this.totneighborVertical.Name = "totneighborVertical";
			this.totneighborVertical.Size = new System.Drawing.Size(94, 17);
			this.totneighborVertical.TabIndex = 14;
			this.totneighborVertical.Tag = "NEIGHBOR";
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
			this.edgeratioVertical.Tag = "EDGE RATIO";
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
			this.densityVertical.Tag = "DENSITY";
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
			this.avghueVertical.Tag = "AVG HUE";
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
			this.sizeVertical.Tag = "SIZE";
			this.sizeVertical.Text = "size";
			this.sizeVertical.UseVisualStyleBackColor = true;
			// 
			// tagVertical
			// 
			this.tagVertical.AutoSize = true;
			this.tagVertical.Checked = true;
			this.tagVertical.Location = new System.Drawing.Point(6, 19);
			this.tagVertical.Name = "tagVertical";
			this.tagVertical.Size = new System.Drawing.Size(40, 17);
			this.tagVertical.TabIndex = 8;
			this.tagVertical.TabStop = true;
			this.tagVertical.Tag = "TAG";
			this.tagVertical.Text = "tag";
			this.tagVertical.UseVisualStyleBackColor = true;
			// 
			// HorizontalAxis
			// 
			this.HorizontalAxis.Controls.Add(this.neuralHorizontal);
			this.HorizontalAxis.Controls.Add(this.totneighborHorizontal);
			this.HorizontalAxis.Controls.Add(this.edgeratioHorizontal);
			this.HorizontalAxis.Controls.Add(this.densityHorizontal);
			this.HorizontalAxis.Controls.Add(this.avghueHorizontal);
			this.HorizontalAxis.Controls.Add(this.sizeHorizontal);
			this.HorizontalAxis.Controls.Add(this.tagHorizontal);
			this.HorizontalAxis.Location = new System.Drawing.Point(6, 19);
			this.HorizontalAxis.Name = "HorizontalAxis";
			this.HorizontalAxis.Size = new System.Drawing.Size(103, 181);
			this.HorizontalAxis.TabIndex = 9;
			this.HorizontalAxis.TabStop = false;
			this.HorizontalAxis.Text = "horizontal axis";
			// 
			// neuralHorizontal
			// 
			this.neuralHorizontal.AutoSize = true;
			this.neuralHorizontal.Location = new System.Drawing.Point(6, 157);
			this.neuralHorizontal.Name = "neuralHorizontal";
			this.neuralHorizontal.Size = new System.Drawing.Size(73, 17);
			this.neuralHorizontal.TabIndex = 15;
			this.neuralHorizontal.Tag = "NET OUTPUT";
			this.neuralHorizontal.Text = "net output";
			this.neuralHorizontal.UseVisualStyleBackColor = true;
			// 
			// totneighborHorizontal
			// 
			this.totneighborHorizontal.AutoSize = true;
			this.totneighborHorizontal.Location = new System.Drawing.Point(6, 134);
			this.totneighborHorizontal.Name = "totneighborHorizontal";
			this.totneighborHorizontal.Size = new System.Drawing.Size(94, 17);
			this.totneighborHorizontal.TabIndex = 14;
			this.totneighborHorizontal.Tag = "NEIGHBOR";
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
			this.edgeratioHorizontal.Tag = "EDGE RATIO";
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
			this.densityHorizontal.Tag = "DENSITY";
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
			this.avghueHorizontal.Tag = "AVG HUE";
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
			this.sizeHorizontal.Tag = "SIZE";
			this.sizeHorizontal.Text = "size";
			this.sizeHorizontal.UseVisualStyleBackColor = true;
			// 
			// totalStatisticsDataGrid
			// 
			this.totalStatisticsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.totalStatisticsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAttribute,
            this.Max,
            this.ColumnMin,
            this.ColumnAvg,
            this.ColumnMean});
			this.totalStatisticsDataGrid.Location = new System.Drawing.Point(940, 55);
			this.totalStatisticsDataGrid.Name = "totalStatisticsDataGrid";
			this.totalStatisticsDataGrid.Size = new System.Drawing.Size(295, 165);
			this.totalStatisticsDataGrid.TabIndex = 10;
			// 
			// ColumnAttribute
			// 
			this.ColumnAttribute.HeaderText = "ATTRIBUTE";
			this.ColumnAttribute.Name = "ColumnAttribute";
			this.ColumnAttribute.Width = 80;
			// 
			// Max
			// 
			this.Max.HeaderText = "MAX";
			this.Max.Name = "Max";
			this.Max.Width = 40;
			// 
			// ColumnMin
			// 
			this.ColumnMin.HeaderText = "MIN";
			this.ColumnMin.Name = "ColumnMin";
			this.ColumnMin.Width = 40;
			// 
			// ColumnAvg
			// 
			this.ColumnAvg.HeaderText = "AVG";
			this.ColumnAvg.Name = "ColumnAvg";
			this.ColumnAvg.Width = 40;
			// 
			// ColumnMean
			// 
			this.ColumnMean.HeaderText = "MODE";
			this.ColumnMean.Name = "ColumnMean";
			this.ColumnMean.Width = 50;
			// 
			// dustStatisticsDataGrid
			// 
			this.dustStatisticsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dustStatisticsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
			this.dustStatisticsDataGrid.Location = new System.Drawing.Point(940, 252);
			this.dustStatisticsDataGrid.Name = "dustStatisticsDataGrid";
			this.dustStatisticsDataGrid.Size = new System.Drawing.Size(295, 165);
			this.dustStatisticsDataGrid.TabIndex = 11;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "ATTRIBUTE";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 80;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "MAX";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 40;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "MIN";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 40;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "AVG";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 40;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.HeaderText = "MODE";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Width = 50;
			// 
			// structureStatisticsDataGrid
			// 
			this.structureStatisticsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.structureStatisticsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
			this.structureStatisticsDataGrid.Location = new System.Drawing.Point(940, 444);
			this.structureStatisticsDataGrid.Name = "structureStatisticsDataGrid";
			this.structureStatisticsDataGrid.Size = new System.Drawing.Size(295, 165);
			this.structureStatisticsDataGrid.TabIndex = 12;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.HeaderText = "ATTRIBUTE";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.HeaderText = "MAX";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Width = 40;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.HeaderText = "MIN";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.Width = 40;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.HeaderText = "AVG";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.Width = 40;
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.HeaderText = "MODE";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.Width = 50;
			// 
			// labelTotalStatistics
			// 
			this.labelTotalStatistics.AutoSize = true;
			this.labelTotalStatistics.Location = new System.Drawing.Point(995, 35);
			this.labelTotalStatistics.Name = "labelTotalStatistics";
			this.labelTotalStatistics.Size = new System.Drawing.Size(76, 13);
			this.labelTotalStatistics.TabIndex = 13;
			this.labelTotalStatistics.Text = "Total Statistics";
			// 
			// labelDustStatistics
			// 
			this.labelDustStatistics.AutoSize = true;
			this.labelDustStatistics.Location = new System.Drawing.Point(995, 236);
			this.labelDustStatistics.Name = "labelDustStatistics";
			this.labelDustStatistics.Size = new System.Drawing.Size(74, 13);
			this.labelDustStatistics.TabIndex = 14;
			this.labelDustStatistics.Text = "Dust Statistics";
			// 
			// labelStructureStatistics
			// 
			this.labelStructureStatistics.AutoSize = true;
			this.labelStructureStatistics.Location = new System.Drawing.Point(995, 428);
			this.labelStructureStatistics.Name = "labelStructureStatistics";
			this.labelStructureStatistics.Size = new System.Drawing.Size(95, 13);
			this.labelStructureStatistics.TabIndex = 15;
			this.labelStructureStatistics.Text = "Structure Statistics";
			// 
			// LogisticParametersGroup
			// 
			this.LogisticParametersGroup.Controls.Add(this.SizeParameterLabel);
			this.LogisticParametersGroup.Location = new System.Drawing.Point(711, 444);
			this.LogisticParametersGroup.Name = "LogisticParametersGroup";
			this.LogisticParametersGroup.Size = new System.Drawing.Size(200, 71);
			this.LogisticParametersGroup.TabIndex = 17;
			this.LogisticParametersGroup.TabStop = false;
			this.LogisticParametersGroup.Text = "Logistic Parameters";
			// 
			// SizeParameterLabel
			// 
			this.SizeParameterLabel.AutoSize = true;
			this.SizeParameterLabel.Location = new System.Drawing.Point(6, 16);
			this.SizeParameterLabel.Name = "SizeParameterLabel";
			this.SizeParameterLabel.Size = new System.Drawing.Size(33, 13);
			this.SizeParameterLabel.TabIndex = 18;
			this.SizeParameterLabel.Text = "Size :";
			// 
			// Diagnostics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1238, 609);
			this.Controls.Add(this.LogisticParametersGroup);
			this.Controls.Add(this.labelStructureStatistics);
			this.Controls.Add(this.labelDustStatistics);
			this.Controls.Add(this.labelTotalStatistics);
			this.Controls.Add(this.structureStatisticsDataGrid);
			this.Controls.Add(this.dustStatisticsDataGrid);
			this.Controls.Add(this.totalStatisticsDataGrid);
			this.Controls.Add(this.ChartOptions);
			this.Controls.Add(this.objectsDataGrid);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Diagnostics";
			this.Text = "Diagnostics";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.objectsDataGrid)).EndInit();
			this.ChartOptions.ResumeLayout(false);
			this.dataTransformsGroup.ResumeLayout(false);
			this.dataTransformsGroup.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.displayGroup.ResumeLayout(false);
			this.displayGroup.PerformLayout();
			this.VerticalAxis.ResumeLayout(false);
			this.VerticalAxis.PerformLayout();
			this.HorizontalAxis.ResumeLayout(false);
			this.HorizontalAxis.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.totalStatisticsDataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dustStatisticsDataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.structureStatisticsDataGrid)).EndInit();
			this.LogisticParametersGroup.ResumeLayout(false);
			this.LogisticParametersGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadXMLToolStripMenuItem;
		private System.Windows.Forms.DataGridView objectsDataGrid;
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
		private System.Windows.Forms.Button ThinkButton;
		private System.Windows.Forms.RadioButton neuralHorizontal;
		private System.Windows.Forms.RadioButton neuralVertical;
		private System.Windows.Forms.GroupBox displayGroup;
		private System.Windows.Forms.CheckBox displayStructure;
		private System.Windows.Forms.CheckBox displayDust;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton funcNone;
		private System.Windows.Forms.RadioButton funcLogistic;
		private System.Windows.Forms.DataGridView totalStatisticsDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAttribute;
		private System.Windows.Forms.DataGridViewTextBoxColumn Max;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMin;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAvg;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMean;
		private System.Windows.Forms.DataGridView dustStatisticsDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridView structureStatisticsDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private System.Windows.Forms.Label labelTotalStatistics;
		private System.Windows.Forms.Label labelDustStatistics;
		private System.Windows.Forms.Label labelStructureStatistics;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_tag;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_decision;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_size;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_avg_hue;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_density;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_edge_ratio;
		private System.Windows.Forms.DataGridViewTextBoxColumn obj_neighbor_count;
		private System.Windows.Forms.DataGridViewTextBoxColumn brain_output;
		private System.Windows.Forms.RadioButton funcOccur;
		private System.Windows.Forms.GroupBox dataTransformsGroup;
		private System.Windows.Forms.CheckBox squareData;
		private System.Windows.Forms.Button LogisticParameters;
		private System.Windows.Forms.GroupBox LogisticParametersGroup;
		private System.Windows.Forms.Label SizeParameterLabel;
	}
}