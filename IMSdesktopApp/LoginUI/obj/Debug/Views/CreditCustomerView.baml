   M S B A M L   `   `   `  ����B  >LoginUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LoginUI.ViewsLoginUI.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   &     LoginUI.Views.CreditCustomerView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:LoginUI.Views     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -   5        $	��700��5
      $
��1080��6'     � WindowStyle$  
ToolWindow=�64    � WindowStartupLocation$ CenterScreen=�6N    � 
ResizeMode$ NoResize=�6s   .��5      � 
�������.+�5   
   � $	��Top=�6   $��Center=�6'   $	��170��6D   $
��1000��6Q   .+�5      �� ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ���� 67   �� 5       � �� 5      �� 5   "    �� 
TargetType" ��62   .R�5   &   �� 5   #   5      5      .@�5!      �� $��50��6   $��right=�6+   $	��Top=�6G   $��0,10,0,0q�6_   .��5"      ��  �� Orientation$ 
Horizontal=�6!   .+�5#      (  "System.Windows.Controls.DatePicker  -   5        $��
datePicker��5#   %   
 �� Now	   SelectedDate#	 Z 67   
   SelectedDateFormat$
 Short=�6b   5$      5%      �� 5&      .��5'      �� $��Credit Customers��6    $
��Bold"�69   $��16(�6K   $��0,10,0,0q�6Y   6m   5(      �� 5)      $��0,10,0,0q�6   .��5*      �� $ 
Horizontal=�6!   .+�5+      �� $��Customer Name/Id��6$   $��0,0,20,0q�6<   $��Center=�6N   $
��Bold"�6i   6~   �� 5,      -   5        $��	txtSearch��5,   $   $��0,0,20,0q�67   $��30��6I   $	��150��6U   $��Center=�6a   
�������
���   � �� TextAlignment$ Center=�6�   �� 5.      -   5        +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5.   !   
��� ���$��5,0,0,0q�6e   .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�66   $��30��6D   $��26��6P   $��Center=�6[   $��Center=�6v   50      53      54      55      56      � 59   
   .+�5:      �� $��Bottom=�6   $��Right=�64   $	��470��6P   $	��400��6]   $��	0,0,50,30q�6i   .+�5;      �� .@�5<      �� .��5=      �� $��Customer Details��6$   $
��Bold"�6=   $��14(�6O   $��Center=�6]   $��Center=�6x   5>      �� 5?      .��5@      �� $ 
Horizontal=�6%   .+�5C      �� $��Customer Name��6(   $��Center=�6@   $��Center=�6[   $	��150��6x   $��DemiBold"�6�    �� TextAlignment$
 Left=�6�   �� 5D      -   5        $��txtCustomerName��5D   (   $��20,0,0,0q�6A   $��25��6S   $	��100��6_   $��Center=�6k   
�������$ Center=�6�    �� 
IsReadOnly . 6�   5E      5F      �� 5H      .��5I      �� $ 
Horizontal=�6%   .+�5L      �� $��Customer Id��6(   $��Center=�6>   $��Center=�6Y   $	��150��6v   $��DemiBold"�6�   $
 left=�6�   �� 5M      -   5        $��txtCustomerId��5M   (   $��20,0,0,0q�6?   $��25��6Q   $	��100��6]   $��Center=�6i   
�������$ Center=�6�    . 6�   5N      5O      �� 5Q      .��5R      �� $ 
Horizontal=�6%   .+�5S      �� $��Increase/Decrease Credit��6(   $��Center=�6K   $��Center=�6f   $	��150��6�   $��DemiBold"�6�   $
 Left=�6�   �� 5T      -   5        $��txtIncDescCredit��5T   '   $��20,0,0,0q�6k   $��25��6}   $	��100��6�   $��Center=�6�   
�������$ Center=�6�   
���  ��6�   5U      5V      �� 5X      .��5Y      �� $ 
Horizontal=�6%   .+�5Z      �� $��Updated Credit Amount��6(   $��Center=�6H   $��Center=�6c   $	��150��6�   $��DemiBold"�6�   $
 Left=�6�   �� 5[      -   5        $��txtCreditAmount��5[   '   $��20,0,0,0q�6@   $��25��6R   $	��100��6^   $��Center=�6j   
������� . $ Center=�6�   
���"�"�6�   5\      5]      5`      �� 5b      -	   5        $��	btnUpdate��5b      $ 8��6*   $��50,50,50,20q�6W   $��80��6l   $��Update��6w   $��10(�6�   
��� d �6�   �� 5c      2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6]   $��10,110,10,0q�6   
���  ��$��50��6]   ��
    "Note: Positive balance means the customer owes the shop money,
                negetive balance means the shop owes the customer money.
                    
                5g      5h      5j      &   System.Windows.Controls.DataGrid  5l   
   -
   5        $��dgvCreditCustomer��5l      $
��Left=�6-   $��Bottom=�6H   $	��400��6c   $	��500��6p   $��	45,0,0,60q�6|      
IsReadOnly . ��5m      �� 5p      )  #System.Windows.Controls.DataGridRow"  6   .�5q      -   5        5r      5t      5x      5z      