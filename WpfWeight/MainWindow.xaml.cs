using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace WpfWeight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double weightKG;
        double weightLB;
        static double conversionToLB = 2.2;
        static int heightCM = 173;
        string baseLocation;
        WeightCategories wc = new WeightCategories();

        public MainWindow()
        {
            InitializeComponent();

            Closing += windowClosing;

            bool readSuccess = false;

            baseLocation = AppDomain.CurrentDomain.BaseDirectory;
            string fileLocation = baseLocation + "value.txt";

            if (File.Exists(fileLocation))
            {
                string fileValue = File.ReadAllText(fileLocation);
                if(Double.TryParse(fileValue, out weightKG))
                {
                    readSuccess = true;
                }
            }

            if (!readSuccess)
            {
                weightKG = 85.7;
            }

            fileLocation = baseLocation + "height.txt";
            if (File.Exists(fileLocation))
            {
                string fileValue = File.ReadAllText(fileLocation);
                if(Int32.TryParse(fileValue, out heightCM))
                {
                    readSuccess = true;
                }
            }
            if(!readSuccess)
            {
                heightCM = 173;
            }

            calcLabelsFromKG();
        }

        private void buttonUpArrowKG_Click(object sender, RoutedEventArgs e)
        {
            if (weightKG < 100)
            {
                weightKG += 1.0;
                calcLabelsFromKG();
            }
        }

        private void buttonDownArrowKG_Click(object sender, RoutedEventArgs e)
        {
            if (weightKG > 0)
            {
                weightKG -= 1.0;
                calcLabelsFromKG();
            }
        }

        private void buttonUpArrowKGsmall_Click(object sender, RoutedEventArgs e)
        {
            if (weightKG < 100)
            {
                weightKG += 0.1;
                calcLabelsFromKG();
            }
        }

        private void buttonDownArrowKGsmall_Click(object sender, RoutedEventArgs e)
        {
            if (weightKG > 0)
            {
                weightKG -= 0.1;
                calcLabelsFromKG();
            }
        }

        private void buttonUpArrowLB_Click(object sender, RoutedEventArgs e)
        {
            if (weightLB < 300)
            {
                weightLB += 1.0;
                calcLabelsFromLB();
            }
        }

        private void buttonDownArrowLB_Click(object sender, RoutedEventArgs e)
        {
            if (weightLB > 0)
            {
                weightLB -= 1.0;
                calcLabelsFromLB();
            }
        }

        private void buttonUpArrowLBsmall_Click(object sender, RoutedEventArgs e)
        {
            if (weightLB < 300)
            {
                weightLB += 0.1;
                calcLabelsFromLB();
            }
        }

        private void buttonDownArrowLBsmall_Click(object sender, RoutedEventArgs e)
        {
            if (weightLB > 0)
            {
                weightLB -= 0.1;
                calcLabelsFromLB();
            }
        }

        private void buttonUpArrowHeight_Click(object sender, RoutedEventArgs e)
        {
            if (heightCM < 1000)
            {
                heightCM++;
                calcBMIFullWeight();
            }
        }
        
        private void buttonDownArrowHeight_Click(object sender, RoutedEventArgs e)
        {
            if (heightCM > 10)
            {
                heightCM--;
                calcBMIFullWeight();
            }
        }

        private void calcLabelsFromKG()
        {
            weightKG = Math.Round(weightKG, 1);
            weightLB = weightKG * conversionToLB;

            calcBMIFullWeight();

        }

        private void calcLabelsFromLB()
        {
            weightLB = Math.Round(weightLB, 1);
            weightKG = weightLB / conversionToLB;

            calcBMIFullWeight();
            
        }

        private void calcBMIFullWeight()
        {
            double h2 = heightCM * heightCM;
            double BMI = weightKG / (h2 / 10000);

            int stone = (int)(Math.Truncate( weightLB / 14));
            double lb = weightLB - (stone * 14);
            if(lb >= 13.5)
            {
                stone++;
                lb = 0;
            }


            updateLabels(BMI, stone, lb);
        }

        private void updateLabels(double BMI, int stone, double lb)
        {
            labelWeight.Content = weightKG;
            labelLB.Content = weightLB;
            labelBMI.Content = BMI;
            labelHeight.Content = heightCM;

            string fullWeight = stone + "-" + String.Format("{0:00}", lb);
            labelWeightFull.Content = fullWeight;

            labelWeightName.Content = wc.getWeight((int)weightLB);
        }

        private void windowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Save the value of KG.
            File.WriteAllText(baseLocation + "value.txt", String.Format("{0:0.0}", weightKG));
            File.WriteAllText(baseLocation + "height.txt", String.Format("{0:0}", heightCM));
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
