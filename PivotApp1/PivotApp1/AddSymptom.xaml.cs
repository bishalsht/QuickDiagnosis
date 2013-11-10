using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;

namespace PivotApp1
{
    public partial class AddSymptom : PhoneApplicationPage
    {
        int I;
        public AddSymptom()
        {
            InitializeComponent();

            StreamReader read = new StreamReader("Data/SymptomsIndex.txt");
            string line;

            for (int i = 0; (line = read.ReadLine())!=null ; i++)
            {
                RadioButton rb = new RadioButton() {Name=Convert.ToString(i),Content = line, IsChecked = i == 0  };
                rb.Checked += (sender, args) =>
                { I = Convert.ToInt32(rb.Name); };
                rb.Unchecked += (sender, args) => { /* Do stuff */ };
                rb.Tag = i;
            
                MyStackPanel.Children.Add( rb );
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            {
                MainPage.panic = I ;
            }
        }
    }
}