   M S B A M L   `   `   `  ����C  ?PrintApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PrintAppPrintApp  5   	   h dSAPBusinessObjects.WPF.Viewer, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304tRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.ViewerSAPBusinessObjects.WPF.Viewer 5	   	       PrintApp.FormShow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:PrintApp     5   	   eViewerRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.Viewer     5	   	     � Title$  FormShow��5   	   $	��700��6   $
��1100��6'    � WindowStartupLocation$ CenterScreen=�64   .��5      � -   5         �Name$
 load��5       � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $	��900��6   $��0q�6!   .+�5      8  2SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer  -   5          Name$ crystalform��5   *   $	��510��6@   $��Bottom=�6N   �� 5       �� Orientation$ 
Horizontal=�6   $��RightToLeft=�62   $��Center=�6N   .+�5      ��  
  BYekan#��[  6   $
��20,0q�6=   $��17(�6L   $��RightToLeft=�6Z   $��نام فرم :��6v   $	��180��6�   �� 5      -   5         ��Name$ lblPictureName��5      #��[  60   $��17(�6V   $��RightToLeft=�6d   $��نام عکس ��6�   5      �� 5      $��Center=�6   $ 
Horizontal=�66   $��RightToLeft=�6O   .+�5      �� #��[  6   $
��20,0q�6=   $��17(�6L   $��RightToLeft=�6Z   $��قیمت هر برگه :��6v   $	��180��6�   �� 5      -   5        $ lblPagePrice��5      #��[  6.   $��17(�6T   $��RightToLeft=�6b   $��1000 تومان��6~   $	��150��6�   �� 5      #��[  6   $
��20,0q�6=   $��17(�6L   $��RightToLeft=�6Z   $��تعداد :��6v   $	��100��6�   � 5!      $	��Top=�6   .+�5"      �� -   5         ��Name$ txtPagesAmount��5"      #��[  6P   $��1��6u   $��3,2,13,3q�6�   �� 5#      -   5         ��Name$ cmdUp��5#      $��10(�6F   $��0,-4,0,0q�6T   $	��▲��6g   $��10��6s   $��	33,2,1,13q�6�   �� 5$      -   5        $ cmdDown��5$      $��10(�6H   $��0,-4,0,0q�6V   $	��▼��6i   $��10��6u   $��	33,12,1,3q�6�   5%      5'      �� 5(      $��Center=�6   $ 
Horizontal=�66   $��RightToLeft=�6O   .+�5)      �� -   5        $ 
btnPayment��5)        RoundCorner#���  6-   $��17(�6U   #��[  6c   $	��190��6�   $��پرداخت و چاپ��6�   $��40,20q�6�   6�   5+      5-      51      	 � 	Resources	 53      
 �� 
TargetType �� Property �� Value �� 	Resources��%=  &	       7   �� 58   
   "
 ��6%   .�59      ��  � ��$ 16q�6'   �� 5:       � ��$ 24(�6)   �� 5;       � ��8   6.   �� 5=       � �� �#9cbde46+    5>      ���� 5?      '��       "
 ��6   .�5@      ��  �@��CornerRadius$ 9��65   5A      5B      5C      5G      5I      