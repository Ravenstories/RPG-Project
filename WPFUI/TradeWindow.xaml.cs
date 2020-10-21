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
using System.Windows.Shapes;
using Engine.Models;
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for TradeWindow.xaml
    /// </summary>
    public partial class TradeWindow : Window
    {
        public GameSession Session => DataContext as GameSession;
        public TradeWindow()
        {
            InitializeComponent();
        }
        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GroupedInventory groupedInventory = ((FrameworkElement)sender).DataContext as GroupedInventory;
            if (groupedInventory != null)
            {
                Session.CurrentPlayer.ReceiveGold(groupedInventory.Item.Price);
                Session.CurrentTrader.AddItemToInventory(groupedInventory.Item);
                Session.CurrentPlayer.RemoveItemFromInventory(groupedInventory.Item);
            }
        }
        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GroupedInventory groupedInventory = ((FrameworkElement)sender).DataContext as GroupedInventory;
            if (groupedInventory != null)
            {
                if (Session.CurrentPlayer.Gold >= groupedInventory.Item.Price)
                {
                    Session.CurrentPlayer.SpendGold(groupedInventory.Item.Price);
                    Session.CurrentTrader.RemoveItemFromInventory(groupedInventory.Item);
                    Session.CurrentPlayer.AddItemToInventory(groupedInventory.Item);
                }
                else
                {
                    MessageBox.Show("You don't have enough gold");
                }
            }
        }
        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
