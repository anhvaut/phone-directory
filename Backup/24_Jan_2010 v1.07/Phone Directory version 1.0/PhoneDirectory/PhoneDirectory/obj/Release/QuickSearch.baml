   M S B A M L   `   `   `  ����   PhoneDirectory     PhoneDirectory.QuickSearch   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    -     � Title$  QuickSearch��$	��320��$	��238�� � WindowStyle$
 None=� � Topmost .  � WindowStartupLocation$ CenterScreen=� J� Opacity$ 1Q�
������� � 
ResizeMode$ NoResize=� � 	Resources    HighlightCloseButton g� 	BeginTime �� 
TargetName	 �� TargetProperty
 O� KeyTime O� Value  FadeCloseButton��%(  &	        &	 �     �� .��U� $ 00:00:00X�$ btnClose��$	 (UIElement.Opacity)�.\��� $
 00:00:00��$	 0.4Q��� $
 00:00:00.3000000��$ 1Q��� .��U� $ 00:00:00X�$ btnClose��$	 (UIElement.Opacity)�.\��� $
 00:00:00��$ 1Q��� $
 00:00:00.3000000��$	 0.4Q� � Triggers :�  :� RoutedEvent$ Mouse.MouseEnter�� :� 
SourceName$ btnClose��.[��� -    ��Name$* $HighlightCloseButton_BeginStoryboard��#��[  :� $ Mouse.MouseLeave��$ btnClose��.[��� -   $% FadeCloseButton_BeginStoryboard��#��[ .��� .+��� -    ��Name$ btnClose��$��Right=�$��0,2,5,0q�$	��Top=�$��16��$��16��$��/Images/Close.png��$
��Fill=�$	 0.4Q� � ToolTip$ Close���� -   $��lbOrganisationName��$��20��$��	39,4,24,0q�$	��Top=�$��YWCA Of  Canberra�� �� TextAlignment$ Center=�$
��Bold"��� -   $��imgLogo��$��10,6,0,0q�$
��Fill=�$��32��$
��Left=�$	��Top=�$/��)/PhoneDirectory;component/Images/logo.gif��$��32��F� ���	#FFFFFFFF �� Stretch$
 Fill=�$��
45,38,13,0q�$	��Top=�$��1�����Ѐ����`����`	 J� SnapsToDevicePixels . ����  �� EndPoint$ 	0.973,0.5&� �� 
StartPoint$ 	0.005,0.5&�.���  � Color$ 	#00ECAD25�� � Offset$ 1Q�� $ 	#87ECAD25��$ 0Q��� -   $��txtName��$��23��$��8,42,5,0q�$	��Top=�$��12(��� -   $��lbName��$��	8,72,5,10q�$��12(��� -	   $��
textBlock2��$��21��$��
40,21,31,0q�$	��Top=�$��Phone Directory��$ Center=�