using Wpf.Ui.Controls;

namespace WpfApp1.Views.Pages;

public partial class DataPage : INavigableView<ViewModels.DataViewModel>
{
    public ViewModels.DataViewModel ViewModel { get; }

    public DataPage(ViewModels.DataViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}