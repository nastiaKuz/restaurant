   M S B A M L   `   `   `  ����C  ?wpf-test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:wpf_test.chefwpf_test.chef  5   	   #    wpf_test.chef.IngredientsList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:wpf_test.chef     5   	     � Title$9  3Підтвердження приготування��5   	    � WindowStartupLocation$ CenterScreen=�6,   $	��480��6Q   $	��500��6^   $��Corbel)�6j   $��14(�6~   .��5
      � $��0,0,0,-1q�6   .+�5   
   �� $��10,10,85,409q�6   �� 6+   $=�7Використати такі інгредієнти:��6/   6W   �� 5   
    �� IsCancel . $
��Ні��6!   $��385,280,22,139q�6.   �� 5   
   -   5         �� 	IsDefault . $��Так��5   7   $��295,280,112,139q�6E   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ IngredientsGrid��5         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   "   VerticalScrollBarVisibility$
 Auto=�6q   $��10,57,20,176q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Назва��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *ingr+  5      $	 Кількість��6%   
 68   �� *count+  5      $!	 Одиниця виміру��6%   
 6=   �� *unit+5      5      5      