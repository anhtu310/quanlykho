   M S B A M L   `   `   `  ����  	QuanLyKho    QuanLyKho.Views.InputView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �� 
�������  �� CornerRadius$  10��6     �� Padding$ 20q�62   ���#ddd$��1q�6R   ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      � $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �  5      �� 5      $��* �6+   �� 5      $��* �6+   �� 5      $��* �6+   .+�5!      (  "System.Windows.Controls.DatePicker  -   5          Name$ dpStartDate��5"      $��0��5!   !   $��20 0 0 0q�61   $
��auto��5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ngày bắt đầu��5$       (  $MaterialDesignFloatingHintDatePicker#��[  5%        5'      -   5        $ 	dpEndDate��5(      $��1��5'   !   $��20 0 0 0q�61   $
��auto��5)      $ Ngày kết thúc��5*      #��[  5+      �� 5-      -   5        $��2��5-      $��20 0 0 0q�6-     MaterialDesignRaisedButton#��[ 5.   	   $
��auto��5/   	    � ToolTip$/ )Resource name: MaterialDesignRaisedButton��51   	   .��6=   Lọc53      54      �� 56      -   5        $��1��56      $��➕ Thêm phiếu nhập��6)   $	��180��6E   $��40��6Q   ���#27AE60
�������$��14(�57      $��SemiBold"�6'   $��Right=�6=    � Cursor$
 Hand��58      $��0q�6'   6;   59      �� 5<      -   5        $��lvInput��5<   $   $��1��6   $��Center=�6_    �� View 5=      �� 5>      .P�5?      �� $��Ngày nhập��6)   	 �� Width$		 150��6�   
 �� DisplayMemberBinding
 6<   �� *	DateInput+ �� StringFormat$ {0:dd/MM/yyyy}��6�   �� 5A      $��Action��6)   $		 250��69    �� CellTemplate 5B      �� 5C   "   .R�5D   &   ��  �� Orientation$ 
Horizontal=�61   $��Center=�6J   $��Center=�6g   .+�5E   *   �� -   5        $��➕ Thêm chi tiết��5E   1   $	��120��6K   $��30��6Z   ���#2980B9
�������$��14(�5F   1   $��SemiBold"�6?   $
 Hand��6U   $��0q�6c   $��0,0,10,0q�6w   6�   �� 5G   *   -   5        $��❌ Xóa��5G   1   $��80��6A   $��30��6O   
���  ��
�������$��14(�5H   1   $��SemiBold"�6?   $
 Hand��6U   $��0q�6c   5I   1   5J   '   5K   #   5M      5N      5P      �� 5S      -   5        $��lvInputInfo��5S   e   $��Center=�6   $��Center=�64   $��2��6X   ���#ccc$��1q�6�   
�������$��0q�6�    5T      �� 5U      .P�5V      �� $��Hợp đồng��6)   $		 130��6;    5W      �� 5X   "   .R�5Y   &   �� $ Vertical=�61   $��Center=�6H   $��Center=�6e   .+�5Z   *   �� $
��auto��6O   $	��100��6\   ��60   �� *ImageSource+6\   �� 5[   *   -	   5        $��Xem hợp đồng��5[   1   $
��auto��6H   $��30��6U   ���#2980B9
�������$��12(�6�   $��SemiBold"�5\   1   $
 Hand��6G   $��0q�6U   $��10,5,0,0q�6i   6{   5]   '   5^   #   5`      �� 5b      $��Sản phẩm��6)   $
	 auto��6h   
 6;   �� *ProductName+6h   �� 5c      $��Nhà cung cấp��6)   $
	 auto��6i   
 6?   �� *
Supplier+6i   �� 5d      $��Số lượng��6)   $
	 auto��6{   
 6;   �� *Count+$ {0:N0}��6{   �� 5e      $��Giá nhập��6)   $
	 auto��6�   
 6;   �� *
InputPrice+$ {0:N0}��6�   �� 5f      $��Giá xuất��6)   $
	 auto��6�   
 6;   �� *OutputPrice+$ {0:N0}��6�   �� 5g      $��Trạng thái��6)   $
	 auto��6e   
 6=   �� *Status+6e   �� 5i      $��Hành động��6)   $		 150��6<    5j      �� 5k   "   .R�5l   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5m   *   �� -
   5        $��✏️ Sửa��5m   1   ���#f39c12
�������$��12(�6j   $��6q�6x   $��0,0,5,0q�6�   $
 Hand��6�   $��0q�6�   6�   �� 5n   *   -   5        $��🗑️ Xóa��5n   1   ���#e74c3c
�������$��12(�6k   $��6q�6y   $
 Hand��6�   $��0q�6�   6�   5o   '   5p   #   5r      5s      5u      � 5y      -   5        $��
ImagePopup��5y       � 	StaysOpen$ False��5z      $��Center=�5{       � AllowsTransparency$
 True��5}      $
��Fade=�5~       � PlacementTarget 5|      ��  �� ElementName$ ZoomedImage��.��5      �� 
����������#ddd$��1q�5�      $ 10q�5�      $  5��5�      ._�5�      � .+�5�      �� -   5        $��ZoomedImage��5�       $��Uniform=�5�      $	��800��5�      $	��700��5�      �� 5�      -   5        $	��✕��5�   !   $��Right=�5�      $	��Top=�5�      $��5q�5�      $��30��5�      $��30��5�      
������ $��0q�5�      $
��Bold"�5�      
���  ��5�      5�      5�      5�      5�      5�      5�      