   M S B A M L   `   `   `  ����D  @WpfClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfClient.View.FramesWpfClient.View.Frames  5      %    WpfClient.View.Frames.UsersPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WpfClient.View.Frames     5        N� Title$  	UsersPage��5	      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ UsersListBox��5      $��0��5   
   $��0,0,0,10q�5   
   
�������
�������$��10q�5   
   $��Stretch=�5   
   ��5   
   �� *Users+��5      �� 5      .R�5      �� 
�������
�������$��1q�5       �� CornerRadius$ 5��5       �� Padding$ 10q�5       $��5q�5!      $��Stretch=�5"      ._�5#      �� .+�5%      �� 
�������$��12(�5'       $��Right=�5(       ��5%   (   �� *Id+5(       �� 5*      $��Логин:��6(   $��SemiBold"�5+       $��14(�5,       $��0,5,0,2q�5-       �� 5.      $��14(�5/       $��0,0,0,5q�50       
���OO/���5.   (   �� *Login+51       �� 54      $��Пароль:��6(   $��SemiBold"�55       $��14(�56       $��0,5,0,2q�57       �� 58      $��14(�59       
���OO/���58   (   �� *
Password+5:       5;      5<      5=      5?      �� 5C   
   $#��Получить данные��6   $��1��5D      $��	0,10,0,10q�5E      $	��150��5F      $��30��5G      $��Center=�5H      ��5I      �� *
GetUsers+�� 5L   
   -   5         ��Name$ ErrorTextBlock��5L      $��2��5M      
���  ��$��14(�5O      $��40��5P      $��Center=�5R      $��Center=�5S      $
��Wrap=�5T      ��5Q      �� *CurrentError+5T      5U      5W      