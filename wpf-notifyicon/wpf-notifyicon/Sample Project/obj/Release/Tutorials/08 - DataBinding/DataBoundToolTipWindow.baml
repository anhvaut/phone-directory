   M S B A M L   `   `   `  ����   Sample Project:    4Samples.Tutorials.DataBinding.DataBoundToolTipWindow   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  $	��300��$	��500��.��� .+�3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -      Name$  MyNotifyIcon1��   
IconSource$ /Icons/Error.ico��   ToolTipText ��  �� ElementName$ 
txtToolTip�� �� Path$
 Text�   TrayToolTip �� 
�������
��� ���$��2q� �� CornerRadius$ 4�� J� Opacity$	 0.8Q�$	��160��$��40��._��� $��Center=�$��Center=����� $ ToolTipText�  -   $  MyNotifyIcon2�� � DataContext$ WPF IS GREAT: ��$ /Icons/Inactive.ico�� �� $ 
txtToolTip��$
 Text� �� 
�������
��� ���$��2q�$ 4��$	 0.8Q�$	��160��$��40��._��� ���� �� $��Center=�$��Center=����� 	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType"
 ��$4 .(tb:TaskbarIcon.ParentTaskbarIcon).ToolTipText��� $��
26,26,24,0q�$	��Top=�$
��Wrap=�$
��Bold"��� $:�4This sample shows data bound ToolTips in two flavors���� �� $� ���� �� $(�"- implicit binding via DataContext���� �� $B�<- explicit binding via ParentTaskbarIcon (attached property)���� �� $� ���� �� $C�=Move over NotifyIcons (grey / red) to show data bound ToolTip���� -    ��Name$ 
txtToolTip��$��
26,0,24,10q�$��hello world�� �� TextWrapping$
 Wrap=�$��25��$��Bottom=��� $��26,0,125,45q�$��Bottom=�$��26��$
��Wrap=��� $�ToolTipText:��