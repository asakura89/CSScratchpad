using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security.AntiXss;
using Scratch;

namespace CSScratchpad.Script {
    class TestVarya : Common, IRunnable {
        public void Run() {
            String template = @"
                <div class='weather-widget'>
                    <div class='weather-widget__content'>
                        <span class='weather-widget__day'>${Day}</span>
                        <span class='weather-widget__date'>${Date}</span>
                    </div>
                    <div class='weather-widget__content'>
                        <div class='weather-widget__temp'>
                            <i class='icon-weather-sun-cloud'></i>
                            <span class='weather-widget__temp__deg'>
                                <a href='${ForecastUrl}' target='_blank'>
                                    <span class='weather-widget__temp__deg__max'>${LowForcastedTemp}</span><span> - ${HighForecastedTemp} &deg;C</span>
                                </a>
                            </span>
                        </div>
                        <div class='weather-widget__psi'>
                            <span class='weather-widget__psi__info'>24Hr PSI</span>
                            <span class='weather-widget__psi__reading'>
                                <a href='${HazeUrl}' target='_blank'>
                                    ${LowForecastedPollutantIndex}-${HighForecastedPollutantIndex}PSI
                                </a>
                            </span>
                        </div>
                    </div>
                </div>";

            IDictionary<String, String> replacementDict = new Dictionary<String, String> {
                ["Day"] = new Func<String>(() => DateTime.Now.DayOfWeek.ToString())(),
                ["Date"] = new Func<String>(() => DateTime.Now.ToString("dd MMMM yyyy"))(),
                ["ForecastUrl"] = "https://weather-info.fake-api.io",
                ["LowForcastedTemp"] = "27",
                ["HighForecastedTemp"] = "36",
                ["HazeUrl"] = "https://haze-info.fake-api.io",
                ["LowForecastedPollutantIndex"] = "11.7",
                ["HighForecastedPollutantIndex"] = "13.0"
            };

            Dbg("ReplaceWithDictionary", StringExt.ReplaceWithDictionary(template, replacementDict));

            var replacementObj = new Replacement {
                Day = new Func<String>(() => DateTime.Now.DayOfWeek.ToString())(),
                Date = new Func<String>(() => DateTime.Now.ToString("dd MMMM yyyy"))(),
                ForecastUrl = "https://weather-info.fake-api.io",
                LowForcastedTemp = "27",
                HighForecastedTemp = "36",
                HazeUrl = "https://haze-info.fake-api.io",
                LowForecastedPollutantIndex = "11.7",
                HighForecastedPollutantIndex = "13.0"
            };

            Dbg("ReplaceWithObject", StringExt.ReplaceWith(template, replacementObj));

            replacementDict = new Dictionary<String, String> { ["Name"] = "Mike" };
            template = "Hello ${Name}, how do you do?";
            String replaced = StringExt.ReplaceWithDictionary(template, replacementDict);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            if (!replaced.Equals("Hello Mike, how do you do?", StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Api.Url") ?? String.Empty;
            replaced = StringExt.Resolve(template);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Http.Timeout") ?? String.Empty;
            replaced = StringExt.Resolve(template);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Http.RepeatInterval") ?? String.Empty;
            replaced = StringExt.Resolve(template);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Http.RetryInterval") ?? String.Empty;
            replaced = StringExt.Resolve(template);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Http.Payload_1") ?? String.Empty;
            replaced = StringExt.Resolve(template);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Http.Payload_2") ?? String.Empty;
            replaced = StringExt.Resolve(template);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Http.Payload_3") ?? String.Empty;
            replaced = StringExt.Resolve(template);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Http.Payload_4") ?? String.Empty;
            replaced = StringExt.Resolve(template);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Http.Payload_5") ?? String.Empty;
            replaced = StringExt.Resolve(template);

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);

            template = ConfigurationManager.AppSettings.Get("Http.Payload_6") ?? String.Empty;
            replaced = StringExt.ReplaceWithDictionary(template, new Dictionary<String, String> { ["Name"] = "Mike" });

            if (String.IsNullOrEmpty(replaced))
                throw new InvalidOperationException("Test failed");

            if (template.Equals(replaced, StringComparison.InvariantCultureIgnoreCase))
                throw new InvalidOperationException("Test failed");

            Dbg(replaced);
        }

        #region :: Replacement Class ::

        public class Replacement {
            public String Day { get; set; }
            public String Date { get; set; }
            public String ForecastUrl { get; set; }
            public String LowForcastedTemp { get; set; }
            public String HighForecastedTemp { get; set; }
            public String HazeUrl { get; set; }
            public String LowForecastedPollutantIndex { get; set; }
            public String HighForecastedPollutantIndex { get; set; }
        }

        #endregion

        #region :: VaryaExt ::

        public static class StringExt {
            //const String MainRegex = @"\$\{(?<key>[a-zA-Z0-9\\.\\-\\_]*)(:(?<value>[a-zA-Z0-9\\.\\-\\_\s]*))?\}";
            const String MainRegex = @"\$\{(?<key>[a-zA-Z0-9\.\-\\_]*)(:(?<value>[^\{\}]+))?\}";

            public static String Resolve(String string2Resolve) => ReplaceWithDictionary(string2Resolve, new Dictionary<String, String>());

            public static String ReplaceWith<TReplace>(String string2Replace, TReplace replacements) where TReplace : class, new() =>
                ReplaceWithDictionary(
                    string2Replace,
                    replacements
                        .GetType()
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .ToDictionary(prop => prop.Name, prop => Convert.ToString(prop.GetValue(replacements, null)))
                );

            public static String ReplaceWithDictionary(String string2Replace, IDictionary<String, String> replacements) {
                String result = Regex.Replace(
                    string2Replace,
                    MainRegex,
                    match => HandleRegex(match, replacements),
                    RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Multiline);

                Match containsExpressionMatch = Regex.Match(result, MainRegex, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Multiline);
                if (containsExpressionMatch.Success)
                    return ReplaceWithDictionary(result, replacements);

                return result;
            }

            static String HandleRegex(Match match, IDictionary<String, String> replacements) {
                String key = match.Groups["key"].Value;
                String value = match.Groups["value"].Value;
                if (String.IsNullOrEmpty(key))
                    return match.Value;

                IEnumerable<String> operations = new[] { "config", "econfig", "var", "urle", "urld", "htmle", "htmld" };
                if (!operations.Contains(key)) {
                    if (replacements == null)
                        return match.Value;

                    if (!replacements.Any())
                        return match.Value;

                    return replacements.ContainsKey(key) ? replacements[key] : String.Empty;
                }

                if (value == null)
                    return String.Empty;

                if (value.All(Char.IsWhiteSpace))
                    return String.Empty;

                switch (key) {
                    case "config":
                        return HandleConfig(value, replacements);
                    case "econfig":
                        return HandleEncryptedConfig(value, replacements);
                    case "var":
                        return HandleVar(value);
                    case "urle":
                        return HandleUrlEncode(value);
                    case "urld":
                        return HandleUrlDecode(value);
                    case "htmle":
                        return HandleHtmlEncode(value);
                    case "htmld":
                        return HandleHtmlDecode(value);
                }

                return String.Empty;
            }

            static String HandleConfig(String configKey, IDictionary<String, String> replacements) => ReplaceWithDictionary(ConfigurationManager.AppSettings.Get(configKey) ?? String.Empty, replacements);

            static String HandleEncryptedConfig(String configKey, IDictionary<String, String> replacements) {
                String config = HandleConfig(configKey, replacements);
                return SecurityExt.Decrypt(config);
            }

            static String HandleVar(String var) {
                var variableRegexes = new Dictionary<String, String> {
                    ["Timespan"] = @"(?<digit>\d{1,})(?<type>[Dd]|[Hh]|[Mm]|[Ss])",
                    ["Datetime"] = @"[Dd]ate[Tt]ime\((?<dtformat>\w*)\)",
                    ["BaseDir"] = "BaseDir"
                };

                var variableHandlers = new Dictionary<String, Func<Match, String>> {
                    ["Timespan"] = HandleTimespan,
                    ["Datetime"] = HandleDatetime,
                    ["BaseDir"] = HandleBaseDir
                };

                foreach (String key in variableRegexes.Keys) {
                    Match varMatch = Regex.Match(var, variableRegexes[key], RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Multiline);
                    if (varMatch.Success)
                        return variableHandlers[key].Invoke(varMatch);
                }

                return String.Empty;
            }

            static String HandleTimespan(Match match) {
                String digit = match.Groups["digit"].Value;
                String type = match.Groups["type"].Value;
                if (String.IsNullOrEmpty(digit))
                    return String.Empty;

                if (String.IsNullOrEmpty(type))
                    return String.Empty;

                String duration = digit.PadLeft(2, '0');
                switch (type) {
                    case "d":
                        return $"{duration}:00:00:00";
                    case "h":
                        return $"00:{duration}:00:00";
                    case "m":
                        return $"00:00:{duration}:00";
                    case "s":
                        return $"00:00:00:{duration}";
                    default:
                        return "00:00:00:00";
                }
            }

            static String HandleDatetime(Match match) {
                String format = match.Groups["dtformat"].Value;
                if (String.IsNullOrEmpty(format))
                    return String.Empty;

                return DateTime.Now.ToString(format);
            }

            static String HandleBaseDir(Match match) => AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');

            static String HandleUrlEncode(String value) => AntiXssEncoder.UrlEncode(value).Replace("+", "%20");

            static String HandleUrlDecode(String value) => HttpUtility.UrlDecode(value);

            static String HandleHtmlEncode(String value) => AntiXssEncoder.HtmlEncode(value, true);

            static String HandleHtmlDecode(String value) => HttpUtility.HtmlDecode(value);
        }

        #endregion

        #region :: Security Ext ::

        public static class SecurityExt {
            static RijndaelManaged CreateRijndaelAlgorithm(String securityKey, String securitySalt) {
                Byte[] saltBytes = Encoding.UTF8.GetBytes(securityKey + securitySalt);
                var randByte = new Rfc2898DeriveBytes(securityKey, saltBytes, 12000);

                const Int32 MaxOutSize = 256;
                const Int32 MaxOutSizeInBytes = MaxOutSize / 8;
                return new RijndaelManaged {
                    BlockSize = MaxOutSize,
                    Key = randByte.GetBytes(MaxOutSizeInBytes),
                    IV = randByte.GetBytes(MaxOutSizeInBytes),
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };
            }

            public static String Encrypt(String plainText) => Encrypt(plainText, GetKey(), GetSalt());

            public static String Encrypt(String plainText, String securityKey, String securitySalt) {
                using (RijndaelManaged algorithm = CreateRijndaelAlgorithm(securityKey, securitySalt)) {
                    Byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    Byte[] cipherBytes = null;
                    using (var stream = new MemoryStream()) {
                        using (var cryptoStream = new CryptoStream(stream, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                            cryptoStream.Write(plainBytes, 0, plainBytes.Length);

                        cipherBytes = stream.ToArray();
                    }

                    return EncodeBase64UrlFromBytes(cipherBytes);
                }
            }

            public static String Decrypt(String chiperText) => Decrypt(chiperText, GetKey(), GetSalt());

            public static String Decrypt(String chiperText, String securityKey, String securitySalt) {
                using (RijndaelManaged algorithm = CreateRijndaelAlgorithm(securityKey, securitySalt)) {
                    Byte[] cipherBytes = DecodeBase64UrlToBytes(chiperText);
                    Byte[] plainBytes = null;
                    using (var encstream = new MemoryStream(cipherBytes)) {
                        using (var decstream = new MemoryStream()) {
                            using (var cryptoStream = new CryptoStream(encstream, algorithm.CreateDecryptor(), CryptoStreamMode.Read)) {
                                Int32 data;
                                while ((data = cryptoStream.ReadByte()) != -1)
                                    decstream.WriteByte((Byte) data);

                                decstream.Position = 0;
                                plainBytes = decstream.ToArray();
                            }
                        }
                    }

                    return Encoding.UTF8.GetString(plainBytes);
                }
            }

            static String GetKey() {
                String key = ConfigurationManager.AppSettings.Get("Security.Key");
                if (String.IsNullOrEmpty(key))
                    return String.Empty;

                return EncodeBase64Url(key);
            }

            static String GetSalt() {
                String salt = ConfigurationManager.AppSettings.Get("Security.Salt");
                if (String.IsNullOrEmpty(salt))
                    return String.Empty;

                return EncodeBase64Url(salt);
            }

            const String Base64Plus = "+";
            const String Base64Slash = "/";
            const String Base64Underscore = "_";
            const String Base64Minus = "-";
            const String Base64Equal = "=";
            const String Base64DoubleEqual = "==";
            const Char Base64EqualChar = '=';

            public static String EncodeBase64Url(String plain) =>
                EncodeBase64UrlFromBytes(
                    Encoding.UTF8.GetBytes(plain)
                );

            static String EncodeBase64UrlFromBytes(Byte[] bytes) =>
                Convert
                    .ToBase64String(bytes)
                    .TrimEnd(Base64EqualChar)
                    .Replace(Base64Plus, Base64Minus)
                    .Replace(Base64Slash, Base64Underscore);

            public static String DecodeBase64Url(String base64Url) =>
                Encoding.UTF8.GetString(
                    DecodeBase64UrlToBytes(base64Url)
                );

            static Byte[] DecodeBase64UrlToBytes(String base64Url) {
                String halfProcessed = base64Url
                    .Replace(Base64Minus, Base64Plus)
                    .Replace(Base64Underscore, Base64Slash);

                String base64 = halfProcessed;
                if (halfProcessed.Length % 4 == 2)
                    base64 = halfProcessed + Base64DoubleEqual;
                else if (halfProcessed.Length % 4 == 3)
                    base64 = halfProcessed + Base64Equal;

                return Convert.FromBase64String(base64);
            }

            public static SecureString AsSecureString(String plain) {
                if (String.IsNullOrEmpty(plain) || String.IsNullOrWhiteSpace(plain))
                    throw new ArgumentNullException(nameof(plain));

                return new NetworkCredential(String.Empty, plain).SecurePassword;
            }

            public static String AsPlainString(SecureString secure) {
                if (secure == null)
                    throw new ArgumentNullException(nameof(secure));

                return new NetworkCredential(String.Empty, secure).Password;
            }

            const String UppercaseAlphabet = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            const String LowercaseAlphabet = "a b c d e f g h i j k l m n o p q r s t u v w x y z";
            const String Numeric = "1 2 3 4 5 6 7 8 9 0";
            const String Symbol = "~ ! @ # $ % ^ & * _ - + = ` | \\ ( ) { } [ ] : ; < > . ? /";

            static Int32 GenerateRandomNo(Int32 upperBound) {
                Int32 seed = Guid.NewGuid().GetHashCode() % InternalHelper.Feigenbaum;
                var rnd = new Random(seed);
                return rnd.Next(0, upperBound);
            }

            static String GenerateRandomAlphanumeric(Int32 length) {
                String[] charCombination = (UppercaseAlphabet + " " + LowercaseAlphabet + " " + Numeric + " " + Symbol).Split(' ');
                var output = new StringBuilder();
                for (Int32 ctr = 0; ctr < length; ctr++) {
                    Int32 randomIdx = GenerateRandomNo(charCombination.Length - 1);
                    output.Append(charCombination[randomIdx]);
                }

                return output.ToString();
            }

            public static String GenerateKey() => EncodeBase64Url(GenerateRandomAlphanumeric(64));

            public static String GenerateSalt() => EncodeBase64Url(GenerateRandomAlphanumeric(128));
        }

        #endregion
    }
}
