   M S B A M L   `   `   `  ����K  GVaccineInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:VaccineInventory.ConvertersVaccineInventory.Converters  5      $    VaccineInventory.Views.Patient   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      S OPrism.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59Z VPrism.DryIoc.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      3l)clr-namespace:VaccineInventory.Converters   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5      �  � 	Resources 5   
   .  (VaccineInventory.Converters.SexConverter   SexConverterKey��%   &	          5	      6   5
       � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6   .+�5   
   �� $��20(�6   $��1��6"   $��1��62   ��6?   �� *Title+�� 5   
   $��15(�6   $��1��6"   $��2��62   $��Center=�6?   ��6Z   �� *	Message+��6s   �� *MessageColor+�� 5   
   $��1��6   $��2��6!   $��25��6.   $��Right=�6:   $
��0 10q�6V   ��6d   �� *SaveButtonClick+.��6�   Add Patient6�   &   System.Windows.Controls.DataGrid  5   
   $��1��6   $��3��6#      AutoGenerateColumns$ False��60      
IsReadOnly$
 True��6L      SelectionMode$ Single=�6^   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5      ��68   �� *PatientList+ �� SelectedItem 6\   �� *SelectedPatient+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
First Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *	FirstName+  5      $
 	Last Name��6%   $ * 68    6B   �� *
LastName+  5      $
 Middle Name��6%   $ * 6:    6D   �� *
MiddleName+  5       $
 Birthday��6%   $ * 67    6A   �� *
Birthday+ �� StringFormat$ {0:MM/dd/yy}��  5!      $
 Contact#��6%   $ * 67    6A   �� *	ContactNo+  5"      $	
 Sex��6%   $ * 62    6<   �� *Sex+4  .System.Windows.Controls.DataGridTemplateColumn  5#      $ * 6)      CellTemplate 5$      �� 5%      .R�5&      �� $
��Edit��6%   ��64   ��  �� Path$ DataContext.GetSelected� �� RelativeSource ��  �� AncestorType"  5(      5*        5+      $ * 6)    5,      �� 5-      .R�5.      �� $��Delete��6%   ��66   �� $# DataContext.DeleteButtonClick� �� "  50      52      54      55      56      