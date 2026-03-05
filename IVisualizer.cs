using FolderVisualizer.Core;
using System.Drawing;

namespace FolderVisualizer.Visualization
{
    public interface IVisualizer
    {
    
        void Draw(Graphics g, FolderItem root, VisualizationContext ctx);

      
        Size Measure(FolderItem root, VisualizationContext ctx);
    }
}
