using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable computing = new DataTable();
        bool xToThePowerOfY = false, percentOfANumber = false;
        public MainWindow()
        {
            InitializeComponent();

            deletingButton.Content = char.ConvertFromUtf32(0x21E6);
            sqrtButton.Content = char.ConvertFromUtf32(0x221A);
            piButton.Content = char.ConvertFromUtf32(0x03C0);
            zeroButton.Click += ZeroButton_Click;
            oneButton.Click += OneButton_Click;
            twoButton.Click += TwoButton_Click;
            threeButton.Click += ThreeButton_Click;
            fourButton.Click += FourButton_Click;
            fiveButton.Click += FiveButton_Click;
            sixButton.Click += SixButton_Click;
            sevenButton.Click += SevenButton_Click;
            eightButton.Click += EightButton_Click;
            nineButton.Click += NineButton_Click;
            deletingAllButton.Click += DeletingAllButton_Click;
            openingRoundBracket.Click += OpeningRoundBracket_Click;
            closingRoundBracket.Click += ClosingRoundBracket_Click;
            deletingButton.Click += DeletingButton_Click;
            plusButton.Click += PlusButton_Click;
            minusButton.Click += MinusButton_Click;
            multiplyButton.Click += MultiplyButton_Click;
            divideButton.Click += DivideButton_Click;
            pointButton.Click += PointButton_Click;
            equalsButton.Click += EqualsButton_Click;
            sineButton.Click += SineButton_Click;
            cosineButton.Click += CosineButton_Click;
            tangentButton.Click += TangentButton_Click;
            cotangentButton.Click += CotangentButton_Click;
            percentOfANumberButton.Click += PercentOfANumberButton_Click;
            sqrtButton.Click += SqrtButton_Click;
            xToThePowerOfYButton.Click += XToThePowerOfYButton_Click;
            factorialButton.Click += FactorialButton_Click;
            decimalLogarithmButton.Click += DecimalLogarithmButton_Click;
            piButton.Click += PiButton_Click;
        }
        
        private void PiButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += Convert.ToString(Math.PI);
        }

        private void DecimalLogarithmButton_Click(object sender, RoutedEventArgs e)
        {
            outputTextBox.Text = Convert.ToString(Math.Log10(Convert.ToDouble(inputTextBox.Text)));
        }

        private void FactorialButton_Click(object sender, RoutedEventArgs e)
        {
            int factorialNumber = 1;
            for (int i = 1; i < Convert.ToInt16(inputTextBox.Text) + 1; i++) // factorial calculation
            {
                factorialNumber = factorialNumber * i;
            }
            outputTextBox.Text = Convert.ToString(factorialNumber);
        }

        private void XToThePowerOfYButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "^";
            xToThePowerOfY = true;
        }

        private void SqrtButton_Click(object sender, RoutedEventArgs e)
        {
            outputTextBox.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(inputTextBox.Text)));
        }

        private void PercentOfANumberButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "%";
            percentOfANumber = true;
        }

        private void CotangentButton_Click(object sender, RoutedEventArgs e)
        {
            outputTextBox.Text = Convert.ToString(Math.Cos(Convert.ToDouble(inputTextBox.Text)) / Math.Sin(Convert.ToDouble(inputTextBox.Text)));
        }

        private void TangentButton_Click(object sender, RoutedEventArgs e)
        {
            outputTextBox.Text = Convert.ToString(Math.Tan(Convert.ToDouble(inputTextBox.Text)));
        }

        private void CosineButton_Click(object sender, RoutedEventArgs e)
        {
            outputTextBox.Text = Convert.ToString(Math.Cos(Convert.ToDouble(inputTextBox.Text)));
        }

        private void SineButton_Click(object sender, RoutedEventArgs e)
        {
            outputTextBox.Text = Convert.ToString(Math.Sin(Convert.ToDouble(inputTextBox.Text)));
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (xToThePowerOfY) // if it needs to calculate a number to a power
            {
                string firstNumber = string.Empty, secondNumber = string.Empty;
                int count = 0;
                for (int i = 0; i < inputTextBox.Text.Length; i++)
                {
                    if (inputTextBox.Text[i] == '^')
                    {
                        count++;
                        continue;
                    }
                    if (count == 0)
                    {
                        firstNumber += inputTextBox.Text[i];
                    }
                    else if (count == 1)
                    {
                        secondNumber += inputTextBox.Text[i];
                    }

                }
                xToThePowerOfY = false;
                outputTextBox.Text = Convert.ToString(Math.Pow(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber)));
            }
            else if (percentOfANumber) // if it needs to calculate the percentage of a number
            {
                string firstNumber = string.Empty, secondNumber = string.Empty;
                int count = 0;
                for (int i = 0; i < inputTextBox.Text.Length; i++)
                {
                    if (inputTextBox.Text[i] == '%')
                    {
                        count++;
                        continue;
                    }
                    if (count == 0)
                    {
                        firstNumber += inputTextBox.Text[i];
                    }
                    else if (count == 1)
                    {
                        secondNumber += inputTextBox.Text[i];
                    }
                }
                percentOfANumber = false;
                outputTextBox.Text = Convert.ToString(Convert.ToDouble(secondNumber) * Convert.ToDouble(firstNumber) / 100);
            }
            else
            {
                outputTextBox.Text = Convert.ToString(computing.Compute(inputTextBox.Text, null));
            }
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += ".";
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "/";
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "*";
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "-";
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "+";
        }

        private void DeletingButton_Click(object sender, RoutedEventArgs e)
        {
            if (inputTextBox.Text == string.Empty)
            {
                return;
            }
            inputTextBox.Text = inputTextBox.Text.Remove(inputTextBox.Text.Length - 1, 1);
        }

        private void ClosingRoundBracket_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += ")";
        }

        private void OpeningRoundBracket_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "(";
        }

        private void DeletingAllButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = string.Empty;
        }
        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "9";
        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "8";
        }

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "7";
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "6";
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "5";
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "4";
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "3";
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "2";
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "1";
        }

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text += "0";
        }
    }
}