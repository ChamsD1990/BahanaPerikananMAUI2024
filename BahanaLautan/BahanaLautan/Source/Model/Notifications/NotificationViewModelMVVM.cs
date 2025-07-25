using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; 
using System.Windows.Input;

namespace BahanaLautan.Source.Model.Notifications;

public class NotificationViewModelMVVM : ObservableObject
{
    public ICommand BackCommand { get; }
    public ICommand SettingsCommand { get; }

    public NotificationViewModelMVVM()
    {
        BackCommand = new RelayCommand(OnBack);
        SettingsCommand = new RelayCommand(OnSettings);
    }

    private void OnBack()
    {
        // Handle back navigation
        Shell.Current.GoToAsync(".."); // This will navigate back in the Shell
    }

    private void OnSettings()
    {
        // Navigate to settings page
        Shell.Current.GoToAsync("//settings"); // Update with your settings page route
    }
}