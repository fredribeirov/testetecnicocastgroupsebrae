using RestSharp.Authenticators;
using RestSharp;
using System.Threading;
using TCastGroupSebrae.API.Interface;
using TCastGroupSebrae.API.Model;

namespace TCastGroupSebrae.API.Service
{
    public class ViaCepService : IViaCepService
    {
        private string _baseUrl = "http://viacep.com.br/ws/";
        public async Task<ViaCep> BuscaCep(string cep)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"{cep}/json",Method.Get);

            var response = await client.ExecuteAsync<ViaCep>(request);
            if(response.IsSuccessful)
            {
                return response.Data;
            }
            return null;
        }
    }
}
