using GameLibrary.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameLibrary.Services
{
    public class ApiService
    {
        public async Task GetAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api/");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response
                        var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonString);

                        if (apiResponse?.results?.Length > 0)
                        {
                            var result = apiResponse.results[0];

                            // Extract the required information
                            string name = $"{result.name.first} {result.name.last}";
                            int age = result.dob.age;

                            // Print the extracted information
                            Console.WriteLine($"Driver: {name}");
                            Console.WriteLine($"Age: {age}");
                        }
                        else
                        {
                            Console.WriteLine("API response is invalid or does not contain any results.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve data from the API.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
