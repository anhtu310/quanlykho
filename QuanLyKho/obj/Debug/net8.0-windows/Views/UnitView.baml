   M S B A M L   `   `   `  ����  	QuanLyKho    QuanLyKho.Views.UnitView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5	      �� 
�������  �� CornerRadius$  10��6     �� Padding$ 20q�62   ���#ddd$��1q�6R   ._�5
   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      � $��0,0,0,10q�6   .+�5      �� -   5        $��0��5      $��➕ Thêm đơn vị��6)   $	��160��6A   $��40��6M   ���#27AE60
�������$��14(�5      $��SemiBold"�6'   $��Right=�6=    � Cursor$
 Hand��5      $��0q�6'   6;   5      � 5      $��1��6   .+�5      �� -   5        $��lvUnit��5   l   $��Center=�6   $��Center=�68   $��0��6\   ���#ccc$��1q�6�   
�������$��0q�6�    �� View 5      �� 5      .P�5      �� $��Tên đơn vị��6-    �� Width$
 auto��6g    �� DisplayMemberBinding 6A   �� *Name+6g   �� 5      $��Hành động��6-   $	 200��6@    �� CellTemplate 5    "   �� 5!   &   .R�5"   *   ��  �� Orientation$ 
Horizontal=�65   $��Center=�6N   .+�5#   .   �� -   5        $��✏️ Sửa��5#   5   ���#f39c12
�������$��12(�6n   $��6q�6|   $��0,0,5,0q�6�   $
 Hand��6�   $��0q�6�   6�   �� 5$   .   -   5        $��🗑️ Xóa��5$   5   ���#e74c3c
�������$��12(�6o   $��6q�6}   $
 Hand��6�   $��0q�6�   6�   5%   +   5&   '   5(      5)      5+      5,      5-      5.      5/      