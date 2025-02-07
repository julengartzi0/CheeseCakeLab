using CheescakeOrdezkaritza.Services;
using CheescakeOrdezkaritza.ViewModels;
using SQLite;

namespace CheescakeOrdezkaritza;


public partial class ProduktuakPage : ContentPage
{
	private readonly ProduktuakViewModel _viewModel;

    public ProduktuakPage() : this(App.ProduktuakService, App.StockService) { }

    public ProduktuakPage(ProduktuakService produktuakService, StockService stockService)
	{
		InitializeComponent();
        _viewModel = new ProduktuakViewModel(produktuakService, stockService);
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.KargatuProduktuakAsync();
    }
}