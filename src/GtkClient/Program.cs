using System.Reflection;
using Adw;
using Gio;
using Gtk;
using RestClient.GtkClient;
using File = System.IO.File;
using System.Runtime.InteropServices;

const string AppId = "ru.is2-19.rest-client";
var app = Adw.Application.New(AppId, ApplicationFlags.DefaultFlags);

LoadGResources();

app.OnActivate += (s, args) =>
{
    SourceView.Init();
    var mainWindow = MainWindow.New();
    app.AddWindow(mainWindow);
    mainWindow.Present();
};

app.RunWithSynchronizationContext(args);

void LoadGResources()
{
    var file = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location ?? "") ?? ".") + $"/{AppId}.gresource";
    if (File.Exists(file))
    {
        Gio.Functions.ResourcesRegister(Gio.Functions.ResourceLoad(file));
    }

    // TODO: Load globaly stored resource file, currently loads only from output dir
}

public partial class SourceView
{
    [LibraryImport("libgtksourceview-5.so.0")]
    private static partial void gtk_source_init();

    private SourceView() { }

    public static void Init() => gtk_source_init();
}
