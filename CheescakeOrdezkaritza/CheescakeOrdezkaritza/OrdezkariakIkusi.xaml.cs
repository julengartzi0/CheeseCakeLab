using CheescakeOrdezkaritza.Services;
using CheescakeOrdezkaritza.ViewModels;
using SQLite;

namespace CheescakeOrdezkaritza;

public partial class OrdezkariakIkusi : ContentPage
{

    private readonly OrdezkaritzaViewModel _viewModel;

    public OrdezkariakIkusi() : this(App.OrdezkaritzaService) { }

    public OrdezkariakIkusi(OrdezkaritzaService ordezkaritzaService)
    {
        InitializeComponent();
        _viewModel = new OrdezkaritzaViewModel(ordezkaritzaService);
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.KargatuOrdezkaritzakAsync();
    }
}