   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   A%clr-namespace:QuanLyKho.UserControlATQuanLyKho.UserControlAT  5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Media;assembly=PresentationCoreSystem.Windows.Media 5   	       QuanLyKho.MainWindow   5   	   \ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   4uc%clr-namespace:QuanLyKho.UserControlAT     5   	   Nmedia<clr-namespace:System.Windows.Media;assembly=PresentationCore     5   	     � WindowStyle$
  None=�5	   	    � Title$ 
MainWindow��5   	   $
��auto��6   $
��1300��6*   .��5      � .+�5   
   .   (QuanLyKho.UserControlAT.UserControlBarUC  �� 5   
   -   5         ��Name$ 
btnWarning��5      $	��⚠��5      $
��Bold"�5      $��40(�5      $	��100��5      $��60��5      $y�	Collapsed=�5       � ToolTip$( "Có sản phẩm sắp hết hàng��5      $��Center=�5      $	��Top=�5      $��	0,0,20,60q�5      $��0q�5      
������  � Cursor$
 Hand��5       K� ZIndex$	 999��5       z�5!      T� 5"       T� Y$	 -30Q�6%   ��5$      �� 5%       �� 
TargetType" ��6   .�5&      ��  �� Property � ��	 �� Value
	 �  ��63   
 �� Triggers
 5'      P� 5(       P� Property �@J�	IsVisible P� Value$
 True��67    N� EnterActions 5)      �� 5*   "   .��5+   &   ��  g� RepeatBehavior$ Forever��61   .��5-   *   ��  �� TargetProperty$* $(Foreground).(SolidColorBrush.Color)�6G   .g�5.   .   ��  �� KeyTime$ 0:0:0��6N    �� Value Red6B   6N   �� 5/   .   $ 0:0:0.5��6R    DarkRed6B   6R   �� 50   .   $ 0:0:1��6N    Red6B   6N   51   +   U� 54   *   $. ((RenderTransform).(TranslateTransform.Y)�6H   .\�55   .   ��  O� KeyTime$ 0:0:0��6O    O� Value -306C   6O   �� 56   .   $ 0:0:0.5��6O    -356C   6O   �� 57   .   $ 0:0:1��6O    -306C   6O   58   +   59   '   5:   #   5<      5>      5@      5A      5B      