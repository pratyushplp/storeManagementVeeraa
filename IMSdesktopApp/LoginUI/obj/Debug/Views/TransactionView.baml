   M S B A M L   `   `   `  ����B  >LoginUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LoginUI.ViewsLoginUI.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   #    LoginUI.Views.TransactionView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:LoginUI.Views     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -   5        $	��700��5
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
Horizontal=�6!   .+�5#      �� $��	Bill Date��6$   $��0,0,20,0q�65   $��Center=�6G   $��DemiBold"�6b   6z   (  "System.Windows.Controls.DatePicker  5$      -   5        $��
datePicker��5$   %   
 �� Now	   SelectedDate#	 Z 67   
   SelectedDateFormat$
 Short=�6b   5%      5&      �� 5'      .��5(      �� $��Product Details��6    $
��Bold"�68   $��16(�6J   $��0,10,0,0q�6X   6l   5)      �� 5*      $��0,10,0,0q�6   .��5+      �� $ 
Horizontal=�6!   .+�5,      �� $��Product Code��6$   $��0,0,20,0q�68   $��Center=�6J   $��DemiBold"�6e   6}   �� 5-      -   5        $��txtProductCode��5-   $   $��0,0,20,0q�6<   $��30��6N   $��80��6Z   $��Center=�6e   
�������
���   � �� TextAlignment$ Center=�6�   �� 5.      $��Inventory Qty��6$   $��0,0,20,0q�69   $��Center=�6K   $��DemiBold"�6f   6~   �� 5/      -   5        $��txtInventoryQty��5/   $   $��0,0,20,0q�6=   $��30��6O   $��80��6[   $��Center=�6f   
�������$ Center=�6�    �� 
IsReadOnly . $��0��6�   �� 50      $��Product Type��6$   $��0,0,20,0q�68   $��Center=�6J   $��DemiBold"�6e   6}   �� 51      -   5        $��txtProductType��51   $   $��0,0,20,0q�6<   $��30��6N   $��80��6Z   $��Center=�6e   
������� . $ Center=�6�   �� 52      $��Price��6$   $��0,0,20,0q�62   $��Center=�6D   $��DemiBold"�6_   6x   �� 53      -   5        $��txtPrice��53   #   $��0,0,20,0q�66   $��30��6H   $��80��6T   $��Center=�6_   
������� . $ Center=�6�   $��0��6�   �� 54      $��Quantity��6$   $��0,0,20,0q�64   $��Center=�6F   $��DemiBold"�6a   6y   �� 55      -   5        $��txtQty��55   #   $��0,0,20,0q�63   $��30��6p   $��80��6|   $��Center=�6�   
�������$ Center=�6�   $��0��6�   �� 57      -   5        +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��57   !   
��� ���$	��ADD��6b   $��5,0,0,0q�6r   6�   59      5:      5;      5<      � 5?   
   .+�5@      �� $��Bottom=�6   $��Right=�64   $	��470��6P   $	��400��6]   $��0,0,49.6,29.6q�6i   .+�5A      �� .@�5B      �� .��5C      �� $ 
Horizontal=�6%   $��0,25,0,0q�6>   .+�5D      �� $��Bill no��6(   $��Center=�6:   $��Center=�6U   $
��Bold"�6r   $��14(�6�   �� 5E      -	   5        $��	txtBillNo��5E   (   $��20,0,0,0q�6:   $��25��6L   $��50��6X   $��Center=�6c   $ Center=�6    . 
�������
��� � �$
��Bold"�6�   �� 5F      -
   5        $��	checkBill��5F   '   $��10,0,0,0q�6t   5G      5H      �� 5I      .��5J      �� $��Calculation Details��6$   $
��Bold"�6@   $��14(�6R   $��Center=�6`   $��Center=�6{   5K      �� 5L      .��5M      �� $ 
Horizontal=�6%   .+�5P      �� $��	Sub Total��6(   $��Center=�6<   $��Center=�6W   $��90��6t   $��DemiBold"�6    �� TextAlignment$ Center=�6�   �� 5Q      -   5        $��txtSubTotal��5Q   (   $��20,0,0,0q�6b   $��25��6t   $	��200��6�   $��Center=�6�   
�������$��0��6�   $ Center=�6�    . 6�   5R      5S      �� 5U      .��5V      �� $ 
Horizontal=�6%   .+�5W      �� $��Discount��6(   $��Center=�6;   $��Center=�6V   $��90��6s   $��DemiBold"�6~   $ Center=�6�   �� 5X      -   5        $��txtDiscount��5X   '   $��20,0,0,0q�6k   $��25��6}   $	��200��6�   $��Center=�6�   
�������$ Center=�6�   �� 5Y      -   5        $��10,0,0,0q�5Y   t   6�   �� 5Z      $	��(%)��6(   $
��Bold"�63   $��14(�6E   $��2,0,0,0q�6S   6f   5[      5\      �� 5^      .��5_      �� $ 
Horizontal=�6%   .+�5`      �� $��VAT(%)��6(   $��Center=�69   $��Center=�6T   $��90��6q   $��DemiBold"�6|   $ Center=�6�   �� 5a      -   5        $��txtVAT��5a   '   $��20,0,0,0q�6a   $��25��6s   $	��200��6   $��Center=�6�   
�������$ Center=�6�   5b      5c      �� 5e      .��5f      �� $ 
Horizontal=�6%   .+�5g      �� $��Total Amount��6(   $��Center=�6?   $��Center=�6Z   $��90��6w   $��DemiBold"�6�   $ Center=�6�   �� 5h      -   5        $��txtTotalAmount��5h   &   $��20,0,0,0q�6?   $��25��6Q   $	��200��6]   $��Center=�6i   
������� . $
��Bold"�6�   $ Center=�6�   5i      5j      �� 5l      .��5m      �� $ 
Horizontal=�6%   .+�5n      �� $��Paid Amount��6(   $��Center=�6>   $��Center=�6Y   $��90��6v   $��DemiBold"�6�   $ Center=�6�   �� 5o      -   5        $��txtPaidAmount��5o   &   $��20,0,0,0q�6o   $��25��6�   $	��200��6�   $��Center=�6�   
�������$
��Bold"�6�   $ Center=�6  5p      5q      �� 5t      .��5u      �� $ 
Horizontal=�6%   .+�5v      �� $��Return Amount��6(   $��Center=�6@   $��Center=�6[   $��90��6x   $��DemiBold"�6�   $ Center=�6�   �� 5w      -   5        $��txtReturnAmount��5w   '   $��20,0,0,0q�6@   $��25��6R   $	��200��6^   $��Center=�6j   $
��Bold"�6�   
���  ��
������� . $ Center=�6�   5x      5y      �� 5{      .��5|      �� $��Payment Method��6$   $
��Bold"�6:   5}      �� 5~      .��5      �� $ 
Horizontal=�6%   .+�5�      	� -   5        $��CashPayment��5�   *   $
��Cash��6W    d� 	IsChecked$
 TrueY�6f   $��
10,0,10,10q�6x   	� 5�      -   5        $��CreditPayment��5�   *   $��Credit��6[   $��
10,0,10,10q�6n   	� 5�      -   5        $��	CCPayment��5�   *   $��Credit Card��6S   $��
10,0,20,10q�6i   �� 5�      -   5        $��cmbBank��5�   '   $y�Hidden=�6b    �� 
IsEditable .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   $��90��6�   -  'MaterialDesignThemes.Wpf.ComboBoxAssist   ClassicMode$
 true��6�   .@�5�   "   �� $��Siddhartha Bank��6/   $
��Bold"�6I   6]   �� 5�   "   $��Kumari Bank��6/   $
��Bold"�6E   6Y   5�      5�      5�      5�      �� 5�      -   5        $��btnSave��5�      $ 8��6(   $��
50,0,50,20q�6U   $	��100��6i   $
��SAVE��6u   6�   5�      5�      &   System.Windows.Controls.DataGrid  5�   
   -   5        $��dgTransaction��5�      $
��Left=�6)   $��Bottom=�6D   $	��400��6_   $	��500��6l   $��	45,0,0,60q�6x      
IsReadOnly . 5�      5�      5�      