using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Caliburn.Micro;
using lab10_WPF.Model;

namespace ConsoleTest
{
    internal class Program
    {
        public static async Task Main()
        {
            //string filePath = "..\\..\\..\\..\\lab10_WPF\\Data\\persons.json";
            string filePath = "Data\\persons.json";

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //Console.WriteLine($"Base Directory: {baseDirectory}");
            List<PersonModel> models = new List<PersonModel>();

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var persons = DeserializeAsyncEnumerable<PersonModel>(fileStream);

                await foreach (var person in persons)
                {
                    Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                    Console.WriteLine($"Middle Name: {person.MiddleName}");
                    Console.WriteLine($"Phone Number: {person.PhoneNumber}");
                    Console.WriteLine($"Passport: {person.Passport.Seria} №{person.Passport.Number}");
                    Console.WriteLine();

                    models.Add( person );
                }

            }

            //string filePathwr = "Data\\path_to_your_file2.json";
            using (var fileStream = File.Create(filePath))
            {
                await SerializeAsyncEnumerable(models, fileStream);
            }


            Console.WriteLine();
            Console.WriteLine($"_________________________________________________________"); 
            Console.WriteLine();

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var persons = DeserializeAsyncEnumerable<PersonModel>(fileStream);

                await foreach (var person in persons)
                {
                    Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                    Console.WriteLine($"Middle Name: {person.MiddleName}");
                    Console.WriteLine($"Phone Number: {person.PhoneNumber}");
                    Console.WriteLine($"Passport: {person.Passport.Seria} №{person.Passport.Number}");
                    Console.WriteLine();
                }

            }
        }

        public static async IAsyncEnumerable<T> DeserializeAsyncEnumerable<T>(FileStream fileStream)
        {
            //using var fileStream = File.OpenRead(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<T>(fileStream, options))
            {
                yield return item;
            }
        }

        public static async Task SerializeAsyncEnumerable<T>(List<T> data, FileStream fileStream)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            //using var fileStream = File.Create(filePath); //for creating a definitely new file
            //await using var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None);

            await using var utf8JsonWriter = new Utf8JsonWriter(fileStream);

            utf8JsonWriter.WriteStartArray(); // Start writing the JSON array

            foreach (var item in data)
            {
                JsonSerializer.Serialize(utf8JsonWriter, item, options);
            }

            utf8JsonWriter.WriteEndArray(); // End writing the JSON array
            await utf8JsonWriter.FlushAsync();
        }
    }
}