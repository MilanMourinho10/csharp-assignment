using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgiften.Services
{
    public class FileService
    {
        private static readonly string filePath = @"C:\kod\customer.json";     
        
        public static async Task SaveToFileAsync(string contentAsJson)
        {
            using StreamWriter file = new StreamWriter(filePath);
            await file.WriteLineAsync(contentAsJson);

            await Task.Delay(10000);
            Console.WriteLine("File Saved");
        }
    }
}
        //  // En privat statiskt läsbar fält för sökvägen där data kommer att lagras i JSON-format
// i min customer service så lagrades information till Json, denna sparar innehållet till en fil och visar att filen sparas efter 10 sekunder.