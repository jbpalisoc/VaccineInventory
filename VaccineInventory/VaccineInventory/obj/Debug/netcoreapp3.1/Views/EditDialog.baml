   M S B A M L   `   `   `  ����K  GVaccineInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:VaccineInventory.ConvertersVaccineInventory.Converters  5      '    !VaccineInventory.Views.EditDialog   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      S OPrism.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59Z VPrism.DryIoc.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      3l)clr-namespace:VaccineInventory.Converters   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      $	��300��5      $
��auto��6   #  Prism.Services.Dialogs.Dialog   WindowStyle 5      �� 5	   
    �� 
TargetType" �6   .�5
      ��  �� Property �@ WindowStartupLocation �� Value$ CenterScreen=�6C   �� 5       �@�
ResizeMode$ NoResize=�6+   �� 5       �@�ShowInTaskbar$ False��6.   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   5      .��5      � -   5         �Name$ 
LayoutRoot��5      $��5q�6    � 	Resources 5   
   .  (VaccineInventory.Converters.SexConverter   SexConverterKey��%   &	          5      6   5       � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $��5 �6   .+�5%   
   �� $��5,0,0,0q�6   $��1��6%   $��
First Name��62   �� 5&   
   $��2��6   $��5q�6   $��25��6*   ��66   �� *	FirstName+�� 5'   
   $��5,0,0,0q�6   $��3��6%   $��Middle Name��62   �� 5(   
   $��4��6   $��5q�6   $��25��6*   ��66   �� *
MiddleName+�� 5)   
   $��5,0,0,0q�6   $��5��6%   $��	Last Name��62   �� 5*   
   $��6��6   $��5q�6   $��25��6*   ��66   �� *
LastName+�� 5+   
   $��5,0,0,0q�6   $��7��6%   $��Birthday��62   (  "System.Windows.Controls.DatePicker  5,   
   $��8��6   $��5q�6"   $��25��6-      Text 69   �� *
Birthday+	 �� Mode$	 TwoWay=��� 5-   
   $��5,0,0,0q�6   $��9��6%   $��Contact#��62   �� 5.   
   $��10��6   $��5q�6    $��25��6+   ��67   �� *	ContactNo+�� 5/   
   $��5,0,0,0q�6   $��11��6%   $	��Sex��63   �� 50   
   $��12��6   $��5q�6#   $��3��6.   
 �� Orientation$
 
Horizontal=�6>   .+�51      	� $��5q�6   $
��Male��6�    d� 	IsChecked 6%   �� *Sex+ �� 	Converter# [   �� ConverterParameter$ M��6�   	� 52      $��5q�6   $��Female��6�    6%   �� *Sex+# [  $ F��6�   53      �� 54   
   $��13��6   $��0 10 0 0q�6#   $
 
Horizontal=�65   $��Right=�6N   .+�55      �� $
��true��6;   $��Update��6S   $��75��6d   $��25��6o   $��Right=�6{   $��5q�6�    �� 	IsDefault$
 True��6�   ��6   �� *UpdateButtonClick+6�   �� 56      $��false��6<   $��Cancel��6U   $��75��6f   $��25��6q   $��Right=�6}   $��0,5,5,5q�6�   $
 True��6�   ��6   �� *CloseDialogCommand+6�   57      58      59      