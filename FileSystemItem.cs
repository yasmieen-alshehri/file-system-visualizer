using System;

namespace FolderVisualizer.Core
{
    public abstract class FileSystemItem
    {
        public string Name { get; protected set; }
        public long Size { get; protected set; }  
        public FolderItem Parent { get; internal set; }
        public virtual int SortOrder => 1;

        protected FileSystemItem(string name)
        {
            Name = name;
        }

      
        public virtual void Add(FileSystemItem item)
            => throw new NotSupportedException();

        public virtual void Remove(FileSystemItem item)
            => throw new NotSupportedException();

        public virtual bool IsFolder => false;

  
        public abstract long CalculateSize();
        public abstract void BuildTreeNode(TreeNode parentNode);
    }
}
