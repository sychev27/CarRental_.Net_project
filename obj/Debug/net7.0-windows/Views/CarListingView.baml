   M S B A M L   `   `   `  ����D  @CarRental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CarRental.ViewsCarRental.Views  5      ;"clr-namespace:CarRental.ConvertersCarRental.Converters  6:   P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl 6p   $    CarRental.Views.CarListingView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CarRental.Views     5      9
converters"clr-namespace:CarRental.Converters     6:   dloadingspinnercontrolBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     6p     � 	Resources  5	      >   8CarRental.Converters.InverseBooleanToVisibilityConverter '  #InverseBooleanToVisibilityConverter��%   &	          5
   
   69   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Car list��6    
 Header#��[ 5      $��Center=�5      $��Center=�5      � 5   
   $��1��6   $��0,25,0,0q�6   .+�5      *  $LoadingSpinnerControl.LoadingSpinner     	Thickness$ 5Q�5         Diameter$ 80Q�5         Color
 �����   	IsLoading 5      �� *	IsLoading+�� 5       $	��250��5"      ��5!      �� *Cars+y�5#      �� *	IsLoading+ �� 	Converter# [  ��5$      �� 5%       �� 
TargetType" ��6   .�5&      ��  �� Property � ��	 �� Value$	 Stretch=�6G   5'      
 �� View
 5)      �� 5*      .P�5+      �� $��Car ID��6)    �� CellTemplate 5,      �� 5-   "   .R�5.   &   �� $��Center=�60   ��6M   �� *CarID+5/   #   51      �� 53      $��Car Type��6)    54      �� 55   "   .R�56   &   �� $��Center=�60    �� Padding$ 0,0,20,0q�6M   ��6`   �� *	CarType+57   #   59      �� 5;      $��	Car Color��6)    5<      �� 5=   "   .R�5>   &   �� $��Center=�60   $ 0,0,20,0q�6M   ��6`   �� *
CarColor+5?   #   5A      5B      5D      5E      �� 5G   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��0,25,0,0q�6;   .+�5H      �� $��Add a new car��6:   ��6   �� *AddNewCarCommand+6:   �� 5I      $��Reservation a car��6?   $��30,0,0,0q�6[   ��6   �� *ReservationCarCommand+6[   �� 5J      $��Cancel��67   $��30,0,0,0q�6H   ��6   �� *CancelCommand+6H   5K      5L      5M      