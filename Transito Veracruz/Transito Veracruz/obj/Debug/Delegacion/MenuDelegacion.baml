   M S B A M L   `   `   `  ����L  HTransito Veracruz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Transito_Veracruz.DelegacionTransito_Veracruz.Delegacion  5   	   1    +Transito_Veracruz.Delegacion.MenuDelegacion   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Transito_Veracruz.Delegacion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  MenuDelegacion��5	   	   $	��650��6    $
��1180��6-    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P    � WindowStyle$
 None=�6u   .��5
      � .+�5   
   �� $	��650��6   $	��Top=�6!   $��
0,0,1028,0q�69   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#    � Offset$ 1Q�63   � 5      $ #E4C843��6#   $	 0.5Q�63   5      5      �� 5   
   -   5         ��Name$ BarraTitulo��5      ���#EAD66F$��129,0,0,568q�6?   .+�5      �� $5��/SECRETARÍA DE TRÁNSITO DEL ESTADO DE VERACRUZ��6   ���#5D3327$
��Bold"�6a   $	��Top=�6s   $��35(�6�   $��
122,0,-2,0q�6�   $��79��6�   5      �� 5   
   -   5        $ MenuVertical��5      $
��Left=�6+   $	��650��6F   $	��Top=�6S   $	��328��6k   .+�5      �� $��Center=�6   $��79��61   $	��Top=�6=   $	��204��6U   $1��+/Transito Veracruz;component/icons/logo.png��6a   $��	39,0,85,0q�6�   5      �� 5   
   -   5        	 ��Name$	 
tb_Control��5      
 �� TabStripPlacement$

 Left=�6)   $
��Left=�6B   $	��518��6]   $��0,82,0,0q�6j   $	��Top=�6|   $
��1175��6�   .@�5      �� -   5         ��Name$ tb_Conductores��5      $��CONDUCTORES��6.   $
��Bold"�6C   $��90��6U   $	��150��6a   
������ $��15(�6�   .��5      � 
�������.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dg_Conductores��5         AutoGenerateColumns .  $
��Left=�6S   $	��416��6n   $��	27,10,0,0q�6{   $	��Top=�6�   $	��980��6�   {�.    Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Numero Licencia��61      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6\   �� *NumeroLicencia+6     5#      $ 	Apellidos��61    . $ * 6t    6V   �� *	Apellidos+6t     5$      $ Nombre��61    . $ * 6n    6S   �� *Nombre+6n     5%      $ Fecha Nacimiento��61    . $ * 6�    6]   �� *FechaNacimiento+6�     5&      $ Telefono��61    . $ * 6r    6U   �� *
Telefono+6r   5(      �� 5)      -   5         ��Name$ btn_AgregarConductor��5)      $��Agregar Conductor��6;   ���#54903B$
��Left=�6l   $��
27,453,0,0q�6�   $	��Top=�6�   $	��159��6�   6�   �� 5*      -   5        $ btn_EliminarConductor��5*      $��Eliminar Conductor��6<   ���	#FFD4231A$
��Left=�6p   $��792,453,0,0q�6�   $	��Top=�6�   $	��159��6�   6�   �� 5+      -   5        $ btn_EditarConductor��5+      $��Editar Conductor��6:   ���#54903B$
��Left=�6j   $��594,453,0,0q�6�   $	��Top=�6�   $	��159��6�   6�   5-      5.      �� 5/      -	   5        $ tb_Vehiculos��5/      $��	VEHICULOS��6,   $
��Bold"�6?   $��90��6Q   
������ $��15(�6v   .��50      � .+�51        -
   5        $ dg_Vehiculos��51       .  $
��Left=�6Q   $	��428��6l   $��	27,10,0,0q�6y   $	��Top=�6�   $	��980��6�   {�.  52        54      $ Numero Placas��61    . $ * 6{    6Z   �� *NumeroPlacas+6{     55      $ Marca��61    . $ * 6l    6R   �� *Marca+6l     56      $ Modelo��61    . $ * 6n    6S   �� *Modelo+6n     57      $
 Año��61    . $ * 6i    6P   �� *Anio+6i     58      $ Color��61    . $ * 6l    6R   �� *Color+6l     59      $ Nombre Aseguradora��61    . $ * 6�    6_   �� *NombreAseguradora+6�     5:      $ Numero Poliza��61    . $ * 6�    6Z   �� *NumeroPolizaSeguro+6�   5<      �� 5=      -   5        $ btn_AgregarVehiculo��5=      $��Agregar Vehiculo��6:   ���#54903B$
��Left=�6j   $��
27,453,0,0q�6�   $	��Top=�6�   $	��153��6�   6�   �� 5>      -   5        $ btn_EliminarVehiculo��5>      $��Eliminar Vehiculo��6;   ���	#FFD4231A$
��Left=�6n   $��792,453,0,0q�6�   $	��Top=�6�   $	��159��6�   6�   �� 5?      -   5        $ btn_EditarVehiculo��5?      $��Editar Vehiculo��69   ���#54903B$
��Left=�6h   $��594,453,0,0q�6�   $	��Top=�6�   $	��159��6�   6�   5@      5A      �� 5B      -   5        $ tb_Reportes��5B      $��REPORTES��6+   $
��Bold"�6=   $��90��6O   
������ $��15(�6t   .��5D      � .+�5E        -   5        $ dg_Reportes��5E      $
��Left=�64   $	��424��6O   $��	27,10,0,0q�6\   $	��Top=�6o   $	��980��6�    .  {�. $��0��6�   $��1��6�      SelectionMode$ Single=�6�    5F        5G      $ No. de Reporte��61    . $ * 6y    6[   �� *	IdReporte+6y     5H      $ Estatus��61    . $ * 6p    6T   �� *	Estatus+6p     5I      $ Nombre Delegaccion��61    . $ * 6�    6_   �� *NombreDelegacion+6�     5J      $ 	Direccion��61    . $ * 6t    6V   �� *	Direccion+6t     5K      $ Folio Dictamen��61    . $ * 6z    6[   �� *
IdDictamen+6z   5P      �� 5Q      -   5        $ btn_AgregarReporte��5Q      $��Agregar Reporte��69   ���#54903B$
��Left=�6h   $��
27,453,0,0q�6�   $	��Top=�6�   $	��151��6�   6�   �� 5R      -   5        $ btn_EliminarReporte��5R      $��Eliminar Reporte��6:   ���	#FFD4231A$
��Left=�6l   $��792,453,0,0q�6�   $	��Top=�6�   $	��159��6�   6�   �� 5S      -   5        $ btn_Actualizar��5S      $��
Actualizar��65   ���#54903B$
��Left=�6_   $��555,453,0,0q�6z   $	��Top=�6�   $	��151��6�   6�   5V      5X      �� 5Y      $��CHAT GRUPAL��6   $
��Bold"�6+   $��90��6=   
������ $��15(�6b   .��5Z      � 
�������$��0,0,0,8q�6*   .+�5[      �� -   5         ��Name$ txt_Mensaje��5[      $��31,417,233,46q�63   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ESCRIBE UN MENSAJE��6J    %  !MaterialDesignFloatingHintTextBox#��[  6~   $��Champagne & Limousines)�6�   $��18(�6�   6�   �� 5\      -   5        $ btn_EnviarMensaje��5\      $��Enviar��68   ���#54903B$
��Left=�6^   $��822,426,0,0q�6y   $	��Top=�6�   $	��149��6�   6�   �� 5]      -   5         ��Name$ 
block_Chat��5]      ���#DADADA$
��Left=�6G   $��	31,25,0,0q�6b   $	��Top=�6v   $	��368��6�   $	��940��6�   5^      5_      5`      �� 5a   
   -   5        $ 	btn_Salir��5a      $��Salir��6$   
����������#D92530
���   �$
��Left=�6p   $��1029,605,0,0q�6�   $	��Top=�6�   $��75��6�   6�   �� 5b   
   -   5         ��Name$ nombre_Usuario��5b      $��Usuario��6(   $
��Left=�6:   $��
253,45,0,0q�6U   $	��Top=�6i   ���#5D3327$
��Bold"�6�   $��20(�6�   �� 5c   
   $��Delegación��6   $
��Left=�6%   $��
975,45,0,0q�6@   $	��Top=�6T   ���#5D3327$
��Bold"�6�   $��20(�6�   5h      5i      