   M S B A M L   `   `   `  ����B  >LoginUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LoginUI.ViewsLoginUI.Views  5   	   !    LoginUI.Views.DashboardView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:LoginUI.Views  5   	   $	��700��5	      $
��1080��6'     � 
ResizeMode$  NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J    � WindowStyle$
 None=�6o   ���	#FFF4F8F9���	#FFF2EBEB � 	Resources 5
         MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 60Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 60Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 ButtonOpenMenu��66   .[�5       �� #��[  6   5!      :� 5#   
   $	 ButtonBase.Click��6   $
 ButtonCloseMenu��66   .[�5$      �� #��[ 6   5%      .��5(      � 
�������.+�5)   
   � $��60��6   $	��Top=�6   ���	#FF166CC6.+�5*      �� $!��Inventory Management System��6   $��23(�6;   $��Center=�6I   $��Center=�6d   
�������6�   �� 5+      $��Right=�6   $��Center=�65    �� Orientation$ 
Horizontal=�6P   .+�5,      '  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�6*   $��10q�6F      PlacementMode$ BottomAndAlignRightEdges=�6R      	StaysOpen .  
�������   PopupContent. 5-      �� $	��150��6!   .+�5.      �� $��Account��6!   �� 5/      -   5         ��Name$ Minimize��5/   !   $��Minimize��63   6F   �� 50      �� 51      -   5        $ ButtonPopUp��51   !   $��Logout��66   6G   52      53      54      55      � 56   
   -   5         �Name$ GridMenu��56      $��60��6!   $
��Left=�6,   ���	#FF1D3F8E.+�57      �� .+�58      � $	��150��6   
�������.+�59      �� -   5        $ ButtonCloseMenu��59      $��60��66   $��60��6A   $	��Top=�6z   $��Right=�6�   $y�	Collapsed=�6�   ��6M   Z� ��6c   Z� .��5:      '  !MaterialDesignThemes.Wpf.PackIcon  
���   ��  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowLeft=�6E   $��25��6V   $��25��6a   5;      �� 5<      -   5        $ ButtonOpenMenu��5<      $��60��65   $��60��6@   $	��Top=�6y   $��Right=�6�   ��6L   Z� ��6b   Z� .��5=        
���   �$
 Menu=�6E   $��25��6Q   $��25��6\   5>      5?      �� 5@      $��Disabled=�6   
�������.@�5A      �� $��60��6#   .��5B      �� $ 
Horizontal=�6%   .+�5C      �� -   5        $��btnInventory��5C   %   $��50��69   $��45��6D   $��Center=�6P   ���	#FF1D3F8E.��5D   "     $ ViewDashboard=�6:   $��25��6O   $��35��6[   $��Center=�6f   $��Center=�6�   6�   5E      �� 5F      $��	Inventory��6(   $��Center=�69   $��10q�6T   5G      5I      �� 5K      $��60��6#   .��5L      �� $ 
Horizontal=�6%   .+�5M      �� -   5        $��btnTransaction��5M   %   $��50��6;   $��45��6F   $��Center=�6R   ���	#FF1D3F8E.��5N   "     $
 Cash=�6:   $��30��6F   $��26��6R   $��Center=�6]   $��Center=�6x   5O      �� 5P      $��Billing��6(   $��Center=�67   $��10q�6R   5Q      5S      �� 5U      $��60��6#   .��5V      �� $ 
Horizontal=�6%   .+�5W      �� -   5        $��	btnReport��5W   %   $��50��66   $��45��6B   $��Center=�6N   $��Center=�6i   ���	#FF1D3F8E.��5X   "     $ BookMultiple=�6:   $��36��6N   $��20��6Z   $��Center=�6e   $
��Left=�6�   5Y      �� 5Z      $��Report��6(   $��Center=�66   $��10q�6Q   5[      5]      �� 5_      $��60��6#   .��5`      �� $ 
Horizontal=�6%   .+�5a      �� -	   5        $��	btnReturn��5a   %   $��50��66   $��45��6B   $��Center=�6N   $��Center=�6i   ���	#FF1D3F8E.��5b   "     $ AssignmentReturn=�6:   $��36��6R   $��20��6^   $��Center=�6i   $
��Left=�6�   5c      �� 5d      $��Return Items��6(   $��Center=�6<   $��10q�6W   5e      5g      �� 5i      $��60��6#   .��5j      �� $ 
Horizontal=�6%   .+�5k      �� -
   5        $��btnCreditCustomer��5k   %   $��50��6>   $��45��6J   $��Center=�6V   $��Center=�6q   ���	#FF1D3F8E.��5l   "     $ CreditCards=�6:   $��36��6M   $��18��6Y   $��Center=�6d   $
��Left=�6   5m      �� 5n      $��Credit Customers��6(   $��Center=�6@   $��10q�6[   5o      5q      �� 5s      $��60��6#   .��5t      �� $ 
Horizontal=�6%   .+�5u      �� -   5        $��btnLoadToDb��5u   %   $��50��68   $��45��6D   $��Center=�6P   $��Center=�6k   ���	#FF1D3F8E.��5v   "     $ DatabaseImport=�6:   $��36��6P   $��20��6\   $��Center=�6g   $
��Left=�6�   5w      �� 5x      $��Load To Database��6(   $��Center=�6@   $��10q�6[   5y      5{      �� 5}      $��60��6#   .��5~      �� $ 
Horizontal=�6%   .+�5      �� -   5        $��btnSyncBackupRestore��5   %   $��50��6A   $��45��6M   $��Center=�6Y   $��Center=�6t   ���	#FF1D3F8E.��5�   "     $
 Sync=�6:   $��36��6F   $��20��6R   $��Center=�6]   $
��Left=�6x   5�      �� 5�      $��Sync-Backup-Restore��6(   $��Center=�6C   $��10q�6^   5�      5�      5�      5�      5�      5�      5�      