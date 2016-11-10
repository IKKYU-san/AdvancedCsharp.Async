
namespace AdvancedCsharp.Async
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class AsyncExample1BadWithWaitAll
    {
        class Helper
        {
            public static void WriteCommand(string s)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(s);
            }

            public static void WriteResponse(string s)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(s);
            }

            public static void WriteElapsedTime(Stopwatch watch)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(watch.ElapsedMilliseconds);
            }
        }

        class StringHelper
        {
            public static string GetTitleOfHtml(string html)
            {
                return Regex.Match(html, @"<title[^>]*>([^<]*)</title>").Groups[1].Value;
            }
        }

        class WebExplorer
        {

            public async Task<string> GetTitleOfMicrosoftPageAsync()
            {
                WebClient client = new WebClient();
                var html = await client.DownloadStringTaskAsync("http://www.microsoft.com");
                return StringHelper.GetTitleOfHtml(html);
            }

            public async Task<string> GetTitleOfFacebookPageAsync()
            {
                WebClient client = new WebClient();
                var html = await client.DownloadStringTaskAsync("http://www.facebook.com");
                return StringHelper.GetTitleOfHtml(html);
            }

            public async Task<string> GetTitleOfTeliaPageAsync()
            {
                WebClient client = new WebClient();
                var html = await client.DownloadStringTaskAsync("http://www.telia.se");
                return StringHelper.GetTitleOfHtml(html);
            }

        }

        public void Run()
        {
            var we = new WebExplorer();
            var watch = new Stopwatch();
            watch.Start();
            Helper.WriteElapsedTime(watch);

            Helper.WriteCommand("Hämta titel från Microsoft");
            var titleMicrosoft = we.GetTitleOfMicrosoftPageAsync();

            Helper.WriteCommand("Hämta titel från Facebook");
            var titleFacebook = we.GetTitleOfFacebookPageAsync();

            Helper.WriteCommand("Hämta titel från Telia");
            var titleTelia = we.GetTitleOfTeliaPageAsync();
            Helper.WriteCommand("");

            Task.WaitAll(new[] { titleMicrosoft, titleFacebook, titleTelia });

            Helper.WriteResponse($"Microsoft: {titleMicrosoft.Result}");
            Helper.WriteElapsedTime(watch);

            Helper.WriteResponse($"Facebook: {titleFacebook.Result}");
            Helper.WriteElapsedTime(watch);

            Helper.WriteResponse($"Telia: {titleTelia.Result}");

            Helper.WriteElapsedTime(watch);

        }

    }
}
