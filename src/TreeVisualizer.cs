using FolderVisualizer.Core;
using System.Collections.Generic;
using System.Drawing;

namespace FolderVisualizer.Visualization
{
    public class TreeVisualizer : IVisualizer
    {
       
        private const int BoxW = 300;
        private const int BoxH = 80;

     
        private const int HGap = 100;  
        private const int VGap = 40; 

       
        private readonly Dictionary<FileSystemItem, Point> _pos = new();

        public void Draw(Graphics g, FolderItem root, VisualizationContext ctx)
        {
            g.Clear(Color.White);
            _pos.Clear();

            
            int y = ctx.Padding + 200;
            Layout(root, depth: 0, baseX: ctx.Padding, ref y);

          
            DrawEdges(g, root, ctx);

            
            DrawBoxes(g, root, ctx);
        }

      
        private void Layout(FileSystemItem node, int depth, int baseX, ref int y)
        {
            int myX = baseX + depth * (BoxW + HGap);

            if (node is FolderItem folder && folder.Children.Count > 0)
            {
               
                int startY = y;

                foreach (var child in folder.Children)
                    Layout(child, depth + 1, baseX, ref y);

                
                int endY = y - (BoxH + VGap);

                
                int midY = (startY + endY) / 2;

                _pos[node] = new Point(myX, midY);
            }
            else
            {
               
                _pos[node] = new Point(myX, y);
                y += BoxH + VGap;
            }
        }

      
        private void DrawEdges(Graphics g, FileSystemItem node, VisualizationContext ctx)
        {
            if (node is not FolderItem folder) return;

            var parentP = _pos[node];
            int parentRightX = parentP.X + BoxW;
            int parentCenterY = parentP.Y + BoxH / 2;

            foreach (var child in folder.Children)
            {
                var childP = _pos[child];
                int childLeftX = childP.X;
                int childCenterY = childP.Y + BoxH / 2;

               
                int midX = parentRightX + HGap / 2;

                g.DrawLine(Pens.Black, parentRightX, parentCenterY, midX, parentCenterY);
                g.DrawLine(Pens.Black, midX, parentCenterY, midX, childCenterY);
                g.DrawLine(Pens.Black, midX, childCenterY, childLeftX, childCenterY);

                DrawEdges(g, child, ctx);
            }
        }

   
        private void DrawBoxes(Graphics g, FileSystemItem node, VisualizationContext ctx)
        {
            var p = _pos[node];
            Rectangle rect = new Rectangle(p.X, p.Y, BoxW, BoxH);

            Brush fill = node is FolderItem ? Brushes.LightGray : Brushes.LightBlue;
            g.FillRectangle(fill, rect);
            g.DrawRectangle(Pens.Black, rect);

            string label = $"{node.Name}\n({FormatSize(node.Size)})";
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using (var treeFont = new Font(ctx.Font.FontFamily, ctx.Font.Size +1 , FontStyle.Regular))
            {
                g.DrawString(label, treeFont, ctx.TextBrush, rect, sf);
            }


            if (node is FolderItem folder)
            {
                foreach (var child in folder.Children)
                    DrawBoxes(g, child, ctx);
            }
        }

    
        public Size Measure(FolderItem root, VisualizationContext ctx)
        {
            _pos.Clear();
            int y = ctx.Padding + 200;
            Layout(root, 0, ctx.Padding, ref y);

            int maxX = 0, maxY = 0;
            foreach (var p in _pos.Values)
            {
                maxX = System.Math.Max(maxX, p.X);
                maxY = System.Math.Max(maxY, p.Y);
            }

            return new Size(maxX + BoxW + ctx.Padding, maxY + BoxH + ctx.Padding);
        }

        private static string FormatSize(long bytes)
        {
            double size = bytes;
            string[] units = { "B", "KB", "MB", "GB", "TB" };
            int unit = 0;

            while (size >= 1024 && unit < units.Length - 1)
            {
                size /= 1024;
                unit++;
            }

            return $"{size:0.##} {units[unit]}";
        }
    }
}
