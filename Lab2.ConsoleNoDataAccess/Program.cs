using RestSharp;

namespace Lab2.ConsoleNoDataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new RestClientOptions("https://localhost:7118")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/WeatherForecast", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            Console.ReadLine();
        }
    }
}
