using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    [JsonObject]
    public class FileData : GameData, IGameFile
    {
        [JsonProperty]
        public string FilePath { get; private set; }

        [JsonProperty]
        public override FolderData? Parent { get; set; }

        /* Constructor */
        public FileData(string path)
        {
            FilePath = path;

        } // end constructor

        public override string GetPath()
        {
            return base.GetPath() + Path.GetFileName(FilePath) + "\\";

        } // end GetPath

    } // end class FileData

} // end namespace