   M S B A M L   `   `   `  ����G  CPizza Stonks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Pizza_StonksPizza_Stonks  5   	       Pizza_Stonks.pizzas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Pizza_Stonks     5   	   -   5          � Title$  pizzas��5   	   $	��500��6   $	��850��6%   $��15(�61   $��
Constantia)�6?    � WindowStartupLocation$ CenterScreen=�6W   .��5	      � ��5
   
   �� 5       �� ImageSource$ /images/pizzaa.jpg��6   6<   .+�5   
   � 
������� J� Opacity$
 0.75Q�6"   $
��20pxq�61    � ColumnDefinitions 5      �� 5      $��1* �6#   60   �� 5      �� 5      $��1* �6#   60    � RowDefinitions 5      �� 5      $��1* �6    6.   �� 5      $��1* �6    6.   �� 5      $��1* �6    6.   .+�5      �� -   5         ��Name$ lvpizza��5      $��1��6)   $��0��69   $��3��6F   ��5      �� *Pizza+ �� SelectedItem 5      �� *SelectedPizza+��5      �� 5       .R�5!      ��  �� Orientation$ 
Horizontal=�6%   .+�5"      �� $	��100��6>   ��6(   �� *Name+6>   �� 5#      $��50��6?   ��6(   �� *Price+6?   5$      5%      5'      �� 5(      $��3��6   $��1��6&   $ Vertical=�66   .+�5)      �� Geselecteerde pizza61   �� 5*      -   5        	 ��Name$	 tbSelectedPizza��5*      67   �� 5+      -   5        
 ��Name$
 deletePizza��5+      $��0,5,0,5q�6/   .��6[   " Verwijder de geselecteerde pizza6}   �� 5,      -   5        $
 
btAddPizza��5,      $��0,5,0,5q�6-   .��6Y   pizza toevoegen6j   �� 5-      -   5        $
 btUpdatePizza��5-      $��0,5,0,5q�60   .��6^   pizza wijzigen6n   5.      �� 5/      -   5        $
 	btAddIngr��5/      .��6@   Ingrediënt eraan toevoegen6\   50      52      53      