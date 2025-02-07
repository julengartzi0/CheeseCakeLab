using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheescakeOrdezkaritza.Models;
using CheescakeOrdezkaritza.Services;

namespace CheescakeOrdezkaritza.ViewModels
{
    public class ProduktuakViewModel
    {
        public ObservableCollection<Produktua> Produktuak { get; set; }
        private readonly ProduktuakService _produktuaService;
        private readonly StockService _stockService;

        public ProduktuakViewModel(ProduktuakService produktuaService, StockService stockService)
        {
            _produktuaService = produktuaService;
            this._stockService = stockService;
            Produktuak = new ObservableCollection<Produktua>();
        }

        public async Task KargatuProduktuakAsync()
        {
            // Obtener listas de productos y stock desde los servicios
            var stockLista = await _stockService.EskuratuStockAsync();
            var produktuakLista = await _produktuaService.EskuratuProduktuakAsync();

            // Limpiar la colección antes de recargar datos
            Produktuak.Clear();

            // Recorrer cada producto y asignarle su stock correspondiente
            foreach (var produktua in produktuakLista)
            {
                // Buscar en la lista de stock el que corresponda con el producto
                var stock = stockLista.FirstOrDefault(s => s.ProduktuaKodea == produktua.ProduktuaKodea);

                // Si existe stock, asignamos la cantidad, de lo contrario, 0
                produktua.Kantitatea = stock?.Kantitatea.ToString() ?? "0";

                // Agregar el producto actualizado a la colección observable
                Produktuak.Add(produktua);
            }
        }

    }
}
