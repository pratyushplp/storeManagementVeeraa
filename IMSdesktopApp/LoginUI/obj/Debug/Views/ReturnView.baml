   M S B A M L   `   `   `  ����B  >LoginUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LoginUI.ViewsLoginUI.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       LoginUI.Views.ReturnView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:LoginUI.Views     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -   5        $	��700��5
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
 Short=�6b   5$      5%      �� 5&      .��5'      �� $��Refund And Returns��6    $
��Bold"�6;   $��16(�6M   $��0,10,0,0q�6[   6o   5(      �� 5)      $��0,10,0,0q�6   .��5*      �� $ 
Horizontal=�6!   .+�5+      �� $��Bill No.��6$   $��0,0,20,0q�64   $��Center=�6F   $
��Bold"�6a   6v   �� 5,      -   5        $��	txtSearch��5,   $   $��0,0,20,0q�67   $��30��6I   $��80��6U   $��Center=�6`   
�������
���   � �� TextAlignment$ Center=�6�   �� 5.      -   5        +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5.   !   
��� ���$��5,0,0,0q�6e   .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�66   $��30��6D   $��26��6P   $��Center=�6[   $��Center=�6v   50      53      54      55      56      � 59   
   .+�5:      �� $��Bottom=�6   $��Right=�64   $	��470��6P   $	��400��6]   $��	0,0,50,30q�6i   .+�5;      �� .@�5<      �� .��5=      �� $��Return Details��6$   $
��Bold"�6;   $��14(�6M   $��Center=�6[   $��Center=�6v   5>      �� 5?      .��5@      �� $ 
Horizontal=�6%   .+�5C      �� $��Product Code��6(   $��Center=�6?   $��Center=�6Z   $	��100��6w   $��DemiBold"�6�    �� TextAlignment$ Center=�6�   �� 5D      -   5        $��txtProductCode��5D   (   $��20,0,0,0q�6@   $��25��6R   $	��200��6^   $��Center=�6j   
�������$ Center=�6�    �� 
IsReadOnly . 6�   5E      5F      �� 5H      .��5I      �� $ 
Horizontal=�6%   .+�5L      �� $��Quantity Sold��6(   $��Center=�6@   $��Center=�6[   $	��100��6x   $��DemiBold"�6�   $ Center=�6�   �� 5M      -   5        $��
txtSoldQty��5M   (   $��20,0,0,0q�6<   $��25��6N   $	��200��6Z   $��Center=�6f   
�������$ Center=�6�    . 6�   5N      5O      �� 5Q      .��5R      �� $ 
Horizontal=�6%   .+�5S      �� $��Return Quantity��6(   $��Center=�6B   $��Center=�6]   $	��100��6z   $��DemiBold"�6�   $ Center=�6�   �� 5T      -   5        $��txtReturnQty��5T   '   $��20,0,0,0q�6g   $��25��6y   $	��200��6�   $��Center=�6�   
�������$ Center=�6�   5V      5W      �� 5Y      .��5Z      �� $ 
Horizontal=�6%   .+�5[      �� $��Credit Amount��6(   $��Center=�6@   $��Center=�6[   $	��100��6x   $��DemiBold"�6�   $ Center=�6�   �� 5\      -   5        $��txtCreditAmount��5\   '   $��20,0,0,0q�6@   $��25��6R   $	��200��6^   $��Center=�6j   
������� . $ Center=�6�   
��� d �6�   5]      5^      5a      �� 5c      -	   5        $��	btnReturn��5c      $ 8��6*   $��50,20,50,20q�6W   $��80��6l   $��Return��6w   $��10(�6�   
����� �6�   5e      5g      &   System.Windows.Controls.DataGrid  5i   
   -
   5        $��dgvBills��5i      $
��Left=�6$   $��Bottom=�6?   $	��400��6Z   $	��500��6g   $��	45,0,0,60q�6s      
IsReadOnly . ��5j      �� 5m      )  #System.Windows.Controls.DataGridRow"  6   .�5n      -   5        5o      5q      5u      5w      