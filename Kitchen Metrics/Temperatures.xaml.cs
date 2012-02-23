using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Kitchen_Metrics
{
    public partial class Temperatures : PhoneApplicationPage
    {
       public Temperatures()
       {
            InitializeComponent(); 

            // Input kind
            LinkedList<string> elemsTemperature = new LinkedList<string>();
            elemsTemperature.AddLast("Degree Celsius");
            elemsTemperature.AddLast("Degree Fahrenheit");

            inputTemperatureKind.ItemsSource = elemsTemperature;
            outputTemperatureKind.ItemsSource = elemsTemperature;

            inputTemperatureKind.SelectedItem = "Degree Celsius";
            outputTemperatureKind.SelectedItem = "Degree Fahrenheit";
            InputTemperature.Text = "100";            
        }

        private void temperaturesConvert(object sender, RoutedEventArgs e)
        {
            // Value converted from input to int32
            double initial = 0.0;
            Boolean succeed = double.TryParse(InputTemperature.Text, out initial);

            // Value in Degree Celsius
            double intermediate = 0.0;

            double final = 0.0; 

            if (succeed)
            {
                switch (inputTemperatureKind.SelectedItem.ToString())
                {
                    case "Degree Celsius":  // The input is a binary number
                        intermediate = initial;
                        break;
                    case "Degree Fahrenheit":  // The input is a binary number
                        intermediate = (initial -32)*5/9;
                        break;
                    default:
                        succeed = false;
                        break;
                }


                switch (outputTemperatureKind.SelectedItem.ToString())
                {
                    case "Degree Celsius":  // The input is a binary number
                        final = intermediate;
                        break;
                    case "Degree Fahrenheit":  // The input is a binary number
                        final = intermediate * 9/5 + 32;
                        break;
                    default:
                        succeed = false;
                        break;
                }
            }

            if (succeed)
            {
                OutputTemperature.Text = String.Format("{0:0.##}", final); 
            }
            else
            {
                OutputTemperature.Text = "Invalid input";
            }
        }
    }
}