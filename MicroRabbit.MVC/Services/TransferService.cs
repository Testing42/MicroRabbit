using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json; // Ensure this namespace is included
using System.Text; // Include for Encoding

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:7031/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto),
                                            Encoding.UTF8, "application/json"); // Encoding specified here

            var response = await _apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
