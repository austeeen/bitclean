
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action FileAction;

	private global::Gtk.Action LoadImageAction;

	private global::Gtk.Action SaveImageAction;

	private global::Gtk.Action ImageAction;

	private global::Gtk.Action RunBitcleanAction;

	private global::Gtk.Action DiagnosticsAction;

	private global::Gtk.Action ExportToXMLAction;

	private global::Gtk.Action OpenDiagnosticsAction;

	private global::Gtk.VBox vbox1;

	private global::Gtk.MenuBar menubar1;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.Image displayedImage;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.FileAction = new global::Gtk.Action("FileAction", global::Mono.Unix.Catalog.GetString("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString("File");
		w1.Add(this.FileAction, null);
		this.LoadImageAction = new global::Gtk.Action("LoadImageAction", global::Mono.Unix.Catalog.GetString("Load Image"), null, null);
		this.LoadImageAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Load Image");
		w1.Add(this.LoadImageAction, null);
		this.SaveImageAction = new global::Gtk.Action("SaveImageAction", global::Mono.Unix.Catalog.GetString("Save Image"), null, null);
		this.SaveImageAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Save Image");
		w1.Add(this.SaveImageAction, null);
		this.ImageAction = new global::Gtk.Action("ImageAction", global::Mono.Unix.Catalog.GetString("Image"), null, null);
		this.ImageAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Image");
		w1.Add(this.ImageAction, null);
		this.RunBitcleanAction = new global::Gtk.Action("RunBitcleanAction", global::Mono.Unix.Catalog.GetString("Run Bitclean"), null, null);
		this.RunBitcleanAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Run Bitclean");
		w1.Add(this.RunBitcleanAction, null);
		this.DiagnosticsAction = new global::Gtk.Action("DiagnosticsAction", global::Mono.Unix.Catalog.GetString("Diagnostics"), null, null);
		this.DiagnosticsAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Diagnostics");
		w1.Add(this.DiagnosticsAction, null);
		this.ExportToXMLAction = new global::Gtk.Action("ExportToXMLAction", global::Mono.Unix.Catalog.GetString("Export to XML..."), null, null);
		this.ExportToXMLAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Export to XML...");
		w1.Add(this.ExportToXMLAction, null);
		this.OpenDiagnosticsAction = new global::Gtk.Action("OpenDiagnosticsAction", global::Mono.Unix.Catalog.GetString("Open Diagnostics"), null, null);
		this.OpenDiagnosticsAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Open Diagnostics");
		w1.Add(this.OpenDiagnosticsAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString(@"<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='LoadImageAction' action='LoadImageAction'/><menuitem name='SaveImageAction' action='SaveImageAction'/></menu><menu name='ImageAction' action='ImageAction'><menuitem name='RunBitcleanAction' action='RunBitcleanAction'/></menu><menu name='DiagnosticsAction' action='DiagnosticsAction'><menuitem name='ExportToXMLAction' action='ExportToXMLAction'/><menuitem name='OpenDiagnosticsAction' action='OpenDiagnosticsAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add(this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		global::Gtk.Viewport w3 = new global::Gtk.Viewport();
		w3.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child GtkViewport.Gtk.Container+ContainerChild
		this.displayedImage = new global::Gtk.Image();
		this.displayedImage.Name = "displayedImage";
		w3.Add(this.displayedImage);
		this.GtkScrolledWindow.Add(w3);
		this.vbox1.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
		w6.Position = 1;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 539;
		this.DefaultHeight = 300;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.LoadImageAction.Activated += new global::System.EventHandler(this.LoadImage);
		this.SaveImageAction.Activated += new global::System.EventHandler(this.SaveImage);
		this.RunBitcleanAction.Activated += new global::System.EventHandler(this.RunBitclean);
		this.ExportToXMLAction.Activated += new global::System.EventHandler(this.ExportToXML);
		this.OpenDiagnosticsAction.Activated += new global::System.EventHandler(this.OpenDiagnostics);
	}
}