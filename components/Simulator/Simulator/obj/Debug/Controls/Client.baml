   M S B A M L   `   `   `  ����D  @Simulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Simulator.ControlsSimulator.Controls  5          Simulator.Controls.Client   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Simulator.Controls     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��1��6   $��1��6!   $
��Port��61   $��18(�6=   $��5q�6K   �� 5   
   $
��10,2q�6   
�������$��36(�62   $��1��6@   $��2��6M   ��6]   ��  �� Path$
 port� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��1��6   $��3��6!   $	��IP ��61   $��18(�6<   $��5q�6J   �� 5   
   $
��10,2q�6   
�������$��36(�62   $��1��6@   $��4��6M   ��6]   �� $ ip�$ PropertyChanged=��� 5   
   -   5        $��Connect��5      $��1��6#   $��5��60   $��20(�6@   $	��120��6N   $��40��6Z   ���	#FF79FF796}   �� 5   
   -   5        $��
Disconnect��5      $��2��6&   $��5��63   $��20(�6C   $	��120��6Q   $��40��6]   ���	#FFE95D5D6�   �� 5    
   $��5��6Q   ��6   �� *status+$ PropertyChanged=�6Q   5!      5"      