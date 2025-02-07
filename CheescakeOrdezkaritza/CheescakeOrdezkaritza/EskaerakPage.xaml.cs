using CheescakeOrdezkaritza.Services;
using CheescakeOrdezkaritza.ViewModels;
using SQLite;

namespace CheescakeOrdezkaritza;

public partial class EskaerakPage : ContentPage
{

	private readonly EskaerakViewModel _viewModel;

	public EskaerakPage() : this(App.EskaerakService, App.EskaeraXehetasunakService, App.ProduktuakService) { }
	public EskaerakPage(EskaerakService eskaerakService, EskaeraXehetasunakService eskaeraXehetasunakService, ProduktuakService produktuakService)
	{
		InitializeComponent();
		_viewModel = new EskaerakViewModel(eskaerakService, eskaeraXehetasunakService, produktuakService);
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.KargatuEskaerakAsync();
    }
}