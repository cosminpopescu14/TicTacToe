//Version: 1.2
//Un simplu joc de X si 0 dezvolat in timpul laboratorului de Win 8.1
//
//Mai multe functii vor fi adaugate in viior; :)
//adaugat buton de inchidere al jocului
//vesiunea buna
//am modificat foaret putitn stiulul casutelor cu numele jucatorilor
//pentru a testa aceasta aplicaie este nevoide de vidsual studio 2013 si windows 8.1

 


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace tic_tac_toe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool jucator = true;
        int[,] mat = new int[3, 3];
        string winner/*x*/ = String.Empty;
        //string winner/*0*/ = String.Empty;
        IAsyncOperation<IUICommand> asyncCommand = null;
        public MainPage()
        {
            this.InitializeComponent();
        }
		
        private  void   Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
			Image img = sender as Image; //cast
			
			if(jucator)	
				img.Source = new BitmapImage(new Uri("ms-appx:/Images/x.png", 
						      UriKind.RelativeOrAbsolute)); //incarcare imagine din Images
			else		
				img.Source = new BitmapImage(new Uri("ms-appx:/Images/zero.png", 
						     UriKind.RelativeOrAbsolute)); //incarcare imagine din Images

			img.Tapped -=Image_Tapped;

			string name = img.Name;

			int i, j;

			i = int.Parse(name[1].ToString() );
			j = int.Parse(name[3].ToString() );

			if (jucator)
				mat[i, j] = 1;
			else
                mat[i, j] = -1;

             VerifCastigator();

            if (jucator)
                jucator = false;
            else
                jucator = true;
           
        }
           private async void VerifCastigator()
           {
               if(Verif())
               {
                   var md/*x*/ = new MessageDialog("Player " + x_player.Text + "-" + winner + " won !");
                   //var md0 = new MessageDialog("Player " + _0_player_player.Text + "-" + winner + " won !");

                   asyncCommand = md.ShowAsync();
                   //asyncCommand = md0.ShowAsync();
                   
                   await asyncCommand;

                   if (asyncCommand != null)
                   {
                       asyncCommand.Cancel();
                       asyncCommand = null;
                   }

                   Restart();
               }

               if (VerifRemiza())
               {
                   var md = new MessageDialog("Draw !!");

                   asyncCommand = md.ShowAsync();
                   await asyncCommand;

                   if (asyncCommand != null)
                   {
                       asyncCommand.Cancel();
                       asyncCommand = null;
                   }

                   Restart();
               }
           }
             
		void Restart()
        {
            jucator = false;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    mat[i, j] = 0;

            C0_0.Tapped += Image_Tapped;
            C0_0.Source = new BitmapImage(new Uri("ms-appx:/Images/blank.png",
                     UriKind.RelativeOrAbsolute));

            C0_1.Tapped += Image_Tapped;
            C0_1.Source = new BitmapImage(new Uri("ms-appx:/Images/blank.png",
                     UriKind.RelativeOrAbsolute));

            C0_2.Tapped += Image_Tapped;
            C0_2.Source = new BitmapImage(new Uri("ms-appx:/Images/blank.png",
                     UriKind.RelativeOrAbsolute));

            C1_0.Tapped += Image_Tapped;
            C1_0.Source = new BitmapImage(new Uri("ms-appx:/Images/blank.png",
                     UriKind.RelativeOrAbsolute));

            C1_1.Tapped += Image_Tapped;
            C1_1.Source = new BitmapImage(new Uri("ms-appx:/Images/blank.png",
                     UriKind.RelativeOrAbsolute));

            C1_2.Tapped += Image_Tapped;
            C1_2.Source = new BitmapImage(new Uri("ms-appx:/Images/blank.png",
                     UriKind.RelativeOrAbsolute));

            C2_0.Tapped += Image_Tapped;
            C2_0.Source = new BitmapImage(new Uri("ms-appx:/Images/blank.png",
                     UriKind.RelativeOrAbsolute));

            C2_1.Tapped += Image_Tapped;
            C2_1.Source = new BitmapImage(new Uri("ms-appx:/Images/blank.png",
                     UriKind.RelativeOrAbsolute));

            C2_2.Tapped += Image_Tapped;
            C2_2.Source = new BitmapImage(new Uri("ms-appx:/Images/blank.png",
                     UriKind.RelativeOrAbsolute));
        }
        

        bool VerifRemiza()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (mat[i, j] == 0)
                        return false;
             return true;
        }

		bool Verif()
		{
			int s1 = 0, s2 = 0, s3 = 0;
			int s4 = 0, s5=0, s6 = 0;
			int s7 = 0, s8 = 0;

			for (int i = 0; i < 3; i++ )
			{
				s1 += mat[0, i];
				s2 += mat[1, i];
				s3 += mat[2, i];

				s4 += mat[i, 0];
				s5 += mat[i, 1];
				s6 += mat[i, 2];

			}

			s7 += mat[0, 0] + mat[1, 1] + mat[2, 2];
			s8 += mat[0, 2] + mat[1, 1] + mat[2, 0];

			if (Winner(s1) == 1 || Winner(s1) == -1)
				return true;
			if (Winner(s2) == 1 || Winner(s2) == -1)
				return true;
		    if (Winner(s3) == 1 || Winner(s3) == -1)
				return true;
			if (Winner(s4) == 1 || Winner(s4) == -1)
				return true;
			if (Winner(s5) == 1 || Winner(s5) == -1)
				return true;
			if (Winner(s6) == 1 || Winner(s6) == -1)
				return true;
			if (Winner(s7) == 1 || Winner(s7) == -1)
				return true;
			if (Winner(s8) == 1 || Winner(s8) == -1)
				return true;

			return false;
		}

		int Winner(int s)
		{
            if (s == -3)
            {
                winner/*0*/ = "zero";
                return -1;
            }
            else if (s == 3)
            {
                winner/*x*/ = "X";
                return 1;
            }
            
			return 0;
		}

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }
 

    }
}
