using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;

namespace DesktopClient.ViewModels
{
    public class ViewModel
    {
        public ISeries[] Series { get; set; } = [
            new ColumnSeries<int>(3, 4, 2),
        new ColumnSeries<int>(4, 2, 6),
        new ColumnSeries<double, DiamondGeometry>(4, 3, 4)
        ];
    }
}
