using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private NumeralSystem numSystem;

        public MainWindow()
        {
            InitializeComponent();
            numSystem = new NumeralSystem();

            firstNotation.MaxValue = numSystem.MaxSystem;
            secondNotation.MaxValue = numSystem.MaxSystem;

            firstNumber.TextChanged += TextBox_TextChanged;
            firstNotation.NUDTextBox.TextChanged += TextBox_TextChanged;
            secondNotation.NUDTextBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int sys1 = Convert.ToInt32(firstNotation.NUDTextBox.Text);
            int sys2 = Convert.ToInt32(secondNotation.NUDTextBox.Text);

            string num = firstNumber.Text;
            StringBuilder builber = new StringBuilder();
            for (int i = 0; i < num.Length; i++)
                if (numSystem.alphabetContainDigit(num[i])) builber.Append(num[i]);
            num = builber.ToString();
            firstNumber.Text = num;

            firstNotation.MinValue = numSystem.getMinSystemToNum(num);
            if (firstNotation.StartValue < firstNotation.MinValue) firstNotation.StartValue = firstNotation.MinValue;

            secondNumber.Text = numSystem.fromSysToSys(num, sys1, sys2);
        }
    }
}
