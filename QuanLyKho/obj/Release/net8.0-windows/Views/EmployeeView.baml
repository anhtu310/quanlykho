   M S B A M L   `   `   `  ���� D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuanLyKho.HelpersQuanLyKho.Helpers  1clr-namespace:QuanLyKho.ViewsQuanLyKho.Views  "    QuanLyKho.Views.EmployeeView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:QuanLyKho.Helpers     /viewsclr-namespace:QuanLyKho.Views       � 	Resources  '   !QuanLyKho.Helpers.StatusConverter   StatusConverter,   &QuanLyKho.Helpers.StatusColorConverter  StatusColorConverter��%   &	        &	          .���� 
������� �� CornerRadius$ 10�� �� Padding$ 20q����#ddd$��1q�._��  � RowDefinitions �� $
��Auto ��� $��* �.+�� $��0,0,0,10q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0�����#f8f9fa$ 5�����#ddd$��1q�$��40��$	��300��$
��Left=�._��  �� $��* ��� $
��Auto �.+��� -    ��Name$ SearchTextBox��$��0q�
������ $	��8,4q�$��14(�$��Center=��� -   $��1��$
��🔍��
����������#7f8c8d$��14(�$	��8,0q� � Cursor$
 Hand��$��0q� � ToolTip$ Tìm kiếm���� -   $��1��$��➕ Thêm nhân viên��$	��160��$��40�����#27AE60
�������$��14(�$��SemiBold"�$��Right=�$
 Hand��$��0q��� -   $��
lvEmployee��$��1�����#ccc$��1q�
�������$��0q�$��Disabled=�   �� 
TargetType	 �� Property
 �� Value��%�   '��       �� " ��.��� 	 � ��$
 SemiBold"��� 	 � ��$
 14(��� 	 � ��
 �#ecf0f1�� 	 � ��$
 8q��� 	 � ��
 �#ccc�� 	 � ��$
 0,0,0,1q� �� View �� .P��� $��ID�� �� Width$ 50�� �� DisplayMemberBinding �� *Id+�� $��Tên nhân viên��$	 150�� �� *Name+�� $��Địa chỉ��$	 150�� �� *	Address+�� $��Số điện thoại��$	 110�� �� *Phone+�� $��Email��$	 160�� �� *Email+�� $��Trạng thái��$ 90�� �� CellTemplate �� .R��� $��SemiBold"����� *Status+ �� 	Converter# [  ���� *Status+# [ �� $��Action��$	 250�� �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��🔄 Đổi trạng thái�����#3498DB
�������$��12(�$��6q�$��0,0,5,0q�$
 Hand��$��0q��� -   $��✏️ Sửa�����#f39c12
�������$��12(�$��6q�$��0,0,5,0q�$
 Hand��$��0q��� -   $��🗑️ Xóa�����#e74c3c
�������$��12(�$��6q�$
 Hand��$��0q�