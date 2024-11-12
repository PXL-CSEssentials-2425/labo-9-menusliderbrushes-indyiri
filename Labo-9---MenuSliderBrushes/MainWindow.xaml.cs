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

namespace Labo_9___MenuSliderBrushes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Wilt u afsluiten?","Afsluiten",MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void numberMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            
            if (menuItem == firstMenuItem)
            {
                numberOneTextBox.Text = "2";
            }
            else if (menuItem == secondMenuItem)
            {
                numberTwoTextBox.Text = "2";
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;

            if (slider == textBoxOneSlider)
            {
                numberOneTextBox.Text = slider.Value.ToString();
            }
            else if (slider == textBoxTwoSlider)
            {
                numberTwoTextBox.Text = slider.Value.ToString();
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string numberOneText = numberOneTextBox.Text;
            string numberTwoText = numberTwoTextBox.Text;
            double newSliderValue;

            if (textBox == numberOneTextBox)
            {
                if (double.TryParse(numberOneText, out newSliderValue) && newSliderValue >= 1 && newSliderValue <= 5)
                {
                    textBoxOneSlider.Value = newSliderValue;
                }
                else if ((!double.TryParse(numberOneText, out newSliderValue) || newSliderValue < 1 || newSliderValue > 5) && !string.IsNullOrWhiteSpace(numberOneText))
                {
                    MessageBox.Show("Geef een getal in tussen 1 en 5","Foutieve invoer",MessageBoxButton.OK, MessageBoxImage.Error);
                    numberOneTextBox.Text = "";
                    numberOneTextBox.Focus();
                }
            }
            else if (textBox == numberTwoTextBox)
            {
                if (double.TryParse(numberTwoText, out newSliderValue) && newSliderValue >= 1 && newSliderValue <= 5)
                {
                    textBoxTwoSlider.Value = newSliderValue;
                }
                else if ((!double.TryParse(numberTwoText, out newSliderValue) || newSliderValue < 1 || newSliderValue > 5) && !string.IsNullOrWhiteSpace(numberTwoText))
                {
                    MessageBox.Show("Geef een getal in tussen 1 en 5", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    numberTwoTextBox.Text = "";
                    numberTwoTextBox.Focus();
                }
            }
        }

    }
}