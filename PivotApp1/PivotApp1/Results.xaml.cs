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
    public partial class Results : PhoneApplicationPage
    {
        public Results()
        {
            InitializeComponent();
        }

        int maxi(int [] a)
        {
            int mx=a[0];
            for(int i=1;i<11;i++){
                if (a[i] > mx)
                {
                    mx = a[i];
                }

            }
            return mx;
        }

        void disp_one(int disease,int count)
        {
            switch (count)
            {
                case 0:
                    Results1.Text = get_disease(disease);
                    Results1.Tag = Convert.ToString(disease);
                    break;
                case 1:
                    Results2.Text = get_disease(disease);
                    Results2.Tag = Convert.ToString(disease);
                    break;
                case 2:
                    Results3.Text = get_disease(disease);
                    Results3.Tag = Convert.ToString(disease);
                    break;
                case 3:
                    Results4.Text = get_disease(disease);
                    Results4.Tag = Convert.ToString(disease);
                    break;
                case 4:
                    Results5.Text = get_disease(disease);
                    Results5.Tag = Convert.ToString(disease);
                    break;
            }
        }
        string get_disease(int dis_index)
        {
            string line;
            StreamReader read = new StreamReader("Data/DiseasesIndex.txt");
            for (int i = 0; i < dis_index; i++)
            {
                read.ReadLine();
            }
            line = read.ReadLine();
            return line;
        }
        void display_here(int[] num,int numberofdata)
        {
            int ct = 0;
            for (int j = 0; j < numberofdata; j++)
            {
                for (int i = 0; i < 11; i++)
                {
                    if (num[i] == maxi(num))
                    {
                        disp_one(i,ct);
                        num[i] = 0;
                        ct++;
                    }
                    if (ct == 5) break;
                }
                if (ct == 5) break;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            StreamReader r = new StreamReader("Data/DiseasesIndex.txt");

            int[,] a = new int[14, 11];
   //         int datacount = 0;
            int[] disease = new int[11];
            int[] num = new int[11];
            int[] visit = new int[11];

            for (int i = 0; i < 14; i++)
                for (int j = 0; j < 11; j++)
                {
                    a[i, j] = 0;
                    disease[j] = 0;
                    num[j] = 0;
                    visit[j] = 0;

                }
            //initalizing the array
            a[0, 0] = 1;
            a[0, 1] = 1;
            a[0, 3] = 1;
            a[0, 7] = 1;
            a[0, 8] = 1;
            a[0, 9] = 1;

            a[1, 7] = 1;
            a[1, 6] = 1;
            a[1, 5] = 1;
            a[1, 8] = 1;
            a[1, 2] = 1;

            a[2, 7] = 1;
            a[2, 6] = 1;
            a[2, 2] = 1;

            a[3, 6] = 1;
            a[3, 7] = 1;
            a[3, 5] = 1;


            a[4, 7] = 1;
            a[4, 4] = 1;
            a[4, 1] = 1;
            a[4, 3] = 1;

            a[5, 1] = 1;
            a[5, 8] = 1;

            a[6, 7] = 1;
            a[6, 2] = 1;
            a[6, 1] = 1;
            a[6, 3] = 1;
            a[6, 9] = 1;
            a[6, 8] = 1;

            a[7, 1] = 1;
            a[7, 3] = 1;
            a[7, 8] = 1;

            a[8, 3] = 1;
            a[8, 4] = 1;
            a[8, 8] = 1;

            a[9, 8] = 1;
            a[9, 3] = 1;
            a[9, 0] = 1;

            a[10, 10] = 1;
            a[10, 6] = 1;

            a[11, 9] = 1;

            a[12, 8] = 1;
            a[12, 1] = 1;

            a[13, 6] = 1;
            a[13, 7] = 1;

            //MMMMMMMMMMMMMMMMMMMMMM
            for (int i = 0; i < MainPage.count; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (a[MainPage.UsSymptom[i], j] > 0) {
                        num[i]++;
                    }
                }
            }

            
            display_here(num,MainPage.count);
            //MMMMMMMMMMMMMMMMMMMMMM


            /*
            //file s=new file();
            int inter = new int();
            inter = 0;
            inter = counting(MainPage.UsSymptom);

            bool temp = false;


            intersection(disease, num, a, MainPage.UsSymptom);
            
             */
            /*
            for (int i=0;i<11;i++)
            {
                for (int j=0;j<10;j++)
                {
                    if (num[j] < num[j + 1])
                    {
                        int temp1 = num[j];
                        num[j] = num[j + 1];
                        num[j + 1] = temp1;
                        temp1 = disease[j];
                        disease[j] = disease[j + 1];
                        disease[j + 1] = temp1;
                    }
                }
            }
            */
            //string line;
            /*
           for (int i = 0; (line = r.ReadLine()) != null; i++)
            {
                if (disease[0] == i)
                    Results1.Text = line;
            }*/

            /*
            int counter;

            for (int i = 0; i < 11; i++)
            {
                counter = 0;
                if (num[i] == inter && disease[i] != 0)
                {
                    temp = true;

                    r.BaseStream.Position = 0;
                    r.DiscardBufferedData();

                    while ((line = r.ReadLine()) != null)
                    {

                        counter++;
                        if (counter == i)
                        {
                            switch (datacount)
                            {
                                case 0: Results1.Text = line; break;
                                case 1: Results2.Text = line; break;
                                case 2: Results3.Text = line; break;
                                case 3: Results4.Text = line; break;
                                case 4: Results5.Text = line; break;
                                default: break;
                            }

                            string resultNum = string.Format("Results", datacount);
                            TextBlock txt;

                            //Console.WriteLine(line);
                        }
                    }
                }
            }
            
            if (temp == false)
            {
                foreach (int x in MainPage.UsSymptom)
                {

                    for (int j = 0; j < 11; j++)
                    {
                        if (a[x, j] != 0 && visit[j] != 1)
                        {
                            counter = 0;
                            visit[j] = 1;
                            r.BaseStream.Position = 0;
                            r.DiscardBufferedData();

                            while ((line = r.ReadLine()) != null)
                            {

                                counter++;
                                if (counter == j)
                                {
                                    switch (datacount)
                                    {
                                        case 0: Results1.Text = line; break;
                                        case 1: Results2.Text = line; break;
                                        case 2: Results3.Text = line; break;
                                        case 3: Results4.Text = line; break;
                                        case 4: Results5.Text = line; break;
                                    }
                                    string resultNum = string.Format("Results", datacount);
                                    TextBlock txt;
                                    //Console.WriteLine(line);
                                }
                            }
                        }
                    }

                }
            }

            //Console.ReadLine();
            */


        }

        /*

        static int counting(params int[] UsSymptom)
        {
            int count = 0;
            foreach (int x in UsSymptom)
            {

                count++;

            }
            return count;
        }

        static void intersection(int[] disease, int[] num, int[,] a, params int[] UsSymptom)
        {
            foreach (int x in UsSymptom)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (a[x, j] != 0)
                    {
                        // Console.WriteLine("{0}", j);
                        disease[j] = 1;
                        num[j]++;
                    }
                }

            }

        }


        */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            moreinfo.dis_no = Convert.ToInt32(Results1.Tag);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            moreinfo.dis_no = Convert.ToInt32(Results2.Tag);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            moreinfo.dis_no = Convert.ToInt32(Results3.Tag);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            moreinfo.dis_no = Convert.ToInt32(Results4.Tag);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            moreinfo.dis_no = Convert.ToInt32(Results5.Tag);
        }
    }
}