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
    public class OrdezkaritzaViewModel
    {
        public ObservableCollection<Ordezkaritza> Ordezkaritzak { get; set; }
        private readonly OrdezkaritzaService _ordezkaritzaService;

        public OrdezkaritzaViewModel(OrdezkaritzaService ordezkaritzaService)
        {
            _ordezkaritzaService = ordezkaritzaService;
            Ordezkaritzak = new ObservableCollection<Ordezkaritza>();
        }

        public async Task KargatuOrdezkaritzakAsync()
        {
            var zerrenda = await _ordezkaritzaService.EskuratuOrdezkaritzakAsync();
            Ordezkaritzak.Clear();
            foreach (var ordezkaritza in zerrenda)
            {
                Ordezkaritzak.Add(ordezkaritza);
            }
        }
    }
}
