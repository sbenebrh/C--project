   M S B A M L   `   `   `  ����C  ?PL_UI2-5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PL_UI2PL_UI2  5   	   ? ;BE-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BE;assembly=BE-1BE 5   	       PL_UI2.ADDEmployer   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PL_UI2     5   	   -BEclr-namespace:BE;assembly=BE-1     5   	     � Title$  ADDEmployer��5	   	    � WindowState$ 	Maximized=�6   $	��654��65   $��1198.5��6B   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��25* �6   �� 5      $	��94* �6    � RowDefinitions 5   
   �� 5      $
��477* �6   �� 5      $	��50* �6   �� 5      $	��66* �6   �� 5      $	��79* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
DataGrid_s��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6&      
IsReadOnly . $��Stretch=�6H   $
��Left=�6d   $��4,10,0,0q�6   $	��926��6�   $��1��6�   �� 5   
   -   5         ��Name$ 	addButton��5      $	��Add��6%   $��30(�64   $��52,0,0,3q�6[   $��2��6m   $
��Left=�6z   $	��108��6�   ��5      �� 5       �� Triggers 5      �� 5       �� Binding 6&   �� 	 �� ElementName$	 companyIDTextBox��
 �� Path$

 Text� �� Value 06b   .a�5      ��  �� Property � {� �� Value .  6A   5      �� 5        6&   �� $	 adresseTextBox��$

 Text�  6`   .a�5!      ��  � {� .  6A   5"      �� 5#       6&   �� $	 firstNameTextBox��$

 Text�  6b   .a�5$      ��  � {� .  6A   5%      �� 5&       6&   �� $	 lastNameTextBox��$

 Text�  6a   .a�5'      ��  � {� .  6A   5(      �� 5)       6&   �� $	 numberEmployeeTextBox��$

 Text� 06g   .a�5*      ��  � {� .  6A   5+      �� 5,       6&   �� $	 phoneTextBox��$

 Text� 06^   .a�5-      ��  � {� .  6A   5.      51      53      � 55   
   -   5         �Name$ grid1��55      $
��Left=�6   $��	10,10,0,0q�69   $	��Top=�6L   $	��349��6d   $	��241��6q   $��2��6}    56      �� 57      $
��Auto �6#   �� 58      $
��Auto �6#    5:      �� 5;      $
��Auto �6    �� 5<      $
��Auto �6    �� 5=      $
��Auto �6    �� 5>      $
��Auto �6    �� 5?      $
��Auto �6    �� 5@      $
��Auto �6    �� 5A      $
��Auto �6    �� 5B      $
��Auto �6    �� 5C      $
��Auto �6    �� 5D      $
��Auto �6    �� 5E      $
��Auto �6    .+�5H      �� $��adresse:��6   
�������$��0��6:   $
��Left=�6J   $��3,0,0,3q�6e   $��2��6v   $��Center=�6�   $	��102��6�   �� 5I      -   5         ��Name$ adresseTextBox��5I      $��1��6.   $
��Left=�6>   $��24��6Y   $��3,0,0,5q�6e   $��2��6v   $��Center=�6�   $	��120��6�   ��6�   �� *	adresse+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   �� 5J      $��city:��6   
�������$��0��68   $
��Left=�6H   $��3,3,0,3q�6c   $��1��6t   $��Center=�6�   $	��102��6�   �� 5K      $��company ID:��6   
�������$��0��6=   $
��Left=�6M   $��3,2,0,4q�6h   $��Center=�6y   $	��102��6�   �� 5L      -   5        $ companyIDTextBox��5L      $��1��60   $
��Left=�6@   $��30��6[   $��3,2,0,0q�6g   $��Center=�6�   $	��120��6�   ��6x   �� *	companyID+$ TwoWay=� .  . 6�   �� 5O      $��creation Date:��6   $��0��6-   
�������$
��Left=�6P   $��3,3,0,3q�6k   $��4��6|   $��Center=�6�   $	��102��6�   (  "System.Windows.Controls.DatePicker  5P      -   5          Name$ creationDateDatePicker��5P      $��1��6;   $
��Left=�6K   $��3q�6f   $��4��6q   $��Center=�6�      SelectedDate 6~   �� *creationDate+$ TwoWay=� .  . 6�   �� 5Q      $��discipline:��6   $��0��6*   
�������$
��Left=�6M   $��3,3,0,3q�6h   $��5��6y   $��Center=�6�   $	��102��6�   �� 5R      -   5         ��Name$ disciplineComboBox��5R      $��1��63   $
��Left=�5T      $
��Auto��5U      $��3,7,0,3q�5V      $��5��6(   $��Center=�5W      $	��120��5X       �� SelectedItem 5S      �� *
discipline+5Y      �� 5[      $��first Name:��6   
�������$��0��6=   $
��Left=�6M   $��3,3,0,3q�6h   $��6��6y   $��Center=�6�   $	��102��6�   �� 5\      -   5        $ firstNameTextBox��5\      $��1��60   $
��Left=�6@   $��23��6[   $��3q�6g   $��6��6r   $��Center=�6�   $	��120��6�   ��6   �� *	firstName+$ TwoWay=� .  . 6�   �� 5]      $��is Private:��6   
�������$��0��6=   $
��Left=�6M   $��3,4,0,2q�6h   $��8��6y   $��Center=�6�   $	��102��6�   �� 5^      -	   5         ��Name$ isPrivateCheckBox��5^      $�� ��62   $��1��6=   $
��Left=�6M   $��	10,7,0,10q�6�   $��8��6�   $��Center=�6�    d� 	IsChecked 6h   �� *	isPrivate+$ TwoWay=� .  . 6�   �� 5_      $��
last Name:��6   
�������$��0��6<   $
��Left=�6L   $��3,2,0,4q�6g   $��7��6x   $��Center=�6�   $	��102��6�   $��26��6�   �� 5`      -
   5        $ lastNameTextBox��5`      $��1��6/   $
��Left=�6?   $��22��6Z   $��3,6,0,4q�6f   $��7��6w   $��Center=�6�   $	��120��6   ��6�   �� *
lastName+$ TwoWay=� .  . 6   �� 5a      $��number Employee:��6   
�������$��0��6B   $
��Left=�6R   $��3,3,0,3q�6m   $��9��6~   $��Center=�6�   $	��102��6�   �� 5b      -   5        $ numberEmployeeTextBox��5b      $��1��65   $
��Left=�6E   $��23��6`   $��3q�6l   $��9��6w   $��Center=�6�   $	��120��6  ��6�   �� *numberEmployee+$ TwoWay=� .  . 6  �� 5c      $��phone:��6   $��0��6%   
�������$
��Left=�6H   $��3,3,0,3q�6c   $��10��6t   $��Center=�6�   $	��102��6�   �� 5d      -   5        $ phoneTextBox��5d      $��1��6,   $
��Left=�6<   $��23��6W   $��3q�6c   $��10��6n   $��Center=�6�   $	��120��6�   ��6|   �� *phone+$ TwoWay=� .  . 6�   �� 5e      -   5        $ comboBox_city��5e      $��1��6.   $
��Left=�6>   $��4,5,0,0q�6Y   $��1��6j   $	��Top=�6w   $	��119��6�   5f      �� 5g   
   -   5        $��670,0,180,0q�5g      $��2��6<   $��1��6I   ��5h      �� 5i       �� Orientation$ 
Horizontal=�6   .+�5j      �� $��images/return.png��6   $��72��67   $��49��6B   5k      5m      ��5o   
   
� 5p      .��5q      �  � Color$ SkyBlue��6    � Offset$ 0.918Q�6/   � 5r      $ 
WhiteSmoke��6   5s      5u      5x      