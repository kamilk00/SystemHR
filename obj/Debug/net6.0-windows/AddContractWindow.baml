   M S B A M L   `   `   `  ????C  ?SystemHR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SystemHRSystemHR  5   	        SystemHR.AddContractWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SystemHR     5   	   a ]Syncfusion.Shared.WPF, Version=20.4600.0.43, Culture=neutral, PublicKeyToken=3d67ed1f87d44c892
syncfusion!http://schemas.syncfusion.com/wpf  5   	     ? Title$  	System HR??5	      $	??450??6   $	??800??6'    ? 
ResizeMode$ NoResize=?63    ? WindowStyle$
 None=?6I    J? 	AllowDrop$ False??6\   .??5
      ? #??? ??6    J? OpacityMask 5   
   ?? 5       ?? EndPoint$ 0.5,1&?6"    ?? 
StartPoint$ 0.5,0&?63   .??5      ?  ? Color$ Black??6   ? 5      $ White??6    ? Offset$ 1Q?6-   5      .+?5   
   ? $??Center=?6   $	??388??6,   $??0,52,0,0q?69   $	??Top=?6K   $	??800??6c   .+?5      ? $??Center=?6   $	??426??60   $	??Top=?6=   $	??676??6U   $??	0,-38,0,0q?6a   	 ? ColumnDefinitions	 5      ?? 5      $
??320* ?6'   ?? 5      $
??357* ?6'   .+?5      ?? -   5        
 ??Name$
 	addButton??5      $	??Add??6.   $
??Left=?6<   $??44??6W   $??105,292,0,0q?6c   $	??Top=?6x   $	??152??6?   ???	#FF09B8006?   ?? 5      -   5        $??typeOfContract??5      $??2??63   $
??Left=?6G   $??30??6b   $??
160,54,0,0q?6n   $	??Top=?6?   $	??462??6?   $??20(?6?   .@?5      ?? -   5        $??employmentContract??5   #   $??employment contract??6>   6^   ?? 5      -   5        $??contractOfMandate??5   #   $??contract of mandate??6<   6\   ?? 5      -   5        $	??B2B??5   #   $	??B2B??6.   6>   5      ?? 5      $??Type of contract??6   $
??Left=?63   $??30??6N   $??	50,54,0,0q?6Z   $	??Top=?6m   $	??105??6?    J? RenderTransformOrigin$ 0.589,0.512&?6?   ?? 5      -   5        $
 cancelButton??5      $??Cancel??61   $
??Left=?6B   $??44??6]   $??
74,292,0,0q?6i   $	??Top=?6}   $	??152??6?   ???	#FFB83C00$??1??6?   ?? 5      $
??Name??6   $
??Left=?6'   $??30??6B   $??	50,95,0,0q?6N   $	??Top=?6a   $??83??6y   ?? 5       -   5         ??Name$
 name??5       $
??Left=?6*   $??30??6E   $??20(?6Q   $??
160,95,0,0q?6_    ?? TextWrapping$
 Wrap=?6t   $?? ??6?   $	??Top=?6?   $	??462??6?   $??2??6?   ?? 5!      $??Salary??6   $
??Left=?6)   $??30??6D   $??
50,136,0,0q?6P   $	??Top=?6d   $??83??6|   &   Syncfusion.Windows.Shared.UpDown  5"      -   5        $??Salary??5"   $   $??30??62   $??160,136,42,267q?6>   $??20(?6V   $
??Bold"?6d   $	??Top=?6v   ?? 5#      $??Start of Contract??6   $
??Left=?64   $??30??6O   $??
50,177,0,0q?6[   $	??Top=?6o   $	??110??6?   ?? 5$      -	   5        $ startOfContract??5$      $
??Left=?65   $??30??6P   $??20(?6\   $??160,177,0,0q?6j   $
 Wrap=?6?   $?? ??6?   $	??Top=?6?   $	??462??6?   $??2??6?   ?? 5%      $??End Of Contract??6   $
??Left=?62   $??30??6M   $??
50,218,0,0q?6Y   $	??Top=?6m   $	??105??6?   ?? 5&      -
   5        $ endOfContract??5&      $
??Left=?63   $??30??6N   $??20(?6Z   $??160,218,0,0q?6h   $
 Wrap=?6~   $?? ??6?   $	??Top=?6?   $	??462??6?   $??2??6?   5'      5(      5)      5*      