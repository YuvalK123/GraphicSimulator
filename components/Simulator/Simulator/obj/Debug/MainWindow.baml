   M S B A M L   `   `   `  ����D  @Simulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Simulator.ControlsSimulator.Controls  5   	   K*clr-namespace:Simulator.Controls.SteeringsSimulator.Controls.Steerings  5   	   I)clr-namespace:Simulator.Controls.JoystickSimulator.Controls.Joystick  5   	   ?$clr-namespace:Simulator.Controls.MapSimulator.Controls.Map  5	   	   %clr-namespace:Simulator	Simulator  5
   	       Simulator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5controls clr-namespace:Simulator.Controls     5   	   @	steerings*clr-namespace:Simulator.Controls.Steerings     5   	   >joystick)clr-namespace:Simulator.Controls.Joystick     5   	   4map$clr-namespace:Simulator.Controls.Map     5	   	   )localclr-namespace:Simulator     5
   	     � Title$  
MainWindow��5   	   $	��750��6   $
��1333��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   (� $��1��6   $��1��6"   $��2��6/   .��5          Simulator.Controls.Map.Map  -   5          Name$	 map��5      $	��240��6#   5      (� 5   
   $��0��6   $��1��6   $	��100��6/   ��6<   �� *Width+.��5          Simulator.Controls.Client  -   5          Name$ c��5       5!      (� 5"   
   $��1��6   $��1��6"   $	��200��6/   $��602.375,0,72,111.25q�6<   $��2��6Y   .��5#      ,   &Simulator.Controls.Steerings.Steerings  -   5          Name$ 	steerings��5#   "   $��921.412��65   5$      .   (Simulator.Controls.Joystick.MainJoystick  5%   
   -   5          Name$ joystick��5%       $��1��62   $��1��6B   $��571.375,225.247,0,86.003q�6O   $
��Left=�6q   $��701.814��6�   $��2��6�   $��2��6�   5&      5'      