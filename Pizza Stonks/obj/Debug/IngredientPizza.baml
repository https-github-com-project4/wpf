   M S B A M L   `   `   `  ����G  CPizza Stonks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Pizza_StonksPizza_Stonks  5   	   "    Pizza_Stonks.IngredientPizza   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Pizza_Stonks     5   	     � Title$&   Ingrediënten op pizza toevoegen��5      $	��500��63   $	��850��6@   $��15(�6L   $��
Constantia)�6Z    � WindowStartupLocation$ CenterScreen=�6r   .��5	      � ��5
   
   �� 5       �� ImageSource$ /images/pizzaa.jpg��6   6<   .+�5   
   � 
������� J� Opacity$
 0.75Q�6"   $
��20pxq�61    � ColumnDefinitions 5      �� 5      $��1* �6#   60   �� 5      $
��0.5* �6#   �� 5      $��1* �6#   60    � RowDefinitions 5      �� 5      $��1* �6    6.   �� 5      $��1* �6    6.   �� 5      $��1* �6    6.   .+�5      � $��0��6   $��0��6$    � DataContext 61   �� *Pizzas+.+�5      �� $��30(�6   $��0��6&   ��63   �� *Name+5      �� 5       -   5         ��Name$ lvIngredients��5       $��1��6.   $��0��6>   $��2��6K   ��5!      �� *Ingredients+ �� SelectedItem 5"      �� *SelectedIngredient+��5$      �� 5%      .R�5&      �� 	 �� Orientation$	 
Horizontal=�6%   .+�5(      �� 
 ��Name$

 Name��6(   $	��100��6L   ��66   �� *Name+6L   �� 5)      Prijs:60   �� 5*      $��5��6(   
������ 62   �� 5+      $
 Price��6(   $��50��6N   ��67   �� *Price+6N   �� 5,      $��5��6(   
������ 63   5.      50      53      �� 54      $��0��6   $��1��6'   $��2��64   ��55      �� *IngredientsInPizzas+��58      �� 59      .R�5:      �� $	 
Horizontal=�6%   .+�5<      �� $

 name��6(   $	��100��6M   ��67   �� *Name+6M   �� 5=       ��Name$ btDelete��6%   -   5        .��5=   N   	verwijder6Y   5@      5B      5E      �� 5F      -   5        $��2��5F      .��6:   	toevoegen6E   5H      5I      5J      