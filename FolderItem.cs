using FolderVisualizer.Core;
using FolderVisualizer.UI;
using System.Collections.Generic;
using System.Linq;

namespace FolderVisualizer.Core
{
    public class FolderItem : FileSystemItem
    {
        private readonly List<FileSystemItem> _children = new();
        public IReadOnlyList<FileSystemItem> Children => _children;
        public override int SortOrder => 0;

        public FolderItem(string name) : base(name) { }

        public override bool IsFolder => true;

        public override void Add(FileSystemItem item)
        {
            item.Parent = this;
            _children.Add(item);
        }

        public override void Remove(FileSystemItem item)
        {
            _children.Remove(item);
            item.Parent = null;
        }

        public override long CalculateSize()
        {
            Size = _children.Sum(c => c.CalculateSize());
            return Size;
        }


        public override void BuildTreeNode(TreeNode parentNode)
        {
            TreeNode myNode = new TreeNode(this.Name);
            parentNode.Nodes.Add(myNode);

            foreach (var child in Children)
                child.BuildTreeNode(myNode);   
        }

    }
}
