using System.Collections.ObjectModel;
using System.Windows.Input;
using BahanaLautan.Source.Object.Notifications;
using Microsoft.Maui.Controls;

namespace BahanaLautan.Source.Model.Notifications
{
    public class NotificationViewModel
    {
        public double ItemHeight { get; set; }
        public ObservableCollection<ItemNotifications> Items { get; set; }
        public ICommand DeleteCommand { get; }

        public NotificationViewModel()
        {
            Items = new ObservableCollection<ItemNotifications>
            {
                new ItemNotifications { Title="Notification Request", Description="Example detail notification request.", ImageSource="Resources/Images/request_notify.png"},
                new ItemNotifications { Title="Notification Process", Description="Example detail notification process.", ImageSource="Resources/Images/process.png"},
                new ItemNotifications { Title="Notification Complete", Description="Example detail notification complete.", ImageSource="Resources/Images/complete.png"},
            };

            DeleteCommand = new Command<ItemNotifications>(DeleteNotification);
            ItemHeight = DeviceDisplay.Current.MainDisplayInfo.Height * 0.3;
        }

        private void DeleteNotification(ItemNotifications item)
        {
            if (item != null && Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
    }
}
