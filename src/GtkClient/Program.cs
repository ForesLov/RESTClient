using Adw;
using Gio;

const string AppId = "";
var app = Adw.Application.New(AppId, ApplicationFlags.DefaultFlags);

var window = new ApplicationWindow
{
    DefaultWidth = 600,
};

var view = new OverlaySplitView();
view.SetMinSidebarWidth(200);

window.SetContent(view);

app.OnActivate += (s, args) => {
  app.AddWindow(window);
  window.Present();
};

app.RunWithSynchronizationContext(args);
