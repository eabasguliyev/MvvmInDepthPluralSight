using System;
using System.Timers;
using ZzaDesktop;

namespace ZzaDashboard
{
    public class MainWindowViewModel:BindableBase
    {
        private string _notificationMessage;
        public object CurrentViewModel { get; set; }

        private Timer _timer;
        public MainWindowViewModel()
        {
            CurrentViewModel = new Customers.CustomerListViewModel();

            _timer = new Timer();

            _timer.Interval = 5000;

            _timer.Elapsed += (sender, args) =>
            {
                NotificationMessage = "At the tone the time will be: " + DateTime.Now.ToLocalTime();
            };

            _timer.Start();
        }


        public string NotificationMessage
        {
            get => _notificationMessage;
            set
            {
                if (value == _notificationMessage)
                    return;

                _notificationMessage = value;

                OnPropertyChanged(nameof(NotificationMessage));
            }
        }
    }
}
