# BackupService

WinService for automatic backup necessary data.
For install use installer (not implemented yet)

SETTINGS:
in config set:

SECTION "appSettings", set value on keys:
key="FolderToBackUp" value="write here folder where will backup projects or data. It will be root folder of backup, others will be create inside"
key="TimerMinutesInterval" value="interval in minutes for start checking is backup needs. If data is up-to-date - backup don't maked"
key="ObsolescenceHours" value="Hours after which old backups will be deleted. Default = 24 hrs (1day)"

SECTION BackupFromFolders:
To this section please add strings with folder path to backup, and project name. 
Name of project isn't important - it just used by user to identification his projects. Example:
<add key="Project1" value="D:\Project1"/> - folder from value will be backuped to value by key="FolderToBackUp" from section "appSettings"

You can add so many projects how many you need.

PLANS:
*Add auto installer for convenience
*Add logging of service working
