   M S B A M L   `   `   `  ����C  ?wpf-test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:wpf_test.accountantwpf_test.accountant  5   	   (    "wpf_test.accountant.ProviderReport   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:wpf_test.accountant     5   	     � Title$  ProviderReport��5   	   $	��345��6    $��418.321��6-   $��Corbel)�6=   $��14(�6Q    � WindowStartupLocation$ CenterScreen=�6_   .��5	      � .+�5
   
   �� -   5         ��Name$ 	textBlock��5
      $
��Left=�6'   $��
182,10,0,0q�6B   $
��Wrap=�6V   $��Звіт��6j   $	��Top=�6v   $��20(�6�   �� 5   
   -   5        $ providerTextBlock��5      $
��Left=�6/   $��	45,65,0,0q�6J   $
��Wrap=�6]   $��Провайдер��6q   $	��Top=�6�   �� 5   
   -   5         ��Name$ providerTextBox��5      $
��Left=�6+   $��29��6F   $��
165,63,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��155��6�   �� 5   
   -   5        $ ingredientTextBlock��5      $
��Left=�61   $��
45,113,0,0q�6L   $
��Wrap=�6`   $��Інгредієнт��6t   $	��Top=�6�   �� 5   
   -   5        $ ingredientTextBox��5      $
��Left=�6-   $��29��6H   $��165,108,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��155��6�   �� 5   
   -   5        $ amountTextBlock��5      $
��Left=�6-   $��
45,166,0,0q�6H   $
��Wrap=�6\   $��Кількість��6p   $	��Top=�6�   �� 5   
   -   5        $ amountTextBox��5      $
��Left=�6)   $��29��6D   $��165,161,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��101��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5   
   -   5        $ priceTextBlock��5      $
��Left=�6,   $��
45,218,0,0q�6G   $
��Wrap=�6[   $��Ціна, грн��6o   $	��Top=�6�   �� 5   
   -	   5        $ priceTextBox��5      $
��Left=�6(   $��29��6C   $��165,213,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��101��6�   �� 5   
   -
   5         ��Name$ closeReportBtn��5      $��Закрити��6)   $
��Left=�6;   $��153,267,0,0q�6V   $	��Top=�6k   $	��113��6�   $��38��6�   6�   �� 5   
   -   5        $ unitsTextBlock��5      $
��Left=�6,   $��288,166,0,0q�6G   $
��Wrap=�6\   $��Кількість��6p   $	��Top=�6�   $��24��6�   $	��112��6�   5      5      