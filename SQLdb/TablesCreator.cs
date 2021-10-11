using System;
using Npgsql;

namespace SQLdb
{
    /// <summary>
    /// Генератор таблиц
    /// </summary>
    public class TablesCreator
    {
        private readonly NpgsqlConnection _npgsqlCommand;
        
        public TablesCreator(string connectString)
        {
            _npgsqlCommand = new NpgsqlConnection(connectString);
        }
        
        public event EventHandler<string>? CreateMessage;

        /// <summary>
        /// Создание всех таблиц.
        /// </summary>
        public void CreateTables()
        {
           _npgsqlCommand.Open();
           
           CreateStoresTable();
           CreateProductsTable();
           CreatePurchasesTable();
           CreateCustomersTable();
           
           _npgsqlCommand.Close();
        }

        /// <summary>
        /// Создание таблицы магазинов
        /// </summary>
        private void CreateStoresTable()
        {
            var command = @"CREATE TABLE otus_stores
            (
                Id SERIAL NOT NULL PRIMARY KEY UNIQUE,
                Name TEXT NOT NULL
            );";
            
            CreateTable(command, "otus_srores");
        }
        
        /// <summary>
        /// Создание таблицы продуктов
        /// </summary>
        private void CreateProductsTable()
        {
            var command = @"CREATE TABLE otus_products
            (
                Id SERIAL NOT NULL PRIMARY KEY,
                Name VARCHAR(30) NOT NULL,
                Price DOUBLE PRECISION NOT NULL,
                StoreId SERIAL NOT NULL,
                FOREIGN KEY (StoreId) REFERENCES otus_stores (id) ON DELETE CASCADE 
            );";
            
            CreateTable(command, "otus_products");
        }
        
        /// <summary>
        /// Создание таблицы покупок
        /// </summary>
        private void CreatePurchasesTable()
        {
            var command = @"CREATE TABLE otus_purchases
            (
                Id SERIAL NOT NULL PRIMARY KEY,
                Date DATE NOT NULL,
                ProductId SERIAL NOT NULL,
                FOREIGN KEY (ProductId) REFERENCES otus_products (id) ON DELETE CASCADE 
            );";
            
            CreateTable(command, "otus_purchases");
        }
        
        /// <summary>
        /// Создание таблицы покупателей
        /// </summary>
        private void CreateCustomersTable()
        {
            var command = @"CREATE TABLE otus_customers
            (
                Id SERIAL NOT NULL PRIMARY KEY,
                First_name VARCHAR(30) NOT NULL,
                Last_name VARCHAR(30) NOT NULL,
                Email VARCHAR(150),
                Address VARCHAR(100) NOT NULL,
                Price DOUBLE PRECISION NOT NULL,
                PurchaseId SERIAL NOT NULL,
                FOREIGN KEY (PurchaseId) REFERENCES otus_purchases (id) ON DELETE CASCADE 
            );";
            
            CreateTable(command, "otus_customers");
        }
        
        /// <summary>
        /// Генерация таблицы
        /// </summary>
        /// <param name="command">Команда</param>
        /// <param name="tableName">Имя таблицы, только для сообщения</param>
        private void CreateTable(string command, string tableName)
        {
            try
            {
                using (var cmd = new NpgsqlCommand(command, _npgsqlCommand))
                {
                    cmd.ExecuteNonQuery();
                    CreateMessage?.Invoke(null, $"Table '{tableName}' create.");
                }
            }
            catch (Exception e)
            {
                CreateMessage?.Invoke(null, $"Table '{tableName}' not create.");
                CreateMessage?.Invoke(null, e.Message);
            }
        }
    }
}