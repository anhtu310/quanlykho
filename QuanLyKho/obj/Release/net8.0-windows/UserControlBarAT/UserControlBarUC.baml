   M S B A M L   `   `   `  ���� D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:QuanLyKho.ViewsQuanLyKho.Views  .    (QuanLyKho.UserControlAT.UserControlBarUC   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     .viewclr-namespace:QuanLyKho.Views     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���  $
��auto��$
��auto�� � 	Resources   OptionMenuStyle �� 
TargetType �� Property �� Value �� ElementName��%�   &	       �� " �.���  � ��$ Bottom=���  �@�PlacementTarget �� $ MenuToggleButton����  �@�	StaysOpen$ False����  � ��$	 150��.���  � RowDefinitions �� $
��auto ��� $��60 ��� $��* �.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��0��   Mode$ 
PrimaryMid=�.��]� .+�`� $��Right=�	 `� 
Background
	 ���� $��5q�.�c� 
������ .@��� -   
���/���$��30��$��50��
 � ToolTip$
 Minimize Window����Z� .��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=��� -    ��Name$ MaximizeButton��$��	20 0 20 0q�
���/���$��30��$��50��$
 Maximize Window����Z� .��  $ WindowMaximize=��� -   
��� E��$��30��$��50��$
 Close Window����Z� .��  $ WindowClose=���  �� Orientation$ 
Horizontal=�.+�d� -    d�Name$ MenuToggleButton�� ' #MaterialDesignHamburgerToggleButton#���  �� -    ��Name$ txtTitle��$��Center=�$��16 0 0 0q�$��20(�$��Medium"�$��	Dashboard��� -    �Name$ 
OptionMenu��#��[ ���� *	IsChecked+$ MenuToggleButton�� �� Mode$ TwoWay=�.���� 
����������#DDD$��1q� �� CornerRadius$ 4��._��� .+��� -   $��Thống kê��  MaterialDesignFlatButton#��[ �� -   $��Đăng xuất��#��[ ]� $��1��$
��auto��.+��  � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -	   $��0��
����ح�$
��auto��$
��auto��$
 
Nhập kho����Z� .���  �� $��* ��� $��* �.+��� $��Center=�$��
Nhập kho��$��0��$��12(�  $ ArrowDownBoldBoxOutline=�$��1��$��Center=��� -
   $��1��
����ح�$
��auto��$
��auto��$
 
Xuất kho����Z� .���  �� $��* ��� $��* �.+��� $��Center=�$��
Xuất kho��$��0��$��12(�  $ ArrowUpBoldBoxOutline=�$��1��$��Center=��� -   $��3��
����ح�$
��auto��$
��auto��$
 	Vật tư����Z� .���  �� $��* ��� $��* �.+��� $��Center=�$��	Vật tư��$��0��$��12(�  $	 Dns=�$��1��$��Center=��� -   $��5��
����ح�$
��auto��$
��auto��$
 Nhà cung cấp����Z� .���  �� $��* ��� $��* �.+��� $��Center=�$��Nhà cung cấp��$��0��$��12(�  $ Factory=�$��1��$��Center=��� -   $��6��
����ح�$
��auto��$
��auto��$
 Khách hàng����Z� .���  �� $��* ��� $��* �.+��� $��Center=�$��Khách hàng��$��0��$��12(�  $ 	HumanMale=�$��1��$��Center=��� -   $��4��
����ح�$
��auto��$
��auto��$
 
Đơn vị����Z� .���  �� $��* ��� $��* �.+��� $��Center=�$��
Đơn vị��$��0��$��12(�  $ 	Altimeter=�$��1��$��Center=��� -   $��2��
����ح�$
��auto��$
��auto��$
 
Danh mục����Z� .���  �� $��* ��� $��* �.+��� $��Center=�$��
Danh mục��$��0��$��12(�  $
 Apps=�$��1��$��Center=��� $��2��$��10q�
�������$ 10�� �� Padding$ 15q����#DDD$��1q�._��� -    ��Name$ ContentArea��