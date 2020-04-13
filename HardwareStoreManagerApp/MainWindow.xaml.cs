using HardwareStoreCommon.Models;
using HardwareStoreCommon.Storage;
using HardwareStoreManagerApp.Model;
using HardwareStoreManagerApp.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HardwareStoreManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HardwareStoreContext _dbContext;
        private readonly MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new HardwareStoreContext();
            _dbContext.Customers.Load();
            //TODO: Set up search filter
            //var view = CollectionViewSource.GetDefaultView(_dbContext.Customers);
            this._viewModel = new MainWindowViewModel
            {
                Customers = _dbContext.Customers.Local
            };
            this.DataContext = _viewModel;
        }

        private void OnNewCustomerClicked(object sender, RoutedEventArgs e)
        {
            CreateNewCustomerBtn.IsEnabled = false;
            new CreateCustomer(CreateNewCustomerBtn, _dbContext).Show();
            CreateNewCustomerBtn.IsEnabled = true;
        }

        private void OnCustomerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SelectedCustomer = e.AddedItems[0] as Customer;
            _dbContext.Customers.Attach(_viewModel.SelectedCustomer);
            _dbContext.Entry(_viewModel.SelectedCustomer)
                .Collection(c => c.Bookings)
                .Query().Where(b => b.Status != Booking.BookingStatus.Returned)
                .Include(b => b.Tool)
                .Load();
            //BookingsList.DataContext = _viewModel.SelectedCustomer.Bookings;
        }

        private void OnBookingDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            var booking = item.DataContext as Booking;
            //TODO: Create a details window to display Booking details when doublecliked
        }

        private void OnReturnedClicked(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedBooking != null)
            {

                _dbContext.Bookings.Attach(_viewModel.SelectedBooking);
                _viewModel.SelectedBooking.Status = Booking.BookingStatus.Returned;
                _dbContext.SaveChanges();
                _viewModel.HandoutBtnIsEnabled = false;
                _viewModel.ReturnBtnIsEnabled = false;
                //TODO : Update bookings list so it does not display the returned booking;
                //_dbContext.Entry(_viewModel.SelectedCustomer)
                //    .Collection(c => c.Bookings)
                //    .Query().Where(b => b.Status != Booking.BookingStatus.Returned)
                //    .Include(b => b.Tool)
                //    .Load();
            }
        }
        private void OnHandOutClicked(object sender, RoutedEventArgs e)
        {
            _dbContext.Bookings.Attach(_viewModel.SelectedBooking);
            _viewModel.SelectedBooking.Status = Booking.BookingStatus.HandedOut;
            _dbContext.SaveChanges();
            //TODO: Add IValueConverter to bind IsEnabled property to Booking.Status 
            _viewModel.HandoutBtnIsEnabled = false;
            _viewModel.ReturnBtnIsEnabled = true;
        }

        private void OnBookingSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _viewModel.SelectedBooking = e.AddedItems[0] as Booking;
                if(_viewModel.SelectedBooking.Status == Booking.BookingStatus.HandedOut)
                {
                    _viewModel.ReturnBtnIsEnabled = true;
                }
                if(_viewModel.SelectedBooking.Status == Booking.BookingStatus.Reserved)
                {
                    _viewModel.HandoutBtnIsEnabled = true;
                }
            }
            else
            {
                _viewModel.SelectedBooking = null;
                HandOutBtn.IsEnabled = false;
                ReturnBtn.IsEnabled = false;
            }
        }
    }
}
