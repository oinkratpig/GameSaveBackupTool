using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace GameSaveBackupTool
{
    public static class ProgramSave
    {
        private static readonly string _programSaveName = "backups.txt";
        private static readonly string _programSavePath = GetLocalPath() + @"backups.txt";

        public static void Init()
        {
            // No program save exists
            if (!File.Exists(_programSavePath))
            {
                FileStream file = File.Create(_programSavePath);
                file.Close();
            }

            /*
            // Program save exists
            else
                ReadProgramSave();
            */

        } // end Init

        public static string GetLocalPath()
        {
            return AppContext.BaseDirectory;

        } // end GetLocalPath

        /*
        public static void Save()
        {
            using (StreamWriter writer = new StreamWriter(_programSavePath))
            {
                List<string> contents = new List<string>();

                // Backup path
                if (GameProfile.BackupDirectory == null)
                    GameProfile.BackupDirectory = GameProfile.GetDefaultBackupDirectory();
                writer.WriteLine(GameProfile.BackupDirectory);

                // Games
                if (FormMain.Profiles != null)
                    foreach(GameProfile save in FormMain.Profiles)
                    {
                        string str = $"{save.GameName},{save.LastDirectoryVisited}";
                        foreach (string fileName in save.FileNames)
                            str += $",{fileName}";
                        writer.WriteLine(str);
                    }
            }

        } // end Save
        */

        private static void SetBackupDirectory()
        {
            using (FileStream file = File.OpenRead(_programSavePath))
            {
                string[] lines = (string[]) File.ReadAllLines(_programSavePath);
                if(lines.Length > 0)
                    GameProfile.BackupDirectory = lines[0];
            }

        } // end SetBackupDirectory

        /*
        private static void ReadProgramSave()
        {
            using(StreamReader reader = new StreamReader(_programSavePath))
            {
                int i = 0;
                string? line = reader.ReadLine();
                while (line != null)
                {
                    // Backup path
                    if (i == 0)
                        GameProfile.BackupDirectory = line;

                    // Games
                    else
                    {
                        string[] game = line.Split(",");
                        if(game.Length > 2)
                        {
                            List<string> files = new List<string>();
                            for (int j = 2; j < game.Length; j++)
                                files.Add(game[j]);
                            FormMain.Profiles.Add(new GameProfile(game[1], game[0], files));
                        }
                    }

                    line = reader.ReadLine();
                    i++;
                }
            }

        } // end SetGameSaves
        */

    } // end class ProgramSave

} // end namespace