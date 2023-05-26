using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
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

            await foreach (var person in DeserializeAsyncEnumerable<PersonModel>(filePath))
            {
                Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                Console.WriteLine($"Middle Name: {person.MiddleName}");
                Console.WriteLine($"Phone Number: {person.PhoneNumber}");
                Console.WriteLine($"Passport: {person.Passport.Seria} №{person.Passport.Number}");
                Console.WriteLine();
            }
        }

        public static async IAsyncEnumerable<T> DeserializeAsyncEnumerable<T>(string filePath)
        {
            using var fileStream = File.OpenRead(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<T>(fileStream, options))
            {
                yield return item;
            }
        }
    }
}