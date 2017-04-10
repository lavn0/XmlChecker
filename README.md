# XmlChecker
XML���`�F�b�N���邽�߂̃c�[���B

## �g����
�Q�ʂ�̎g�������ł��܂��B

1. �R�}���h���C���c�[��
2. MSBuild�^�X�N

### �R�}���h���C���c�[���̎g����
XmlCheckerConsole.exe ���R�}���h���C���c�[���ł��B<br/>
�ȉ��̂悤�ɂ��Ďg�p�ł��܂��B

> XmlCheckerConsole.exe [target]

"target" �ɂ̓f�B���N�g���܂��̓t�@�C���̃p�X���w�肵�܂��B
�f�B���N�g�����w�肳�ꂽ�ꍇ�A���s�o�[�W�����ł̓f�B���N�g���z���̂��ׂĂ�xaml�t�@�C�����`�F�b�N�ΏۂƂ��܂��B

Visual Studio����͉��}�̂悤�ɊO���c�[���Ƃ��ēo�^���Ďg�p����ƕ֗��ł��B  
![VisualStudio�̊O���c�[���Ƃ��ēo�^����Ƃ��̐ݒ�](vssetting.png "VisualStudio�̊O���c�[���Ƃ��ēo�^����Ƃ��̐ݒ�")

### MSBuild�^�X�N�̎g����
XmlCheckTask �� MSBuild �Ƃ��Ē�`���Ă���܂��B<br/>
�g�p�ł���p�����[�^�͈ȉ��̒ʂ�ł��B

�p�����[�^|����
---|---
TargetFiles|�`�F�b�N�ΏۂƂ���t�@�C�����w�肵�܂��B�R�}���h���C���c�[���Ƃ͈قȂ�A�f�B���N�g�����w�肵�Ă��@�\���܂���B
RuleFiles|CSV�ŋL�q���ꂽ���[���t�@�C�����w�肵�܂��B
ErrorLevels|�G���[�Ƃ��Ĉ������x�����w�肵�܂��B���x���̓��[���t�@�C���ŋL�q���܂��B�ڂ����́A���[���̋L�q���@���Q�Ƃ��Ă��������B

"XmlChecker.targets" �t�@�C����MSBuild�^�X�N�̃T���v���ƂȂ�܂��B
���̃t�@�C����nuget�p�b�P�[�W���Ŏg�p����Ă��܂��B

### ���[���t�@�C���ɂ���
Silverlight�����̃��[���t�@�C��(SilverlightRule.csv)��WPF�����̃��[���t�@�C��(WpfRule.csv)���t�����Ă��܂��B  
nuget�Ńv���W�F�N�g�Ɏ�荞�񂾏ꍇ�́A�v���W�F�N�g�̎�ނɉ����ĕs�v�ȕ����폜���Ė�肠��܂���B  
���[���t�@�C���͈ȉ��̂悤�ȃt�H�[�}�b�g�ɏ]���ACSV�ŋL�q���܂��B�w�b�_�͂���܂���B  
���R�ɏ����������\�ł��̂ŁA�s�v�ȃ��[�����폜������A�K�v�ȃ��[����ǉ����ė��p���܂��B

ID|���x��|XPath|���b�Z�[�W
---|---|---
WPFXA0101|Default|//*[name(.)='Border']/@Visibility[.='Visible']|Visibility="Visible"�̓f�t�H���g�l�ł��B
WPFXA0102|Default|//*[name(.)='Border']/@IsEnabled[.='True']|IsEnabled="True"�̓f�t�H���g�l�ł��B

