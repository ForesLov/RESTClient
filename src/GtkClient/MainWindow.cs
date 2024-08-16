using Adw;
using Gtk;
using RestClient.GtkClient.Toolkit;
using RestClient.GtkClient.Views;

namespace RestClient.GtkClient;

public class MainWindow : Adw.ApplicationWindow
{
    const bool NotOwnReference = false;
    private readonly Builder _builder;

    [Gtk.Connect]
    private readonly Button _splitTitleButton;

    [Gtk.Connect]
    private readonly OverlaySplitView _splitView;
    [Gtk.Connect]
    private readonly Adw.TabView _tabView;

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

        _tabView.AddShortcuts(TabViewShortcuts.AllShortcuts);

        var page = _tabView.Append(RequestView.New());
        page.Title = "Generated tab";
        page.NeedsAttention = true;
        page.Child.Show();
        _tabView.Append(RequestView.New());
        _tabView.Append(RequestView.New());
        _tabView.Append(RequestView.New());
        _tabView.Append(RequestView.New());

#if DEBUG
        AddCssClass("devel");
#endif
    }


    private bool _isDevelopment = true;

    public static new MainWindow New()
    {
        var builder = BuilderHelper.FromFile(nameof(MainWindow) + UIFileExtension);

        return new MainWindow(builder);
    }

    const string UIFileExtension = ".ui";
}
