using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace scg.Services
{
    public class BggApiService
    {
        private readonly CookieContainer _cookie = new();

        private string _token = string.Empty;

        public async Task Login(string username, string password)
        {
            var postData = @"{""credentials"":{""username"":""" + username + @""",""password"":""" + password + @"""}}";

            var byteArray = Encoding.UTF8.GetBytes(postData);

            var webRequest = (HttpWebRequest)WebRequest.Create("https://www.boardgamegeek.com/login/api/v1");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.CookieContainer = _cookie;

            await using (var webpageStream = await webRequest.GetRequestStreamAsync())
            {
                await webpageStream.WriteAsync(byteArray, 0, byteArray.Length);
            }

            try
            {
                using var response = await webRequest.GetResponseAsync();
                using var reader = new StreamReader(response.GetResponseStream());
                var responseText = await reader.ReadToEndAsync();

                _token = _cookie.GetAllCookies().FirstOrDefault(p => p.Name == "SessionID").Value;

                if (responseText.Contains("<h1>Login Required</h1>"))
                {
                    Console.WriteLine("Error: Login failed.");
                    Environment.Exit(2);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Login failed.");
                Environment.Exit(2);
            }
        }

        public async Task PostGeeklistItem(int listId, int objectId, string comments)
        {
            var client = new RestClient("https://api.geekdo.com/api/");
            var request = new RestRequest($"geeklists/{listId}/listitems", Method.Post);
            request.AddHeader("authority", "api.geekdo.com");
            request.AddHeader("accept", "application/json, text/plain, */*");
            request.AddHeader("accept-language", "en-US,en;q=0.9,de;q=0.8");
            request.AddHeader("authorization", $"GeekAuth {_token}");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("origin", "https://boardgamegeek.com");
            request.AddHeader("referer", "https://boardgamegeek.com/");
            request.AddHeader("sec-ch-ua", "\"Opera\";v=\"95\", \"Chromium\";v=\"109\", \"Not;A=Brand\";v=\"24\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "cross-site");

            var body = new GeeklistPostBody
            {
                Item = new Item { Id = objectId },
                Body = comments
            };

            var serialized = JsonConvert.SerializeObject(body);

            request.AddParameter("application/json", serialized, ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);
            if (response.StatusCode != HttpStatusCode.Created)
            {
                Console.WriteLine("Failed to create subscription geeklist item.");
                Environment.Exit(2);
            }
        }

        public async Task<Uri> PostThread(string subject, string body, int forumId, int objectId, string objectType)
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler { CookieContainer = _cookie });
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent("save"), "action");
            form.Add(new StringContent(forumId.ToString()), "forumid");
            form.Add(new StringContent(""), "articleid");
            form.Add(new StringContent(objectType), "objecttype");
            form.Add(new StringContent(objectId.ToString()), "objectid");
            form.Add(new StringContent(""), "replytoid");
            form.Add(new StringContent(forumId.ToString()), "forumid");
            form.Add(new StringContent(""), "geek_link_select_1");
            form.Add(new StringContent("10"), "sizesel");
            form.Add(new StringContent(subject), "subject");
            form.Add(new StringContent(body), "body");
            form.Add(new StringContent("1"), "notify");

            var response = await httpClient.PostAsync("https://boardgamegeek.com/article/save", form);
            response.EnsureSuccessStatusCode();
            var location = response.RequestMessage.RequestUri;
            httpClient.Dispose();
            return location;
        }

        public async Task<int> PostImage(string path, string filename)
        {
            var httpClient = new HttpClient(new HttpClientHandler { CookieContainer = _cookie });
            var form = new MultipartFormDataContent();
            form.Add(new StringContent("4"), "license[licenseid]");
            form.Add(new StringContent("user"), "objecttype");
            form.Add(new StringContent("1034692"), "objectid");

            var fs = System.IO.File.OpenRead(Path.Combine(path, filename));

            var streamContent = new StreamContent(fs);
            streamContent.Headers.Add("Content-Type", "application/octet-stream");
            streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + filename + "\"");
            form.Add(streamContent, "file", filename);

            var response = await httpClient.PostAsync("https://boardgamegeek.com/api/images", form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ImageUploadResult>(result).ImageId;
        }

        public async Task<bool> LogPlay(string username, string password, int gameId, DateTime date, int amount, string comments, int length)
        {
            string requestBase = "dummy=1&ajax=1&action=save&version=2&objecttype=thing&objectid={0}&playid=&action=save&playdate={1}&dateinput={2}&YUIButton=&twitter=0&savetwitterpref=0&location=&quantity={3}&length={4}&incomplete=0&nowinstats=0&comments={5}";
            string request = string.Format(requestBase, gameId, date.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), amount, length, comments);

            byte[] byteArray = Encoding.UTF8.GetBytes(request);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://www.boardgamegeek.com/geekplay.php");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = _cookie;

            using (Stream webpageStream = await webRequest.GetRequestStreamAsync())
            {
                webpageStream.Write(byteArray, 0, byteArray.Length);
            }
            using (WebResponse response = await webRequest.GetResponseAsync())
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    string responseText = reader.ReadToEnd();
                    if (responseText == "You must login to save plays")
                        return false;
                }
            }
            return true;
        }

        private class ImageUploadResult
        {
            public string Message { get; set; }
            public int ImageId { get; set; }
        }

        private class GeeklistPostBody
        {
            [JsonProperty(PropertyName = "item")]
            public Item Item { get; set; }

            [JsonProperty(PropertyName = "body")]
            public string Body { get; set; }
        }

        private class Item
        {
            [JsonProperty(PropertyName = "type")]
            public string Type { get; set; } = "things";


            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }
        }
    }
}