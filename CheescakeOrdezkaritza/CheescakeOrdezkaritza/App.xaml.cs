﻿using CheescakeOrdezkaritza.Models;
using CheescakeOrdezkaritza.Service;
using CheescakeOrdezkaritza.Services;

namespace CheescakeOrdezkaritza
{
    public partial class App : Application
    {
        private static readonly DatuBaseaService _database = new DatuBaseaService();
        public static DatuBaseaService Database => _database;

        public static OrdezkaritzaService OrdezkaritzaService { get; } = new OrdezkaritzaService(_database.GetConnection());
        public static PartnerrakService PartnerrakService { get; } = new PartnerrakService(_database.GetConnection());

        public static ProduktuakService ProduktuakService { get; } = new ProduktuakService(_database.GetConnection());

        public static StockService StockService { get; } = new StockService(_database.GetConnection());

        public static EskaerakService EskaerakService { get; } = new EskaerakService(_database.GetConnection());

        public static EskaeraXehetasunakService EskaeraXehetasunakService { get; } = new EskaeraXehetasunakService(_database.GetConnection());

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); // Asegura que se usa el Shell
        }
    }
}
