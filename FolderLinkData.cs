using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    [JsonObject]
    public class FolderLinkData : GameData, IGameFolderLink
    {
        [JsonProperty]
        public string FolderPath { get; private set; }

        [JsonProperty]
        public override FolderData? Parent { get; set; }

        /* Constructor */
        public FolderLinkData(string path)
        {
            FolderPath = path;

        } // end constructor

        /// <summary>
        /// Returns last folder name in path.
        /// </summary>
        public static string GetFolderName(string folderPath)
        {
            return Path.GetFileName(folderPath.TrimEnd(Path.DirectorySeparatorChar));

        } // end GetFolderName

        public override string GetPath()
        {
            return base.GetPath() + GetFolderName(FolderPath) + "\\";

        } // end GetPath

    } // end class FolderLinkData

} // end namespace