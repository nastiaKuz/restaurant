   M S B A M L   `   `   `  ����C  ?wpf-test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:wpf_test.chefwpf_test.chef  5   	       wpf_test.chef.ShowRecipe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:wpf_test.chef     5   	     � Title$)  #Переглянути рецепт��5   	   $	��410��6$   $	��542��61    � WindowStartupLocation$ CenterScreen=�6=   $��Corbel)�6b   $��14(�6v   .��5	      � .+�5
   
   �� -   5         ��Name$ nameTextBlock��5
      $
��Left=�6+   $��	10,10,0,0q�6F   $
��Wrap=�6Y   $��Рецепт��6m   $	��Top=�6{   $��20(�6�   $	��514��6�    �� TextAlignment$ Center=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ IngredientsGrid��5         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   "   VerticalScrollBarVisibility$
 Auto=�6q   $��	0,61,0,89q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Інгредієнт��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 69   �� *
ingredient+  5      $	 Кількість��6%   
 68   �� *count+  5      $+	 %Одиниці вимірювання��6%   
 6B   �� *unit+5      �� 5   
   -   5         ��Name$ 	updateBtn��5      $��Редагувати��6$   $��393,320,10,19q�6Q   5      5      