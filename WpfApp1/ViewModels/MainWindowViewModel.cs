using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Controls;
using WpfApp1.Views.Pages;

namespace WpfApp1.ViewModels;
    
public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<NavigationViewItem> _navigationItems;
    
    public MainWindowViewModel()
    {
        NavigationItems = new ObservableCollection<NavigationViewItem>
        {
            new NavigationViewItem
            {
                Content = "Data",
                TargetPageType = typeof(DataPage)
            },
            new NavigationViewItem
            {
                Content = "Settings",
                TargetPageType = typeof(SettingsPage)
            }
        };
    }
}