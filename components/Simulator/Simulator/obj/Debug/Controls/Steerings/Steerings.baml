   M S B A M L   `   `   `  ����D  @Simulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Simulator.Controls.SteeringsSimulator.Controls.Steerings  5      ,    &Simulator.Controls.Steerings.Steerings   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Simulator.Controls.Steerings     5      .��5	      � -   5          �Name$  
gridObject��5	      
������� � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��1��6!   $��30(�61   $��indicated-heading-deg ��6?   $
�� 0,3q�6]   �� 5   
   $��2��6   $��1��6!   $��30(�61   $#��gps_indicated-vertical-speed ��6?   $
�� 0,3q�6d   �� 5   
   $��3��6   $��1��6!   $��30(�61   $%��gps_indicated-ground-speed-kt  ��6?   $
�� 0,3q�6f   �� 5   
   $��4��6   $��1��6!   $��30(�61   $,��&airspeed-indicator_indicated-speed-kt ��6?   $
�� 0,3q�6m   �� 5   
   $��5��6   $��1��6!   $��30(�61   $ ��gps_indicated-altitude-ft ��6?   $
�� 0,3q�6a   �� 5    
   $��6��6   $��1��6!   $��30(�61   $+��%attitude-indicator_internal-roll-deg ��6?   $
�� 0,3q�6l   �� 5!   
   $��7��6   $��1��6!   $��30(�61   $,��&attitude-indicator_internal-pitch-deg ��6?   $
�� 0,3q�6m   �� 5"   
   $��8��6   $��1��6!   $��30(�61   $&�� altimeter_indicated-altitude-ft ��6?   $
�� 0,3q�6g   �� 5$   
   $��1��6   $��2��6!   $��20(�61   $
�� 0,3q�6�   ��6@   ��  �� Path$ VM_headingDeg� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5%   
   $��2��6   $��2��6!   $��20(�61   $
�� 0,3q�6�   ��6@   �� $ VM_verticalSpeed�$ PropertyChanged=�6�   �� 5&   
   $��3��6   $��2��6!   $��20(�61   $
�� 0,3q�6�   ��6@   �� $ VM_groundSpeed�$ PropertyChanged=�6�   �� 5'   
   $��4��6   $��2��6!   $��20(�61   $
�� 0,3q�6�   ��6@   �� $ VM_indicatedSpeed�$ PropertyChanged=�6�   �� 5(   
   $��5��6   $��2��6!   $��20(�61   $
�� 0,3q�6�   ��6@   �� $ VM_gpsAltitude�$ PropertyChanged=�6�   �� 5)   
   $��6��6   $��2��6!   $��20(�61   $
�� 0,3q�6�   ��6@   �� $ VM_internalRollDeg�$ PropertyChanged=�6�   �� 5*   
   $��7��6   $��2��6!   $��20(�61   $
�� 0,3q�6�   ��6@   �� $ VM_internalPitchDeg�$ PropertyChanged=�6�   �� 5+   
   $��8��6   $��2��6!   $��20(�61   $
�� 0,3q�6�   ��6@   �� $ VM_altimeterAltitude�$ PropertyChanged=�$ OneWay=�6�   5,      5-      