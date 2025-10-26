using System;
using System.Text.Json;

namespace Shop.Helpers
{
    public static class DebugHelper
    {
        public static void dd(object obj)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            Console.WriteLine(json);
            throw new Exception("Debug Die()");
        }
    }
}
