   M S B A M L   `   `   `  ����B  >LoginUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LoginUI.ViewsLoginUI.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   %    LoginUI.Views.ReturnHistoryView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:LoginUI.Views     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   $	��700��5
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
Horizontal=�6!   .+�5#      (  "System.Windows.Controls.DatePicker  -   5        $��
datePicker��5#   %   
 �� Now	   SelectedDate#	 Z 67   
   SelectedDateFormat$
 Short=�6b   5$      5%      �� 5&      .��5'      �� $��Return History��6    $
��Bold"�67   $��16(�6I   $��0,10,0,0q�6W   6k   5(      �� 5)      $��0,10,0,0q�6   .��5*      �� $ 
Horizontal=�6!   .+�5+      �� $��Bill No.��6$   $��0,0,20,0q�64   $��Center=�6F   $
��Bold"�6a   6v   �� 5,      -   5        $��	txtSearch��5,   $   $��0,0,20,0q�67   $��30��6I   $��80��6U   $��Center=�6`   
�������
���   � �� TextAlignment$ Center=�6�   �� 5.      -   5        +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5.   !   
��� ���$��5,0,0,0q�6e   .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�66   $��30��6D   $��26��6P   $��Center=�6[   $��Center=�6v   50      �� 51      -   5        $ 8��51   !   
���W�.�$��20,0,0,0q�6g   .��52        $ FileDocumentBox=�66   $��30��6M   $��26��6Y   $��Center=�6d   $��Center=�6   53      57      58      59      5:      &   System.Windows.Controls.DataGrid  5?   
   -   5        $��	dgvReturn��5?      $
��Left=�6%   $��Bottom=�6@   $	��450��6[   $	��800��6h   $��	45,0,0,60q�6t      
IsReadOnly . ��5@      �� 5C      )  #System.Windows.Controls.DataGridRow"  6   .�5D      -   5        5E      5G      5K      5M      