   M S B A M L   `   `   `  ����@  <BTMS1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BTMS1BTMS1  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       BTMS1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:BTMS1     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$"  Bus Ticket Management System��5	   	   $��474.8��6.   $	��800��6=    � WindowStartupLocation$ CenterScreen=�6I   $��Center=�6n    � UseLayoutRounding . &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6�    � WindowStyle$ ThreeDBorderWindow=�6�   $��2q�6�   $��Times New Roman)�6�   $��Light"�6   � Icon$ bus.png��6.  .��5      � $��-3,0,-68.4,-46q�6   ���	#FF00C000|�.  .  J� SnapsToDevicePixels .  � ColumnDefinitions 5   
   �� 5      $
��134* �6   �� 5      $
��184* �6   �� 5      $
��390* �6   �� 5      $
��157* �6   .+�5   
   �� $"��Bus Ticket
Management
System��6   $
��Left=�6?   $��
25,251,0,0q�6Z   $	��Top=�6n   $	��228��6�   $	��170��6�   $��Times New Roman)�6�   $��32(�6�   $��	ExtraBold"�6�   $��2��6�   |�.  .  . 6!  �� 5   
   $��28,18,84.8,259.6q�6   $��bus.png��6*   $
��Fill=�6;   $	��Top=�6J   $	��214��6b   $��4��6o   |�.  .  . 6�   �� 5   
   $��User Name:-��6   $
��Left=�6&   $��136.6,246,0,0q�6A   $	��Top=�6X   $��Times New Roman)�6p   $��14(�6�   $
��Bold"�6�   $��1��6�   $��2��6�   |�.  .  . 6�   �� 5   
   -   5         ��Name$ passwordtex��5      $��
Password:-��6%   $
��Left=�6:   $��136.6,296,0,0q�6U   $	��Top=�6l   $��Times New Roman)�6�   $��14(�6�   $
��Bold"�6�   $��1��6�   $��2��6�   |�.  .  . 6  �� 5   
   -   5        	 ��Name$	 passwordtxtbox��5      $��34��6*   $��47.6,294,0,0q�66   
 �� TextWrapping$

 Wrap=�6L   $	��Top=�6`   $	��414��6x   $��2��6�   $��2��6�   $��Enter Password Here��6�    J� RenderTransformOrigin$ 0.485,-1.194&�6�   $
��Left=�6�   $��Center=�6   .  . 6@  �� 5   
   -   5         ��Name$ loginbtn��5      $��Login��6#   $
��Left=�63   $��47.6,352,0,0q�6N   $	��Top=�6d   $	��120��6|   $��37��6�   $��Times New Roman)�6�   $
��Bold"�6�   $��17(�6�   ���	#FF189D2C �� 	ClickMode$ Press=�6�   $��2��6   .  . 6<  �� 5   
   -   5        $ exitbtn��5      $
��Exit��6"   $
��Left=�61   $��341.6,352,0,0q�6L   $	��Top=�6c   $	��120��6{   $��37��6�   $��Times New Roman)�6�   $
��Bold"�6�   $��17(�6�   ���	#FF189D2C$ Press=�6�   $��2��6  $��2��6"   .  . 6M  �� 5   
   -   5        $ resetbtn��5      $��Reset��6#   $
��Left=�63   $��193.6,352,0,0q�6N   $	��Top=�6e   $	��120��6}   $��37��6�   $��Times New Roman)�6�   $
��Bold"�6�   $��17(�6�   ���	#FF189D2C$ Press=�6   $��2��6   .  . 6=  �� 5   
   -   5        $ forgetpasswordbtn��5      $��Forgot Password?��6,   $
��Left=�6G   $��50.6,411,0,0q�6b   $	��Top=�6x   $	��103��6�   $��20��6�   ���	#FF0E8B14$ Press=�6�   $��Medium"�6�      TextFormattingMode$ Display=�6�   $��Times New Roman)�6  $��2��6B   .  . 6m  �� 5   
   -   5        $	 usernametxtbox��5      $��2��6*   $��33��6:   $��47.6,245,0,0q�6F   $

 Wrap=�6\   $��Enter User Name Here��6p   $	��Top=�6�   $	��412��6�   $ 0.433,2.139&�6�   $��2��6�   $
��Left=�6�   $��Center=�6   .  . 6@  5      5      