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

### About Rule.csv

included A rule file (SilverlightRule.csv) for Silverlight and a rule file (WpfRule.csv) for WPF.
If you imported into project by nuget, you can delete unnecessary one according to the type of project.
The rule file is written in CSV. There is no header. Sample is below.
Rules can be freely add and delete if you need.

Id|Level|XPath|Message
---|---|---
WPFXA0101|Default|//*[name(.)='Border']/@Visibility[.='Visible']|Visibility="Visible"はデフォルト値です。
WPFXA0102|Default|//*[name(.)='Border']/@IsEnabled[.='True']|IsEnabled="True"はデフォルト値です。

