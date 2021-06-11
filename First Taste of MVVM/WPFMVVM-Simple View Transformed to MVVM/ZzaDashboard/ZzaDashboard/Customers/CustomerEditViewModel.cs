using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Annotations;
using ZzaDashboard.Services;
using ZzaDesktop;

namespace ZzaDashboard.Customers
{
    public class CustomerEditViewModel:BindableBase
    {
        private Customer _customer;
        
        private ICustomersRepository _repository;

        public Guid CustomerId { get; set; }

        public ICommand SaveCommand { get; set; }


        public CustomerEditViewModel()
        {
            _repository = new CustomersRepository();
            SaveCommand = new RelayCommand(OnSave);
        }

        public async void LoadCustomer()
        {
            Customer = await _repository.GetCustomerAsync(CustomerId);
        }

        private async void OnSave()
        {
            Customer = await _repository.UpdateCustomerAsync(Customer);
        }


        public Customer Customer
        {
            get => _customer;
            set
            {
                if (Equals(value, _customer))
                    return;

                _customer = value;
                OnPropertyChanged("Customer");
            }
        }
    }
}