   M S B A M L   `   `   `  ����B  >LoginUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LoginUI.ViewsLoginUI.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   ,    &LoginUI.Views.UpdateCreditCustomerView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:LoginUI.Views     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -   5        $	��700��5
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
��� ���$��5,0,0,0q�6e   .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�66   $��30��6D   $��26��6P   $��Center=�6[   $��Center=�6v   50      �� 51      -   5        $ 8��51   !   
���W�.�$��20,0,0,0q�6g   .��52        $ FileDocumentBox=�66   $��30��6M   $��26��6Y   $��Center=�6d   $��Center=�6   53      56      57      58      59      � 5<   
   .+�5=      �� $��Bottom=�6   $��Right=�64   $	��470��6P   $	��400��6]   $��	0,0,50,30q�6i   .+�5>      �� .@�5?      �� .��5@      �� $��Add/Delete Customers��6$   $
��Bold"�6A   $��14(�6S   $��Center=�6a   $��Center=�6|   5A      �� 5B      .��5C      �� $ 
Horizontal=�6%   .+�5D      �� $��Customer Name��6(   $��Center=�6@   $��Center=�6[   $	��150��6x   $��DemiBold"�6�    �� TextAlignment$
 Left=�6�   �� 5E      -   5        $��txtCustomerName��5E   (   $��20,0,0,0q�6A   $��25��6S   $	��150��6_   $��Center=�6k   
�������$ Center=�6�   5F      5G      �� 5I      .��5J      �� $ 
Horizontal=�6%   .+�5K      �� $��Phone Number��6(   $��Center=�6?   $��Center=�6Z   $	��150��6w   $��DemiBold"�6�   $
 Left=�6�   �� 5L      -   5        $��txtPhoneNumber��5L   '   $��20,0,0,0q�6?   $��25��6Q   $	��150��6]   $��Center=�6i   
�������$ Center=�6�   5M      5N      �� 5Q      .��5R      �� $ 
Horizontal=�6%   .+�5U      �� $��Credit Amount��6(   $��Center=�6@   $��Center=�6[   $	��150��6x   $��DemiBold"�6�   $
 left=�6�   �� 5V      -   5        $��txtCreditAmount��5V   (   $��20,0,0,0q�6k   $��25��6}   $	��150��6�   $��Center=�6�   
�������$ Center=�6�   5W      5X      5^      �� 5`      -	   5        $��btnAdd��5`      $ 8��6'   $��50,50,50,20q�6T   $��80��6i   $	��Add��6t   $��10(�6�   
��� d �6�   �� 5a      -
   5        $��	btnDelete��5a      $ 8��6*   $��50,10,50,20q�6W   $��80��6l   $��Delete��6w   $��10(�6�   
���  ��6�   5c      5e      &   System.Windows.Controls.DataGrid  5g   
   -   5        $��dgvCreditCustomer��5g      $
��Left=�6-   $��Bottom=�6H   $	��400��6c   $	��500��6p   $��	45,0,0,60q�6|   ��5h      �� 5k      )  #System.Windows.Controls.DataGridRow"  6   .�5l      -   5        5m      5o      5s      5u      