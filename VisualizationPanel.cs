using FolderVisualizer.Core;
using FolderVisualizer.Visualization;
using System.Drawing;
using System.Windows.Forms;

namespace FolderVisualizer.UI
{
    public class VisualizationPanel : Panel
    {
        public FolderItem Root { get; private set; }
        public IVisualizer Visualizer { get; private set; }
        public VisualizationContext Ctx { get; } = new();

        public VisualizationPanel()
        {
            this.DoubleBuffered = true;
            this.AutoScroll = true;
            this.BackColor = Color.White;
        }

        public void SetModel(FolderItem root)
        {
            Root = root;
            UpdateScrollSize();
            Invalidate();
        }

        public void SetVisualizer(IVisualizer visualizer)
        {
            Visualizer = visualizer;
            UpdateScrollSize();
            Invalidate();
        }

        private void UpdateScrollSize()
        {
            if (Root == null || Visualizer == null) return;
            var size = Visualizer.Measure(Root, Ctx);
            this.AutoScrollMinSize = size;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Root == null || Visualizer == null) return;

            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            Visualizer.Draw(e.Graphics, Root, Ctx);
        }
    }
}
