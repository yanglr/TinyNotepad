; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "TinyNotepad"
#define MyAppVersion "1.0"
#define MyAppPublisher "iMath Company, Inc."
#define MyAppURL "http://yanglr.github.io/"
#define MyAppExeName "MyNotepad.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{F6689E75-5AE6-463A-ADFE-473826780FE2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputBaseFilename=TinyNotepad-Setup
SetupIconFile=C:\diskD\Algo\exercises\TinyNotepad\TinyNotepad\TinyNotepad\images\notepad.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "C:\diskD\Algo\exercises\TinyNotepad\TinyNotepad\TinyNotepad\bin\Release\MyNotepad.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\diskD\Algo\exercises\TinyNotepad\TinyNotepad\TinyNotepad\bin\Release\MyNotepad.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\diskD\Algo\exercises\TinyNotepad\TinyNotepad\TinyNotepad\bin\Release\MyNotepad.pdb"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

