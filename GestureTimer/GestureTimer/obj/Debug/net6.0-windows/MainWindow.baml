   M S B A M L   `   `   `  ����G  CGestureTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GestureTimerGestureTimer  5   	       GestureTimer.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GestureTimer     5   	     � Title$!  Gesture Timer by MrMerowind��5   	   $	��500��6-   $	��400��6:    � 
ResizeMode$ CanResizeWithGrip=�6F    � SizeToContent$ WidthAndHeight=�6e   $	��400��6�   $	��500��6�   .��5	      � .+�5
   
   �� -   5         ��Name$ image��5
      $
��Left=�6   $��	10,10,0,0q�6:   $	��Top=�6M   $��Uniform=�6e   �� 5   
   -   5         ��Name$ selectFolderButton��5      $��Select folder��6-   $
��Left=�6E   $��10,0,0,7q�6`   $��Bottom=�6r   $��20(�6�   $	��127��6�   $��31��6�   �� 5   
   -   5         ��Name$ timeComboBox��5      $
��Left=�6)   $��	10,0,0,47q�6D   $��Bottom=�6W   $	��127��6r    �� Text$ Time per image��6~   $��16(�6�   .@�5      �� .��6   10s6    �� 5      .��6   20s6    �� 5      .��6   30s6    �� 5      .��6   40s6    �� 5      .��6   50s6    �� 5      .��6   1m6   �� 5      .��6   2m6   �� 5      .��6   3m6   �� 5      .��6   4m6   �� 5       �� 
IsSelected$
 True��6   .��6-   5m61   �� 5      .��6   10m6    �� 5      .��6   20m6    �� 5      .��6   30m6    �� 5      .��6   1h6   �� 5      .��6   2h6   �� 5      .��6   	Unlimited6&   5      �� 5   
   -   5        $ 
nextButton��5      $��>��6%   $��Right=�64   $��0,0,10,7q�6P   $��Bottom=�6b   $��20(�6}   $��28��6�   $��34��6�   6�   �� 5   
   -   5        $ pauseButton��5      $	��| |��6&   $��Right=�64   $��0,0,43,7q�6P   $��Bottom=�6b   $��20(�6}    J� RenderTransformOrigin$ -1.374,0.58&�6�   $��31��6�   $��34��6�   6�   �� 5    
   -   5        $ previousButton��5       $��<��6)   $��Right=�68   $��0,0,79,7q�6T   $��Bottom=�6f   $��20(�6�   $��29��6�   $��34��6�   6�   �� 5!   
   -   5        	 ��Name$	 timeLeftBox��5!      $��Right=�6'   $��	0,0,10,47q�6C   
 �� TextWrapping$

 Wrap=�6V   $
��5:00��6j   $��Bottom=�6v   $��98��6�   $��14(�6�   ${�False��6�   
���   �6�   �� 5"   
   -   5        $ 
flipButton��5"      $
��Flip��6%   $
��Left=�64   $��	142,0,0,7q�6O   $��20(�6b   $��Bottom=�6p   $��31��6�   6�   �� 5#   
   -	   5        $ 	bnwButton��5#      $	��B&W��6$   $
��Left=�66   $��	182,0,0,7q�6Q   $��Bottom=�6d   $��20(�6   $��31��6�   6�   5&      5'      