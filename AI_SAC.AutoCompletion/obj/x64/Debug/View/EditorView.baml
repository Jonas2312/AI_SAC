   M S B A M L   `   `   `  ����I  EAutoCompletion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AI_SAC.AutoCompletion.ViewAI_SAC.AutoCompletion.View  5      +    %AI_SAC.AutoCompletion.View.EditorView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:AI_SAC.AutoCompletion.View     5      .��5	      � -   5        $
��Grid��5	        � ColumnDefinitions  5
   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��75 �6   �� 5      $��55 �6   .+�5   
   �� -   5        $��NewDatabase��5      $��0��6$   $	��125��61   $��50��6=   $��	25,10,0,0q�6I   $	��Top=�6\   $
��Left=�6t   .��5      �� Create new Database5      5      �� 5   
   -   5        $��LoadDatabase��5      $��0��6%   $	��125��62   $��50��6>   $��
163,10,0,0q�6J   $	��Top=�6^   $
��Left=�6v   .��5      �� Load existing database5      5      �� 5"   
   -   5        $��AddItemButton��5"      $��0��6&   $	��125��63   $��50��6?   $��
300,10,0,0q�6K   $	��Top=�6_   $
��Left=�6w   .��5#      �� 
Add Item5%      5&      �� 5(   
   -   5        $
��Help��5(      $��0��6   $	��125��6*   $��50��66   $��
437,10,0,0q�6B   $	��Top=�6V   $
��Left=�6n   .��5)      �� Help5+      5,      �� 5.   
   -   5        $��SearchLabel��5.      $
��Left=�6#   $��0��6>   $��
570,20,0,0q�6K   $��Search for:��6_   6w   �� 5/   
   -   5        $��SearchTextBox��5/      $
��Left=�6'   $	��Top=�6B   $��0��6Z   $	��150��6g   $��25��6s   $��
645,20,0,0q�6   6�   �� 51   
   $��25,0,0,0q�6   $��Stretch=�6&   $
��Left=�6B   $��1��6]   $ ��Current registered Input: ��6j   �� 52   
   $��	175,0,0,0q�6   $��Stretch=�6'   $
��Left=�6C   $��1��6^   $
��Bold"�6�   ��6k   �� *.,HookFeedController.keyAnalyzer.CurrentString+6�   �� 54   
   -   5        $��StartProgramButton��54      $��3��6+   $	��250��68   $��75��6D   $��0,0,0,0q�6P   $	��Top=�6a   $
��Left=�6y   ��55      �� 56       �� Color$
 Blue��6"    �� Opacity$	 0.3Q�6/   .��58      �� $��20(�6   Start Program5:      5;      �� 5=   
   -	   5        $��StopProgramButton��5=      $��3��6*   $	��600��67   $��75��6C   $��	250,0,0,0q�6O   $	��Top=�6b   $
��Left=�6z   ��5>      �� 5?      $	 Red��6"   $	 0.6Q�6.   .��5A      �� $��32(�6   Stop Program5C      5D      �� 5F   
   -
   5        $��ProgramRunningText��5F      $
��Left=�6.   $��4��6I   
���  ��$��40(�6g    AutoCompletion Program Running5H      �� 5J   
   -   5        $��ProgramNotRunningText��5J      $
��Left=�61   $��4��6L   
����  �$��40(�6k   $"AutoCompletion Program NOT Running5L      /   )AI_SAC.AutoCompletion.View.ExcelTableView  5N   
   -   5          Name$ XMLDataGrid��5N   ,   $��2��6    � DataContext 6A   �� *ExcelTableViewModel+5P      5Q      5R      