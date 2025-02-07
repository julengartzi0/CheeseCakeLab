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
    public class PartnerrakViewModel
    {
        public ObservableCollection<Partner> Partnerrak { get; set; }
        private readonly PartnerrakService _partnerraService;
        private readonly OrdezkaritzaService _ordezkaritzaService; 

        public PartnerrakViewModel(PartnerrakService partnerraService, OrdezkaritzaService ordezkaritzaService)
        {
            _partnerraService = partnerraService;
            _ordezkaritzaService = ordezkaritzaService;
            Partnerrak = new ObservableCollection<Partner>();
        }

        public async Task KargatuPartnerrakAsync()
        {
            // 1. Obtener la lista de Ordezkaritza para mapear nombres
            var ordezkaritzak = await _ordezkaritzaService.EskuratuOrdezkaritzakAsync();

            // 2. Obtener la lista de Partner
            var partnerrakLista = await _partnerraService.EskuratuPartnerrakAsync();
            Partnerrak.Clear();

            foreach (var partner in partnerrakLista)
            {
                // 3. Buscar el nombre de la Ordezkaritza correspondiente al código
                var ordezkaritza = ordezkaritzak.FirstOrDefault(o => o.OrdezkaritzaKodea == partner.OrdezkaritzaKodea);

                // Asignar el nombre de la Ordezkaritza al Partner
                partner.OrdezkaritzaIzena = ordezkaritza != null ? ordezkaritza.Izena : "Ez da aurkitu";

                Partnerrak.Add(partner);
            }
        }


    }
}
