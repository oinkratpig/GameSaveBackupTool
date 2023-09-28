using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    /// <summary>
    /// Used for saving program information.
    /// </summary>
    public static class Save
    {
        /// <summary>
        /// Filename of the program's save file.<br/>
        /// Does not include the path.
        /// </summary>
        public const string SAVE_FILE = "games.gsbt";

        /// <summary>
        /// Path to store program's save file.<br/>
        /// Does not include the save filename.
        /// </summary>
        public static string ProgramSavePath { get; private set; }

        /// <summary>
        /// Directory containing all backup folders.
        /// </summary>
        public static string BackupDirectory { get; set; }

        /// <summary>
        /// All folder data for each profile's root folder.<br/>
        /// Key: Name of game.<br/>
        /// Value: Root folder data.
        /// </summary>
        public static Dictionary<string, FolderData> ProfileRootFolders { get; set; }

        /* Constructor */
        static Save()
        {
            ProgramSavePath = Environment.CurrentDirectory;
            ProfileRootFolders = new Dictionary<string, FolderData>();
            BackupDirectory = GetDefaultBackupDirectory();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
        };

        } // end constructor

        /// <summary>
        /// Get default directory for storing backup folders.
        /// </summary>
        public static string GetDefaultBackupDirectory()
        {
            return ProgramSavePath + "\\Backups";

        } // end GetDefaultBackupDirectory

        /// <summary>
        /// Get default name of saves.
        /// </summary>
        public static string GetDefaultSaveName()
        {
            string dateTime = DateTime.Now.ToString().Replace("/", "_").Replace(":", "-");
            return $"save {dateTime}";

        } // end GetDefaultSaveName

        /// <summary>
        /// Save game profiles, etc. to disk.
        /// </summary>
        public static void CreateSave()
        {
            using (StreamWriter writer = new StreamWriter(ProgramSavePath + "\\" + SAVE_FILE))
            {
                // Backup directory
                writer.WriteLine(BackupDirectory);
                // Profiles
                writer.WriteLine(JsonConvert.SerializeObject(ProfileRootFolders));
            }

        } // end CreateSave

        /// <summary>
        /// Save game profiles, etc. to disk.
        /// </summary>
        public static void LoadSave()
        {
            if (!File.Exists(ProgramSavePath + "\\" + SAVE_FILE)) return;

            using (StreamReader reader = new StreamReader(ProgramSavePath + "\\" + SAVE_FILE))
            {
                // Backup directory
                BackupDirectory = reader.ReadLine();
                // Profiles
                string json = reader.ReadLine();
                ProfileRootFolders = JsonConvert.DeserializeObject<Dictionary<string, FolderData>>(json);
                foreach(FolderData root in ProfileRootFolders.Values)
                    root.UpdateParents();
            }

        } // end class Save

        /// <summary>
        /// Creates an archive containing the profile's save files and folders.
        /// </summary>
        public static void Backup(FolderData rootFolder, string gameName, string? saveName, bool numberPrefix, bool numberPostfix)
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
            string backupGameDirectory = @$"{BackupDirectory}\{gameName}";
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
                if (numberPrefix)
                    prefix = $"{(highestPrefix + 1).ToString("D2")} ";
                if (numberPostfix)
                    postfix = $" {(highestPostfix + 1).ToString("D2")}";
            }

            // Zip save to backup directory
            using (FileStream zipStream = File.Create(backupGameDirectory + @$"\{prefix}{saveName}{postfix}.zip"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (ZipArchive zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    {
                        // Add all files in folder
                        List<FileData> files = rootFolder.GetAllFiles();
                        foreach (FileData file in files)
                        {
                            ZipArchiveEntry entry = zip.CreateEntryFromFile(
                                    file.FilePath,
                                    file.GetPath()
                            );
                        }
                        // Add all folder links in folder
                        List<FolderLinkData> folderLinks = rootFolder.GetAllFolderLinks();
                        foreach (FolderLinkData folderLink in folderLinks)
                        {
                            string[] filePaths = Directory.GetFiles(folderLink.FolderPath);
                            foreach(string path in filePaths)
                            {
                                ZipArchiveEntry entry = zip.CreateEntryFromFile(
                                    path, folderLink.GetPath() + Path.GetFileName(path)
                                );
                            }
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

    }

} // end namespace