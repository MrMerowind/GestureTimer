   M S B A M L   `   `   `  ���� G  CGestureTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GestureTimerGestureTimer      GestureTimer.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:GestureTimer       � Title$!  Gesture Timer by MrMerowind��$	��500��$	��450�� � 
ResizeMode$ CanResizeWithGrip=� � SizeToContent$ WidthAndHeight=�$	��450��$	��500�� � Topmost$
 True�� � Icon$ 	/icon.ico��.��� .+��� -    ��Name$ image��$
��Left=�$��	10,10,0,0q�$	��Top=�$��Uniform=��� -    ��Name$ selectFolderButton��$��Select folder��$
��Left=�$��10,0,0,7q�$��Bottom=�$��20(�$	��127��$��31��$��Adobe Hebrew)����	#FF2ADE77��Z� �� -    ��Name$ timeComboBox��$
��Left=�$��	10,0,0,47q�$��Bottom=�$	��127�� �� Text$ Time per image��$��16(�$��Adobe Hebrew)�.@��� .��10s�� .��20s�� .��30s�� .��40s�� .��50s�� .��1m�� .��2m�� .��3m�� .��4m�� 	 �� 
IsSelected$
	 True��.��5m�� .��10m�� .��20m�� .��30m�� .��1h�� .��2h�� .��	Unlimited�� -   $ 
nextButton��$��Right=�$��0,0,10,7q�$��Bottom=�$��20(�$��28��$��34��$��Showcard Gothic)����� .R��� .���� $��28��$��28�����	#FF4FBCD8
 J� RenderTransformOrigin$	
 0,1&� �� CornerRadius$ 100,100,100,100��._��� $��>��$��Center=�$��Center=�$��28��$��12��$��10,0,0,0q�$
 0.083,0.512&��� -   $ pauseButton��$��Right=�$��0,0,43,7q�$��Bottom=�$��20(�$
 -1.374,0.58&�$��31��$��34��$��Center=�$	��Top=�$��Showcard Gothic)���Z� $	��| |���� -   $ previousButton��$��Right=�$��0,0,79,7q�$��Bottom=�$��20(�$��29��$��34��$��Showcard Gothic)����� .R��� .���� $��28��$��28�����	#FF4FBCD8$	
 0,1&�$ 100,100,100,100��._��� $��<��$��Center=�$��Center=�$��28��$��12���� -    ��Name$ timeLeftBox��$��Right=�$��	0,0,10,47q� �� TextWrapping$
 Wrap=�$
��5:00��$��Bottom=�$��98��$��14(�${�False��
���   �$��RightToLeft=���Z� �� -   $ 
flipButton��$
��Flip��$
��Left=�$��	142,0,0,7q�$��20(�$��Bottom=�$��50��$��53��$��Adobe Hebrew)���Z� �� -	   $ 	bnwButton��$
��Left=�$��	211,0,0,7q�$��Bottom=�$��14(�$��50��$��99��$��
Monochrome��$��Adobe Hebrew)���Z� 