using Graph.Models;
using Newtonsoft.Json;

namespace Graph.BO
{
    public class RequestAPI<T>
    {
        private string _uri;
        private string _path;
        public RequestAPI(string uri, string path) 
        { 
            _uri = uri;
            _path = path;
        }

        public async Task<IEnumerable<T>> GetDataAsync()
        {
            IEnumerable<T> Liste;

            using (var httpClient = new HttpClient())
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(_uri);
                using (var response = await httpClient.GetAsync($"{_uri}{_path}"))
                {
                    try
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Liste = JsonConvert.DeserializeObject<IEnumerable<T>>(apiResponse);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }                    
                }
            }
            return Liste;
        }

    }

    
}



/*
          client.BaseAddress = new Uri("http://localhost:6740");
          var content = new FormUrlEncodedContent(new[]
          {
              new KeyValuePair<string, string>("", "login")
          });

var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("", "login")
        });
        var result = await client.PostAsync("/api/Membership/exists", content);
          */