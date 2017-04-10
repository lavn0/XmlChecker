# XmlChecker
XMLをチェックするためのツール。

## 使い方
２通りの使い方ができます。

1. コマンドラインツール
2. MSBuildタスク

### コマンドラインツールの使い方
XmlCheckerConsole.exe がコマンドラインツールです。<br/>
以下のようにして使用できます。

> XmlCheckerConsole.exe [target]

"target" にはディレクトリまたはファイルのパスを指定します。
ディレクトリが指定された場合、現行バージョンではディレクトリ配下のすべてのxamlファイルをチェック対象とします。

Visual Studioからは下図のように外部ツールとして登録して使用すると便利です。  
![VisualStudioの外部ツールとして登録するときの設定](vssetting.png "VisualStudioの外部ツールとして登録するときの設定")

### MSBuildタスクの使い方
XmlCheckTask が MSBuild として定義してあります。<br/>
使用できるパラメータは以下の通りです。

パラメータ|説明
---|---
TargetFiles|チェック対象とするファイルを指定します。コマンドラインツールとは異なり、ディレクトリを指定しても機能しません。
RuleFiles|CSVで記述されたルールファイルを指定します。
ErrorLevels|エラーとして扱うレベルを指定します。レベルはルールファイルで記述します。詳しくは、ルールの記述方法を参照してください。

"XmlChecker.targets" ファイルがMSBuildタスクのサンプルとなります。
このファイルはnugetパッケージ内で使用されています。

### ルールファイルについて
Silverlight向けのルールファイル(SilverlightRule.csv)とWPF向けのルールファイル(WpfRule.csv)が付属しています。  
nugetでプロジェクトに取り込んだ場合は、プロジェクトの種類に応じて不要な方を削除して問題ありません。  
ルールファイルは以下のようなフォーマットに従い、CSVで記述します。ヘッダはありません。  
自由に書き換えが可能ですので、不要なルールを削除したり、必要なルールを追加して利用します。

ID|レベル|XPath|メッセージ
---|---|---
WPFXA0101|Default|//*[name(.)='Border']/@Visibility[.='Visible']|Visibility="Visible"はデフォルト値です。
WPFXA0102|Default|//*[name(.)='Border']/@IsEnabled[.='True']|IsEnabled="True"はデフォルト値です。

