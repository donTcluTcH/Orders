using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using Orders.Model;

namespace Orders
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static int Summa = 0;

        public MainWindow()
        {
            InitializeComponent();

            this.MinHeight = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.5);
            this.MinWidth = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.5);

            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.9);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.75);

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();

            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Clock.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Item1_Click(object sender, RoutedEventArgs e)
        {
            List<OrderElement> list = new List<OrderElement>();
            for (int i = 0; i < 10; i++)
            {
                OrderElement OE = new OrderElement();
                list.Add(OE);
            }

            int price = 50;

            List<string> names = new List<string>() { "Предмет 1", "Предмет 2", "Предмет 3", "Предмет 4", "Предмет 5", "Предмет 6", "Предмет 7", "Предмет 8", "Предмет 9", "Предмет 10" };
            int counter = 0;
            foreach (var item in list)
            {
                item.cost = price;
                item.ElementCount.Content = price;
                item.ElementName.Content = names[counter];

                OrderList.Items.Add(item);

                price = (price + 100);
                counter++;
            }

            Price.Content = 100 + (counter * price );
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var qwe = OrderList.SelectedItem;

            OrderList.Items.Remove(qwe);
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Clear();

            OrderID.Content = "";

            Price.Content = "0";

            Continuee.Visibility = Visibility.Visible;

            Payy.Visibility = Visibility.Hidden;
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            //int i = rand.Next(1, 99999);
            int b = rand.Next(1, 999);

            OrderID.Content = b;
            //Price.Content = i;

            Continuee.Visibility = Visibility.Hidden;

            Payy.Visibility = Visibility.Visible;
        }

        private void OrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            Itog.Content = Price.Content;
            ItogOrder.Content = OrderID.Content;

            OrderScreen.Visibility = Visibility.Hidden;
            PayScreen.Visibility = Visibility.Visible;

            this.ResizeMode = ResizeMode.NoResize;

            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.7);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.55);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            OrderScreen.Visibility = Visibility.Visible;
            PayScreen.Visibility = Visibility.Hidden;

            this.ResizeMode = ResizeMode.CanResize;

            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.9);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.75);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PaymentType.Visibility = Visibility.Hidden;
            Oplata.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PaymentType.Visibility = Visibility.Hidden;
            Oplata.Visibility = Visibility.Visible;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PaymentType.Visibility = Visibility.Visible;
            Oplata.Visibility = Visibility.Hidden;
        }

        private void PendingOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PaidOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PostponeOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
