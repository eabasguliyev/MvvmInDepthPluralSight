using System.Collections.ObjectModel;
using System.ComponentModel;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    public class CustomerListViewModel
    {
        private readonly ICustomersRepository _repository;


        public CustomerListViewModel()
        {
            _repository = new CustomersRepository();

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            Customers = new ObservableCollection<Customer>(_repository.GetCustomersAsync().Result);
        }


        public ObservableCollection<Customer> Customers { get; set; }
    }
}