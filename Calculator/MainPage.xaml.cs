using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Calculator
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Controller controller;

        public MainPage()
        {
            this.InitializeComponent();
            controller = new Controller();
            DataContext = controller;
            result.Text = String.Empty;
        }

        #region Методы представления
        /// <summary>
        /// Кнопки от 0 до 9(включительно)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if(button != null)
            {
                if (field.Text.Length == 1 && field.Text.Contains("0"))
                    field.Text = String.Empty;
                field.Text += button.Content.ToString();
            }
        }

        /// <summary>
        /// Кнопка 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Zero(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (field.Text.Length == 1 && field.Text == "0")
                    return;
                field.Text += button.Content.ToString();
            }
        }

        /// <summary>
        /// Кнопка Вещественная часть(разделитель)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Point(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (field.Text.Contains(".") && button.Content.ToString() == ".")
                    return;
                field.Text += button.Content.ToString();
            }
        }

        /// <summary>
        /// Кнопка сложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Add_Operator_Click(object sender, RoutedEventArgs e)
        {
            controller.SetValue(field.Text, controller.AddResult);
            field.Text = "0";
        }
        
        /// <summary>
        /// Кнопка вычитания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Sub_Operator_Click(object sender, RoutedEventArgs e)
        {
            controller.SetValue(field.Text, controller.SubResult);
            field.Text = "0";
        }

        /// <summary>
        /// Кнопка умножения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Myltiply_Operator_Click(object sender, RoutedEventArgs e)
        {
            controller.SetValue(field.Text, controller.MultiplyResult);
            field.Text = "0";
        }

        /// <summary>
        /// Кнопка деления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Divide_Operator_Click(object sender, RoutedEventArgs e)
        {
            controller.SetValue(field.Text, controller.DivideResult);
            field.Text = "0";
        }

        /// <summary>
        /// Кнопка сброса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Reset(object sender, RoutedEventArgs e)
        {
            field.Text = "0";
            result.Text = String.Empty;
            controller.ResetController();
            history.Text = String.Empty;
        }

        /// <summary>
        /// Кнопка равно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Result_Operator_Click(object sender, RoutedEventArgs e)
        {
            controller.Result(field.Text);
        }

        /// <summary>
        /// Кнопка отрицания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Negative_Click(object sender, RoutedEventArgs e)
        {
            if (field.Text.Contains("-"))
                field.Text = field.Text.Remove(field.Text.IndexOf("-"), 1);
            else
                field.Text = field.Text.Insert(0, "-");
        }

        /// <summary>
        /// Кнопка удаления последнего символа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (field.Text.Length > 1)
            {
                field.Text = field.Text.Remove(field.Text.Length - 1, 1);
            }
            else
                field.Text = "0";
        }




        #endregion

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch(e.Key)
            {
                case VirtualKey.NumberPad0:
                case VirtualKey.Number0:
                    Button_Click_Zero(numZero, null);
                    break;
                case VirtualKey.NumberPad1:
                case VirtualKey.Number1:
                    Button_Click(numOne, null);
                    break;
                case VirtualKey.NumberPad2:
                case VirtualKey.Number2:
                    Button_Click(numTwo, null);
                    break;
                case VirtualKey.NumberPad3:
                case VirtualKey.Number3:
                    Button_Click(numThr, null);
                    break;
                case VirtualKey.NumberPad4:
                case VirtualKey.Number4:
                    Button_Click(numFou, null);
                    break;
                case VirtualKey.NumberPad5:
                case VirtualKey.Number5:
                    Button_Click(numFiv, null);
                    break;
                case VirtualKey.NumberPad6:
                case VirtualKey.Number6:
                    Button_Click(numSix, null);
                    break;
                case VirtualKey.NumberPad7:
                case VirtualKey.Number7:
                    Button_Click(numSev, null);
                    break;
                case VirtualKey.NumberPad8:
                case VirtualKey.Number8:
                    Button_Click(numEig, null);
                    break;
                case VirtualKey.NumberPad9:
                case VirtualKey.Number9:
                    Button_Click(numNin, null);
                    break;
                case VirtualKey.Add:
                    Button_Add_Operator_Click(numAdd, null);
                    break;
                case VirtualKey.Subtract:
                    Button_Sub_Operator_Click(numSub, null);
                    break;
                case VirtualKey.Multiply:
                    Button_Myltiply_Operator_Click(numMul, null);
                    break;
                case VirtualKey.Divide:
                    Button_Divide_Operator_Click(numDiv, null);
                    break;
                case VirtualKey.Decimal:
                    Button_Click_Point(numSep, null);
                    break;
                case VirtualKey.Back:
                    Button_Delete_Click(numDel,null);
                    break;
            }
            //MessageDialog message = new MessageDialog(e.Key.ToString());
            //message.ShowAsync();
        }


        
    }
}
