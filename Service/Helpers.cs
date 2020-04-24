using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public static class Helpers
    {
        public static HtmlNode GetHtml(string url)
        {
            ScrapingBrowser browser = new ScrapingBrowser();
            WebPage webpage = browser.NavigateToPage(new Uri(url));
            return webpage.Html;
        }

    }
}
