   M S B A M L   `   `   `  ����C  ?PL_UI2-5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PL_UI2PL_UI2  5   	   !    PL_UI2.Contract_to_employer   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PL_UI2     5   	     � Title$  Contract_to_employer��5   	    � WindowState$ 	Maximized=�6&   $��343.985��6>   $��1202.986��6O   .��5	      � $��
0,0,0,-113q�6    � ColumnDefinitions 5
   
   �� 5      $
��976* �6   �� 5      $
��177* �6   �� 5      $	��42* �6    � RowDefinitions 5   
   �� 5      $
��250* �6   �� 5      $	��63* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
DataGrid_s��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6(      
IsReadOnly . $��Stretch=�6J   $��275,10,9.8,123.6q�6f   $��3��6�   �� 5   
   -   5         ��Name$ label��5      $��18(�6   $��contracts employers :��6-   
����� �$
��Left=�6f   $��	18,37,0,0q�6�   $	��Top=�6�   $	��192��6�   $��36��6�   �� 5   
   -   5         ��Name$ 
comboBox_1��5      $��25(�6'   $
��Left=�65   $��	18,98,0,0q�6P   $	��Top=�6c   $	��192��6{   $��41��6�   �� 5   
   -   5        	 ��Name$
	 menu��5      $��RETURN��6    $
��Left=�61   $	��Top=�6L   $	��177��6e   $��63��6q   
����� �$��18.667(�6�   $
��Bold"�6�   
 J� RenderTransformOrigin$
 0.228,0.554&�6�   $��1��6�   $��1��6�   �� 5   
   -   5        $ comboBox_1_Copy��5      $��25(�6,   $
��Left=�6:   $��
18,247,0,0q�6U   $	��Top=�6i   $	��192��6�   $��41��6�   6�   �� 5   
   -   5        $ 
label_Copy��5      $��18(�6$   $��contracts employees :��62   
����� �$
��Left=�6k   $��
18,176,0,0q�6�   $	��Top=�6�   $	��192��6�   $��42��6�   ��5   
   �� 5      -   5        
imagge�� �� ImageSource$ images/stat1.jpg��5   +   5      5      