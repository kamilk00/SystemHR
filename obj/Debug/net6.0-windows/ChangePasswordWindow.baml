   M S B A M L   `   `   `  ????C  ?SystemHR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SystemHRSystemHR  5   	   #    SystemHR.ChangePasswordWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SystemHR     5   	   a ]Syncfusion.Shared.WPF, Version=20.4600.0.43, Culture=neutral, PublicKeyToken=3d67ed1f87d44c892
syncfusion!http://schemas.syncfusion.com/wpf  5   	     ? Title$  	System HR??5	      $	??450??6   $	??800??6'    ? 
ResizeMode$ NoResize=?63    ? WindowStyle$
 None=?6I    J? 	AllowDrop$ False??6\   .??5
      ? #??? ??6    J? OpacityMask 5   
   ?? 5       ?? EndPoint$ 0.5,1&?6"    ?? 
StartPoint$ 0.5,0&?63   .??5      ?  ? Color$ Black??6   ? 5      $ White??6    ? Offset$ 1Q?6-   5      .+?5   
   ? $??Center=?6   $	??388??6,   $??0,52,0,0q?69   $	??Top=?6K   $	??800??6c   .+?5      ? $??Center=?6   $	??426??60   $	??Top=?6=   $	??676??6U   $??	0,-38,0,0q?6a   	 ? ColumnDefinitions	 5      ?? 5      $
??320* ?6'   ?? 5      $
??357* ?6'   .+?5      ?? -   5        
 ??Name$
 changeButton??5      $??Change??61   $
??Left=?6B   $??44??6]   $??105,292,0,0q?6i   $	??Top=?6~   $	??152??6?   ???	#FF09B8006?   ?? 5      -   5        $
 cancelButton??5      $??Cancel??61   $
??Left=?6B   $??44??6]   $??
74,292,0,0q?6i   $	??Top=?6}   $	??152??6?   ???	#FFB83C00$??1??6?   ?? 5      $??New Password??6   $
??Left=?6/   $??30??6J   $??
50,182,0,0q?6V   $	??Top=?6j   $	??110??6?   ?? 5      $??Password??6   $
??Left=?6+   $??30??6F   $??
51,130,0,0q?6R   $	??Top=?6f   $	??110??6~   5      5      G? 5   
   -   5         G?Name$ password??5      $
??Left=?6*   $??20(?6E   $??30??6S   $??224,143,0,0q?6_   $	??Top=?6t   $	??462??6?   G? 5   
   -   5        $ newPassword??5      $
??Left=?6-   $??20(?6H   $??30??6V   $??224,195,0,0q?6b   $	??Top=?6w   $	??462??6?   5      5       