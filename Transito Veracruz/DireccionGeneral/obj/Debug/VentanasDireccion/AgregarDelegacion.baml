   M S B A M L   `   `   `  ����K  GDireccionGeneral, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DireccionGeneral.VentanasDireccion"DireccionGeneral.VentanasDireccion  5   	   :    4DireccionGeneral.VentanasDireccion.AgregarDelegacion   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:DireccionGeneral.VentanasDireccion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  AgregarDelegacion��5	   	    � 
ResizeMode$ NoResize=�6#    � WindowStartupLocation$ CenterScreen=�69   $��640.562��6^   $��511.842��6o    � WindowStyle$
 None=�6   .��5
      � ���#DADADA$	��559��6    $��Bottom=�6-    � RowDefinitions 5   
   �� 5      $
��140* �6   �� 5      $
��419* �6   .+�5   
   �� $	��356��6   $	��Top=�6!   $��2��69   $��	0,-94,0,0q�6J   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#    � Offset$ 1Q�63   � 5      $ #E4C843��6#   $	 0.5Q�63   5      5      �� 5   
   $	��534��6   
�������$��Bottom=�6.   $��29,-68,32,93q�6I   	 �� RadiusY$	 14.286��6_   
 �� RadiusX$
 14.286��6p   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      Color$ 	#FFBBBBBB��61      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6l   5      �� 5   
   -   5         ��Name$ btn_AgregarDelegacion��5      $��Agregar��60   ���#54903B$
��Left=�6W   $��289,357.868,0,0q�6r   $	��Top=�6�   $	��159��6�   $��1��6�   6�   �� 5   
   -   5        $ btn_Cancelar��5      $��Cancelar��6'   ���#D92530$
��Left=�6O   $��47,357.868,0,0q�6j   $	��Top=�6�   $	��159��6�   $��1��6�   6�   �� 5   
   $��NUEVA DELEGACIÓN��6   $	��Top=�6,   $��Center=�6D   $��18(�6a   
�������$��171,-51,166,0q�6�   $��28��6�   $	��175��6�   �� 5    
   -   5         ��Name$ 
txt_Nombre��5       $��
47,7,83,90q�6&   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ NOMBRE��6:    %  !MaterialDesignFloatingHintTextBox#��[  6b   $��Champagne & Limousines)�6�   $��18(�6�    �� 	MaxLength$ 50��6  �� 5!   
   -   5        $ 	txt_Calle��5!      $��49,82,81,14q�6%   $ CALLE��6:   #��[  6a   $��Champagne & Limousines)�6�   $��18(�6�   $ 50��6   �� 5"   
   -   5        $ txt_NumeroCalle��5"      $��47,17,386,359q�6+   $	 NO.��6B   #��[  6g   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 4��6  �� 5#   
   -   5        $ txt_Colonia��5#      $��171,17,83,359q�6'   $ COLONIA��6>   #��[  6g   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 30��6  �� 5%   
   -   5         ��Name$ cb_Municipio��5%      $
��Left=�6)   ���#DADADA$��154,182,0,0q�6Y   $	��Top=�6n   $	��277��6�   $��28��6�   $��1��6�   .@�5&      �� $��Acajete��6   �� 5'      $��Acatlán��6   �� 5(      $��Acayucan��6   �� 5)      $��Actopan��6   �� 5*      $��Acula��6   �� 5+      $��
Acultzingo��6   �� 5,      $��Alpatláhuac��6   �� 5-      $��Alto Lucero��6   �� 5.      $��	Altotonga��6   �� 5/      $��Alvarado��6   �� 50      $��
Amatitlán��6   �� 51      $��Naranjos��6   �� 52      $��Amatlán de los Reyes��6   �� 53      $��Ángel R. Cabada��6   �� 54      $��
La Antigua��6   �� 55      $��Apazapan��6   �� 56      $��Aquila��6   �� 57      $��	Astacinga��6   �� 58      $��
Atlahuilco��6   �� 59      $��Atoyac��6   �� 5:      $��Atzacan��6   �� 5;      $��Atzalan��6   �� 5<      $��
Tlaltetela��6   �� 5=      $��Ayahualulco��6   �� 5>      $��
Banderilla��6   �� 5?      $��Benito Juárez��6   �� 5@      $��Boca del Río��6   �� 5A      $��Calcahualco��6   �� 5B      $��Camerino Z. Mendoza��6   �� 5C      $��Carrillo Puerto��6   �� 5D      $��Catemaco��6   �� 5E      $��Cazones de Herrera��6   �� 5F      $��
Cerro Azul��6   �� 5G      $��Citlaltépetl��6   �� 5H      $��Coacoatzintla��6   �� 5I      $��Coahuitlán��6   �� 5J      $��Coatepec��6   �� 5K      $��Coatzacoalcos��6   �� 5L      $��
Coatzintla��6   �� 5M      $��Cuitláhuac��6   �� 5N      $��Chalma��6   �� 5O      $��
Chiconamel��6   �� 5P      $��Chiconquiaco��6   �� 5Q      $��Chicontepec��6   �� 5R      $��	Chinameca��6   �� 5S      $��Chinampa de Gorostiza��6   �� 5T      $��Las Choapas��6   �� 5U      $��Chontla��6   �� 5V      $��
Chumatlán��6   �� 5W      $��Emiliano Zapata��6   �� 5X      $��Espinal��6   �� 5Y      $��Fortín��6   �� 5Z      $��Gutiérrez Zamora��6   �� 5[      $��Huatusco��6   �� 5\      $��Huayacocotla��6   �� 5]      $��Ignacio de la Llave��6   �� 5^      $��	Ixcatepec��6   �� 5_      $��Ixhuatlán de Madero��6   �� 5`      $��	Jalacingo��6   �� 5a      $��Xalapa��6   �� 5b      $��
Jalcomulco��6   �� 5c      $
��Xico��6   �� 5d      $��Martínez de la Torre��6   �� 5e      $��Minatitlán��6   �� 5f      $��Naolinco��6   �� 5g      $��Pánuco��6   �� 5h      $��Papantla��6   �� 5i      $��Paso del Macho��6   �� 5j      $��Paso de Ovejas��6   �� 5k      $��Perote��6   �� 5l      $��Platón Sánchez��6   �� 5m      $��Tamiahua��6   �� 5n      $��Tampico Alto��6   �� 5o      $��	Tantoyuca��6   �� 5p      $��	Tecolutla��6   �� 5q      $��Álamo Temapache��6   �� 5r      $��Tepetzintla��6   �� 5s      $��
Tihuatlán��6   �� 5t      $��Tlacotalpan��6   �� 5u      $��Tuxpan��6   �� 5v      $��Vega de Alatorre��6   �� 5w      $��Veracruz��6   �� 5x      $��Villa Aldama��6   �� 5y      $��Yanga��6   �� 5z      $��Zaragoza��6   �� 5{      $��Zentla��6   �� 5|      $��	Zongolica��6   �� 5}      $��Zontecomatlán��6   5~      �� 5   
   -   5        $ txt_CodigoPostal��5      $��49,99,306,277q�6,   $ CODIGO POSTAL��6C   #��[  6r   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 5��6%  �� 5�   
   -	   5        $ txt_Telefono��5�      $��233,99,83,277q�6(   $ 	TELÉFONO��6?   #��[  6i   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�    �� IsUndoEnabled . $ 10��6-  �� 5�   
   -
   5        $ 
txt_Correo��5�      $��47,251,83,124q�6&   $ CORREO��6=   #��[  6e   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $ 40��6�   �� 5�   
   $��	MUNICIPIO��6   $��Champagne & Limousines)�6$   
�������$��18(�6^   $
��Left=�6l   $��
47,182,0,0q�6�   $	��Top=�6�   $��33��6�   $	��117��6�   $��1��6�   5�      5�      