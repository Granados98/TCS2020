   M S B A M L   `   `   `  ����K  GDireccionGeneral, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DireccionGeneral.VentanasDireccion"DireccionGeneral.VentanasDireccion  5   	   7    1DireccionGeneral.VentanasDireccion.MenuDirGeneral   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:DireccionGeneral.VentanasDireccion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  MenuDireccionGeneral��5	   	   $	��650��6&   $
��1180��63    � 
ResizeMode$ NoResize=�6@    � WindowStartupLocation$ CenterScreen=�6V    � WindowStyle$
 None=�6{   .��5
      � .+�5   
   �� $	��650��6   $	��Top=�6!   $��
0,0,1028,0q�69   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#    � Offset$ 1Q�63   � 5      $ #E4C843��6#   $	 0.5Q�63   5      5      �� 5   
   -   5         ��Name$ BarraTitulo��5      ���#EAD66F$��129,0,0,568q�6?   .+�5      �� $5��/SECRETARÍA DE TRÁNSITO DEL ESTADO DE VERACRUZ��6   ���#5D3327$
��Bold"�6a   $	��Top=�6s   $��35(�6�   $��
122,0,-2,0q�6�   $��79��6�   5      �� 5   
   -   5        $ MenuVertical��5      $
��Left=�6+   $	��650��6F   $	��Top=�6S   $	��328��6k   .+�5      �� $��Center=�6   $��79��61   $	��Top=�6=   $	��204��6U   $0��*/DireccionGeneral;component/icons/logo.png��6a   $��	39,0,85,0q�6�   5      �� 5   
   	 �� TabStripPlacement$
	 Left=�6   $
��Left=�6.   $	��518��6I   $��0,82,0,0q�6V   $	��Top=�6h   $
��1175��6�   .@�5      �� $��DELEGACIONES��6   $
��Bold"�6,   
���   �$��90��6Q   $	��150��6]   
������ $��15(�6�   .��5      � 
�������.+�5      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 dgDelegaciones��5         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6e   $	��416��6�   $��	27,10,0,0q�6�   $	��Top=�6�   $	��980��6�      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��61      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *Nombre+6n     5"      $ Colonia��61    . $ * 6p    6T   �� *	Colonia+6p     5#      $ Codigo Postal��61    . $ * 6{    6Z   �� *CodigoPostal+6{     5$      $ 	Municipio��61    . $ * 6t    6V   �� *	Municipio+6t     5%      $ Telefono��61    . $ * 6r    6U   �� *
Telefono+6r     5&      $ Correo��61    . $ * 6y    6S   �� *CorreoElectronico+6y     5'      $ Calle��61    . $ * 6l    6R   �� *Calle+6l     5(      $ Numero��61    . $ * 6w    6S   �� *NumeroDireccion+6w   5*      �� 5+      -   5         ��Name$ btn_AgregarDelegacion��5+      $��Agregar Delegación��6<   ���#54903B$
��Left=�6n   $��
27,453,0,0q�6�   $	��Top=�6�   $	��159��6�   6�   �� 5,      -   5        $ btn_EditarDelegacion��5,      $��Editar Delegación��6;   ���#54903B$
��Left=�6l   $��562,453,0,0q�6�   $	��Top=�6�   $	��160��6�   6�   �� 5-      -   5        $ btn_EliminarDelegacion��5-      $��Eliminar Delegacion��6=   
����������#D92530
���   �$
��Left=�6�   $��814,453,0,0q�6�   $	��Top=�6�   $	��166��6�   6�   5/      50      �� 51      $��USUARIOS��6   $
��Bold"�6(   $��90��6:   
������ $��15(�6_   .��52      � .+�53        -   5        $
 
dgPersonal��53       .  .  $
��Left=�6a   $	��428��6|   $��	27,10,0,0q�6�   $	��Top=�6�   $	��980��6�    54        55      $ Usuario��61    . $ * 6p    6T   �� *	Usuario+6p     56      $ Tipo Personal��61    . $ * 6{    6Z   �� *TipoPersonal+6{     57      $ 	Apellidos��61    . $ * 6t    6V   �� *	Apellidos+6t     58      $ Nombre��61    . $ * 6n    6S   �� *Nombre+6n     59      $ Cargo��61    . $ * 6l    6R   �� *Cargo+6l   5;      �� 5<      -   5        $ btn_AgregarUsuario��5<      $��Agregar Usuario��69   ���#54903B$
��Left=�6h   $��
27,453,0,0q�6�   $	��Top=�6�   $	��153��6�   6�   �� 5=      -	   5        $ btn_EditarUsuario��5=      $��Editar Usuario��68   ���#54903B$
��Left=�6f   $��240,453,0,0q�6�   $	��Top=�6�   $	��153��6�   6�   �� 5>      -
   5        $ btn_EliminarUsuario��5>      $��Eliminar Usuario��6:   
����������#D92530
���   �$
��Left=�6�   $��802,453,0,0q�6�   $	��Top=�6�   $	��140��6�   6�   5?      5@      �� 5A      $��REPORTES��6   $
��Bold"�6(   $��90��6:   
������ $��15(�6_   .��5C      � .+�5D        -   5        $
 
dgReportes��5D       .  $
��Left=�6O   $	��275��6j   $��
27,159,0,0q�6w   $	��Top=�6�   $	��980��6�    5E        5F      $ No. de Reporte��61    . $ * 6y    6[   �� *	IdReporte+6y     5G      $ Estatus��61    . $ * 6p    6T   �� *	Estatus+6p     5H      $ Nombre Delegacion��61   $ * 6q    6L   �� *NombreDelegacion+6q     5I      $ 
Dirección��61   $ * 6b    6D   �� *	Direccion+6b     5J      $ Fecha Creacion��61   $ * 6k    6I   �� *FechaCreacion+6k     5K      $ Folio Dictamen��61   $ * 6k    6I   �� *FolioDictamen+6k   5M      �� 5N      -   5        $ btn_AgregarDictamen��5N      $��Asignar Dictamen��6:   ���#54903B$
��Left=�6j   $��
27,453,0,0q�6�   $	��Top=�6�   $	��151��6�   6�   �� 5O      -   5         ��Name$ cb_Delegacion��5O      ���#DADADA$
��Left=�6K   $��
251,32,0,0q�6f   $	��Top=�6z   $	��219��6�   �� 5P      $��DELEGACIÓN��6   $��Champagne & Limousines)�61   
�������$��Normal"�6k   $��18(�6   $��108,32,791,450q�6�   �� 5Q      -   5        $ 
cb_Estatus��5Q      ���#DADADA$
��Left=�6H   $��
702,32,0,0q�6c   $	��Top=�6w   $	��219��6�   .@�5R      �� $��Asignado��6'   �� 5S      $��No revisado��6'   5T      �� 5U      $��ESTATUS��6   $��Champagne & Limousines)�6.   
�������$��Normal"�6h   $��18(�6|   $��559,32,340,450q�6�   �� 5V      -   5        $ btn_VerDetalle��5V      $��Ver Detalle��65   ���#54903B$
��Left=�6`   $��211,453,0,0q�6{   $	��Top=�6�   $	��151��6�   6�   �� 5W      -   5        $ btn_Actualizar��5W      $��
Actualizar��65   ���#54903B$
��Left=�6_   $��730,453,0,0q�6z   $	��Top=�6�   $	��151��6�   6�   �� 5X      -   5        $ 
btn_Buscar��5X      $��Buscar��61   ���#54903B$
��Left=�6W   $��
770,92,0,0q�6r   $	��Top=�6�   $	��151��6�   6�   5Y      5[      �� 5\      $��CHAT GRUPAL��6   $
��Bold"�6+   $��90��6=   
������ $��15(�6b   .��5]      � 
�������$��0,0,0,8q�6*   .+�5^      �� -   5         ��Name$ txt_Mensaje��5^      $��31,417,233,46q�63   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ESCRIBE UN MENSAJE��6J    %  !MaterialDesignFloatingHintTextBox#��[  6~   $��Champagne & Limousines)�6�   $��18(�6�   �� 5_      -   5        $ 
btn_Enviar��5_      $��Enviar��61   ���#54903B$
��Left=�6W   $��822,426,0,0q�6r   $	��Top=�6�   $	��149��6�   6�   �� 5`      -   5         ��Name$ 
block_Chat��5`      ���#DADADA$
��Left=�6G   $��	31,25,0,0q�6b   $	��Top=�6v   $	��368��6�   $	��940��6�   5a      5b      5c      �� 5d   
   -   5        $ 	btn_Salir��5d      $��Salir��6$   
����������#D92530
���   �$
��Left=�6p   $��1029,605,0,0q�6�   $	��Top=�6�   $��75��6�   6�   �� 5e   
   -   5         ��Name$ nombre_Usuario��5e      $��Usuario��6(   $
��Left=�6:   $��
253,45,0,0q�6U   $	��Top=�6i   ���#5D3327$
��Bold"�6�   $��20(�6�   �� 5f   
   $��Dirección General��6   $
��Left=�6,   $��
975,45,0,0q�6G   $	��Top=�6[   ���#5D3327$
��Bold"�6�   $��20(�6�   5j      5k      