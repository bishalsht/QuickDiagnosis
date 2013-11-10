using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PivotApp1.Resources;
using System.IO;
using PivotApp1.Resources;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Threading;




namespace PivotApp1
{
    
    public partial class MainPage : PhoneApplicationPage
    {
        private Popup popup;
        private BackgroundWorker backroungWorker;
        public static int panic {get;set;}
        public static int count { get; set; }
        public static int[] UsSymptom = new int[7];
        public int first { get; set; }
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            panic = -1;

            ShellTile appTile = ShellTile.ActiveTiles.First();


            StandardTileData tileData = new StandardTileData { Title = "QuickDiagnosis", BackTitle = "QuickDiagnosis", BackBackgroundImage = new Uri("/Assets/Tiles/IconicTileMediumLarge.png", UriKind.Relative) };


            appTile.Update(tileData);

            ShowSplash();

            //count = 0;
            // Set the data context of the listbox control to the sample data
            if (first == 0)
            {
                DataContext = App.ViewModel;
                first = 1;
            }

            //for (int i = 0; i < 7; i++)
            //{
            //    UsSymptom[i] = -1;
            //}
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }



        private void ShowSplash()
        {
            this.popup = new Popup();
            this.popup.Child = new SplashScreenControl();
            this.popup.IsOpen = true;
            StartLoadingData();
        }

        private void StartLoadingData()
        {
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }


        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;

            }
            );
        }

        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //here we can load data
            Thread.Sleep(5000);
        }








        string get_symptom(int position)
        {
            string line;
            StreamReader read = new StreamReader("Data/SymptomsIndex.txt");
            for (int i = 0; i < position; i++)
            {
                read.ReadLine();
            }
            line = read.ReadLine();
            return line;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();   
            }

            Image1.Visibility = Visibility.Collapsed;
            Image2.Visibility = Visibility.Collapsed;
            Image3.Visibility = Visibility.Collapsed;
            Image4.Visibility = Visibility.Collapsed;
            Image5.Visibility = Visibility.Collapsed;
            Image6.Visibility = Visibility.Collapsed;


            if (panic != -1)
            {
                UsSymptom[count++] = panic;
                panic = -1;
            
            
                if (count >= 1)
                {
                    Symptom1.Text = get_symptom(UsSymptom[0]);
                    Image1.Visibility = Visibility.Visible;
                }
                if (count >= 2)
                {
                    Symptom2.Text = get_symptom(UsSymptom[1]);
                    Image2.Visibility = Visibility.Visible;
                }
                if (count >= 3)
                {
                    Symptom3.Text = get_symptom(UsSymptom[2]);
                    Image3.Visibility = Visibility.Visible;
                }
                if (count >= 4)
                {
                    Symptom4.Text = get_symptom(UsSymptom[3]);
                    Image4.Visibility = Visibility.Visible;
                }
                if (count >= 5)
                {
                    Symptom5.Text = get_symptom(UsSymptom[4]);
                    Image5.Visibility = Visibility.Visible;
                }
                if (count >= 6)
                {
                    Symptom6.Text = get_symptom(UsSymptom[5]);
                    Image6.Visibility = Visibility.Visible;
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            adjust(count--, 1);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            adjust(count--, 2);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            adjust(count--, 3);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            adjust(count--, 4);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            adjust(count--, 5);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            adjust(count--, 6);
        }
        void adjust(int count, int position)
        {
            switch (count)
            {
                case 1:
                    Image1.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    Image2.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    Image3.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    Image4.Visibility = Visibility.Collapsed;
                    break;
                case 5:
                    Image5.Visibility = Visibility.Collapsed;
                    break;
                case 6:
                    Image6.Visibility = Visibility.Collapsed;
                    break;
            }
            switch (position)
            {
                case 1:
                    Symptom1.Text=Symptom2.Text;
                    UsSymptom[1] = UsSymptom[2];
                    Symptom2.Text=Symptom3.Text;
                    UsSymptom[2] = UsSymptom[3];
                    Symptom3.Text=Symptom4.Text;
                    UsSymptom[3] = UsSymptom[4];
                    Symptom4.Text=Symptom5.Text;
                    UsSymptom[4] = UsSymptom[5];
                    Symptom5.Text=Symptom6.Text;
                    UsSymptom[5] = UsSymptom[6];
                    Symptom6.Text="";
                    UsSymptom[6]=0;
                    break;
                case 2:
                    Symptom2.Text=Symptom3.Text;
                    UsSymptom[2] = UsSymptom[3];
                    Symptom3.Text=Symptom4.Text;
                    UsSymptom[3] = UsSymptom[4];
                    Symptom4.Text=Symptom5.Text;
                    UsSymptom[4] = UsSymptom[5];
                    Symptom5.Text=Symptom6.Text;
                    UsSymptom[5] = UsSymptom[6];
                    Symptom6.Text="";
                    UsSymptom[6]=0;
                    break;
                case 3:
                    Symptom3.Text=Symptom4.Text;
                    UsSymptom[3] = UsSymptom[4];
                    Symptom4.Text=Symptom5.Text;
                    UsSymptom[4] = UsSymptom[5];
                    Symptom5.Text=Symptom6.Text;
                    UsSymptom[5] = UsSymptom[6];
                    Symptom6.Text="";
                    UsSymptom[6]=0;
                    break;
                case 4:
                    Symptom4.Text=Symptom5.Text;
                    UsSymptom[4] = UsSymptom[5];
                    Symptom5.Text=Symptom6.Text;
                    UsSymptom[5] = UsSymptom[6];
                    Symptom6.Text="";
                    UsSymptom[6]=0;
                    break;
                case 5:
                    Symptom5.Text=Symptom6.Text;
                    UsSymptom[5] = UsSymptom[6];
                    Symptom6.Text="";
                    UsSymptom[6]=0;
                    break;
                case 6:
                    Symptom6.Text="";
                    break;
            }
        }
        }
        
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
