using System;
using System.Collections.Generic;
using Npgsql;
using SQLdb.Models;

namespace SQLdb
{
    /// <summary>
    /// Чтение данных
    /// </summary>
    public class DataReader
    {
        private readonly NpgsqlConnection _npgsqlCommand;
        
        public event EventHandler<string>? CreateMessage;
        
        public DataReader(string connectString)
        {
            _npgsqlCommand = new NpgsqlConnection(connectString);
        }

        /// <summary>
        /// Получение всех магазинов
        /// </summary>
        public void WriteAllStores()
        {
            var command = @"SELECT * FROM public.otus_stores";
            
            _npgsqlCommand.Open();
            
            using (var cmd = new NpgsqlCommand(command, _npgsqlCommand))
            {
                var executeReader =  cmd.ExecuteReader();
               
                CreateMessage?.Invoke(null, $"Stores:");
                while (executeReader.Read())
                {
                    CreateMessage?.Invoke(null, $"id: {executeReader.GetInt32(0)}. Name: {executeReader.GetString(1)}.");
                    
                }
            }
            
            _npgsqlCommand.Close();
        }
        
        /// <summary>
        /// Получение всех продуктов
        /// </summary>
        public void WriteAllProducts()
        {
            var command = @"SELECT * FROM public.otus_products";
            
            _npgsqlCommand.Open();
            
            using (var cmd = new NpgsqlCommand(command, _npgsqlCommand))
            {
                var executeReader =  cmd.ExecuteReader();
               
                CreateMessage?.Invoke(null, $"Product:");
                while (executeReader.Read())
                {
                    CreateMessage?.Invoke(null, string.Format("id: {0}. Name: {1}. Price: {2}",
                                           executeReader.GetInt32(0), 
                                           executeReader.GetString(1), 
                                           executeReader.GetDouble(2)));
                }
            }
            
            _npgsqlCommand.Close();
        }
    }
}