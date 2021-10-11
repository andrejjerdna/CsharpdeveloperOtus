using System;
using System.IO;
using Npgsql;

namespace SQLdb
{
    /// <summary>
    /// Класс генерирующий данные.
    /// Магазины генерируются с жестко указанными именами, для продуктов происходит рандомная генерацция имен.
    /// В качестве генератор тектовых данных добавлен генератор случайных имен файлов.
    /// </summary>
    public class DataGenerator
    {
        private readonly NpgsqlConnection _npgsqlCommand;
        private readonly Random _random;
        
        public DataGenerator(string connectString)
        {
            _npgsqlCommand = new NpgsqlConnection(connectString);
            _random = new Random();
        }
        
        public event EventHandler<string>? CreateMessage;

        /// <summary>
        /// Генерация данных
        /// </summary>
        public void Generate()
        {
            _npgsqlCommand.Open();
 
            StoresGenerator();
            ProductsGenerator();
            PurchasesGenerator();
            CustomersGenerator();
            
            _npgsqlCommand.Close();
        }

        /// <summary>
        /// Генерация магазинов
        /// </summary>
        private void StoresGenerator()
        {
            var command = @"INSERT INTO otus_stores (name) 
                            VALUES ('testStore1'),
                                   ('testStore2'),
                                   ('testStore3'),
                                   ('testStore4'),
                                   ('testStore5')";
            
            using (var cmd = new NpgsqlCommand(command, _npgsqlCommand))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    CreateMessage?.Invoke(null, $"Stores create.");
                }
                catch 
                {
                    CreateMessage?.Invoke(null, $"Stores not create.");
                }
            }
        }
        
        /// <summary>
        /// Генератор продуктов
        /// </summary>
        private void ProductsGenerator()
        {
            for (int i = 0; i < 10; i++)
            {
                var storeId = _random.Next(1, 1000);
                var price = _random.Next(1, 1000);
                var productName = Path.GetRandomFileName();
                
                var command = @"INSERT INTO otus_products (name, price, storeId) VALUES (@productName, @price, @storeId)";
            
                using (var cmd = new NpgsqlCommand(command, _npgsqlCommand))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@storeId", storeId);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        CreateMessage?.Invoke(null, $"Generate product: {productName}, price: {price} for store id: {storeId} ");
                    }
                    catch
                    {

                    }
                }
            }
        }
        
        /// <summary>
        /// Генератор покупок
        /// </summary>
        private void PurchasesGenerator()
        {
            for (int i = 0; i < 10; i++)
            {
                var productId = _random.Next(0, 1000);
                var date = DateTime.Now;
                
                var command = @"INSERT INTO otus_purchases (date, productId) VALUES (@date, @productId)";
            
                using (var cmd = new NpgsqlCommand(command, _npgsqlCommand))
                {
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    
                    try
                    {
                        cmd.ExecuteNonQuery();
                        CreateMessage?.Invoke(null, $"Generate purchase: {date} for product id: {productId} ");
                    }
                    catch
                    {

                    }
                }
            }
        }
        
        /// <summary>
        /// Генератор покупателей
        /// </summary>
        private void CustomersGenerator()
        {
            for (int i = 0; i < 10; i++)
            {
                var purchaseId = _random.Next(0, 1000);
                var firstName = Path.GetRandomFileName();
                var lastName = Path.GetRandomFileName();
                var email = Path.GetRandomFileName();
                var address = Path.GetRandomFileName();
                var price = _random.Next(1, 1000);
                
                var command = @"INSERT INTO otus_customers (first_name, last_name, email, address, price, purchaseId) 
                                VALUES (@first_name, @last_name, @email, @address, @price, @purchaseId)";
            
                using (var cmd = new NpgsqlCommand(command, _npgsqlCommand))
                {
                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@purchaseId", purchaseId);
                    
                    try
                    {
                        cmd.ExecuteNonQuery();
                        CreateMessage?.Invoke(null, $"Generate customers. {firstName} {lastName} email: {email} address: {address}");
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}