   M S B A M L   `   `   `  ���� D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  A%clr-namespace:QuanLyKho.UserControlATQuanLyKho.UserControlAT  W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Media;assembly=PresentationCoreSystem.Windows.Media     QuanLyKho.MainWindow   \ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:QuanLyKho     4uc%clr-namespace:QuanLyKho.UserControlAT     Nmedia<clr-namespace:System.Windows.Media;assembly=PresentationCore       � WindowStyle$
  None=� � Title$ 
MainWindow��$
��auto��$
��1300��.��� .+�.   (QuanLyKho.UserControlAT.UserControlBarUC  �� -    ��Name$ 
btnWarning��$	��⚠��$
��Bold"�$��40(�$	��100��$��60��$y�	Collapsed=� � ToolTip$( "Có sản phẩm sắp hết hàng��$��Center=�$	��Top=�$��	0,0,20,60q�$��0q�
������  � Cursor$
 Hand�� K� ZIndex$	 999��z�T�  T� Y$	 -30Q�����  �� 
TargetType" ��.���  �� Property � ��	 �� Value
	 �  ��
 �� Triggers
 P�  P� Property �@J�	IsVisible P� Value$
 True�� N� EnterActions �� .����  g� RepeatBehavior$ Forever��.����  �� TargetProperty$* $(Foreground).(SolidColorBrush.Color)�.g���  �� KeyTime$ 0:0:0�� �� Value Red�� $ 0:0:0.5�� DarkRed�� $ 0:0:1�� RedU� $. ((RenderTransform).(TranslateTransform.Y)�.\���  O� KeyTime$ 0:0:0�� O� Value -30�� $ 0:0:0.5�� -35�� $ 0:0:1�� -30