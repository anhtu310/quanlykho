   M S B A M L   `   `   `  ����   	QuanLyKho    QuanLyKho.Views.InputView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .���� 
�������  �� CornerRadius$  10�� �� Padding$ 20q����#ddd$��1q�._��  � RowDefinitions �� $
��Auto ��� $��* ��� $��* �.+�� $��0,0,0,10q� � ColumnDefinitions �� $��* ��� $��* ��� $
��Auto �.+��  �� $��* ��� $��* ��� $��* �.+�(  "System.Windows.Controls.DatePicker  -     Name$ dpStartDate��$��0��$��20 0 0 0q�$
��auto��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ngày bắt đầu�� (  $MaterialDesignFloatingHintDatePicker#��[    -   $ 	dpEndDate��$��1��$��20 0 0 0q�$
��auto��$ Ngày kết thúc��#��[  �� -   $��2��$��20 0 0 0q�  MaterialDesignRaisedButton#��[ $
��auto�� � ToolTip$/ )Resource name: MaterialDesignRaisedButton��.��Lọc�� -   $��1��$��➕ Thêm phiếu nhập��$	��180��$��40�����#27AE60
�������$��14(�$��SemiBold"�$��Right=� � Cursor$
 Hand��$��0q��� -   $��lvInput��$��1��$��Center=� �� View �� .P��� $��Ngày nhập��	 �� Width$		 150��
 �� DisplayMemberBinding
 �� *	DateInput+ �� StringFormat$ {0:dd/MM/yyyy}���� $��Action��$		 250�� �� CellTemplate �� .R���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� -   $��➕ Thêm chi tiết��$	��120��$��30�����#2980B9
�������$��14(�$��SemiBold"�$
 Hand��$��0q�$��0,0,10,0q��� -   $��❌ Xóa��$��80��$��30��
���  ��
�������$��14(�$��SemiBold"�$
 Hand��$��0q��� -   $��lvInputInfo��$��Center=�$��Center=�$��2�����#ccc$��1q�
�������$��0q� �� .P��� $��Hợp đồng��$		 130�� �� .R��� $ Vertical=�$��Center=�$��Center=�.+��� $
��auto��$	��100������ *ImageSource+�� -	   $��Xem hợp đồng��$
��auto��$��30�����#2980B9
�������$��12(�$��SemiBold"�$
 Hand��$��0q�$��10,5,0,0q��� $��Sản phẩm��$
	 auto��
 �� *ProductName+�� $��Nhà cung cấp��$
	 auto��
 �� *
Supplier+�� $��Số lượng��$
	 auto��
 �� *Count+$ {0:N0}���� $��Giá nhập��$
	 auto��
 �� *
InputPrice+$ {0:N0}���� $��Giá xuất dự kiến��$
	 auto��
 �� *OutputPrice+$ {0:N0}���� $��Trạng thái��$
	 auto��
 �� *Status+�� $��Action��$		 150�� �� .R��� $ 
Horizontal=�$��Center=�.+��� -
   $��✏️ Sửa�����#f39c12
�������$��12(�$��6q�$��0,0,5,0q�$
 Hand��$��0q��� -   $��🗑️ Xóa�����#e74c3c
�������$��12(�$��6q�$
 Hand��$��0q�� -   $��
ImagePopup�� � 	StaysOpen$ False��$��Center=� � AllowsTransparency$
 True��$
��Fade=� � PlacementTarget ��  �� ElementName$ ZoomedImage��.���� 
����������#ddd$��1q�$ 10q�$  5��._�� .+��� -   $��ZoomedImage��$��Uniform=�$	��800��$	��700���� -   $	��✕��$��Right=�$	��Top=�$��5q�$��30��$��30��
������ $��0q�$
��Bold"�
���  ��