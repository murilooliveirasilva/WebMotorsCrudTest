using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WM.Bussiness.Interfaces;
using WM.Bussiness.Models;

namespace WM.Bussiness.Service
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public async Task<List<MakeModel>> callMakeAPI()
        {
            var client = new HttpClient();
            var request = await client.GetAsync("https://desafioonline.webmotors.com.br/api/OnlineChallenge/Make");
            string response = await request.Content.ReadAsStringAsync();
            if (request.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<MakeModel>>(response);
            }
            return null;
            
        }

        public async Task<List<ModelModel>> callModelAPI(int id)
        {
            var client = new HttpClient();
            var request = await client.GetAsync($"https://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID={id}");
            string response = await request.Content.ReadAsStringAsync();
            if (request.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<ModelModel>>(response);
            }
            return null;
        }

        public async Task<List<VersionModel>> callVersionAPI(int id)
        {
            var client = new HttpClient();
            var request = await client.GetAsync($"https://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID={id}");
            string response = await request.Content.ReadAsStringAsync();
            if (request.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<VersionModel>>(response);
            }
            return null;
        }

        public void Dispose()
        {
            _anuncioRepository?.Dispose();
        }


    }
}
