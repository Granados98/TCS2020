   M S B A M L   `   `   `  ����K  GDireccionGeneral, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DireccionGeneral.VentanasDireccion"DireccionGeneral.VentanasDireccion  5   	   :    4DireccionGeneral.VentanasDireccion.VisualizarReporte   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:DireccionGeneral.VentanasDireccion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  LevantarReporte��5	   	    � 
ResizeMode$ NoResize=�6!    � WindowStartupLocation$ CenterScreen=�67   $��691.305��6\   $��511.842��6m    � WindowStyle$
 None=�6}   .��5
      � ���#DADADA$	��559��6    $��Bottom=�6-    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��10* �6   .+�5   
   �� $	��319��6   $	��Top=�6!   $��
0,-134,0,0q�69   $��2��6M   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#    � Offset$ 1Q�63   � 5      $ #E4C843��6#   $	 0.5Q�63   5      5      �� 5   
   $	��566��6   
�������$��Bottom=�6.   $��33,-79,28,72q�6I   	 �� RadiusY$	 14.286��6_   
 �� RadiusX$
 14.286��6p   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      Color$ 	#FFBBBBBB��61      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6l   5      �� 5   
   -   5         ��Name$ 	btn_Salir��5      $��Salir��6$   ���#D92530$
��Left=�6I   $��
47,373,0,0q�6d   $	��Top=�6x   $	��159��6�   $��1��6�   6�   �� 5   
   $��REPORTE REGISTRADO    ��6   $	��Top=�62   $��Center=�6J   $��18(�6g   
�������$��159,-122,156,0q�6�   $��29��6�   $	��197��6�   �� 5   
   $��NUMERO REPORTE��6   $��Champagne & Limousines)�6)   
�������$��18(�6c   $
��Left=�6q   $��
48,-50,0,0q�6�   $	��Top=�6�   $��32��6�   $	��174��6�   �� 5    
   $��NOMBRE DELEGACION��6   $��Champagne & Limousines)�6,   
�������$��18(�6f   $
��Left=�6t   $��48,4,0,0q�6�   $	��Top=�6�   $��32��6�   $	��200��6�   �� 5!   
   $��INVOLUCRADOS��6   $��Champagne & Limousines)�6'   
�������$��18(�6a   $
��Left=�6o   $��	48,19,0,0q�6�   $	��Top=�6�   $��32��6�   $	��158��6�   $��1��6�   �� 5"   
   -   5         ��Name$ tb_Involucrados��5"      ���#DADADA$��Champagne & Limousines)�6B   $��18(�6j   $
��Left=�6x   $��	47,56,0,0q�6�   $
��Wrap=�6�   $��INVOLUCRADOS��6�   $	��Top=�6�   $��92��6�   $	��400��6�   ���	#FF878787$��1��6  �� 5#   
   $��	DIRECCION��6   $��Champagne & Limousines)�6$   
�������$��18(�6^   $
��Left=�6l   $��	48,60,0,0q�6�   $	��Top=�6�   $��32��6�   $	��126��6�   �� 5$   
   -   5        $ txt_Direccion��5$      ���#DADADA$��Champagne & Limousines)�6@   $��18(�6h   $
��Left=�6v   $��	47,97,0,0q�6�   $
��Wrap=�6�   $��
DIRECCIÓN��6�   $	��Top=�6�   $��32��6�   $	��400��6�   ���	#FF8787876�   �� 5%   
   -   5        $ txt_NumReporte��5%      ���#DADADA$��Champagne & Limousines)�6A   $��18(�6i   $
��Left=�6w   $��222,-50,0,0q�6�   $
��Wrap=�6�   $��
NUMREPORTE��6�   $	��Top=�6�   $��32��6�   $	��226��6�   ���	#FF8787876�   �� 5&   
   -   5        $ txt_Delegacion��5&      ���#DADADA$��Champagne & Limousines)�6A   $��18(�6i   $
��Left=�6w   $��	258,4,0,0q�6�   $
��Wrap=�6�   $��
DELEGACION��6�   $	��Top=�6�   $��32��6�   $	��190��6�   ���	#FF8787876�   �� 5'   
   $��IMAGENES��6   $��Champagne & Limousines)�6#   
�������$��18(�6]   $
��Left=�6k   $��
48,174,0,0q�6�   $	��Top=�6�   $��32��6�   $	��104��6�   $��1��6�    J� RenderTransformOrigin$ 0.519,1.281&�6�   �� 5(   
   -   5         ��Name$ box_Imagenes��5(      $
��Left=�6(   $	��114��6C   $��
48,211,0,0q�6P   $��1��6d   $	��Top=�6q   $	��401��6�   
������ ���	#FFDADADA6�   5*      5+      