using System.Drawing;

namespace FolderVisualizer.Visualization
{
    public class VisualizationContext
    {
        public Font Font { get; set; } = SystemFonts.DefaultFont;
        public int Indent { get; set; } = 20;
        public int LineHeight { get; set; } = 22;
        public int Padding { get; set; } = 10;

        public int BarHeight { get; set; } = 22;
        public int BarGap { get; set; } = 8;
        public int BarMaxWidth { get; set; } = 500;

        public Brush FolderBrush { get; set; } = Brushes.SteelBlue;
        public Brush FileBrush { get; set; } = Brushes.Orange;
        public Brush TextBrush { get; set; } = Brushes.Black;
    }
}
