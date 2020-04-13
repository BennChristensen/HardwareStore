using HardwareStoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreManagerApp.Model
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public String SearchForCustomerParameter { get; set; }
        public Customer SelectedCustomer { get; set; }
        public Booking SelectedBooking { get; set; }
        
        private Boolean handoutBtnIsEnabled;
        public Boolean HandoutBtnIsEnabled
        {
            get
            { 
                return handoutBtnIsEnabled; 
            }
            set
            {
                handoutBtnIsEnabled = value;
                Notify(nameof(HandoutBtnIsEnabled));
            }
        }

        private Boolean returnBtnIsEnabled;
        public Boolean ReturnBtnIsEnabled
        {
            get
            {
                return returnBtnIsEnabled;
            }
            set
            {
                returnBtnIsEnabled = value;
                Notify(nameof(ReturnBtnIsEnabled));
            }
        }

        public MainWindowViewModel()
        {
            HandoutBtnIsEnabled = false;
            ReturnBtnIsEnabled = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
