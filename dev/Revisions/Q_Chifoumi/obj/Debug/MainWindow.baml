   M S B A M L   `   `   `  ����E  AQ_Chifoumi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Q_Chifoumi
Q_Chifoumi  5   	       Q_Chifoumi.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Q_Chifoumi     5   	     � Title$  Chifoumi��5   	   $	��450��6   $	��800��6'   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      .+�5   
   o� .@�5      m� $��_Menu��6   .@�5      m� $��_Nouvelle partie��6    m� Command 65   �� *NouvellePartieCommand+m� 5      $��_Fermer��6    6-   �� *FermerCommand+�� 5      m� 5      $��_Pierre��6    m� CommandParameter$ Pierre��6L    6-   �� *
PfcCommand+{�6f   �� *
PfcEnabled+m� 5      $��_Feuille��6   $ Feuille��6M    6.   �� *
PfcCommand+{�6h   �� *
PfcEnabled+m� 5      $��_Ciseau��6   $ Ciseau��6L    6-   �� *
PfcCommand+{�6f   �� *
PfcEnabled+5      5      �� 5   
   $��Center=�6   $��Center=�60   .+�5      �� $��Center=�6   $��28(�6N   ��66   �� *Points+6N   �� 5      $��Center=�6   $��28(�6t   ��65   �� *	Message+��6N   �� *MessageCouleur+6t   5      � 5   
   $��1��6    5      �� 5      �� 5       �� 5!       � RowDefinitions 5#      �� 5$      �� 5%      .+�5(      �� $��3��6   $��10q�6)   {�.   � DataContext 6G   �� *ChoixMachine+.��5)      �� .+�5*      �� $	��150��65   ��6   �� *Image+65   �� 5+      $��16(�67   $��Center=�6E   ��6    �� *Texte+6E   5,      5-      �� 5/      $��1��6   $��10q�6"   $��Pierre��6M   ��6.   �� *
PfcCommand+{�50      �� *
PfcEnabled+.��51      �� .+�52      �� $��/images/pierre.png��6   $	��100��68   �� 53      $��Pierre��6    $��16(�6.   $��Center=�6<   54      55      �� 57      $��1��6   $��1��6"   $��10q�62   $��Feuille��6]   ��6>   �� *
PfcCommand+{�58      �� *
PfcEnabled+.��59      �� .+�5:      �� $��/images/feuille.png��6   $	��100��69   �� 5;      $��Feuille��6    $��16(�6/   $��Center=�6=   5<      5=      �� 5?      $��1��6   $��2��6"   $��10q�62   $��Ciseau��6]   ��6>   �� *
PfcCommand+{�5@      �� *
PfcEnabled+.��5A      �� .+�5B      �� $��/images/ciseau.png��6   $	��100��68   �� 5C      $��Ciseau��6    $��16(�6.   $��Center=�6<   5D      5E      5F      5G      5H      