   M S B A M L   `   `   `  ����D  @CarRental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CarRental.ViewsCarRental.Views  5      3clr-namespace:CarRental.ModelsCarRental.Models  5      #    CarRental.Views.CarAddingView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CarRental.Views     5      .mdsclr-namespace:CarRental.Models     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Adding a new car��6    
  Header#��[  5      $��Center=�5      $��Center=�5      � 5   
   $��1��6   $
��5,10q�6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $
��auto �6#   .+�5      �   5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   .+�5"      �   5#      �� 5$      $
��auto �6(   �� 5%      $
��auto �6(   .+�5(      �� $��Car type��6    $��20(�60   $��20,10q�6>   �� 5)      $��1��6   $��15(�6w   $
��20.5q�6�   ��6,   �� *
AllTypes+ �� SelectedItem 6M   �� *SelectedCarType+6�   5*      � 5,      $��1��6     5-      �� 5.      $
��auto �6(   �� 5/      $
��auto �6(   .+�52      �� $��Car ID��6    $��20(�6.   $��20,10q�6<   �� 53      $��1��6   $��15(�6g   $��20.10q�6u   ��6+   �� *CarID+ �� UpdateSourceTrigger$ PropertyChanged=�6u   54      � 56      $��2��6     57      �� 58      $
��auto �6(   �� 59      $
��auto �6(   .+�5<      �� $��	Car color��6    $��20(�61   $��20,10q�6?   �� 5=      $��1��6   $��15(�6y   $
��20.5q�6�   ��6,   �� *	AllColors+ 6N   �� *SelectedCarColor+6�   5>      5?      �� 5A      $��1��6   .+�5B      �� $��Add car��6   $	��120��6Q   $��30,130q�6]   $��Center=�6m   ��6,   �� *AddNewCarCommand+6m   �� 5C      $��Cancel��6   $	��120��6M   $��Center=�6Y   ��6+   �� *CancelCommand+6Y   5D      5F      5G      5H      