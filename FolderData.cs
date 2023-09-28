using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    [JsonObject]
    public class FolderData : GameData, IGameFolder
    {
        [JsonProperty]
        public string FolderName { get; private set; }

        [JsonProperty]
        public List<GameData> Children;

        [JsonProperty]
        public override FolderData? Parent { get; set; }

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
                // Add folder links
                else if (child is TreeNodeFolderLink)
                {
                    FolderLinkData childFolderLink = new FolderLinkData(((TreeNodeFolderLink)child).FolderPath);
                    startFolder.Children.Add(childFolderLink);
                    childFolderLink.Parent = startFolder;
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
                    childFile.Text = Path.GetFileName(((FileData)child).FilePath);
                    startFolder.Nodes.Add(childFile);
                }
                // Add folders
                else if(child is FolderData)
                {
                    TreeNodeFolder childFolder = ((FolderData)child).ConvertToTreeNode(ref treeView);
                    childFolder.Text = ((FolderData)child).FolderName;
                    startFolder.Nodes.Add(childFolder);
                }
                // Add folder links
                if (child is FolderLinkData)
                {
                    TreeNodeFolderLink childFolderLink = new TreeNodeFolderLink(((FolderLinkData)child).FolderPath);
                    childFolderLink.Text = Path.GetFileName(FolderLinkData.GetFolderName(((FolderLinkData)child).FolderPath));
                    startFolder.Nodes.Add(childFolderLink);
                }
            }
            return startFolder;

        } // end CreateNodes

        /// <summary>
        /// Returns list of every single file within folder and all subfolders.
        /// </summary>
        public List<FileData> GetAllFiles()
        {
            List<FileData> files = new List<FileData>();
            foreach(GameData child in Children)
            {
                if(child is FileData)
                    files.Add((FileData)child);
                // Add all subfolders' children
                else if(child is FolderData)
                    files.AddRange(((FolderData)child).GetAllFiles());
            }
            return files;

        } // end GetAllFiles

        /// <summary>
        /// Returns list of every single folder link within folder and all subfolders.
        /// </summary>
        public List<FolderLinkData> GetAllFolderLinks()
        {
            List<FolderLinkData> folderLinks = new List<FolderLinkData>();
            foreach (GameData child in Children)
            {
                if (child is FolderLinkData)
                    folderLinks.Add((FolderLinkData)child);
                // Add all subfolders' children
                else if (child is FolderData)
                    folderLinks.AddRange(((FolderData)child).GetAllFolderLinks());
            }
            return folderLinks;

        } // end GetAllFolderLinks

        /// <summary>
        /// Fix parents that are null when serialized. No idea why this is an issue.<br/>
        /// (This program isn't that serious and I don't feel like spending 10 hours on it).
        /// </summary>
        public void UpdateParents()
        {
            foreach(GameData child in Children)
            {
                child.Parent = this;
                if(child is FolderData)
                    ((FolderData)child).UpdateParents();
            }

        } // end UpdateParents

        public override string GetPath()
        {
            return base.GetPath() + FolderName + "\\";

        } // end GetPath

    } // end class FolderData

} // end namespace
