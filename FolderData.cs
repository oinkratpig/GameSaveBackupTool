using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    public class FolderData : GameData, IGameFolder
    {
        public string FolderName { get; private set; }

        public List<GameData> Children;

        /* Constructor */
        public FolderData(string name)
        {
            FolderName = name;

            Children = new List<GameData>();

        } // end constructor
        
        /// <summary>
        /// Creates data from the folder and all subfolders.<br/>
        /// Used for saving.
        /// </summary>
        public static FolderData ConvertFromFolderNode(TreeNodeFolder node)
        {
            FolderData startFolder = new FolderData(node.FolderName);
            foreach(TreeNode child in node.Nodes)
            {
                // Add files
                if (child is TreeNodeFile)
                {
                    FileData childFile = new FileData(((TreeNodeFile)child).FilePath);
                    startFolder.Children.Add(childFile);
                    childFile.Parent = startFolder;
                }
                // Add folders
                else if(child is TreeNodeFolder)
                {
                    FolderData childFolder = ConvertFromFolderNode((TreeNodeFolder)child);
                    startFolder.Children.Add(childFolder);
                    childFolder.Parent = startFolder;
                }
            }
            return startFolder;

        } // end ConvertFromFolderNode

        /// <summary>
        /// Convert a folder and its subfolders/files to <see cref="TreeNode"/>s.
        /// </summary>
        public TreeNodeFolder ConvertToTreeNode(ref TreeView treeView)
        {
            TreeNodeFolder startFolder = new TreeNodeFolder(FolderName);
            foreach(GameData child in Children)
            {
                // Add files
                if(child is FileData)
                {
                    TreeNodeFile childFile = new TreeNodeFile(((FileData)child).FilePath);
                    startFolder.Nodes.Add(childFile);
                }
                // Add folders
                else if(child is FolderData)
                {
                    TreeNodeFolder childFolder = ((FolderData)child).ConvertToTreeNode(ref treeView);
                    childFolder.Text = ((FolderData)child).FolderName;
                    startFolder.Nodes.Add(childFolder);
                }
            }
            return startFolder;

        } // end CreateNodes

    } // end class FolderData

} // end namespace
