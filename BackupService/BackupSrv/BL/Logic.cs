using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace BackupSrv.BL
{
    public class Logic
    {
        private static Timer _timer;
        public static void Start()
        {

        }

        private void StartBackup()
        {
            var folders = GetFoldersForBackup();
            if (folders.Any())
            {
                //forEach directory
                    //create directory with project name and date of creating
                    //get files from source
                    //copy files to destination
            }
        }

        private List<string> GetFoldersForBackup()
        {
            return null;
        }

        private bool ClearOldData()
        {
            return true;
        }
    }
}