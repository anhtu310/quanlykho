   M S B A M L   `   `   `  ���� D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:QuanLyKho.ViewsQuanLyKho.Views  "    QuanLyKho.Views.CategoryView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:QuanLyKho.Views     .���� 
�������  �� CornerRadius$  10�� �� Padding$ 20q����#ddd$��1q�._��  � RowDefinitions �� $
��Auto ��� $��* �.+�� $��0,0,0,10q�.+��� -   $��0��$��➕ Thêm danh mục��$	��160��$��40�����#27AE60
�������$��14(�$��SemiBold"�$��Right=� � Cursor$
 Hand��$��0q�� $��1��.+��� -   $��
lvCategory��$��Center=�$��Center=�$��0�����#ccc$��1q�
�������$��0q� �� View �� .P��� $��Tên danh mục�� �� Width$
 auto�� �� DisplayMemberBinding �� *Name+�� $��Action��$
 auto�� �� CellTemplate �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��✏️ Sửa�����#f39c12
�������$��12(�$��6q�$��0,0,5,0q�$
 Hand��$��0q��� -   $��🗑️ Xóa�����#e74c3c
�������$��12(�$��6q�$
 Hand��$��0q�