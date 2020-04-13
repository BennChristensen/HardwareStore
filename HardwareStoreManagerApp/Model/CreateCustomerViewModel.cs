using HardwareStoreCommon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreManagerApp.Model
{
    class CreateCustomerViewModel : INotifyPropertyChanged
    {
        public Customer Customer { get; set; }

        private String validationErrorOnName;
        public String ValidationErrorOnName
        {
            get
            {
                return validationErrorOnName;
            }
            set
            {
                if (validationErrorOnName == value) { return; }
                validationErrorOnName = value;
                Notify(nameof(ValidationErrorOnName));
            }
        }

        private String validationErrorOnEmail;
        public String ValidationErrorOnEmail
        {
            get
            {
                return validationErrorOnEmail;
            }
            set
            {
                if (validationErrorOnEmail == value) { return; }
                validationErrorOnEmail = value;
                Notify(nameof(ValidationErrorOnEmail));
            }
        }

        private String validationErrorOnUserName;
        public String ValidationErrorOnUserName
        {
            get
            {
                return validationErrorOnUserName;
            }
            set
            {
                if (validationErrorOnUserName == value) { return; }
                validationErrorOnUserName = value;
                Notify(nameof(ValidationErrorOnUserName));
            }
        }

        private void Notify(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CreateCustomerViewModel()
        {
            this.Customer = new Customer { Name = "", Address = "", Email = "", UserName =""};
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
