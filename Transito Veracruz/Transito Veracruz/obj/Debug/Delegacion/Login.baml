   M S B A M L   `   `   `  ����L  HTransito Veracruz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Transito_Veracruz.DelegacionTransito_Veracruz.Delegacion  5   	   (    "Transito_Veracruz.Delegacion.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Transito_Veracruz.Delegacion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��500��6   $	��350��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F    � WindowStyle$
 None=�6k   .��5
      � ���#DADADA.+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#    � Offset$ 1Q�63   � 5      $ #E4C843��6#   $	 0.5Q�63   5      5      �� 5   
   $	��100��6   $	��Top=�6   $1��+/Transito Veracruz;component/icons/logo.png��65   $��20q�6j   �� 5   
   $	��280��6   $	��240��6    
�������$��Bottom=�6:   $��0,100q�6U    �� RadiusY$ 14.286��6d   	 �� RadiusX$	 14.286��6u   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      Color$ 	#FFBBBBBB��61      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6l   5      � 5   
   $	��280��6   $	��240��6   $��Bottom=�6(   $��0,100q�6C   .+�5      �� $��INICIAR SESIÓN��6   $	��Top=�6.   $��Center=�6F   $��18(�6c   
�������$��5q�6�   �� 5      $��Center=�6   $��10q�65   .+�5      �� -   5         ��Name$ txt_Usuario��5      $
��0,10q�6/   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ USUARIO��6=    %  !MaterialDesignFloatingHintTextBox#��[  6f   $��Champagne & Limousines)�6�   $��18(�6�   G� 5      -   5         G�Name$ txt_Contrasenia��5      $
��0,10q�67   $ CONTRASEÑA��6E    ) %MaterialDesignFloatingHintPasswordBox#��[ 6q   $��Champagne & Limousines)�6�   $��18(�6�   5       5!      �� 5"   
   -   5         ��Name$ btn_Ingresar��5"      $	��150��6'   $��Center=�63   $��Bottom=�6P   $
��0,90q�6k   $��INGRESAR��6y   
����������#603210
���   �6�   �� 5#   
   $5��/SECRETARÍA DE TRÁNSITO DEL ESTADO DE VERACRUZ��6   $��Center=�6I   $��23,429,20,0q�6f   $	��Top=�6{   $	��307��6�   �� 5$   
   $��www.veracruz.gob.mx��6   $��Center=�6.   $��110,453,110,23q�6K   $��Center=�6c   $	��130��6~   5'      5*      