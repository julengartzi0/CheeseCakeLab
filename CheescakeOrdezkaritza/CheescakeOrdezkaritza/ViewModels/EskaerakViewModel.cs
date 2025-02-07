using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CheescakeOrdezkaritza.Models;
using CheescakeOrdezkaritza.Services;

namespace CheescakeOrdezkaritza.ViewModels
{
    public class EskaerakViewModel
    {
        public ObservableCollection<EskaeraXehetasuna> EskaeraXehetasunak { get; set; }
        private readonly EskaerakService _eskaerakService;
        private readonly EskaeraXehetasunakService _eskaeraXehetasunakService;
        private readonly ProduktuakService _produktuakService;
        private readonly PartnerrakService _partnerrakService;

        public EskaerakViewModel(EskaerakService eskaerakService, EskaeraXehetasunakService eskaeraXehetasunakService, ProduktuakService produktuakService)
        {
            _eskaerakService = eskaerakService;
            _eskaeraXehetasunakService = eskaeraXehetasunakService;
            _produktuakService = produktuakService;
            EskaeraXehetasunak = new ObservableCollection<EskaeraXehetasuna>();
        }

        /** 
         * Método para cargar la información de la clase EskaeraXehetasuna
         * desde el servicio correspondiente.
         */
        public async Task KargatuEskaerakAsync()
        {
            // Obtener listas de detalles de pedido, pedidos y productos desde los servicios
            var eskaeraXehetasunakLista = await _eskaeraXehetasunakService.EskuratuEskaeraXehetasunakAsync();
            var eskaerakLista = await _eskaerakService.EskuratuEskaerakAsync();
            var produktuakLista = await _produktuakService.EskuratuProduktuakAsync();

            // Limpiar la colección antes de recargar datos
            EskaeraXehetasunak.Clear();

            // Recorrer cada detalle de pedido y asignarle su información de pedido y producto correspondiente
            foreach (var eskaeraXehetasuna in eskaeraXehetasunakLista)
            {
                // Buscar en la lista de pedidos (Eskaerak) el que corresponda con el EskaeraKodea
                var eskaera = eskaerakLista.FirstOrDefault(e => e.EskaeraKodea == eskaeraXehetasuna.EskaeraKodea);

                // Buscar en la lista de productos (Produktua) el que corresponda con el ProduktuaKodea
                var produktua = produktuakLista.FirstOrDefault(p => p.ProduktuaKodea == eskaeraXehetasuna.ProduktuaKodea);

                // Si existe la relación, asignamos la fecha y el código de partner
                eskaeraXehetasuna.EskaeraData = eskaera?.EskaeraData ?? "Desconocido";
                eskaeraXehetasuna.PartnerKodea = eskaera?.PartnerKodea.ToString() ?? "0";

                // Si existe el producto, asignamos su nombre
                eskaeraXehetasuna.Izena = produktua?.Izena ?? "Desconocido";

                // Agregar el detalle de pedido actualizado a la colección observable
                EskaeraXehetasunak.Add(eskaeraXehetasuna);
            }
        }



    }
}
