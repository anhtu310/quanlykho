   M S B A M L   `   `   `  ���� D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuanLyKho.HelpersQuanLyKho.Helpers  "    QuanLyKho.Views.SupplierView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:QuanLyKho.Helpers       � 	Resources  '   !QuanLyKho.Helpers.StatusConverter   StatusConverter,   &QuanLyKho.Helpers.StatusColorConverter  StatusColorConverter��%   &	        &	          .���� 
������� �� CornerRadius$ 10�� �� Padding$ 20q����#ddd$��1q�._��  � RowDefinitions �� $
��Auto ��� $��* �.+�� $��0,0,0,10q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0�����#f8f9fa$ 5�����#ddd$��1q�$��40��$	��300��$
��Left=�._��  �� $��* ��� $
��Auto �.+��� -    ��Name$ SearchTextBox��$��0q�
������ $	��8,4q�$��14(�$��Center=��� -   $��1��$
��🔍��
����������#7f8c8d$��14(�$	��8,0q� � Cursor$
 Hand��$��0q� � ToolTip$ Tìm kiếm���� -   $��1��$��➕ Thêm nhà cung cấp��$	��180��$��40�����#27AE60
�������$��14(�$��SemiBold"�$��Right=�$
 Hand��$��0q��� -   $��
lvSupplier��$��Center=�$��1�����#ccc$��1q�
������� �� View �� .P��� $��Tên nhà cung cấp��	 �� Width$
	 auto��
 �� DisplayMemberBinding
 �� *Name+�� $��Địa chỉ��$
	 auto��
 �� *	Address+�� $��Số điện thoại��$
	 auto��
 �� *Phone+�� $��Email��$
	 auto��
 �� *Email+�� $��Ngày liên hệ��$
	 auto��
 �� *ContactDate+�� $��Ghi chú��$
	 auto��
 �� *
MoreInfo+�� $��Action��$
	 auto�� �� CellTemplate �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��✏️ Sửa�����#f39c12
�������$��12(�$��6q�$��0,0,5,0q�$
 Hand��$��0q��� -   $��🗑️ Xóa�����#e74c3c
�������$��12(�$��6q�$
 Hand��$��0q�