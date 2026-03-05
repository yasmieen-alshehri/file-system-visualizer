using FolderVisualizer.Core;
using FolderVisualizer.UI;

namespace FolderVisualizer
{
    public static class FolderItemExtensions
    {
        public static void Visualize(this FolderItem root, VisualizationPanel panel)
        {
            panel.SetModel(root);
        }
    }
}
