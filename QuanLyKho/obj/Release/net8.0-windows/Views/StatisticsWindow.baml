   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf   	QuanLyKho&    QuanLyKho.Views.StatisticsWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � Title$ Thống Kê Kho Hàng��$	��600��$	��900�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency$
 True�� � 	Resources  �� 
TargetType  MaterialDesignTextBlock �� BasedOn  MaterialDesignFlatButton��%:   '��       7  '��      7  �� " ��8   �� " ��8   .��� $��0q�	 � RowDefinitions	 �� $
��Auto ��� $��* �.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��0��
   Mode$
 
PrimaryMid=�$��10q�.��]� .+�`� $��Right=� `� 
Background
 ���� $��5q�.�c� 
������ $��0q�.@��� -   $��30��$��50�� � ToolTip$ Minimize Window����Z� ����  �� 
TargetType" ��.R���  ��Name$ border��
������  �� CornerRadius$ 4��$��0q�._�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=����#607D8B$��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� 
TargetName$ border�� �� Property � �� �� Value �#E0E0E0�� $ border�� � �� �#B0BEC5P�  � ��$
 True��. ��� $ border�� � �� �#B0BEC5�� -    ��Name$ MaximizeButton��$��30��$��50��$ Maximize Window��$
��10 0q���Z� ���� " ��.R��� $ border��
������ $ 4��$��0q�._�  $ WindowMaximize=����#607D8B$��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �#E0E0E0�� $ border�� � �� �#B0BEC5P�  � ��$
 True��. ��� $ border�� � �� �#B0BEC5�� -   $��30��$��50��$ Close Window����Z� ���� " ��.R��� $ border��
������ $ 4��$��0q�._�  $ WindowClose=����#607D8B$��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �#FFCDD2�� $ border�� � �� �#EF9A9AP�  � ��$
 True��. ��� $ border�� � �� �#EF9A9A�� $ border�� � �� �#E57373��  �� Orientation$ 
Horizontal=�.+�  $ ChartBar=�$��24��$��24��$��0,0,10,0q��� $��THỐNG KÊ KHO HÀNG��$��18(�$
��Bold"��� $��1��$��10q�.@��� $��Tổng quan��.��� 	 �� $
��Auto ��� $��* �.+��� -    ��Name$ dpStartDate��$��0��$ 
Horizontal=�$��0,0,0,10q�.+�(  "System.Windows.Controls.DatePicker  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Từ ngày��$	��150��$��0,0,10,0q� ( $MaterialDesignFloatingHintDatePicker#��[    SelectedDate �� *
FromDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  $ Đến ngày��$	��150��$��	20,0,10,0q�#��[  �� *ToDate+$ TwoWay=�$ PropertyChanged=��� $��Xuất Excel��$��Right=�$��50 0 0 0q�$	��100��  MaterialDesignRaisedButton#��[ ���� *ExportToExcelCommand+&   System.Windows.Controls.DataGrid  $��1��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��  MaterialDesignDataGrid#��[ ���� *StatisticsData+    Columns  0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn!   Header$! Tên SP��"   Width5	  /System.Windows.Controls.DataGridLengthConverter$
" auto	 1
  +System.Windows.Controls.DataGridBoundColumn# 
  Binding# �� *ProductName+  $! 	Tồn kho��$
" auto	 # �� *	Inventory+$ �� StringFormat$$ {0:N0}��  $! Nhập��$
" auto	 # �� *ImportQuantity+$$ {0:N0}��  $! Xuất��$
" auto	 # �� *ExportQuantity+$$ {0:N0}��  $! 	Doanh thu��$
" auto	 # �� *	Revenue+$$ {0:N0}���� $��Biểu đồ��.��� .+�#   LiveCharts.Wpf.CartesianChart  -   %  Name$% StatisticsChart��&    LiveCharts.Wpf.Charts.Base.Chart&   Series& !   LiveCharts.Wpf.ColumnSeries     LiveCharts.Wpf.Series'   Title$' Nhập hàng��(   Fill
( � � �)   Values) �� *
ImportData+  $' Xuất hàng��
( �  ��) �� *
ExportData+  $' 	Doanh thu��
( ��  �) �� *RevenueData+*   AxisX*    LiveCharts.Wpf.Axis  +   Title$+ Sản phẩm��,   Labels, �� *ProductLabels+-   AxisY-   $+ Số lượng / Doanh thu��