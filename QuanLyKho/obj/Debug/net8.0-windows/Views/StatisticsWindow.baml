   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	    	QuanLyKho&    QuanLyKho.Views.StatisticsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5	   	      TextRenderingMode$
 Auto=�5
   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Thống Kê Kho Hàng��5   	   $	��600��5   	   $	��900��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � 	Resources 5       �� 
TargetType  MaterialDesignTextBlock �� BasedOn  MaterialDesignFlatButton��%`   '��       7  '�� "     7  �� 5   
   " ��6   8   6'   �� 5   
   " ��6   8   6$   5      .��5      � $��0q�6   	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5    
   (  "MaterialDesignThemes.Wpf.ColorZone  $��0��6#   
   Mode$
 
PrimaryMid=�60   $��10q�6B   .��5!      ]� .+�5"      `� $��Right=�6    `� 
Background
 ���� $��5q�6N   .�5#      c� 
������ $��0q�67   .@�5%      �� -   5        $��30��5%   2   $��50��6>    � ToolTip$ Minimize Window��6I   ��6!   Z� ��5'      �� 5(   "    �� 
TargetType" ��62   .R�5)   &   ��  ��Name$ border��6-   
������  �� CornerRadius$ 4��5*      $��0q�6.   ._�5+   *   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6B   ���#607D8B$��Center=�5,   6   $��Center=�6S   5-   '    �� Triggers 5.   &   P� 5/   *    P� Property �@J�IsMouseOver P� Value$
 True��6I   . �50   .   ��  �� 
TargetName$ border��65    �� Property � �� �� Value �#E0E0E06_   �� 51   .   $ border��65    � �� �#B0BEC56`   52   +   P� 53   *    � ��$
 True��6G   . �54   .   �� $ border��65    � �� �#B0BEC56_   55   +   57   #   59      �� 5<      -   5         ��Name$ MaximizeButton��5<   !   $��30��6J   $��50��6V   $ Maximize Window��5=      $
��10 0q�6H   ��5<   9   Z� ��5>      �� 5?   "   " ��62   .R�5@   &   �� $ border��6-   
������ $ 4��5A      $��0q�6.   ._�5B   *     $ WindowMaximize=�6B   ���#607D8B$��Center=�5C   6   $��Center=�6S   5D   '    5E   &   P� 5F   *    �@J�IsMouseOver$
 True��6I   . �5G   .   �� $ border��65    � �� �#E0E0E06_   �� 5H   .   $ border��65    � �� �#B0BEC56`   5I   +   P� 5J   *    � ��$
 True��6G   . �5K   .   �� $ border��65    � �� �#B0BEC56_   5L   +   5N   #   5P      �� 5S      -   5        $��30��5S   2   $��50��6>   $ Close Window��6I   ��6!   Z� ��5U      �� 5V   "   " ��62   .R�5W   &   �� $ border��6-   
������ $ 4��5X      $��0q�6.   ._�5Y   *     $ WindowClose=�6B   ���#607D8B$��Center=�5Z   6   $��Center=�6S   5[   '    5\   &   P� 5]   *    �@J�IsMouseOver$
 True��6I   . �5^   .   �� $ border��65    � �� �#FFCDD26_   �� 5_   .   $ border��65    � �� �#EF9A9A6`   5`   +   P� 5a   *    � ��$
 True��6G   . �5b   .   �� $ border��65    � �� �#EF9A9A6_   �� 5c   .   $ border��65    � �� �#E573736`   5d   +   5f   #   5h      5i      5j      �� 5l       �� Orientation$ 
Horizontal=�6   .+�5m        $ ChartBar=�6.   $��24��6>   $��24��6I   $��0,0,10,0q�6U   �� 5n      $��THỐNG KÊ KHO HÀNG��6    $��18(�69   $
��Bold"�6G   5o      5p      5q      �� 5t   
   $��1��6   $��10q�6"   .@�5u      �� $��Tổng quan��6   .��5v      � 	 5w      �� 5x      $
��Auto �6(   �� 5y      $��* �6(   .+�5}      �� -   5         ��Name$ dpStartDate��5}   !   $��0��66   $ 
Horizontal=�6C   $��0,0,0,10q�6\   .+�5~      (  "System.Windows.Controls.DatePicker  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Từ ngày��6%   $	��150��5      $��0,0,10,0q�5�       ( $MaterialDesignFloatingHintDatePicker#��[ 5�         SelectedDate 5�      �� *
FromDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5�        5�      $ Đến ngày��6%   $	��150��5�      $��	20,0,10,0q�5�      #��[ 5�       5�      �� *ToDate+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��Xuất Excel��6!   $��Right=�67   $��50 0 0 0q�6S   $	��100��5�   	     MaterialDesignRaisedButton#��[ 5�   	   ��5�   	   �� *ExportToExcelCommand+5�      &   System.Windows.Controls.DataGrid  5�      $��1��6      AutoGenerateColumns$ False��5�         
IsReadOnly$
 True��5�        MaterialDesignDataGrid#��[ 5�      ��5�      �� *StatisticsData+    Columns  5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn!   Header$! Tên SP��61   "   Width5	  /System.Windows.Controls.DataGridLengthConverter$
" auto	 6a   1
  +System.Windows.Controls.DataGridBoundColumn# 
  Binding# 6A   �� *ProductName+6a     5�      $! 	Tồn kho��61   $
" auto	 6y   # 6B   �� *	Inventory+$ �� StringFormat$$ {0:N0}��6y     5�      $! Nhập��61   $
" auto	 6{   # 6?   �� *ImportQuantity+$$ {0:N0}��6{     5�      $! Xuất��61   $
" auto	 6{   # 6?   �� *ExportQuantity+$$ {0:N0}��6{     5�      $! 	Doanh thu��61   $
" auto	 6y   # 6D   �� *	Revenue+$$ {0:N0}��6y   5�      5�      5�      �� 5�      $��Biểu đồ��6   .��5�      � .+�5�      #   LiveCharts.Wpf.CartesianChart  -   5        %  Name$% StatisticsChart��5�   )   &    LiveCharts.Wpf.Charts.Base.Chart&   Series& 5�      !   LiveCharts.Wpf.ColumnSeries     LiveCharts.Wpf.Series'   Title$' Nhập hàng��6/   (   Fill
( � � �)   Values) 6A   �� *
ImportData+6_     5�      $' Xuất hàng��6/   
( �  ��) 6A   �� *
ExportData+6_     5�      $' 	Doanh thu��6/   
( ��  �) 6A   �� *RevenueData+6`   *   AxisX* 5�         LiveCharts.Wpf.Axis  +   Title$+ Sản phẩm��6'   ,   Labels, 68   �� *ProductLabels+-   AxisY- 5�        $+ Số lượng / Doanh thu��6'   5�      5�      5�      5�      5�      5�      