   M S B A M L   `   `   `  ����  AutoCompletion,    &AI_SAC.AutoCompletion.View.Suggestions   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  MySuggestions��5   "   $	��425��6	   $	��475��6   .��5      � $��15q�6    � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5	   
   �� 5
      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   �� 5      $��30 �6   .+�5   
   �� $��0,0,0,0q�6   $��Stretch=�6%   $
��Left=�6A   $��0��6\   $ ��Current registered Input: ��6l   �� 5   
   $��	150,0,0,0q�6   $��Stretch=�6'   $
��Left=�6C   $��0��6^   $
��Bold"�6�   ��6n   �� *CurrentString+ �� ElementName$ MySuggestions��6�   �� 5   
   $��1��6   .��5      �� ��6   �� *Items+$ MySuggestions����5      �� 5      .R�5      �  5      �� 5   "   $	��150 �63   �� 5   "   $��10 �63   �� 5   "   $��* �63   �� 5   "   $��10 �63   �� 5   "   $��50 �63   .+�5      �� -   5        $��0��5   %   
 � Tag 65   �� ��6E   �� *	Trigger+6a   �� 5      $��2��6(   $��Stretch=�6T   ��68   �� *
Completion+6T   �� 5      $��4��6'   {�.   d� 	IsChecked 67   �� *IsReplacing+6Y   5       5!      5#      5$      �� 5%   
   -   5        $��
ClearInput��5%   o   $��2��6   $L��FAn Error Happened? Click here to clear registered input and try again.��6   6�   �� 5&   
   -   5        $��ClearInputRemove��5&   H   $��3��6   $%��Remove current registered Input��6   6`   5'      5(      