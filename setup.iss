#define MainBinaryName	"AppSeal\bin\Release\AppSeal.exe"
#define SetupBaseName	"AppSeal-"
#define AppVersion		GetVersionNumbersString(AddBackslash(SourcePath) + MainBinaryName)

[Setup]
AppVersion={#AppVersion}
OutputBaseFilename={#SetupBaseName + AppVersion}
OutputDir=c:\Temp
AppName=AppSeal
AppVerName=AppSeal
AppPublisher=Brian Schau
AppPublisherURL=https://github.com/bschau/AppSeal
AppSupportURL=https://github.com/bschau/AppSeal
AppUpdatesURL=https://github.com/bschau/AppSeal
DefaultDirName={autopf}\AppSeal
DefaultGroupName=AppSeal
DisableProgramGroupPage=yes
UsePreviousAppDir=yes
SetupIconFile=installer.ico
UninstallDisplayIcon={app}\installer.ico
PrivilegesRequired=lowest

[Types]
Name: "full"; Description: "Everything"

[Components]
Name: "full"; Description: "Everything"; Types: full

[Files]
; Common
Source: "installer.ico"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Components: full

; AppSeal
Source: "AppSeal\bin\Release\AppSeal.exe"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Components: full
Source: "AppSeal\bin\Release\AppSeal.exe.config"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Components: full
Source: "AppSeal\bin\Release\appseal.json"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Components: full
Source: "AppSeal\bin\Release\AppSeal.pdb"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Components: full
Source: "AppSeal\bin\Release\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Components: full
Source: "AppSeal\bin\Release\Newtonsoft.Json.xml"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Components: full

[UninstallDelete]
Type: dirifempty; Name: "{app}"

[Icons]
Name: "{group}\AppSeal"; Filename: "{app}\AppSeal.exe"; WorkingDir: "{app}"; Components: full
Name: "{usersendto}\AppSeal"; Filename: "{app}\AppSeal.exe"; WorkingDir: "{app}"; Components: full
