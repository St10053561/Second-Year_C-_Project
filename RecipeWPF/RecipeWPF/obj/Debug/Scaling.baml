   M S B A M L   `   `   `  ����D  @RecipeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:RecipeWPF	RecipeWPF  5   	       RecipeWPF.Scaling   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:RecipeWPF     5   	     � Title$  Scaling��5   	   $	��450��6   $	��800��6&   .��5	      �  J� RenderTransformOrigin$ 0.494,0.516&�6   .+�5
   
   �� $$��Ingredients Capture for Recipe��6   $
��Left=�69   $��235,4,0,388q�6T   $	��375��6i   $��24(�6u   $��42��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#      	Direction$	 320Q�61      ShadowDepth$ 2Q�6A      Opacity$	 0.5Q�6Q      
BlurRadius$ 4Q�6_   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&   	 �� EndPoint$	 0.5,1&�69   .��5      � 
 � Offset$
 0Q�6#    � Color$ 	#FF2B2B2B��6.   � 5      $
 1Q�6#   $ 	#FF909090��6.   5      5      �� 5   
   $��Center=�6   $��0,60,0,0q�61   $
��Wrap=�6C   $8��2Here you can add measurements for your ingredients��6W   $	��Top=�6�   $��14(�6�   $��Italic$�6�   �� 5   
   $��Center=�6   $��	0,120,0,0q�62   $	��Top=�6E   .+�5      �� $��
Half (1/2)��6   $��16(�6*   $
��Bold"�68   	� 5      -   5         	�Name$ HalfRadioButton��5      $��Apply Half Scaling��63   $
��10,5q�6P   $��Center=�6^    	� 	GroupName$ ScalingGroup��6y   5      �� 5   
   $��Center=�6   $��	0,190,0,0q�62   $	��Top=�6E   .+�5      �� $��Double (X2)��6   $��16(�6+   $
��Bold"�69   	� 5      -   5        $ DoubleRadioButton��5      $��Apply Double Scaling��65   $
��10,5q�6T   $��Center=�6b   $ ScalingGroup��6}   5      �� 5!   
   $��Center=�6   $��	0,260,0,0q�62   $	��Top=�6E   .+�5"      �� $��Triple (3X)��6   $��16(�6+   $
��Bold"�69   	� 5#      -   5        $ TripleRadioButton��5#      $��Apply Triple Scaling��65   $
��10,5q�6T   $��Center=�6b   $ ScalingGroup��6}   5$      �� 5'   
   -   5        $��Submit��5'      $��Center=�6"   $��	0,340,0,0q�6?   $	��Top=�6R   $	��100��6j   $��44��6v   ��5(      �� 5)       �� 
TargetType" ��6   .�5*      ��  �� Property � �� �� Value$ 
10,10,10,0q�6/   �� 5+       � ��$ 10q�60   �� 5,       � ��$ Center=�6:   �� 5-       � ��$ 16(�61   �� 5.       � �� �#0078D763   �� 5/       � ��
 �����63   �� 50       � ��$ 0q�68   �� 51       � ��$	 120��61   52      54      55      57      