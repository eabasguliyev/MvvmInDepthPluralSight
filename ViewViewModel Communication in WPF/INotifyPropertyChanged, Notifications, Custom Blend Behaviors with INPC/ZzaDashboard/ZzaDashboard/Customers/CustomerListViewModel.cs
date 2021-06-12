using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;
using ZzaDesktop;

namespace ZzaDashboard.Customers
{
    public class CustomerListViewModel:BindableBase
    {
        private readonly ICustomersRepository _repository;
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;


        public CustomerListViewModel()
        {
            _repository = new CustomersRepository();

            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }

        public async void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            Customers = new ObservableCollection<Customer>(await _repository.GetCustomersAsync());
        }

        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }

        private void OnDelete()
        {
            _customers.Remove(SelectedCustomer);
        }


        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                (DeleteCommand as RelayCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand DeleteCommand { get; private set; }
    }
} 