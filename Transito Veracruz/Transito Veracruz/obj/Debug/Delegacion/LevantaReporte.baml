   M S B A M L   `   `   `  ����L  HTransito Veracruz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Transito_Veracruz.DelegacionTransito_Veracruz.Delegacion  5   	   1    +Transito_Veracruz.Delegacion.LevantaReporte   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Transito_Veracruz.Delegacion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  LevantarReporte��5	   	    � 
ResizeMode$ NoResize=�6!    � WindowStartupLocation$ CenterScreen=�67   $��709.053��6\   $��511.842��6m    � WindowStyle$
 None=�6}   .��5
      � ���#DADADA$	��559��6    $��Bottom=�6-    � ColumnDefinitions 5   
   �� 5      $
��407* �6   �� 5      $
��106* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��10* �6   .+�5   
   �� $	��393��6   $	��Top=�6!   $��2��69   $��
0,-156,0,0q�6J   $��2��6^   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#   	 � Offset$	 1Q�63   � 5      $ #E4C843��6#   $		 0.5Q�63   5      5      �� 5   
   $	��581��6   
�������$��Bottom=�6.   $��27,-113,34,91q�6I   
 �� RadiusY$
 14.286��6`    �� RadiusX$ 14.286��6q   $��2��6�   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      Color$ 	#FFBBBBBB��61      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6l   5       �� 5!   
   -   5         ��Name$ btn_AgregarReporte��5!      $��Agregar��6-   ���#54903B$
��Left=�6T   $��289,364,0,0q�6o   $	��Top=�6�   $	��159��6�   $��1��6�   $��2��6�   �� 5"   
   -   5        $ btn_Cancelar��5"      $��Cancelar��6'   ���#D92530$
��Left=�6O   $��
47,364,0,0q�6j   $	��Top=�6~   $	��159��6�   $��1��6�   6�   �� 5#   
   $��NUEVO REPORTE��6   $	��Top=�6)   $��Center=�6A   $��18(�6^   
�������$��171,-94,60,0q�6~   $��29��6�   $	��175��6�   �� 5$   
   -   5         ��Name$ cb_Conductor��5$      $
��Left=�6)   ���#DADADA$��171,-39,0,0q�6Y   $	��Top=�6n   $	��277��6�   $��28��6�   $��2��6�   �� 5%   
   $��	CONDUCTOR��6   $��Champagne & Limousines)�6$   
�������$��18(�6^   $
��Left=�6l   $��
47,-39,0,0q�6�   $	��Top=�6�   $��32��6�   $	��117��6�   �� 5&   
   -   5         ��Name$ txt_Direccion��5&      $��47,0,64,375q�6)   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
DIRECCIÓN��6>    %  !MaterialDesignFloatingHintTextBox#��[  6i   $��Champagne & Limousines)�6�   $��18(�6�   $��2��6�   $��1��6�   �� 5'   
   $��VEHICULO��6   $��Champagne & Limousines)�6#   
�������$��18(�6]   $
��Left=�6k   $��	47,16,0,0q�6�   $	��Top=�6�   $��32��6�   $	��117��6�   �� 5(   
   -   5        $ cb_VehiculosConductor��5(      $
��Left=�62   ���#DADADA$��
171,16,0,0q�6b   $	��Top=�6v   $	��277��6�   $��28��6�   $��2��6�   �� 5)   
   -   5        $ btn_AgregarImagenes��5)      $��Adjuntar Imágenes��6.   ���#54903B$
��Left=�6_   $��289,245,0,0q�6z   $	��Top=�6�   $	��159��6�   $��1��6�   $��2��6�   �� 5*   
   -   5         ��Name$ box_Implicados��5*      $
��Left=�6*   $	��114��6E   $��	47,60,0,0q�6R   $��1��6e   $	��Top=�6r   $	��401��6�   $��2��6�   
������ ���	#FFDADADA6�   �� 5+   
   -   5        $ cb_Delegacion��5+      $
��Left=�6*   ���#DADADA$��
171,78,0,0q�6Z   $	��Top=�6n   $	��277��6�   $��28��6�   $��2��6�   6�   �� 5,   
   $��
DELEGACION��6   $��Champagne & Limousines)�6%   
�������$��18(�6_   $
��Left=�6m   $��	47,78,0,0q�6�   $	��Top=�6�   $��32��6�   $	��117��6�   �� 5-   
   -	   5        $ box_Imagenes��5-      $
��Left=�6(   $��87��6C   $��
47,232,0,0q�6O   $��1��6c   $	��Top=�6p   $	��221��6�   
������ ���	#FFDADADA6�   �� 5.   
   -
   5        $ btn_EliminarImagen��5.      $��Eliminar Imagen��6-   ���#D92530$
��Left=�6\   $��289,287,0,0q�6w   $	��Top=�6�   $	��159��6�   $��1��6�   $��2��6�   6�   �� 5/   
   -   5        $ btn_EliminarImplicado��5/      $��Eliminar Implicado��60   ���#D92530$
��Left=�6b   $��
47,179,0,0q�6}   $	��Top=�6�   $	��158��6�   $��1��6�   6�   54      55      