   M S B A M L   `   `   `  ����C  ?wpf-test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Restaurant.ProviderRestaurant.Provider  5   	   (    "Restaurant.Provider.AddStorageItem   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Restaurant.Provider     5   	     � Title$;  5Добавити інгредієнт на склад��5   	   $	��252��6.   $��615.517��6;    � WindowStartupLocation$ CenterScreen=�6K   .��5	      � .+�5
   
   o� $��Corbel)�6   $��14(�6#   $��30��61   $	��Top=�6=   .@�5      m� -   5        $	��0,5q�5      $+��%Змінити користувача��6$   6W   m� 5      -   5        $	��0,5q�5      $��Допомога��6$   6J   m� 5      -   5        $	��0,5q�5      $��Про програму��6$   6O   m� 5      -   5        $	��0,5q�5      $��
Вихід��6$   6K   5      �� 5   
   -   5         ��Name$ 	textBlock��5   (   $��Corbel)�6   $��Center=�6;   $��256,47,250,0q�6X   $
��Wrap=�6n   $�� Інгредієнт��6�   $	��Top=�6�   $��20(�6�   $	��102��6�   �� 5   
   -   5        $ storageNameToAdd��5   6   $��Corbel)�6   $��14(�6(   $
��Left=�6P   $��
191,83,0,0q�6k   $
��Wrap=�6   $��
Назва��6�   $	��Top=�6�   $��16��6�   �� 5   
   -   5        $ textBlock2_Copy��5   6   $��Corbel)�6   $��14(�6(   $
��Left=�6O   $��
389,83,0,0q�6j   $
��Wrap=�6~   $+��%Одиниця вимірювання��6�   $	��Top=�6�   $��65��6�   $��23��6�   �� 5   
   -   5         ��Name$ unitComboBox��5   5   $��Corbel)�6   $��14(�6'   $
��Left=�6K   $��351,104,0,0q�6f   $	��Top=�6{   $	��135��6�    �� DisplayMemberPath$
 name��6�    �� SelectedValuePath$ id��6�   $��22��6�    �� SelectedValue 6�   �� *id+6�   �� 5   
   -	   5         ��Name$ addStorageItemBtn��5   3   $��Corbel)�6   $��14(�6%   $��Додати��6N   $
��Left=�6_   $��242,143,0,0q�6z   $	��Top=�6�   $	��116��6�   $��22��6�   6�   �� 5   
   -
   5         ��Name$ StorageItemNameTextBox��5   4   $��Corbel)�6   $��14(�6&   $
��Left=�6T   $��22��6o   $��134,104,0,0q�6{   	 �� TextWrapping$
	 Wrap=�6�   $	��Top=�6�   $	��155��6�   5      5      