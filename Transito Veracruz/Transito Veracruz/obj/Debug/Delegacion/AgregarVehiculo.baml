   M S B A M L   `   `   `  ����L  HTransito Veracruz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Transito_Veracruz.DelegacionTransito_Veracruz.Delegacion  5   	   2    ,Transito_Veracruz.Delegacion.AgregarVehiculo   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Transito_Veracruz.Delegacion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  RegistroConductor��5	   	    � 
ResizeMode$ NoResize=�6#    � WindowStartupLocation$ CenterScreen=�69   $��638.553��6^   $��511.842��6o    � WindowStyle$
 None=�6   .��5
      � ���#DADADA$	��559��6    $��Bottom=�6-    � RowDefinitions 5   
   �� 5      $
��140* �6   �� 5      $
��419* �6   .+�5   
   �� $	��321��6   $	��Top=�6!   $��2��69   $��	0,-81,0,0q�6J   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#    � Offset$ 1Q�63   � 5      $ #E4C843��6#   $	 0.5Q�63   5      5      �� 5   
   $	��536��6   
�������$��Bottom=�6.   $��27,-56,34,79q�6I   	 �� RadiusY$	 14.286��6_   
 �� RadiusX$
 14.286��6p   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      Color$ 	#FFBBBBBB��61      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6l   5      �� 5   
   -   5         ��Name$ btn_AgregarVehiculo��5      $��Agregar��6.   ���#54903B$
��Left=�6U   $��289,364,0,0q�6p   $	��Top=�6�   $	��159��6�   $��1��6�   6�   �� 5   
   -   5        $��Cancelar��5      ���#D92530$
��Left=�69   $��
47,364,0,0q�6T   $	��Top=�6h   $	��159��6�   $��1��6�   6�   �� 5   
   $��NUEVO VEHICULO��6   $	��Top=�6*   $��Center=�6B   $��18(�6_   
�������$��171,-37,166,0q�6   $��29��6�   $	��175��6�   �� 5    
   -   5         ��Name$ 	txt_Marca��5       $��47,87,76,10q�6%   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ MARCA��6:    %  !MaterialDesignFloatingHintTextBox#��[  6a   $��Champagne & Limousines)�6�   $��18(�6�    �� 	MaxLength$ 30��6�   6�   �� 5!   
   -   5        $ 
txt_Modelo��5!      $��47,34,273,342q�6&   $ MODELO��6=   #��[  6e   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 20��6�   6�   �� 5"   
   -   5        $ txt_Año��5"      $��244,34,76,342q�6#   $
 AÑO��6:   #��[  6_   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 4��6�   6�   �� 5#   
   -   5        $ 	txt_Color��5#      $��47,113,273,263q�6%   $ COLOR��6=   #��[  6d   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 15��6�   6�   �� 5$   
   -   5         ��Name$ cb_Conductores��5$      $
��Left=�6+   ���#DADADA$��
171,18,0,0q�6[   $	��Top=�6o   $	��277��6�   $��28��6�   6�   �� 5%   
   $��	CONDUCTOR��6   $��Champagne & Limousines)�6$   
�������$��18(�6^   $
��Left=�6l   $��	47,18,0,0q�6�   $	��Top=�6�   $��32��6�   $	��117��6�   �� 5&   
   -   5        $ txt_NumeroPlaca��5&      $��244,113,76,263q�6+   $ NO. DE PLACA��6C   #��[  6q   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 7��6�   6�   �� 5'   
   -	   5        $ txt_Aseguradora��5'      $��47,183,76,192q�6+   $ ASEGURADORA��6B   #��[  6o   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 50��6�   6�   �� 5(   
   -
   5        $ 
txt_Poliza��5(      $��47,257,76,118q�6&   $ POLIZA DE SEGURO��6=   #��[  6o   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 10��6�   6�   5,      5-      