   M S B A M L   `   `   `  ����   Sample Project    Samples.FancyPopup   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.3.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  -     >�Name$  me��$	��215��$	��300�� � 	Resources    
RotateIcon g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� 	KeySpline��%�   &	        �� .��U� $ 00:00:00X�$ image��$V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�.\��� $ 00:00:00��$ 0Q��� $ 0,0.284,0.39,1��$ 00:00:01.4000000��$	 360Q� � Triggers :� 	 :� RoutedEvent$ 	 tb:TaskbarIcon.PopupOpened��.[��� -   
 ��Name$ 
 RotateIcon_BeginStoryboard��#��[  .��� .+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��$��5,5,5,5q� �� CornerRadius$ 10,10,10,10�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FF474747������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF58C2FF�� � Offset$ 0Q�� $ 	#FFFFFFFF��$ 1Q��� -    ��Name$ image��$
��Left=�$��	19,10,0,0q�$	��Top=�$��72��$��72��$��/Images/Preferences.png��$
��Fill=� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~���  �� ScaleX$ 1Q� �� ScaleY$ 1Q���  �� AngleX$ 0Q� �� AngleY$ 0Q���  �� Angle$ 0Q�T�  T� X$ 0Q� T� Y$ 0Q��� $��107,10,20,0q�$
��Wrap=�$
��Auto��$	��Top=�$��16(�$
��Bold"����	#FF575757$��Right=��� $�This is a fancy Popup...�� � Language$ de-ch��� -   $��Right=�$��Bottom=�$��89��$��29��$��Click me��$��	0,0,20,20q����	#FFFFFFFF � ToolTip ��  �� Path$ ToolTipText����� $	 0,1&�$	 0,0&�.��� $ 	#FFFFFFFF��$ 1Q�� $ 	#FFFFD197��$ 0.459Q�� $ 	#FFFFDBAD��$ 0Q�� $ 	#FFF18E23��$ 0.508Q�� $ 	#FFF9D4AC��$ 0.954Q��� $��19,92,10,49q�$
��Wrap=��� $)�#This user control makes use of the ��$ de-ch��� $��Italic$�$
��Bold"�$�PopupOpened ��$ de-ch��� $z�tattached routed event . Whenever the popup is opened, this attached event fires and triggers the rotation animation.��$ de-ch��� $��	0,52,20,0q�$	��Top=�$
��Auto��$
��Wrap=�$
��Bold"�$��14(�$��Right=����	#FF575757�� $�Clicks: ��$ de-ch��� .F��� $
��Auto��$
��Auto��$
��Wrap=����� $ 
ClickCount� �� ElementName$ me�� �� Mode$ Default=��� $��16��$
��Left=�$��	19,0,0,23q�$��16��$��Bottom=����� $ 
IconSource�