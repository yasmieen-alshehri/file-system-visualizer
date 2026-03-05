using FolderVisualizer.Core;
using System.IO;
using System.Xml.Linq;

namespace FolderVisualizer.Core
{
    public class FileItem : FileSystemItem
    {
        public string Extension { get; }

        public FileItem(FileInfo file) : base(file.Name)
        {
            Extension = file.Extension;
            Size = file.Length;  
        }

        public override long CalculateSize()
        {
            return Size;
        }
        public override void BuildTreeNode(TreeNode parentNode)
        {
            parentNode.Nodes.Add(new TreeNode(this.Name));
        }


    }
}
