using System.Net;
using System.Threading.Tasks;

namespace scg
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new BggApiService();
            var cookie = await service.Login("<<USER>>", "<<PASSWORD>>", new CookieContainer());
            await service.PostImage(cookie, @"D:\Incoming", "IMG_20201020_112002.jpg");
            await service.PostThread(cookie);
        }
    }
}
