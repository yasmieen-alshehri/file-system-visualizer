using FolderVisualizer.Core;
using System.IO;

namespace FolderVisualizer.Services
{
    public static class FolderTraverser
    {
        public static FolderItem BuildTree(string rootPath)
        {
            var rootDir = new DirectoryInfo(rootPath);
            var rootFolder = new FolderItem(rootDir.Name);
            BuildRecursive(rootDir, rootFolder);
            return rootFolder;
        }

        private static void BuildRecursive(DirectoryInfo dir, FolderItem folderNode)
        {
            // files
            foreach (var file in dir.GetFiles())
            {
                folderNode.Add(new FileItem(file));
            }

            // subfolders
            foreach (var subDir in dir.GetDirectories())
            {
                var subFolderNode = new FolderItem(subDir.Name);
                folderNode.Add(subFolderNode);
                BuildRecursive(subDir, subFolderNode);
            }
        }
    }
}
