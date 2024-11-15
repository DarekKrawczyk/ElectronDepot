using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using DesktopClient.Templates;
using System;

namespace DesktopClient.CustomControls;

public class ComponentNodeButton : Button
{
    /// <summary>
    /// Image StyledProperty definition
    /// </summary>
    public static readonly StyledProperty<Bitmap> ImageProperty =
        AvaloniaProperty.Register<MenuButton, Bitmap>(nameof(Image), ImageHelper.LoadFromResource(new Uri($"avares://DesktopClient/Assets/Temperature_Sensor_Icon.png")));

    /// <summary>
    /// Gets or sets the Image property. This StyledProperty 
    /// indicates ....
    /// </summary>
    public Bitmap Image
    {
        get => this.GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }


    // Using a DependencyProperty as the backing store for ComponentName.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<string> ComponentNameProperty =
        AvaloniaProperty.Register<MenuButton, string>(nameof(ComponentName), "TMP117");

    public string ComponentName
    {
        get { return GetValue(ComponentNameProperty); }
        set { SetValue(ComponentNameProperty, value); }
    }


}