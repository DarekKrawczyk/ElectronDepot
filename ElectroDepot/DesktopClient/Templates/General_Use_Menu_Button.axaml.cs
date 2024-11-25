using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media.Imaging;
using DesktopClient.Templates;
using System;

namespace DesktopClient.Templates;

public class General_Use_Menu_Button : TemplatedControl
{
    /// <summary>
    /// Name StyledProperty definition
    /// </summary>
    public static readonly StyledProperty<string> NameProperty =
        AvaloniaProperty.Register<MenuButton, string>(nameof(Name), "Add Supplier");

    /// <summary>
    /// Gets or sets the Name property. This StyledProperty
    /// indicates ....
    /// </summary>
    public string Name
    {
        get => this.GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }


    /// <summary>
    /// ProjectImage StyledProperty definition
    /// </summary>
    public static readonly StyledProperty<Bitmap> IconProperty =
        AvaloniaProperty.Register<MenuButton, Bitmap>(nameof(Icon), ImageHelper.LoadFromResource(new Uri($"avares://DesktopClient/Assets/Add_Supplier_icon.png")));

    /// <summary>
    /// Gets or sets the ProjectImage property. This StyledProperty 
    /// indicates ....
    /// </summary>
    public Bitmap Icon
    {
        get => this.GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}