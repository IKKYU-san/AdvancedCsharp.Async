
namespace AdvancedCsharp.Async
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Text.RegularExpressions;

    class AsyncExample1Bad
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

            public string GetTitleOfMicrosoftPage()
            {
                WebClient client = new WebClient();

                var html = client.DownloadString("http://www.microsoft.com");
                return StringHelper.GetTitleOfHtml(html);
            }

            public string GetTitleOfFacebook()
            {
                WebClient client = new WebClient();

                var html = client.DownloadString("http://www.facebook.com");
                return StringHelper.GetTitleOfHtml(html);
            }


            public string GetTitleOfTelia()
            {
                WebClient client = new WebClient();

                var html = client.DownloadString("http://www.telia.se");
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
            var titleMicrosoft = we.GetTitleOfMicrosoftPage();
            Helper.WriteResponse($"Microsoft: {titleMicrosoft}");
            Helper.WriteElapsedTime(watch);

            Helper.WriteCommand("Hämta titel från Facebook");
            var titleFacebook = we.GetTitleOfFacebook();
            Helper.WriteResponse($"Facebook: {titleFacebook}");
            Helper.WriteElapsedTime(watch);

            Helper.WriteCommand("Hämta titel från Telia");
            var titleTelia = we.GetTitleOfTelia();
            Helper.WriteResponse($"Telia: {titleTelia}");
            Helper.WriteElapsedTime(watch);
        }

    }
}
