   M S B A M L   `   `   `  ����D  @RecipeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:RecipeWPF	RecipeWPF  5   	       RecipeWPF.Display   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:RecipeWPF     5   	     � Title$  Display��5   	   $	��735��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   $	��464��6*   .+�5   
   �� $��0��6   $
��Left=�6!   $��
258,0,0,21q�6<   $'��!Displaying Recipe and Description��6P   $��18(�6y   $
��Bold"�6�   $	��288��6�   �� 5   
   $��22,38,18,47q�6   $
��Wrap=�6)   $��14(�6=   $��Italic$�6K   $��2��6^   �� 6q    � Language$ en-za�6u   $	�			��6�   �� 6�   $E�?You can choose any three Recipe Ingredients you want to capture��6�   6�   �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��20,20,20,20q�6;   .+�5      �� $��Ingredient Name��6   $��Center=�6.   $	��120��6I   �� 5      -   5         ��Name$ displayIngredientName��5      $	��200��65   .��6A   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ 	10,5,10,5q�63   �� 5       � ��$ 5q�64   �� 5       � ��$ Center=�6>   �� 5       � ��$ 16(�65   �� 5       � ��$ 1q�6<   �� 5        � �� �#CCCCCC68   �� 5!       � �� �#F5F5F567   �� 5"       � ��$	 120��65   5#      .��5$   !   5%      5'      �� 5)   
   -   5         ��Name$ SubmitDisplay��5)      $��3��6   $��Submit��65   $
��Left=�6F   $��	229,0,0,0q�6a   $	��115��6t   $��45��6�   ��5*      �� 5+      " ��6   .�5,      ��  � ��$ 
10,10,10,0q�6/   �� 5-       � ��$ 10q�60   �� 5.       � ��$ Center=�6:   �� 5/       � ��$ 16(�61   �� 50       � �� �#0078D763   �� 51       � ��
 �����63   �� 52       � ��$ 0q�68   �� 53       � ��$	 120��61   54      56      �� 59   
   $��4��6   
�������$��1q�66   $��20,22,20,20q�6J   ._�5:      �� -   5        	 ��Name$	 displayTextBox��5:      $��10q�60   $
��Wrap=�6<   $	��700��6P   $	��380��6\   5;      �� 5=   
   $��1��6   $��4��6"   $ Vertical=�63   $��Right=�6J   $��
0,20,20,20q�6f   $	��296��6z   .+�5?      �� .+�5@      �� $��
Food Group��6   $��14(�6-   �� 5A      -   5        
 ��Name$
 comboListValues��5A      $
��Left=�64   $	��200��6O   $	��0,5q�6[   ��5B      �� 5C      " ��6    .�5D      ��  � ��$ 	10,5,10,5q�67   �� 5E       � ��$ 5q�68   �� 5F       � ��$ Center=�6B   �� 5G       � ��$ 16(�69   �� 5H       � ��$ 1q�6@   �� 5I       � �� �#CCCCCC6<   �� 5J       � �� �#F5F5F56;   �� 5K       � ��$	 120��69   5L      .@�5N      �� $��Starchy foods��6#   �� 5O      $��Vegetables and fruits��6#   �� 5P      $'��!Dry beans, peas, lentils and soya��6#   �� 5Q      $"��Chicken, fish, meat and eggs��6#   �� 5R      $��Milk and dairy products��6#   �� 5S      $��Fats and oil��6#   �� 5T      $��Water��6#   5U      5W      �� 5Y      $��	0,20,80,0q�6   .+�5Z      �� $��Maximum Calories��6   $��14(�63   �� 5[      -   5        $ MaxiCal��5[      $	��197��6+   .��67   ��5\      �� 5]      " ��6    .�5^      ��  � ��$ 	10,5,10,5q�67   �� 5_       � ��$ 5q�68   �� 5`       � ��$ Center=�6B   �� 5a       � ��$ 16(�69   �� 5b       � ��$ 1q�6@   �� 5c       � �� �#CCCCCC6<   �� 5d       � �� �#F5F5F56;   �� 5e       � ��$	 120��69   5f      .��5g   %   5h      5j      5k      5l      5p      