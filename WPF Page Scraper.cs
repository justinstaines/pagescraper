using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Media;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

//(c) Copyright 2021 Justin Staines

namespace WpfApp2variable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

            public MainWindow()
            {
                InitializeComponent();


                this.DataContext = this;
                var client = new WebClient();
                string myString;
                int number;

                string url = "https://www.thewire.co.uk/audio/the-wire-tapper/the-wire-tapper-42/2";
                string content = client.DownloadString(url);
                
                string pattern = @"\#\w*\b"; // look for the character # on the web page and scrape the number near it
                string pattern2 = @"\@\w*\b";
                string pattern3 = @"\$\w*\b";
                
                Match m = Regex.Match(content, pattern, RegexOptions.IgnoreCase);
                Match m2 = Regex.Match(content, pattern2, RegexOptions.IgnoreCase);
                Match m3 = Regex.Match(content, pattern3, RegexOptions.IgnoreCase);
                if (m.Success)
                {
                    myString = m.Value;
                    myString = myString.Substring(1);
                    //string test = myString;


                    bool isParsable = Int32.TryParse(myString, out number);

                }
                _Hello = m.Value;
                _Hello = _Hello.Substring(1);
                _Hello2 = m2.Value;
                _Hello2 = _Hello2.Substring(1);
                _Hello3 = m3.Value;
                _Hello3 = _Hello3.Substring(1);
                

            }



            private string _Hello = "Select Workflow Variant:";

            private string _Hello2 = "Select Workflow Variant:";

            private string _Hello3 = "Select Workflow Variant:";
            public string Hello
            {
                get { return _Hello; }
                set
                {
                    _Hello = value;
                    OnPropertyChanged();
                }
            }

            public string Hello2
            {
                get { return _Hello2; }
                set
                {
                    _Hello2 = value;
                    OnPropertyChanged();
                }
            }

            public string Hello3
            {
                get { return _Hello3; }
                set
                {
                    _Hello2 = value;
                    OnPropertyChanged();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;

            /// <summary>
            /// Raises this object's PropertyChanged event.
            /// </summary>
            /// <param name="propertyName">The property that has a new value.</param>
            protected void OnPropertyChanged(string propertyName = null)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    var e = new PropertyChangedEventArgs(propertyName);
                    handler(this, e);
                }
            }
        }
    }
