   M S B A M L   `   `   `  ����D  @CarRental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CarRental.ViewsCarRental.Views  5      ,    &CarRental.Views.ListForReservationView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CarRental.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��List for reservation��6    
  Header#��[  5      $��Center=�5      $��Center=�5      � 5   
   $��1��6   $��0,10,0,0q�6     5      �� 5      $
��auto �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5!      �� $��0��6   $��0��6%   $��
Start Date��65   (  "System.Windows.Controls.DatePicker  5"      $��1��6   $��0��6&   $��0,10,0,0q�66      SelectedDate 6H   �� *	StartDate+ �� UpdateSourceTrigger$ PropertyChanged=��� 5$      $��0��6   $��1��6%   $��End Date��65   $��40,0,0,0q�6E     5%      $��1��6   $��1��6&   $��	40,10,0,0q�66    6I   �� *	EndDate+$ PropertyChanged=�5&      �� 5(   
   $��2��6   $��0,25,0,0q�6    $	��170��6�   ��62   �� *CarsToReservation+ �� SelectedItem 6\   �� *SelectedCar+��5)      �� 5*       �� 
TargetType" ��6   .�5+      ��  �� Property � �� �� Value$ Stretch=�6C   5,       �� View 5.      �� 5/      .P�50      �� $��Car ID��6%   	 �� CellTemplate	 51      �� 52      .R�53   "   �� $��Center=�6,   ��6I   �� *CarID+54      56      �� 58      $��Car Type��6%   	 59      �� 5:      .R�5;   "   �� $��Center=�6,   
 �� Padding$
 0,0,20,0q�6I   ��6\   �� *	CarType+5<      5>      �� 5@      $��	Car Color��6%   	 5A      �� 5B      .R�5C   "   �� $��Center=�6,   $
 0,0,20,0q�6I   ��6\   �� *
CarColor+5D      5F      5G      5I      � 5K   
   $��3��6    5L      �� 5M      $��* �6#   �� 5N      $��* �6#   �� 5O      $��* �6#   .+�5R      �� $��0��6   $��5,10,0,0q�6)   .+�5S      �� $��Customer name��6   $��14(�61   �� 5T      ��6   �� *
Username+$ PropertyChanged=�5U      �� 5W      $��1��6   $��	30,10,0,0q�6)   .+�5X      �� $��Customer ID��6   $��14(�6/   �� 5Y      ��6   �� *UserID+$ PropertyChanged=�5Z      �� 5\      $��2��6   .+�5]      �� $��Reservation��6   $��14(�6W   $��	30,20,0,0q�6e   ��60   �� *ReservationCommand+6e   �� 5^      $��Cancel��6   $��14(�6M   $��	30,10,0,0q�6[   ��6+   �� *CancelCommand+6[   5_      5`      5b      5c      