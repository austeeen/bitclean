
// This file has been generated by the GUI designer. Do not modify.
namespace bitclean.UI
{
	public partial class ChartConfiguration
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.VBox vbox1;

		private global::Gtk.Label horizontalAxisLabel;

		private global::Gtk.RadioButton radioHTag;

		private global::Gtk.RadioButton radioHSize;

		private global::Gtk.RadioButton radioHAvgHue;

		private global::Gtk.RadioButton radioHDensity;

		private global::Gtk.RadioButton radioHEdgeRatio;

		private global::Gtk.RadioButton radioHNeighbors;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Label verticalAxisLabel;

		private global::Gtk.RadioButton radioVTag;

		private global::Gtk.RadioButton radioVSize;

		private global::Gtk.RadioButton radioVAvgHue;

		private global::Gtk.RadioButton radioVDensity;

		private global::Gtk.RadioButton radioVEdgeRatio;

		private global::Gtk.RadioButton radioVNeighbors;

		private global::Gtk.VBox vbox4;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Label functionsLabel;

		private global::Gtk.ComboBox functionsCombo;

		private global::Gtk.Label PreProcessLabel;

		private global::Gtk.CheckButton squaredCheck;

		private global::Gtk.Label filterLabel;

		private global::Gtk.CheckButton showDustChecked;

		private global::Gtk.CheckButton showStructuresChecked;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget bitclean.UI.ChartConfiguration
			this.Name = "bitclean.UI.ChartConfiguration";
			this.Title = global::Mono.Unix.Catalog.GetString("ChartConfiguration");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child bitclean.UI.ChartConfiguration.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.horizontalAxisLabel = new global::Gtk.Label();
			this.horizontalAxisLabel.Name = "horizontalAxisLabel";
			this.horizontalAxisLabel.Xpad = 22;
			this.horizontalAxisLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Horizontal Axis");
			this.vbox1.Add(this.horizontalAxisLabel);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.horizontalAxisLabel]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.radioHTag = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Tag"));
			this.radioHTag.CanFocus = true;
			this.radioHTag.Name = "radioHTag";
			this.radioHTag.Active = true;
			this.radioHTag.DrawIndicator = true;
			this.radioHTag.UseUnderline = true;
			this.radioHTag.Group = new global::GLib.SList(global::System.IntPtr.Zero);
			this.vbox1.Add(this.radioHTag);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.radioHTag]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.radioHSize = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Size"));
			this.radioHSize.CanFocus = true;
			this.radioHSize.Name = "radioHSize";
			this.radioHSize.DrawIndicator = true;
			this.radioHSize.UseUnderline = true;
			this.radioHSize.Group = this.radioHTag.Group;
			this.vbox1.Add(this.radioHSize);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.radioHSize]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.radioHAvgHue = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Avg Hue"));
			this.radioHAvgHue.CanFocus = true;
			this.radioHAvgHue.Name = "radioHAvgHue";
			this.radioHAvgHue.DrawIndicator = true;
			this.radioHAvgHue.UseUnderline = true;
			this.radioHAvgHue.Group = this.radioHTag.Group;
			this.vbox1.Add(this.radioHAvgHue);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.radioHAvgHue]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.radioHDensity = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Density"));
			this.radioHDensity.CanFocus = true;
			this.radioHDensity.Name = "radioHDensity";
			this.radioHDensity.DrawIndicator = true;
			this.radioHDensity.UseUnderline = true;
			this.radioHDensity.Group = this.radioHTag.Group;
			this.vbox1.Add(this.radioHDensity);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.radioHDensity]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.radioHEdgeRatio = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Edge Ratio"));
			this.radioHEdgeRatio.CanFocus = true;
			this.radioHEdgeRatio.Name = "radioHEdgeRatio";
			this.radioHEdgeRatio.DrawIndicator = true;
			this.radioHEdgeRatio.UseUnderline = true;
			this.radioHEdgeRatio.Group = this.radioHTag.Group;
			this.vbox1.Add(this.radioHEdgeRatio);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.radioHEdgeRatio]));
			w6.Position = 5;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.radioHNeighbors = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Neighbors"));
			this.radioHNeighbors.CanFocus = true;
			this.radioHNeighbors.Name = "radioHNeighbors";
			this.radioHNeighbors.DrawIndicator = true;
			this.radioHNeighbors.UseUnderline = true;
			this.radioHNeighbors.Group = this.radioHTag.Group;
			this.vbox1.Add(this.radioHNeighbors);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.radioHNeighbors]));
			w7.Position = 6;
			w7.Expand = false;
			w7.Fill = false;
			this.hbox1.Add(this.vbox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox1]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.verticalAxisLabel = new global::Gtk.Label();
			this.verticalAxisLabel.Name = "verticalAxisLabel";
			this.verticalAxisLabel.Xpad = 22;
			this.verticalAxisLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Vertical Axis");
			this.vbox2.Add(this.verticalAxisLabel);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.verticalAxisLabel]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioVTag = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Tag"));
			this.radioVTag.CanFocus = true;
			this.radioVTag.Name = "radioVTag";
			this.radioVTag.Active = true;
			this.radioVTag.DrawIndicator = true;
			this.radioVTag.UseUnderline = true;
			this.radioVTag.Group = new global::GLib.SList(global::System.IntPtr.Zero);
			this.vbox2.Add(this.radioVTag);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.radioVTag]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioVSize = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Size"));
			this.radioVSize.CanFocus = true;
			this.radioVSize.Name = "radioVSize";
			this.radioVSize.DrawIndicator = true;
			this.radioVSize.UseUnderline = true;
			this.radioVSize.Group = this.radioVTag.Group;
			this.vbox2.Add(this.radioVSize);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.radioVSize]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioVAvgHue = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Avg Hue"));
			this.radioVAvgHue.CanFocus = true;
			this.radioVAvgHue.Name = "radioVAvgHue";
			this.radioVAvgHue.DrawIndicator = true;
			this.radioVAvgHue.UseUnderline = true;
			this.radioVAvgHue.Group = this.radioVTag.Group;
			this.vbox2.Add(this.radioVAvgHue);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.radioVAvgHue]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioVDensity = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Density"));
			this.radioVDensity.CanFocus = true;
			this.radioVDensity.Name = "radioVDensity";
			this.radioVDensity.DrawIndicator = true;
			this.radioVDensity.UseUnderline = true;
			this.radioVDensity.Group = this.radioVTag.Group;
			this.vbox2.Add(this.radioVDensity);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.radioVDensity]));
			w13.Position = 4;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioVEdgeRatio = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Edge Ratio"));
			this.radioVEdgeRatio.CanFocus = true;
			this.radioVEdgeRatio.Name = "radioVEdgeRatio";
			this.radioVEdgeRatio.DrawIndicator = true;
			this.radioVEdgeRatio.UseUnderline = true;
			this.radioVEdgeRatio.Group = this.radioVTag.Group;
			this.vbox2.Add(this.radioVEdgeRatio);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.radioVEdgeRatio]));
			w14.Position = 5;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.radioVNeighbors = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Neighbors"));
			this.radioVNeighbors.CanFocus = true;
			this.radioVNeighbors.Name = "radioVNeighbors";
			this.radioVNeighbors.DrawIndicator = true;
			this.radioVNeighbors.UseUnderline = true;
			this.radioVNeighbors.Group = this.radioVTag.Group;
			this.vbox2.Add(this.radioVNeighbors);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.radioVNeighbors]));
			w15.Position = 6;
			w15.Expand = false;
			w15.Fill = false;
			this.hbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.functionsLabel = new global::Gtk.Label();
			this.functionsLabel.Name = "functionsLabel";
			this.functionsLabel.Xpad = 50;
			this.functionsLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Functions");
			this.hbox6.Add(this.functionsLabel);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.functionsLabel]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox4.Add(this.hbox6);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox6]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.functionsCombo = global::Gtk.ComboBox.NewText();
			this.functionsCombo.AppendText(global::Mono.Unix.Catalog.GetString("None"));
			this.functionsCombo.AppendText(global::Mono.Unix.Catalog.GetString("Logistic"));
			this.functionsCombo.Name = "functionsCombo";
			this.functionsCombo.Active = 0;
			this.vbox4.Add(this.functionsCombo);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.functionsCombo]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.PreProcessLabel = new global::Gtk.Label();
			this.PreProcessLabel.Name = "PreProcessLabel";
			this.PreProcessLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Data Preprocessing");
			this.vbox4.Add(this.PreProcessLabel);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.PreProcessLabel]));
			w20.Position = 2;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.squaredCheck = new global::Gtk.CheckButton();
			this.squaredCheck.CanFocus = true;
			this.squaredCheck.Name = "squaredCheck";
			this.squaredCheck.Label = global::Mono.Unix.Catalog.GetString("Squared");
			this.squaredCheck.DrawIndicator = true;
			this.squaredCheck.UseUnderline = true;
			this.vbox4.Add(this.squaredCheck);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.squaredCheck]));
			w21.Position = 3;
			w21.Expand = false;
			w21.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.filterLabel = new global::Gtk.Label();
			this.filterLabel.Name = "filterLabel";
			this.filterLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Data Filter");
			this.vbox4.Add(this.filterLabel);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.filterLabel]));
			w22.Position = 4;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.showDustChecked = new global::Gtk.CheckButton();
			this.showDustChecked.CanFocus = true;
			this.showDustChecked.Name = "showDustChecked";
			this.showDustChecked.Label = global::Mono.Unix.Catalog.GetString("Dust");
			this.showDustChecked.Active = true;
			this.showDustChecked.DrawIndicator = true;
			this.showDustChecked.UseUnderline = true;
			this.vbox4.Add(this.showDustChecked);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.showDustChecked]));
			w23.Position = 5;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.showStructuresChecked = new global::Gtk.CheckButton();
			this.showStructuresChecked.CanFocus = true;
			this.showStructuresChecked.Name = "showStructuresChecked";
			this.showStructuresChecked.Label = global::Mono.Unix.Catalog.GetString("Structures");
			this.showStructuresChecked.Active = true;
			this.showStructuresChecked.DrawIndicator = true;
			this.showStructuresChecked.UseUnderline = true;
			this.vbox4.Add(this.showStructuresChecked);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.showStructuresChecked]));
			w24.Position = 6;
			w24.Expand = false;
			w24.Fill = false;
			this.hbox1.Add(this.vbox4);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox4]));
			w25.Position = 2;
			w25.Expand = false;
			w25.Fill = false;
			this.Add(this.hbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 481;
			this.DefaultHeight = 218;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteConfiguration);
		}
	}
}
