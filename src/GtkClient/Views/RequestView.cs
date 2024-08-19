using Gtk;
using RestClient.GtkClient.Toolkit;

namespace RestClient.GtkClient.Views;

public class RequestView : Gtk.Box
{
    private readonly Builder _builder;

    [Connect]
    private readonly DropDown _methodsDropdown;

    private RequestView(Builder builder) : base(builder.GetPointer("_root"), true)
    {
        _builder = builder;
        builder.Connect(this);
        var methodsList = StringList.New(["GET", "POST", "DELETE", "PUT", "PATCH", "TRACE", "CONNECT", "HEAD", "OPTIONS"]);
        _methodsDropdown?.SetModel(methodsList);
    }

    public static RequestView New()
    {
        var builder = BuilderHelper.FromFile(nameof(RequestView) + ".ui");

        return new(builder);
    }
}
