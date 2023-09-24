using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    public abstract class GameData
    {
        public abstract FolderData? Parent { get; set; }

        /// <summary>
        /// Gets a relative path combining all parent folders' names.
        /// </summary>
        public virtual string GetPath()
        {
            // Get list of folders in order of path
            List<string> folders = new List<string>();
            FolderData? folder = Parent;
            while(folder != null)
            {
                folders.Add(folder.FolderName);
                folder = folder.Parent;
            }
            folders.Reverse();

            // Path
            string path = "";
            for(int i = 1 /* Skip root folder */; i < folders.Count; i++)
                path += folders[i] + "\\";
            return path;

        } // end GetPath

    } // end class GameData

} // end namespace