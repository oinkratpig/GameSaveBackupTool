using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    public class GameProfile
    {
        public string LastDirectoryVisited { get; private set; }

        public string GameName { get; private set; }

        public FolderData? RootFolderData { get; set; }

        /* Constructor */
        public GameProfile(string gameName, FolderData rootFolderData) : this(gameName)
        {
            RootFolderData = rootFolderData;

        } // end constructor

        /* Constructor */
        public GameProfile(string gameName)
        {
            GameName = gameName;

            LastDirectoryVisited = string.Empty;

        } // end constructor

        public static string GetDefaultSaveName()
        {
            string dateTime = DateTime.Now.ToString().Replace("/", "_").Replace(":", "-");
            return $"save {dateTime}";

        } // end GetDefaultSaveName

        /// <summary>
        /// Creates an archive containing the profile's save files and folders.
        /// </summary>
        public void Backup(FolderData rootFolder, string? saveName, bool numberPrefix, bool numberPostfix)
        {
            if (Save.BackupDirectory == null) return;

            // Output msg
            FormMain.outputText = $"({DateTime.Now}) Backing up...";

            // == ERRORS ===============

            // Invalid save name
            if (saveName != null)
                foreach (char ch in Path.GetInvalidFileNameChars())
                    if (saveName.Contains(ch))
                    {
                        FormMain.outputText += $"\r\nSave name \"{saveName}\" invalid. Using default name.";
                        saveName = null;
                        break;
                    }

            // Set save name
            if (string.IsNullOrWhiteSpace(saveName))
                saveName = GetDefaultSaveName();

            // Create backup directory if it doesn't already exist
            string backupGameDirectory = @$"{Save.BackupDirectory}\{GameName}";
            Directory.CreateDirectory(backupGameDirectory);

            // Save name already taken
            if (File.Exists(backupGameDirectory + @$"\{saveName}.zip"))
                FormMain.outputText += $"\r\nSave name \"{saveName}\" already taken. Overwriting.";

            // =========================

            // Get all backup file names
            List<string> fileNames = new List<string>();
            foreach (string path in Directory.GetFiles(backupGameDirectory))
                fileNames.Add(Path.GetFileNameWithoutExtension(path));

            // Number the save name
            string prefix = "";
            string postfix = "";
            if (numberPrefix || numberPostfix)
            {
                // Find prefix and postfix
                int highestPrefix = 0;
                int highestPostfix = 0;
                foreach (string fileName in fileNames)
                {
                    string[] words = fileName.Split(" ");
                    if (words.Length == 0) continue;
                    else
                    {
                        int prefixNum = 0;
                        int postfixNum = 0;
                        if (numberPrefix)
                            Int32.TryParse(words[0], out prefixNum);
                        if (numberPostfix)
                            Int32.TryParse(words[words.Length - 1], out postfixNum);
                        highestPrefix = Math.Max(highestPrefix, prefixNum);
                        highestPostfix = Math.Max(highestPostfix, postfixNum);
                    }
                }

                // Add prefix and postfix
                if(numberPrefix)
                    prefix = $"{(highestPrefix + 1).ToString("D2")} ";
                if(numberPostfix)
                    postfix = $" {(highestPostfix + 1).ToString("D2")}";
            }

            // Zip save to backup directory
            using (FileStream zipStream = File.Create(backupGameDirectory + @$"\{prefix}{saveName}{postfix}.zip"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (ZipArchive zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    {
                        List<FileData> files = rootFolder.GetAllFiles();
                        foreach (FileData file in files)
                        {
                            ZipArchiveEntry entry = zip.CreateEntryFromFile(
                                    Path.GetFileName(file.FilePath),
                                    Path.GetFileName(file.GetPath())
                            );
                        }
                    }
                    ms.WriteTo(zipStream);
                }
            }

            /*
            // Zip all save files to backup directory
            FileStream zipStream = File.Create(backupGameDirectory + @$"\{prefix}{saveName}{postfix}.zip");
            using (MemoryStream ms = new MemoryStream())
            {
                using (ZipArchive zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    foreach (string file in FileNames)
                    {
                        if (!File.Exists(file))
                            FormMain.outputText += $"\r\nNo file found \"{file}\". Ignoring.";
                        else
                            zip.CreateEntryFromFile(file, Path.GetFileName(file));
                    }
                }
                ms.WriteTo(zipStream);
            }
            zipStream.Close();
            */

            // Done
            FormMain.outputText += "\r\nDone.";

        } // end Backup

    } // end class SaveFiles

} // end namespace