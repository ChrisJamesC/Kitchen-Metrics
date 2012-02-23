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
    public partial class MainPage : PhoneApplicationPage
    {
       
        // Constructor
        public MainPage()
        {
            InitializeComponent(); 

            // Input kind
            LinkedList<string> elemsIn = new LinkedList<string>();
            elemsIn.AddLast("Litre"); //Litre, Mililitre, Teaspoon, Tablespoon, Fluid ounce, Cup, Pint, Quart, Gallon
            elemsIn.AddLast("Mililitre");
            elemsIn.AddLast("Teaspoon");
            elemsIn.AddLast("Tablespoon");
            elemsIn.AddLast("Fluid ounce");
            elemsIn.AddLast("Cup");
            elemsIn.AddLast("Pint");
            elemsIn.AddLast("Quart");
            elemsIn.AddLast("Gallon");
            inputVolumeKind.ItemsSource = elemsIn;
            outputVolumeKind.ItemsSource = elemsIn;


            inputVolumeKind.SelectedItem = "Litre";
            outputVolumeKind.SelectedItem = "Litre";
            InputText.Text = "1";
            

            
        }

        // different number kinds supported by the converter


        private void volumeConvert(object sender, RoutedEventArgs e)
        {
            // Value converted from input to int32
            double initial = 0.0;
            Boolean succeed = double.TryParse(InputText.Text, out initial);

            // Value in Litre
            double intermediate = 0.0;

            double final = 0.0; 

            if (succeed)
            {
                switch (inputVolumeKind.SelectedItem.ToString())
                {
                    case "Litre":  // The input is a binary number
                        intermediate = initial;
                        break;
                    case "Mililitre":  // The input is a binary number
                        intermediate = initial * 0.001;
                        break;
                    case "Teaspoon":
                        intermediate = initial * 4.93 * 0.001;
                        break;
                    case "Tablespoon":
                        intermediate = initial * 14.79 * 0.001;
                        break;
                    case "Fluid ounce":
                        intermediate = initial * 29.57 * 0.001;
                        break;
                    case "Cup":
                        intermediate = initial * 236.59 * 0.001;
                        break;
                    case "Pint":
                        intermediate = initial * 473.18 * 0.001;
                        break;
                    case "Quart":
                        intermediate = initial * 946.35 * 0.001;
                        break;
                    case "Gallon":
                        intermediate = initial * 3785.41 * 0.001;
                        break;
                    default:
                        succeed = false;
                        break;
                }


                switch (outputVolumeKind.SelectedItem.ToString())
                {
                    case "Litre":  // The input is a binary number
                        final = intermediate;
                        break;
                    case "Mililitre":  // The input is a binary number
                        final = intermediate * 1000.0;
                        break;
                    case "Teaspoon":
                        final = intermediate / (4.93 * 0.001);
                        break;
                    case "Tablespoon":
                        final = intermediate / (14.79 * 0.001);
                        break;
                    case "Fluid ounce":
                        final = intermediate / (29.57 * 0.001);
                        break;
                    case "Cup":
                        final = intermediate / (236.59 * 0.001);
                        break;
                    case "Pint":
                        final = intermediate / (473.18 * 0.001);
                        break;
                    case "Quart":
                        final = intermediate / (946.35 * 0.001);
                        break;
                    case "Gallon":
                        final = intermediate / (3785.41 * 0.001);
                        break;
                    default:
                        succeed = false;
                        break;
                }
            }

            if (succeed)
            {
                OutputText.Text = String.Format("{0:0.##}", final); 
            }
            else
            {
                OutputText.Text = "Invalid input";
            }
        }

    }
}