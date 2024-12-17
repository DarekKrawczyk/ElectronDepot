using Avalonia.Controls;
using Avalonia.Input;

namespace DesktopClient.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Toolbar_PointerPressed(object sender, PointerPressedEventArgs e)
        {
            // Allow window dragging
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                BeginMoveDrag(e);
            }
        }
    }
}