   M S B A M L   `   `   `  ����K  GDireccionGeneral, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DireccionGeneral.VentanasDireccion"DireccionGeneral.VentanasDireccion  5   	   :    4DireccionGeneral.VentanasDireccion.DictaminarReporte   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:DireccionGeneral.VentanasDireccion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  DictaminarReporte��5	   	    � 
ResizeMode$ NoResize=�6#    � WindowStartupLocation$ CenterScreen=�69   $��638.553��6^   $��511.842��6o    � WindowStyle$
 None=�6   .��5
      � ���#DADADA$	��559��6    $��Bottom=�6-    � ColumnDefinitions 5   
   �� 5      $	��15* �6   �� 5      $
��219* �6   �� 5      $
��278* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��10* �6   .+�5   
   �� $	��321��6   $	��Top=�6!   $��2��69   $��	0,-81,0,0q�6J   $��3��6]   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      �  � Color$ #EAD66F��6#   � 5      $ #CAA500��6#   	 � Offset$	 1Q�63   � 5      $ #E4C843��6#   $		 0.5Q�63   5      5      �� 5   
   $	��536��6   
�������$��Bottom=�6.   $��11.615,-56,34,79q�6I   
 �� RadiusY$
 14.286��6c    �� RadiusX$ 14.286��6t   $��2��6�   $��2��6�   $��1��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      Color$ 	#FFBBBBBB��61      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6l   5!      �� 5"   
   -   5         ��Name$ btn_GuardarDictamen��5"      $��Aceptar��6.   ���#54903B$
��Left=�6U   $��
70,364,0,0q�6p   $	��Top=�6�   $	��159��6�   $��1��6�   $��2��6�   6�   �� 5#   
   $��DICTAMEN��6   $	��Top=�6$   $��Center=�6<   $��18(�6Y   
�������$��171.615,-37,235,0q�6y   $��29��6�   $��90��6�   $��2��6�   $��1��6�   �� 5$   
   -   5         ��Name$ txt_NumeroReporte��5$      $��46,27,50,47q�6-   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ NUMEROREPORTE��6B    %  !MaterialDesignFloatingHintTextBox#��[  6q   $��Champagne & Limousines)�6�   $��18(�6�   $��1��6�   $��2��6�    �� 	MaxLength$ 5��6  {�.  6B  �� 5%   
   -   5        $ btn_Cancelar��5%      $��Cancelar��6'   ���#D92530$
��Left=�6O   $��
42,364,0,0q�6j   $	��Top=�6~   $	��159��6�   $��1��6�   $��1��6�   �� 5&   
   -   5        $ tb_Descripcion��5&      $��1��6*   ���#DADADA$��18(�6O   
�������$
��Left=�6o   $��46,0,0,0q�6�   $��1��6�    �� TextWrapping$
 Wrap=�6�   $��DESCRIPCION��6�   $	��Top=�6�   $	��377��6�   $��2��6�   $	��297��6	  $
��Left=�6  $	��Top=�68  $	 200��6W  5'      5(      