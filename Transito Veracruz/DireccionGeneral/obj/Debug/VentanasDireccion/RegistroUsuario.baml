   M S B A M L   `   `   `  ����K  GDireccionGeneral, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DireccionGeneral.VentanasDireccion"DireccionGeneral.VentanasDireccion  5   	   8    2DireccionGeneral.VentanasDireccion.RegistroUsuario   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:DireccionGeneral.VentanasDireccion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  RegistroUsuario��5	   	    � 
ResizeMode$ NoResize=�6!    � WindowStartupLocation$ CenterScreen=�67   $��638.553��6\   $��511.842��6m    � WindowStyle$
 None=�6}   .��5
      � ���#DADADA$	��559��6    $��Bottom=�6-    � RowDefinitions 5   
   �� 5      $
��140* �6   �� 5      $
��419* �6   .+�5   
   �� $	��321��6   $	��Top=�6!   $��2��69   $��	0,-79,0,0q�6J   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#    � Offset$ 1Q�63   � 5      $ #E4C843��6#   $	 0.5Q�63   5      5      �� 5   
   $	��533��6   
�������$��Bottom=�6.   $��27,-53,34,79q�6I   	 �� RadiusY$	 14.286��6_   
 �� RadiusX$
 14.286��6p   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      Color$ 	#FFBBBBBB��61      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6l   5      �� 5   
   -   5         ��Name$ btn_AgregarUsuario��5      $��Agregar��6-   ���#54903B$
��Left=�6T   $��289,364,0,0q�6o   $	��Top=�6�   $	��159��6�   $��1��6�   $��32��6�   6�   �� 5   
   -   5        $ btn_Cancelar��5      $��Cancelar��6'   ���#D92530$
��Left=�6O   $��
47,364,0,0q�6j   $	��Top=�6~   $	��159��6�   $��1��6�   $��32��6�   �� 5   
   $��NUEVO USUARIO��6   $	��Top=�6)   $��Center=�6A   $��18(�6^   
�������$��171,-35,166,0q�6~   $��29��6�   $	��175��6�   �� 5    
   -   5         ��Name$ cb_Delegacion��5       $
��Left=�6*   ���#DADADA$��
171,19,0,0q�6[   $	��Top=�6o   $	��277��6�   $��29��6�   .@�5!      �� $��Panuco��6   �� 5"      $��	Tantoyuca��6   �� 5#      $��Papantla��6   �� 5$      $��	Poza Rica��6   �� 5%      $��Tuxpan��6   �� 5&      $��Martinez de la Torre��6   �� 5'      $��Boca del Rio��6   �� 5(      $��Xalapa��6   �� 5)      $��Orizaba��6   �� 5*      $��Cordoba��6   �� 5+      $��Perote��6   �� 5,      $��Coscomatepec��6   �� 5-      $��Cosomoalapan��6   �� 5.      $��Acayucan��6   �� 5/      $��
Minatitlan��6   �� 50      $��Coatzacoalcos��6   51      �� 52   
   $��DELEGACIÓN��6   $��Champagne & Limousines)�6%   
�������$��18(�6_   $
��Left=�6m   $��	47,19,0,0q�6�   $	��Top=�6�   $��33��6�   $	��117��6�   �� 53   
   -   5         ��Name$ 
txt_Nombre��53      $��49,33,74,342q�6&   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ NOMBRE��6<    %  !MaterialDesignFloatingHintTextBox#��[  6d   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6  �� 54   
   -   5        $ txt_Apellidos��54      $��49,102,74,274q�6)   $ 	APELLIDOS��6@   #��[  6k   $��Champagne & Limousines)�6�   $��18(�6   $��1��6  �� 55   
   -   5        $ txt_Usuario��55      $��47,164,76,212q�6'   $ NOMBRE DE USUARIO��6>   #��[  6q   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   �� 56   
   $��CARGO��6   $��Champagne & Limousines)�6    
�������$��18(�6Z   $
��Left=�6h   $��	49,82,0,0q�6�   $	��Top=�6�   $��32��6�   $	��117��6�   �� 57   
   -   5        $ cb_Cargo��57      $
��Left=�6%   ���#DADADA$��
171,82,0,0q�6U   $	��Top=�6i   $	��277��6�   $��28��6�   .@�58      �� $��Administrativo��6   �� 59      $��Administrador��6   �� 5:      $��Soporte��6   �� 5;      $��Atencion��6   5<      �� 5=   
   -   5        $ txt_Contraseña��5=      $��47,233,76,142q�6*   $ CONTRASEÑA��6A   #��[  6m   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   �� 5>   
   $��PERSONAL��6   $��Champagne & Limousines)�6#   
�������$��18(�6]   $
��Left=�6k   $��
49,137,0,0q�6�   $	��Top=�6�   $��33��6�   $	��117��6�   $��2��6�   �� 5?   
   -	   5        $ cb_Personal��5?      $
��Left=�6(   ���#DADADA$��	171,2,0,0q�6X   $	��Top=�6k   $	��277��6�   $��28��6�   $��1��6�   .@�5@      �� $��
Delegacion��6   �� 5A      $��Direccion General��6   5B      5D      5E      