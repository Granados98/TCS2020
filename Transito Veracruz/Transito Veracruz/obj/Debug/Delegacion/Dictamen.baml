   M S B A M L   `   `   `  ����L  HTransito Veracruz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Transito_Veracruz.DelegacionTransito_Veracruz.Delegacion  5   	   +    %Transito_Veracruz.Delegacion.Dictamen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Transito_Veracruz.Delegacion     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  Dictamen��5	   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�60   $��638.553��6U   $��511.842��6f    � WindowStyle$
 None=�6v   .��5
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
 14.286��6c    �� RadiusX$ 14.286��6t   $��2��6�   $��2��6�   $��1��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      Color$ 	#FFBBBBBB��61      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6l   5!      �� 5"   
   -   5         ��Name$ btn_Aceptar��5"      $��Aceptar��6&   ���#54903B$
��Left=�6M   $��
66,364,0,0q�6h   $	��Top=�6|   $	��159��6�   $��1��6�   $��2��6�   6�   �� 5#   
   $��DICTAMEN��6   $	��Top=�6$   $��Center=�6<   $��18(�6Y   
�������$��171.615,-37,235,0q�6y   $��29��6�   $��90��6�   $��2��6�   $��1��6�   �� 5$   
   -   5         ��Name$ txt_NombrePerito��5$      $��1��6,    �� 
IsReadOnly . $��Champagne & Limousines)�6N   $��18(�6v   
�������$
��Left=�6�   $��40��6�   $��42,0,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $��NOMBRE DEL PERITO��6�   $	��Top=�6�   $	��371��6  $��2��6   �� 5%   
   -   5         ��Name$ txt_Descripcion��5%      ���#DADADA$��Champagne & Limousines)�6B   $��18(�6j   $
��Left=�6x   $��	42,10,0,0q�6�   $��1��6�   $
��Wrap=�6�   $��DESCRIPCIÓN��6�   $	��Top=�6�   $	��311��6�   $	��371��6�   ���	#FF878787$��2��6"  $��1��66  �� 5&   
   -   5        $ btn_Cancelar��5&      $��Cancelar��6'   ���#D92530$
��Left=�6O   $��
27,364,0,0q�6j   $	��Top=�6~   $	��160��6�   $��1��6�   $��1��6�   �� 5'   
   -   5        $ txt_FechaRegistro��5'      $��1��6-    . $��Champagne & Limousines)�6O   $��18(�6w   
�������$
��Left=�6�   $��40��6�   $��	42,67,0,0q�6�   $
 Wrap=�6�   $��NOMBRE DEL PERITO��6�   $	��Top=�6�   $	��371��6  $��2��6"  5,      5-      