   M S B A M L   `   `   `  ����A  =RaToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:RaToDo.UserControlsRaToDo.UserControls  5          RaToDo.UserControls.Task   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:RaToDo.UserControls     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      -   5        $
��task��5	        � 	Resources  5         MyButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��5      .�5      ��  �@�OverridesDefaultStyle . 5      �� 5       �@�Cursor$
 Hand��5      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�5   !   
���   �#��z��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�5    )   5"      5$      5&      5'      5(      .��5*      �� -   5         ��Name$ 
borderMain��5*       
 Color5#��[ 5+      	 �� Padding$	 5q�5,      $��	0 10 0 10q�5-      $��1q�5.       
 Color2#��[ 5/      
 �� CornerRadius$
 10��50      ._�51   
   � $	��480��6   $	��100��52       � ColumnDefinitions 54      �� 55      $��25 �6#   �� 56      $��* �6#   �� 57      $	��100 �6#    � RowDefinitions 5;      �� 5<      $��25 �6    �� 5=      $��* �6    .+�5A      �� -   5         ��Name$ btnCheck��5A      
������ #��[  5D      .��5E      !  FontAwesome.Sharp.IconImage  -   5          Name$ btnCheckIcon��5E      �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Circle=�5F      $
��Fill=�5G      $��15��5H      $��15��5I      5J      ]� 5L      $��1��6   .+�5M      �� -   5         ��Name$ txtblockTitle��5M        titleColor1#��[ 5O      $��
Montserrat)�5P      $��18(�5Q      $��SemiBold"�5R      $��5 0 0 0q�5S      $��Center=�5T      $
��Left=�5U      $
��Left=�5V       �� 
IsReadOnly . $��0q�5X      $��2q�5Y      ��5N      ��  �� Path$ Title� �� ElementName$
 task��5Y      �� 5[      -   5        $ txtblockCategory��5[        titleColor3#��[ 5]      $��
Montserrat)�5^      $��14(�5_      $��SemiBold"�5`      $��Right=�5a      $��Center=�5b      $��Right=�5c       . $��0q�5e      $��2q�5f      ��5\      �� $ Category�$
 task��5f      5g      ]� 5j      $��1��6   $��1��5k      $��2��5l      $��5q�5m      .+�5n      �� -   5        $ txtblockDescription��5n      $	��Top=�5o      $��
Montserrat)�5q        titleColor2#��[ 5r       �� TextWrapping$
 Wrap=�5s       . $��0q�5u      ��5p      �� $ Description�$
 task��5u      �� 5v       �� Orientation$ 
Horizontal=�6   $��Bottom=�5w      $��Bottom=�5x      .+�5y      �� -   5         ��Name$ txtblockDeadline��5y       $��
Montserrat)�5{       $��16��5|       
�������$��12(�5~       ��5z       �� $
 Date�$
 task��5~       �� 5      $��|��6    $��
Montserrat)�5�       $��16��5�       
�������$��12(�5�       $��5 0 5 0q�5�       �� 5�      -	   5        $ txtblockTypeOfTask��5�       $��
Montserrat)�5�       $��16��5�       
�������$��12(�5�       ��5�       �� $ 
TypeOfTask�$
 task��5�       5�      5�      �� 5�      $ 
Horizontal=�6   $��RightToLeft=�5�      $��2��5�      $��0��5�      .+�5�      �� -
   5        $ 	btnDelete��5�      
������ $��0q�5�      $��Center=�5�      .��5�        $ Trash=�6#   $��15��5�   #   $��15��5�   #   $��Center=�5�   #   $��Center=�5�   #   5�      �� 5�      -   5        $ btnEdit��5�      
������ $��0q�5�      $��Center=�5�      .��5�        -   5        $ btnEditImage��5�   #   $
 Edit=�5�   #   $��15��5�   #   $��15��5�   #   $��Uniform=�5�   #   $��Center=�5�   #   $��Center=�5�   #   5�      5�      5�      5�      5�      