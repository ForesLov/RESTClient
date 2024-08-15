using Adw;
using Gtk;
using RestClient.GtkClient.Toolkit;

namespace RestClient.GtkClient;

public class MainWindow : Adw.ApplicationWindow
{
    const bool NotOwnReference = false;
    private readonly Builder _builder;

    [Gtk.Connect]
    private readonly Button _splitTitleButton;

    [Gtk.Connect]
    private readonly OverlaySplitView _splitView;

    private MainWindow(Gtk.Builder builder)
        : base(builder.GetPointer("_root"), NotOwnReference)
    {
        _builder = builder;
        /* Building UI */
        _builder.Connect(this);

        _splitTitleButton.OnClicked += (s, e) =>
        {
            _splitView.ShowSidebar = true;
        };
    }

    public static new MainWindow New()
    {
        var builder = BuilderHelper.FromFile("main_window" + UIFileExtension);

        return new MainWindow(builder);
    }

    const string UIFileExtension = ".ui";
}
