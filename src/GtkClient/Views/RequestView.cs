using Gtk;
using RestClient.GtkClient.Toolkit;

namespace RestClient.GtkClient.Views;

public class RequestView : Gtk.Box
{
    private readonly Builder _builder;

    private RequestView(Builder builder) : base(builder.GetPointer("_root"), true)
    {
        _builder = builder;
        builder.Connect(this);
    }

    public static RequestView New()
    {
        var builder = BuilderHelper.FromFile(nameof(RequestView) + ".ui");

        return new(builder);
    }
}
