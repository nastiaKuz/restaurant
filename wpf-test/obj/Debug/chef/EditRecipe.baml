   M S B A M L   `   `   `  ����C  ?wpf-test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:wpf_test.chefwpf_test.chef  5   	       wpf_test.chef.EditRecipe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:wpf_test.chef     5   	     � Title$'  !Редагувати рецепт��5   	   $	��471��6#   $	��600��60    � WindowStartupLocation$ CenterScreen=�6<   $��Corbel)�6a   $��14(�6u   .��5	      � .+�5
   
   �� -   5         ��Name$ 	textBlock��5
      $
��Left=�6'   $��
199,10,0,0q�6B   $
��Wrap=�6V   $��Рецепт��6j   $	��Top=�6x   $��20(�6�   �� 5   
   -   5         ��Name$ nameTextBox��5      $
��Left=�6'   $��32��6B   $��
165,51,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��199��6�   �� 5   
   -   5        $ 
textBlock2��5      $
��Left=�6(   $��	63,95,0,0q�6C   $
��Wrap=�6V   $��Інгредієнт��6j   $	��Top=�6|   $��73��6�   �� 5   
   -   5        $ ingrAmountTextBox��5      $
��Left=�6-   $��22��6H   $��367,116,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $��70��6�   �� 5   
   -   5        $ 
textBlock3��5      $
��Left=�6(   $��
378,95,0,0q�6C   $
��Wrap=�6W   $��Кількість��6k   $	��Top=�6|   �� 5   
   -   5         ��Name$ ingredientComboBox��5      $
��Left=�6/   $��
34,116,0,0q�6J   $	��Top=�6^   $	��137��6v    �� DisplayMemberPath$
 name��6�    �� SelectedValuePath$ id��6�    �� SelectedValue 6�   �� *id+6�   �� 5   
   -   5        	 ��Name$	 saveBtn��5      $��Зберегти��6"   $
��Left=�65   $��254,389,0,0q�6P   $	��Top=�6e   $	��110��6}   $��33��6�   �� 5   
   -   5        $	 addIngredient��5      $��Додати��6(   $
��Left=�69   $��497,116,0,0q�6T   $	��Top=�6i   $��59��6�   $��22��6�   6�   �� 5   
   -	   5        $ textBlock2_Copy��5      $
��Left=�6-   $��
210,95,0,0q�6H   $
��Wrap=�6\   $+��%Одиниця вимірювання��6p   $	��Top=�6�   $	��135��6�   $��23��6�   �� 5   
   -
   5        $ unitComboBox��5      $
��Left=�6)   $��243,116,0,0q�6D   $	��Top=�6Y   $��59��6q   $
 name��6|   $ id��6�    6�   �� *id+6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 IngredientsGrid��5         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   "   VerticalScrollBarVisibility$
 Auto=�6q   $��
0,166,0,70q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Інгредієнт��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
ingredient+  5      $ Кількість��6%    68   �� *count+  5      $+ %Одиниці вимірювання��6%    6B   �� *unit+4  .System.Windows.Controls.DataGridTemplateColumn  5         HeaderTemplate 5      �� 5      .R�5      �� $��Дії��6(   5         CellTemplate 5      �� 5       .R�5!      ��  �� Orientation$ 
Horizontal=�6)   .+�5"   "   �� $	 	deleteBtn��6)   -   5        $��Видалити��5"   <   6O   5#      5$      5&      5(      �� 5)   
   -   5        $ 
textBlock1��5)      $
��Left=�6(   $��	74,60,0,0q�6C   $
��Wrap=�6V   $��Назва страви��6j   $	��Top=�6~   5*      5+      