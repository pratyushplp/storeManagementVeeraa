   M S B A M L   `   `   `  ����B  >LoginUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LoginUI.ViewsLoginUI.Views  5   	       LoginUI.Views.LoginView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:LoginUI.Views     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	LoginView��5	   	   $	��500��6   $	��350��6(    � WindowStyle$ 
ToolWindow=�64    � WindowStartupLocation$ CenterScreen=�6N    � 
ResizeMode$ NoResize=�6s   .��5
      � .+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69   .��5      �  � Color$ 	#FF2281d1��6#    � Offset$ 0Q�65   � 5      $ 	#FF34268A��6#   $ 1Q�65   � 5      $ 	#FF33288B��6#   $	 0.5Q�65   5      5      �� 5   
   $��/Images/HomeIcon3.png��6   $��80��61   $	��Top=�6=   $��20q�6U   �� 5   
   $	��280��6   $	��240��6    
�������$��Bottom=�6:   $��	0,0,0,100q�6U    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   Color$	 	#FFBBBBBB��6#   
   	Direction$
 0Q�65      
BlurRadius$ 10Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 5Q�6k   5      � 5    
   $	��280��6   $	��240��6   $��Bottom=�6(   $��	0,0,0,100q�6C   .+�5!      �� $��Login To VEERAA��6   $��Center=�6/   $	��Top=�6L   $��5q�6d   
�������$��18(�6�   �� 5"      $��Center=�6   $��10q�64   .+�5#      �� -   5        $��txtUserName��5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ USERNAME��6-    %  !MaterialDesignFloatingHintTextBox#��[  6W   $
��0,10q�6�   $��14(�6�   G� 5$      -   5        $��txtPassword��5$      $ PASSWORD��61    ) %MaterialDesignFloatingHintPasswordBox#��[ 6[   $
��0,10q�6�   $��14(�6�   5'      5(      �� 5*   
   -   5        $��btnlogin��5*      $��Bottom=�6:   $
��0,85q�6U   $	��150��6c   $��LOGIN��6o   ���	#FF339EF76   �� 5+   
   $��Change Password��6   $��118,0,110,65q�6+   $��Bottom=�6A   
������� � Cursor$
 Hand��6n   5-      5.      