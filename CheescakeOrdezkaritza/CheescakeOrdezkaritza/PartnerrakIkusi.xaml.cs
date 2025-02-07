using CheescakeOrdezkaritza.Services;
using CheescakeOrdezkaritza.ViewModels;
using SQLite;

namespace CheescakeOrdezkaritza;

public partial class PartnerrakIkusi : ContentPage
{
    private readonly PartnerrakViewModel _viewModel;

    public PartnerrakIkusi() : this(App.PartnerrakService, App.OrdezkaritzaService) { }

    public PartnerrakIkusi(PartnerrakService partnerrakService, OrdezkaritzaService ordezkaritzaService)
    {
        InitializeComponent();
        _viewModel = new PartnerrakViewModel(partnerrakService, ordezkaritzaService);
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.KargatuPartnerrakAsync();
    }
}
