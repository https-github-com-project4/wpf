   M S B A M L   `   `   `  ����G  CPizza Stonks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Pizza_StonksPizza_Stonks  5   	       Pizza_Stonks.Ingredient   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Pizza_Stonks     5   	     � Title$  Ingrediënten��5      $	��450��6!   $	��800��6.   $��15(�6:   $��
Constantia)�6H   .��5	      � ��5
   
   �� 5       �� ImageSource$ /images/pizzaa.jpg��6   6<   .+�5   
   � 
������� J� Opacity$
 0.75Q�6"   $
��20pxq�61    � ColumnDefinitions 5      �� 5      $��1* �6#   60   �� 5      $
��1.7* �6#   62   �� 5      $��1* �6#   60    � RowDefinitions 5      �� 5      $��1* �6    6.   �� 5      $��1* �6    6.   �� 5      $
��1.2* �6    60   .+�5      �� -   5         ��Name$ lvIngredients��5      $��1��6.   $��0��6>   $��2��6K   ��5      �� *Ingredients+ �� SelectedItem 5      �� *SelectedIngredient+��5      �� 5       .R�5!      ��  �� Orientation$ 
Horizontal=�6%   .+�5"      ��  ��Name$ Id��6(   $��50��6I   ��65   �� *Id+6I   �� 5#      Ingredienten:67   �� 5$      $��5��6(   
������ 62   �� 5%      $
 Name��6(   $	��100��6L   ��66   �� *Name+6L   �� 5&      Prijs:60   �� 5'      $��5��6(   
������ 62   �� 5(      $ Price��6(   $��50��6N   ��67   �� *Price+6N   �� 5)      $��5��6(   
������ 63   5+      5-      50      �� 51      $��3��6   $��1��6&   $ Vertical=�66   .+�53      �� $��Geselecteerde ingrediënt��6   6>   �� 54      -   5        $ selectedIngr��54      64   �� 55      -   5        	 ��Name$	 delete��55      $��0,5,0,5q�6*   .��6R   *(Verwijder het geselecteeerde ingrediënt6{   �� 56      -   5        $	 btAdd��56      $��0,5,0,5q�6(   .��6O   Ingrediënt toevoegen6e   �� 57      -   5        $	 btUpdate��57      $��0,5,0,5q�6+   .��6]   wijzig6e   58      59      5;      5<      