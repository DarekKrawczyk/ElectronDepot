using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using DesktopClient.Templates;
using System;

namespace DesktopClient.CustomControls;

public class SupplierNodeButton : Button
{
    /// <summary>
    /// Image StyledProperty definition
    /// </summary>
    public static readonly StyledProperty<Bitmap> ImageProperty =
        AvaloniaProperty.Register<MenuButton, Bitmap>(nameof(Image), ImageHelper.LoadFromResource(new Uri($"avares://DesktopClient/Assets/TempLogo.png")));

    /// <summary>
    /// Gets or sets the Image property. This StyledProperty 
    /// indicates ....
    /// </summary>
    public Bitmap Image
    {
        get => this.GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }
}