# XmlChecker
Analyzer for XML.

## How to use
Two way to use.

1. Command-Line
2. MSBuild Task

### Use by Command-Line
XmlCheckerConsole.exe is Command-Line tool.<br/>
Here is command usage.

> XmlCheckerConsole.exe [target]

"target" require directory or file.
If "target" is directory, XmlCheckerConsole.exe check "*.xaml" files in directory hierarchical.

if you wanto to call from Visual Studio, settings is below.  
![settings for visual studio to call outside tools](vssetting.png "settings for visual studio to call outside tools")

### Use by MSBuild
XmlCheckTask is msbuild task.<br/>
Usable parameters are here.

parameter|description
---|---
TargetFiles|Target files to check. Only file path. Not directory.
RuleFiles|Rule files of csv.
ErrorLevels|Level to be treated as an error. Level is defined in RuleFiles.

"XmlChecker.targets" file is sample for msbuild task.
This file is used for nuget package.
