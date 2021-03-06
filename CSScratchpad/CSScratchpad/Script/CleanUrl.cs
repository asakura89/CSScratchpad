using System;
using System.Text.RegularExpressions;
using Scratch;

namespace CSScratchpad.Script {
    public class CleanUrl : Common, IRunnable {
        public void Run() {
            String domain = "http://www.mcdonalds.co.id";
            String[] urls = {
                "http://www.mcdonalds.co.id/wp-content/gallery/menu-andalan/chicken_pahadada-edit.jpg",
                "/menu-andalan/chicken_pahadada-edit.jpg"
            };

            foreach (String url in urls)
                Console.WriteLine(CleanURL(url, domain));

            foreach (String url in urls)
                Console.WriteLine(GetDomainFromUrl(url));
        }

        public String CleanURL(String url, String domain) {
            String strReturn = String.Empty;

            Boolean bHasDomain = !String.IsNullOrEmpty(GetDomainFromUrl(url));
            if (bHasDomain)
                strReturn = url;
            else {
                String strImgLink = "/" + url;
                String strPattern2Find = "^//?.*";
                String strPattern2Replace = "//?";
                String strReplacer = "/";
                strReturn = domain + FindAndReplace(strImgLink, strPattern2Find, strPattern2Replace, strReplacer);
            }

            return strReturn;
        }

        public String GetDomainFromUrl(String url) {
            String strReturn = String.Empty;

            String strPattern2Find = "^(?<protocol>https?:\\/\\/)(?<domain>[^\\/]+)\\/";
            Match mat = Regex.Match(url, strPattern2Find, RegexOptions.Compiled | RegexOptions.Singleline);
            strReturn = mat.Groups["domain"].Value;

            return strReturn;
        }

        public String FindAndReplace(String source, String pattern2Find, String pattern2Replace, String replacer) {
            String replaced = String.Empty;

            Match mat = Regex.Match(source, pattern2Find, RegexOptions.Compiled | RegexOptions.Singleline);
            replaced = Regex.Replace(mat.Groups[0].Value, pattern2Replace, replacer);

            return replaced;
        }
    }
}
