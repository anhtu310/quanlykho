   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	       QuanLyKho.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStyle$
  None=�5	   	    � 
ResizeMode$ NoResize=�5
   	      MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ Đăng nhập��5   	   $	��300��6   $	��400��6(    � WindowStartupLocation$ CenterScreen=�64   .��5      � 
�������.+�5   
   �� $��Đăng nhập��6   $��Center=�6$   $	��Top=�6A   $��20(�6Y   $
��Bold"�6g   $��0 10 0 0q�6y   #  MaterialDesignThemes.Wpf.Card  5   
   $	��200��6   $	��300��6+   $��
50,65,50,0q�67   $	��Top=�6K   .��5      �  � 	Resources 5       �� 
TargetType �� Property	 �� Value��%Z   '�       �� 5      " �6   .�5      ��  � ��$	 
15 15 15 0q�63   5      5      
 � RowDefinitions
 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5       $
��Auto �6$   .+�5"      � $��0��6   .+�5#      �� -   5         ��Name$ txtUsername��5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��5$       % !MaterialDesignFloatingHintTextBox#��[ 5%      5&      � 5'      $��1��6    � ColumnDefinitions 5(      �� 5)      $	��67* �6+   �� 5*      $
��173* �6+   .+�5,      G� -   5         G�Name$ txtPassword��5-      $ Mật khẩu��5.       ) %MaterialDesignFloatingHintPasswordBox#��[ 5/      $��2��6T   50      � 51      $��2��6    52      �� 53      �� 54      .+�56      �� -   5        $��0��56   2     MaterialDesignRaisedButton#��[ 6B   $	��100��6v    � ToolTip$/ )Resource name: MaterialDesignRaisedButton��6�   .��6�   _Đăng nhập58      �� 59      -   5        $��1��59   3   #��[ 6C   
��� E��$	��100��6�   $/ )Resource name: MaterialDesignRaisedButton��6�   .��6�   	_Thoát5;      5<      5=      5>      5?      5@      