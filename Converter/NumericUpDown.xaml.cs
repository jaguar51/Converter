using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Converter
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    /// 

    public partial class NumericUpDown : UserControl
    {
        int minvalue = 2;
        public int MinValue
        {
            get { return minvalue; }
            set
            {
                if (minvalue < maxvalue) minvalue = value;
            }
        }

        int maxvalue = 35;
        public int MaxValue
        {
            get { return maxvalue; }
            set
            {
                if (minvalue < maxvalue) maxvalue = value;
            }
        }

        int startvalue = 10;
        public int StartValue
        {
            get { return startvalue; }
            set
            {
                if (value < maxvalue && value > minvalue) startvalue = value;
                NUDTextBox.Text = value.ToString();
            }
        }
        

        public NumericUpDown()
        {
            InitializeComponent();
            NUDTextBox.Text = startvalue.ToString();
        }

        private void NUDButtonUP_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if (NUDTextBox.Text != "") number = Convert.ToInt32(NUDTextBox.Text);
            else number = 0;
            if (number < maxvalue)
                NUDTextBox.Text = Convert.ToString(number + 1);
        }

        private void NUDButtonDown_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if (NUDTextBox.Text != "") number = Convert.ToInt32(NUDTextBox.Text);
            else number = 0;
            if (number > minvalue)
                NUDTextBox.Text = Convert.ToString(number - 1);
        }

        private void NUDTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Up)
            {
                NUDButtonUP.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonUP, new object[] { true });
            }


            if (e.Key == Key.Down)
            {
                NUDButtonDown.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonDown, new object[] { true });
            }
        }

        private void NUDTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonUP, new object[] { false });

            if (e.Key == Key.Down)
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonDown, new object[] { false });
        }

        private void NUDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int number = 0;
            if (NUDTextBox.Text != "")
                if (!int.TryParse(NUDTextBox.Text, out number)) NUDTextBox.Text = startvalue.ToString();
            if (number > maxvalue) NUDTextBox.Text = maxvalue.ToString();
            if (number < minvalue) NUDTextBox.Text = minvalue.ToString();
            NUDTextBox.SelectionStart = NUDTextBox.Text.Length;
            startvalue = number;
        }

    }
}
