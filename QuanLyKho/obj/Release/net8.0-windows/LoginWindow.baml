   M S B A M L   `   `   `  ���� D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho      QuanLyKho.LoginWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:QuanLyKho     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � WindowStyle$
  None=� � 
ResizeMode$ NoResize=�   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � Title$ Đăng nhập��$	��300��$	��400�� � WindowStartupLocation$ CenterScreen=�.��� 
�������.+��� $��Đăng nhập��$��Center=�$	��Top=�$��20(�$
��Bold"�$��0 10 0 0q�#  MaterialDesignThemes.Wpf.Card  $	��200��$	��300��$��
50,65,50,0q�$	��Top=�.���  � 	Resources  �� 
TargetType �� Property	 �� Value��%5   '�       �� " �.���  � ��$	 
15 15 15 0q�
 � RowDefinitions
 �� $
��Auto ��� $
��Auto ��� $
��Auto �.+�� $��0��.+��� -    ��Name$ txtUsername��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập�� % !MaterialDesignFloatingHintTextBox#��[ � $��1�� � ColumnDefinitions �� $	��67* ��� $
��173* �.+�G� -    G�Name$ txtPassword��$ Mật khẩu�� ) %MaterialDesignFloatingHintPasswordBox#��[ $��2��� $��2�� �� �� .+��� -   $��0��  MaterialDesignRaisedButton#��[ $	��100�� � ToolTip$/ )Resource name: MaterialDesignRaisedButton��.��_Đăng nhập�� -   $��1��#��[ 
��� E��$	��100��$/ )Resource name: MaterialDesignRaisedButton��.��	_Thoát