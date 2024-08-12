using Adw;
using Gio;

const string AppId = "";
var app = Adw.Application.New(AppId, ApplicationFlags.DefaultFlags);
var window = ApplicationWindow.New();
app.OnActivate += (s, args) => {
  app.AddWindow(window);
  window.Present();
};

app.RunWithSynchronizationContext(args);
