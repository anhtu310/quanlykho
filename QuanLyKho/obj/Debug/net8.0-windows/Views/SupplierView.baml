   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuanLyKho.HelpersQuanLyKho.Helpers  5      "    QuanLyKho.Views.SupplierView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      1localclr-namespace:QuanLyKho.Helpers     5        � 	Resources  5
      '   !QuanLyKho.Helpers.StatusConverter   StatusConverter,   &QuanLyKho.Helpers.StatusColorConverter  StatusColorConverter��%:   &	        &	        5   
   6      5   
   6%   5      .��5      �� 
������� �� CornerRadius$ 10��6     �� Padding$ 20q�62   ���#ddd$��1q�6R   ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      � $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0��6   ���#f8f9fa$ 5��6>   ���#ddd$��1q�6b   $��40��6v   $	��300��6�   $
��Left=�6�   ._�5      �  5      �� 5       $��* �6/   �� 5!      $
��Auto �6/   .+�5$      �� -   5         ��Name$ SearchTextBox��5$   "   $��0q�69   
������ $	��8,4q�6f   $��14(�6t   $��Center=�6�   6�   �� 5%      -   5        $��1��5%   !   $
��🔍��61   
����������#7f8c8d$��14(�6j   $	��8,0q�6x    � Cursor$
 Hand��6�   $��0q�6�    � ToolTip$ Tìm kiếm��6�   6�   5&      5'      �� 5)      -   5        $��1��5)      $��➕ Thêm nhà cung cấp��6)   $	��180��6G   $��40��6S   ���#27AE60
�������$��14(�5*      $��SemiBold"�6'   $��Right=�6=   $
 Hand��5+      $��0q�6'   6;   5,      �� 5/      -   5        $��
lvSupplier��5/   H   $��Center=�6   $��1��6;   ���#ccc$��1q�6m   
������� �� View 50      �� 51      .P�52      �� $��Tên nhà cung cấp��6)   	 �� Width$
	 auto��6i   
 �� DisplayMemberBinding
 6C   �� *Name+6i   �� 53      $��Địa chỉ��6)   $
	 auto��6c   
 6:   �� *	Address+6c   �� 54      $��Số điện thoại��6)   $
	 auto��6g   
 6@   �� *Phone+6g   �� 55      $��Email��6)   $
	 auto��6_   
 68   �� *Email+6_   �� 56      $��Ngày liên hệ��6)   $
	 auto��6l   
 6?   �� *ContactDate+6l   �� 57      $��Ghi chú��6)   $
	 auto��6d   
 6:   �� *
MoreInfo+6d   �� 59      $��Hành động��6)   $
	 auto��6<    �� CellTemplate 5:      �� 5;   "   .R�5<   &   ��  �� Orientation$ 
Horizontal=�61   $��Center=�6J   .+�5=   *   �� -   5        $��✏️ Sửa��5=   1   ���#f39c12
�������$��12(�6j   $��6q�6x   $��0,0,5,0q�5>      $
 Hand��6*   $��0q�68   6L   �� 5@   *   -   5        $��🗑️ Xóa��5@   1   ���#e74c3c
�������$��12(�6k   $��6q�6y   $
 Hand��5A      $��0q�6'   6;   5B   '   5C   #   5E      5F      5H      5I      5J      5K      