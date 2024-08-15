using Adw;
using Gio;
using Gtk;
using RestClient.GtkClient;

const string AppId = "ru.is2-19.rest-client";
var app = Adw.Application.New(AppId, ApplicationFlags.DefaultFlags);

var window = new Adw.ApplicationWindow { DefaultWidth = 600, };

var splitView = new OverlaySplitView
{
    CssClasses = ["flat"],
    Content = GetContent(),
    Sidebar = GetSidebarContent(),
    Collapsed = false,
    ShowSidebar = true,
    // PinSidebar = true,
    // ShowSidebar = true
};
splitView.SetMinSidebarWidth(200);

/* var view = new ToolbarView
{
    TopBarStyle = ToolbarStyle.Raised,
    Content = splitView,
    CssClasses = ["flat"],
}; */
// view.AddTopBar(header);
var breakpoint = Breakpoint.New(Adw.BreakpointCondition.Parse("max-width: 400sp"));
breakpoint.AddSetter(splitView, "collapsed", new GObject.Value(true));
window.SetContent(splitView);
window.AddBreakpoint(breakpoint);

app.OnActivate += (s, args) =>
{
    var mainWindow = MainWindow.New();
    app.AddWindow(mainWindow);
    mainWindow.Present();
};

app.RunWithSynchronizationContext(args);

Widget GetContent()
{
    var label = Label.New("Label");
    label.AddCssClass("title-1");

    var box = Box.New(Orientation.Vertical, 12);
    box.Append(GetHeaderBar());
    box.Append(label);

    return box;
}

Widget GetSidebarContent()
{
    var list = ListBox.New();
    list.AddCssClass("boxed-list");
    for (int i = 0; i < 10; i++)
    {
        var row = new ActionRow { Title = "Fuck", Subtitle = "That's the war going on" };
        list.Append(row);
    }
    var box = Box.New(Orientation.Vertical, 12);
    box.Append(list);

    box.SetMarginStart(12);
    box.SetMarginEnd(12);
    box.SetMarginTop(12);
    box.SetMarginBottom(12);

    return box;
}

void LoadGResources() { }

Adw.HeaderBar GetHeaderBar()
{
    var header = new Adw.HeaderBar
    {
        TitleWidget = new WindowTitle { Title = "REST client", },
        CssClasses = ["flat"]
    };

    return header;
}
