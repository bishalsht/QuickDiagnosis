using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PivotApp1.Resources;

namespace PivotApp1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new ItemViewModel() { LineOne = "CONTINENTAL HOSPITAL", LineTwo = "040-67229999", LineThree = "Plot No. 3, Road No. 2, IT & Financial District,, Nanakramguda, Gachibowli,, Hyderabad, AP 500035, India" });
            this.Items.Add(new ItemViewModel() { LineOne = "INDIRA HOSPITAL", LineTwo = "08413-223333", LineThree = "NATIONAL HIGHWAY 7 SHAMSHBAD – 501218 HYDERABAD NEAR" });
            this.Items.Add(new ItemViewModel() { LineOne = "KAMALA HOSPITAL", LineTwo = "040-24152266/77", LineThree = "KAMALA COMPLEX CHANDANA CORNELY,CHANDANA BROS,COMPLEX DSNR" });
            this.Items.Add(new ItemViewModel() { LineOne = "SAGAR HOSPITAL", LineTwo = "040-23156979", LineThree = "HIG 547,4TH PHASE,R.R.DISTRICT,A.P-500072" });
            this.Items.Add(new ItemViewModel() { LineOne = "SAINATH HOSPITAL", LineTwo = "040-4047809/4057305", LineThree = "CHAITANYA CHAMBER Dilsukhnagar, Hyderabad" });
            this.Items.Add(new ItemViewModel() { LineOne = "UNITY CENTRE FOR ORTHOPAEDICS & TRAUMA", LineTwo = "040-23261933", LineThree = "3-5-1705 G.S. NARAYANAGUDA" });
            
            this.IsDataLoaded = true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}