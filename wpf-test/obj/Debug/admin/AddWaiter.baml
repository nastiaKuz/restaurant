   M S B A M L   `   `   `  ����C  ?wpf-test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Restaurant.AdminRestaurant.Admin  5   	        Restaurant.Admin.AddWaiter   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Restaurant.Admin     5   	     � Title$6  0Добавити нового офіціанта��5   	   $	��252��6+   $��615.517��68    � WindowStartupLocation$ CenterScreen=�6H   .��5	      � $��0,0,2,17q�6   .+�5
   
   o� $��Corbel)�6   $��14(�6#   $��30��61   $	��Top=�6=   .@�5      m� -   5        $	��0,5q�5      $+��%Змінити користувача��6$   6W   m� 5      -   5        $	��0,5q�5      $��Допомога��6$   6J   m� 5      -   5        $	��0,5q�5      $��Про програму��6$   6O   m� 5      -   5        $	��0,5q�5      $��
Вихід��6$   6K   5      �� 5   
   -   5         ��Name$ 	textBlock��5   (   $��Corbel)�6   $��Center=�6;   $��268,48,248,0q�6X   $
��Wrap=�6n   $�� Офіціант��6�   $	��Top=�6�   $��20(�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��90��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.018Q�6&   T� 5      5      5      �� 5   
   -   5        $ 	NameToAdd��5   6   $��Corbel)�6   $��14(�6(   $
��Left=�6I   $��
175,92,0,0q�6d   $
��Wrap=�6x   $��Ім'я��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ addWaiterBtn��5   3   $��Corbel)�6   $��14(�6%   $��Додати��6I   $
��Left=�6Z   $��267,131,0,0q�6u   $	��Top=�6�   $��80��6�   $��22��6�   6�   �� 5   
   -   5         ��Name$ WaiterNameTextBox��5   4   $��Corbel)�6   $��14(�6&   $
��Left=�6O   $��22��6j   $��
226,92,0,0q�6v    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��211��6�   5      5      