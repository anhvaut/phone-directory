   M S B A M L   `   `   `  ����  PhoneDirectory     PhoneDirectory.QuickSearch   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -   5          � Title$  QuickSearch��5      $	��347��6   $	��253��6&    � WindowStyle$
 None=�62    � Topmost .  � WindowStartupLocation$ CenterScreen=�6T    J� Opacity$ 1Q�6y   
������� � 
ResizeMode$ 	CanResize=�6�    � 	Resources 5         HighlightCloseButton g� 	BeginTime �� 
TargetName	 �� TargetProperty
 O� KeyTime O� Value  FadeCloseButton��%�  &	        &	 �     �� 5   
   .��5      U� $ 00:00:00X�6,   $ btnClose��6A   $	 (UIElement.Opacity)�6b   .\�5      �� $
 00:00:00��6'   $	 0.4Q�6:   �� 5	      $
 00:00:00.3000000��6'   $ 1Q�6B   5
      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ btnClose��6A   $	 (UIElement.Opacity)�6b   .\�5      �� $
 00:00:00��6'   $ 1Q�6:   �� 5      $
 00:00:00.3000000��6'   $	 0.4Q�6B   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ Mouse.MouseEnter��6    :� 
SourceName$ btnClose��66   .[�5      �� -   5         ��Name$* $HighlightCloseButton_BeginStoryboard��5   Q   #��[  6   6Q   5      :� 5   
   $ Mouse.MouseLeave��6   $ btnClose��66   .[�5      �� -   5        $% FadeCloseButton_BeginStoryboard��5   L   #��[ 6   6L   5      .��5      � $ 1Q�6   .+�5   
   �� -   5         ��Name$ btnClose��5   �   $��Right=�6   $��0,2,5,0q�6,   $	��Top=�6=   $��16��6U   $��16��6`   $��/Images/Close.png��6l   $
��Fill=�6�   $	 0.4Q�6�    � ToolTip$ Close��6�   6�   �� 5   
   -   5        $��lbOrganisationName��5   3   $��20��6   $��	39,4,24,0q�6    $	��Top=�6M   $��	Wollundra��6e    �� TextAlignment$ Center=�6v   $
��Bold"�6�   �� 5   
   -   5        $��imgLogo��5   "   $��10,6,0,0q�6   $
��Fill=�61   $��32��6@   $
��Left=�6L   $	��Top=�6g   $/��)/PhoneDirectory;component/Images/logo.gif��6   $��32��6�    � Cursor$
 Hand��6�   6�   F� 5       ���	#FFFFFFFF �� Stretch$
 Fill=�5"      $��
45,38,13,0q�5#      $	��Top=�5$      $��1��5%      ���Ѐ����`����`	 J� SnapsToDevicePixels . ��5'   
   �� 5(       �� EndPoint$ 	0.973,0.5&�5)       �� 
StartPoint$ 	0.005,0.5&�5*      .��5+      �  � Color$ 	#00ECAD25��5,       � Offset$ 1Q�5-      � 5.      $ 	#87ECAD25��5/      $ 0Q�50      51      53      �� 54      -   5        $��txtName��54   ,   $��23��6   $��8,42,5,0q�6   $	��Top=�6;   $��12(�6S   6�   �� 55      -   5        $��lbName��55   !   $��	8,72,5,21q�6   $��12(�6�   �� 6�   -	   5        $��
textBlock2��55   �   $��21��6�   $��
40,21,31,0q�6�   $	��Top=�6�   $��Phone Directory��6�   $ Center=�6  �� 6  -
   5        $��lbNumberOfContacts��55   E  $��18��6&  $��	10,0,5,-1q�62  $��Bottom=�6_  $��	0 contact��6z  $ Right=�6�  56      57      