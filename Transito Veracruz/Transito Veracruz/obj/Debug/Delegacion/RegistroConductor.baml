   M S B A M L   `   `   `  ����L  HTransito Veracruz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Transito_Veracruz.DelegacionTransito_Veracruz.Delegacion  5   	   4    .Transito_Veracruz.Delegacion.RegistroConductor   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Transito_Veracruz.Delegacion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
     � Title$  RegistroConductor��5	   	    � 
ResizeMode$ NoResize=�6#    � WindowStartupLocation$ CenterScreen=�69   $��649.5��6^   $	��511��6m    � WindowStyle$
 None=�6y   .��5
      � ���#DADADA$��0,41,0,0q�6     � ColumnDefinitions 5   
   �� 5      $
��489* �6   �� 5      $	��22* �6    � RowDefinitions 5   
   �� 5      $
��163* �6   �� 5      $
��446* �6   .+�5   
   �� $	��300��6   $	��Top=�6!   $��2��69   $��
-1,-50,0,0q�6J   $��2��6^   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#   	 � Offset$	 1Q�63   � 5      $ #E4C843��6#   $		 0.5Q�63   5      5      �� 5   
   $	��466��6   
�������$��Bottom=�6.   $��27,0,12,111q�6I   
 �� RadiusY$
 14.286��6^    �� RadiusX$ 14.286��6o   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      Color$ 	#FFBBBBBB��61      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6l   5       �� 5!   
   -   5         ��Name$ btn_AgregarConductor��5!      $��Agregar��6/   ���#54903B$
��Left=�6V   $��292,376,0,0q�6q   $	��Top=�6�   $	��160��6�   $��1��6�   6�   �� 5"   
   -   5        $ btn_Cancelar��5"      $��Cancelar��6'   ���#D92530$
��Left=�6O   $��
47,376,0,0q�6j   $	��Top=�6~   $	��159��6�   $��1��6�   6�   �� 5#   
   $��NUEVO CONDUCTOR��6   $	��Top=�6+   $��Center=�6C   $��18(�6`   
�������$��170,-19,143,0q�6�   $��28��6�   $	��176��6�   �� 5$   
   -   5         ��Name$ 
txt_Nombre��5$      $��47,106,61,8q�6&   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ NOMBRE��6;    %  !MaterialDesignFloatingHintTextBox#��[  6c   $��Champagne & Limousines)�6�   $��18(�6�    �� 	MaxLength$ 50��6�   6�   �� 5%   
   -   5        $ txt_Licencia��5%      $��47,69,61,332q�6(   $ NO. DE LICENCIA��6>   #��[  6o   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 8��6�   6�   �� 5&   
   -   5        $ txt_Telefono��5&      $��47,135,61,266q�6(   $ 	TELÉFONO��6?   #��[  6i   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 10��6�   6�   �� 5'   
   -   5        $ txt_Contrasena��5'      $��47,265,61,136q�6*   $ CONTRASEÑA DE ACCESO��6A   #��[  6w   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 15��6�   �� 5(   
   -   5        $ txt_Apellidos��5(      $��47,46,61,75q�6)   $ 	APELLIDOS��6>   #��[  6i   $��Champagne & Limousines)�6�   $��18(�6�   $ 50��6�   6�   �� 5)   
   -   5        $ txt_NombreUsuario��5)      $��47,195,61,206q�6-   $ NOMBRE DE USUARIO��6D   #��[  6w   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 20��6�   (  "System.Windows.Controls.DatePicker  5*   
   -	   5          Name$ select_Date��5*      $
��Left=�6*   $��
246,23,0,0q�6E   $	��Top=�6Y   $	��100��6q   $��1��6}   �� 5+   
   $��FECHA NACIMIENTO��6   $��47,23,248,382q�6+   $��Champagne & Limousines)�6B   $��18(�6j   $��1��6x   $��1��6�   ���	#890000006�   5-      5/      