using FolderVisualizer.Core;
using FolderVisualizer.Visualization;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FolderVisualizer.Visualization
{
    public class BarChartVisualizer : IVisualizer
    {
        
        private const float HeightScale = 3.2f;   
        private const float GapScale = 3.0f;     
        private const float FontScale = 2.5f;
        int textWidth = 1400;


        private const int TextLeftPadding = 8;

        private string FormatSize(long bytes)
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


        public void Draw(Graphics g, FolderItem root, VisualizationContext ctx)
        {
            g.Clear(Color.White);

            var items = Flatten(root).ToList();
            if (items.Count == 0) return;

            long maxSize = items.Max(i => i.Size);

          
            int barHeight = (int)(ctx.BarHeight * HeightScale);
            int barGap = (int)(ctx.BarGap * GapScale);

            int y = ctx.Padding + 200;

         
            using var barFont = new Font(
                ctx.Font.FontFamily,
                ctx.Font.Size * FontScale,
                FontStyle.Bold
            );

            foreach (var item in items)
            {
                int barWidth = maxSize == 0 ? 0 :
                    (int)(ctx.BarMaxWidth * (item.Size / (double)maxSize));

                var brush = item.IsFolder ? ctx.FolderBrush : ctx.FileBrush;

              
                Rectangle barRect = new Rectangle(ctx.Padding, y, barWidth, barHeight);
                g.FillRectangle(brush, barRect);
                g.DrawRectangle(Pens.Black, barRect);

                string label = $"({FormatSize(item.Size)}) {item.Name}";

                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Near,        
                    LineAlignment = StringAlignment.Center, 
                    Trimming = StringTrimming.EllipsisCharacter,
                    FormatFlags = StringFormatFlags.NoWrap
                };


                Rectangle textRect = new Rectangle(
                    ctx.Padding + TextLeftPadding,
                    y,
                    textWidth,
                    barHeight
                );


                g.DrawString(label, barFont, Brushes.Black, textRect, sf);

                y += barHeight + barGap;
            }
        }

        public Size Measure(FolderItem root, VisualizationContext ctx)
        {
            int count = Flatten(root).Count();

            int barHeight = (int)(ctx.BarHeight * HeightScale);
            int barGap = (int)(ctx.BarGap * GapScale);

            int height = ctx.Padding + 200 * 2 + count * (barHeight + barGap);

       
            int width = ctx.Padding * 2 + ctx.BarMaxWidth + 900;
            return new Size(width, height);
        }

        private IEnumerable<FileSystemItem> Flatten(FolderItem root)
        {
            foreach (var child in root.Children.OrderBy(c => c.SortOrder))
                yield return child;
        }



    }
}
