   M S B A M L   `   `   `  ����C  ?wpf-test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:wpf_test.chefwpf_test.chef  5   	       wpf_test.chef.AddDish   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:wpf_test.chef     5   	     � Title$(  "Додати нову страву��5   	   $	��237��6$   $	��611��61   $��Corbel)�6=   $��14(�6Q    � WindowStartupLocation$ CenterScreen=�6_   .��5	      � $��0,0,2,17q�6    � RowDefinitions 5
   
   �� 5      $
��147* �6   �� 5      $	��43* �6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
281,10,0,0q�6B   $
��Wrap=�6V   $��Рецепт��6j   $	��Top=�6x   $��20(�6�   �� 5   
   -   5        $ recipeNameToAdd��5      $
��Left=�6-   $��	88,63,0,0q�6H   $
��Wrap=�6[   $��Назва страви��6o   $	��Top=�6�   �� 5   
   -   5        $ 
textBlock2��5      $
��Left=�6(   $��
63,107,0,0q�6C   $
��Wrap=�6W   $��Тип страви��6k   $	��Top=�6}   $��73��6�   �� 5   
   -   5         ��Name$ sizeDishTextBox��5      $
��Left=�6+   $��22��6F   $��226,133,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $��70��6�   $��2��6�   �� 5   
   -   5        $ 
textBlock3��5      $
��Left=�6(   $��237,107,0,0q�6C   $
��Wrap=�6X   $��Розмір��6l   $	��Top=�6z   �� 5   
   -   5         ��Name$ typeDishComboBox��5      $
��Left=�6-   $��
34,133,0,0q�6H   $	��Top=�6\   $	��137��6t    �� DisplayMemberPath$
 type��6�    �� SelectedValuePath$ id��6�   $��2��6  	 �� SelectedValue	 6�   �� *id+6  �� 5   
   -   5        
 ��Name$
 
addDishBtn��5      $��Додати��6%   $
��Left=�66   $��497,133,0,0q�6Q   $	��Top=�6f   $��59��6~   $��22��6�   $��2��6�   �� 5   
   -   5        $ textBlock2_Copy��5      $
��Left=�6-   $��324,107,0,0q�6H   $
��Wrap=�6]   $+��%Одиниця вимірювання��6q   $	��Top=�6�   $	��135��6�   $��23��6�   �� 5   
   -	   5        $ unitComboBox��5      $
��Left=�6)   $��343,133,0,0q�6D   $	��Top=�6Y   $��73��6q   $
 name��6|   $ id��6�   $��2��6�   	 6�   �� *id+6�   �� 5   
   -
   5        $ dishNameTextBox��5      $
��Left=�6+   $��22��6F   $��
205,59,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��211��6�   5      5      