   M S B A M L   `   `   `  ����   	QuanLyKho!    QuanLyKho.Views.ProductView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .���� 
�������  �� CornerRadius$  10�� �� Padding$ 20q����#ddd$��1q�._��  � RowDefinitions �� $
��auto ��� $��* ��� $��* �.+�� $��0,0,0,10q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0�����#f8f9fa$  5�����#ddd$��1q�$��40��$	��300��$
��Left=�._��  �� $��* ��� $
��Auto �.+��� -    ��Name$ SearchTextBox��$��0q�
������ $	��8,4q�$��14(�$��Center=��� -   $��1��$
��🔍��
����������#7f8c8d$��14(�$	��8,0q� � Cursor$
 Hand��$��0q� � ToolTip$ Tìm kiếm���� -   $��1��$��➕ Thêm sản phẩm��$	��160��$��40�����#27AE60
�������$��14(�$��SemiBold"�$��Right=�$
 Hand��$��0q��� -   $��	lvProduct��$��Center=�$��1�����#ccc$��1q�
�������$��Disabled=� �� View �� .P��� $��Tên sản phẩm�� �� Width$
 auto��	 �� DisplayMemberBinding	 �� *Name+�� $��
Danh mục��$
 auto��	 �� *Category.Name+�� $��Số lượng��$
 auto��	 �� *
Quantity+
 �� StringFormat$
 {0:N0}���� $��Số lượng cảnh báo��$
 auto��	 �� *WarningQuantity+$
 {0:N0}���� $��
Đơn vị��$
 auto��	 �� *IdUnitNavigation.Name+�� $��Action��$
 auto�� �� CellTemplate �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��✏️ Sửa�����#f39c12
�������$��12(�$��6q�$��0,0,5,0q�$
 Hand��$��0q��� -   $��🗑️ Xóa�����#e74c3c
�������$��12(�$��6q�$
 Hand��$��0q��� -   $��lvSuppliers��$��2��$��Center=����#ccc$��1q�
�������$��0,10,0,0q� �� .P��� $��Nhà cung cấp��$
 auto��	 �� *SupplierName+�� $��Địa chỉ��$
 auto��	 �� *SupplierAddress+�� $��Email��$
 auto��	 �� *SupplierEmail+�� $��Số điện thoại��$
 auto��	 �� *SupplierPhone+�� $��Số lượng nhập��$
 auto��	 �� *Count+$
 {0:N0}���� $��Giá nhập��$
 auto��	 �� *
InputPrice+$
 {0:N0}���� $��Ngày nhập��$
 auto��	 �� *	DateInput+