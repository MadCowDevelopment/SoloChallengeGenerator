using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace scg
{
    public class BggApiService
    {
        public async Task<string> PostThread(CookieContainer cookie)
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler {CookieContainer = cookie});
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent("save"), "action");
            form.Add(new StringContent("8"), "forumid");
            form.Add(new StringContent(""), "articleid");
            form.Add(new StringContent("region"), "objecttype");
            form.Add(new StringContent("1"), "objectid");
            form.Add(new StringContent(""), "replytoid");
            form.Add(new StringContent("8"), "forumid");
            form.Add(new StringContent(""), "geek_link_select_1"); 
            form.Add(new StringContent("10"), "sizesel");
            form.Add(new StringContent("SampleSubject"), "subject");
            form.Add(new StringContent("SampleBody"), "body");
            form.Add(new StringContent("1"), "notify");

            var response = await httpClient.PostAsync("https://boardgamegeek.com/article/save", form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> PostImage(CookieContainer cookie, string path, string filename)
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler { CookieContainer = cookie });
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent("4"), "license[licenseid]");
            form.Add(new StringContent("user"), "objecttype");
            form.Add(new StringContent("1034692"), "objectid");

            FileStream fs = File.OpenRead(Path.Combine(path, filename));

            var streamContent = new StreamContent(fs);
            streamContent.Headers.Add("Content-Type", "application/octet-stream");
            streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + filename + "\"");
            form.Add(streamContent, "file", filename);

            var response = await httpClient.PostAsync("https://boardgamegeek.com/api/images", form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public async Task<bool> LogPlay(string username, string password, int gameId, DateTime date, int amount, string comments, int length)
        {
            //http://www.boardgamegeek.com/geekplay.php?objecttype=thing&objectid=104557&ajax=1&action=new

            CookieContainer jar = new CookieContainer();
            jar = await Login(username, password, jar);
            
            string requestBase = "dummy=1&ajax=1&action=save&version=2&objecttype=thing&objectid={0}&playid=&action=save&playdate={1}&dateinput={2}&YUIButton=&twitter=0&savetwitterpref=0&location=&quantity={3}&length={4}&incomplete=0&nowinstats=0&comments={5}";
            string request = string.Format(requestBase, gameId, date.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), amount, length, comments);

            byte[] byteArray = Encoding.UTF8.GetBytes(request);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://www.boardgamegeek.com/geekplay.php");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = jar;

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

        public async Task<CookieContainer> Login(string username, string password, CookieContainer cookie)
        {
            string postData = string.Format("lasturl=&username={0}&password={1}", username, password);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://www.boardgamegeek.com/login");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookie;


            using (Stream webpageStream = await webRequest.GetRequestStreamAsync())
            {
                webpageStream.Write(byteArray, 0, byteArray.Length);
            }
            using (WebResponse response = await webRequest.GetResponseAsync())
            {

            }
            return cookie;

        }
    }
}