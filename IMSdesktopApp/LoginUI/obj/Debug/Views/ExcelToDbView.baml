   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    LoginUI!   LoginUI.Views.ExcelToDbView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   $	��700��5	      $
��1080��6'     � WindowStyle$  
ToolWindow=�64    � WindowStartupLocation$ CenterScreen=�6N    � 
ResizeMode$ NoResize=�6s   .��5      � 
�������.+�5   
   � $	��Top=�6   $��Center=�6'   $	��170��6D   $
��1000��6Q   .+�5      �� ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ���� 67   �� 5       � �� 5      �� 5   "    �� 
TargetType" ��62   .R�5   &   �� 5   #   5      5      .@�5       �� $��50��6   $��right=�6+   $	��Top=�6G   $��0,10,0,0q�6_   .��5!      ��  �� Orientation$ 
Horizontal=�6!   .+�5"      (  "System.Windows.Controls.DatePicker  -   5        $��
datePicker��5"   %   
 �� Now	   SelectedDate#	 Z 67   
   SelectedDateFormat$
 Short=�6b   5#      5$      �� 5%      .��5&      �� $"��Load Excel Files To Database��6    $
��Bold"�6E   $��16(�6W   $��0,10,0,0q�6e   6y   5'      �� 5(      $��0,10,0,0q�6   .��5)      �� $ 
Horizontal=�6!   .+�5*      �� $��File Name: ��6$   $��0,0,20,0q�67   $��Center=�6I   $
��Bold"�6d   6y   �� 5+      -   5        $��txtFileName��5+   $   $��0,0,20,0q�69   $��30��6K   $	��250��6W   $��Center=�6c   
�������
���   � �� TextAlignment$ Center=�6�   �� 5-      -   5        +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5-   !   
���"�"�$��5,0,0,0q�6j   .��5.      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ DotsHorizontal=�66   $��25��6L   $��30��6X   $��Center=�6c   $��Center=�6~   5/      52      53      �� 54      .��55      �� $ 
Horizontal=�6!   .+�57      �� $��Sheet: ��6$   $��0,5,20,0q�63   $��Center=�6E   $
��Bold"�6`   6u   �� 59      -   5        $��cmbSheet��59   #   $��	25,5,20,0q�63   $��30��6F   $	��250��6R   $��Center=�6^   6y   5:      5;      5<      5=      &   System.Windows.Controls.DataGrid  5B   
   -   5        $��dgvExcelToDb��5B      $
��Left=�6(   $��Bottom=�6C   $	��437��6^   $
��1000��6k   $��	37,0,0,60q�6x      
IsReadOnly . ��5C      �� 5F      )  #System.Windows.Controls.DataGridRow"  6   .�5G      -   5        5H      5J      � 5L   
   $��Bottom=�6   $��Right=�6*   $��55��6F   $	��300��6R   .+�5M      �� $��55��6   $��right=�6'   $	��Top=�6C   $��0,0,0,0q�6[   .��5N      �� -   5        $ 8��5N      
��� ���$��0,0,35,0q�6]   .��5O        $ DatabaseImport=�6.   $��25��6D   $	��100��6P   $��Center=�6\   5P      5Q      5R      5T      5V      