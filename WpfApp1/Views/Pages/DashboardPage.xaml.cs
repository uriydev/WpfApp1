using Wpf.Ui.Controls;

namespace WpfApp1.Views.Pages;

public partial class DashboardPage : INavigableView<ViewModels.DashboardViewModel>
{
    public ViewModels.DashboardViewModel ViewModel { get; }

    public DashboardPage(ViewModels.DashboardViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}