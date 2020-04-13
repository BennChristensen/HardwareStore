using HardwareStoreCommon.Models;
using HardwareStoreCommon.Storage;
using HardwareStoreManagerApp.Model;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HardwareStoreManagerApp.Views
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window
    {
        private readonly Button _button;
        private readonly CreateCustomerViewModel _viewModel;
        private readonly HardwareStoreContext _dbContext;
        public CreateCustomer(Button button, HardwareStoreContext dbContext)
        {
            _button = button;
            _button.IsEnabled = false;
            _dbContext = dbContext;
            InitializeComponent();
            this._viewModel = new CreateCustomerViewModel();
            this.DataContext = _viewModel;
        }

        private void OnCreateCustomerClicked(object sender, RoutedEventArgs e)
        {
                try
                {
                    _dbContext.AddNewCustomer(_viewModel.Customer);
                    CloseThisWindow();
                    MessageBox.Show("Ny kunde oprettet.");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationError in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            switch (validationError.PropertyName)
                            {
                                case "Name":
                                    _viewModel.ValidationErrorOnName = validationError.ErrorMessage;
                                    break;
                                case "Email":
                                    //TODO: Find out how to validate e-mail.  
                                    _viewModel.ValidationErrorOnEmail = validationError.ErrorMessage;
                                    break;
                                case "UserName":
                                    _viewModel.ValidationErrorOnUserName = validationError.ErrorMessage;
                                    break;
                                default:
                                    throw ex;
                            }

                        }
                    }
                }
                catch (DbUpdateException)
                {
                    //TODO: Check exception is constaint violation on userName
                     _viewModel.ValidationErrorOnUserName = "Bruger navn eksisterer allerede. Vælg venligst et andet";
                }
        }

        private void OnCancelClicked(object sender, RoutedEventArgs e)
        {
            CloseThisWindow();
        }

        private void OnUserNameGotFocus(object sender, RoutedEventArgs e)
        {
            _viewModel.ValidationErrorOnUserName = "";
        }

        private void OnNameGotFocus(object sender, RoutedEventArgs e)
        {
            _viewModel.ValidationErrorOnName = "";
        }

        private void CloseThisWindow()
        {
            _button.IsEnabled = true;
            this.Close();
        }
    }
}
