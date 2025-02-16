﻿using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using System.Diagnostics;

namespace CheescakeOrdezkaritza.Service
{
    public class DatuBaseaService
    {
        private readonly string _dbPath;
        private readonly SQLiteAsyncConnection _database;

        public DatuBaseaService()
        {
            try
            {
                _dbPath = Path.Combine(FileSystem.AppDataDirectory, "OrdezkaritzaDB0.db");

                //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //string logFilePath = Path.Combine(desktopPath, "log.txt");

                //File.AppendAllText(logFilePath, $"📌 Ruta BD: {_dbPath}\n");


                // Si la BD no existe en AppDataDirectory, la copiamos
                if (!File.Exists(_dbPath))
                {
                    Console.WriteLine("📂 Base de datos no encontrada, copiando...");
                    CopyDatabaseFromAssets();
                }
                else
                {
                    Console.WriteLine("✔ Base de datos ya existente en AppDataDirectory.");
                }

                _database = new SQLiteAsyncConnection(_dbPath);
                Console.WriteLine($"✔ Base de datos inicializada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inicializando la base de datos: {ex.Message}");
            }
        }

        private async void CopyDatabaseFromAssets()
        {
            try
            {
                using Stream dbStream = await FileSystem.OpenAppPackageFileAsync("OrdezkaritzaDB0.db");
                using FileStream fileStream = new FileStream(_dbPath, FileMode.Create, FileAccess.Write);
                await dbStream.CopyToAsync(fileStream);
                Console.WriteLine("✅ Base de datos copiada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error copiando la base de datos: {ex.Message}");
            }
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return _database;
        }
    }
}
