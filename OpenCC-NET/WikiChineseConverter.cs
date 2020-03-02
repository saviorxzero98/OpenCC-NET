using OpenCC.NET.Toolkits;
using System.Collections.Generic;

namespace OpenCC.NET
{
    /// <summary>
    /// Wiki (使用 MediaWiki 1.34.0 繁簡轉換字典)
    /// </summary>
    public class WikiChineseConverter : AbstractChineseConverter
    {
        public const string DictionaryPath = "~\\Dictionaries\\wiki-dictionary.json";

        public WikiChineseConverter()
        {
            FilePathHelper helper = new FilePathHelper();

            // Get File Absolute Path
            string filePath = helper.GetAbsolutePath(DictionaryPath);

            // Load Dictionary
            LoadDictionary(filePath);
        }
        public WikiChineseConverter(string dictionaryPath)
        {
            string filePath = dictionaryPath;

            if (string.IsNullOrEmpty(filePath))
            {
                FilePathHelper helper = new FilePathHelper();

                // Get File Absolute Path
                filePath = helper.GetAbsolutePath(DictionaryPath);
            }

            // Load Dictionary
            LoadDictionary(filePath);
        }

        /// <summary>
        /// 中文 --> 臺灣正體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToTaiwanTraditional(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(WikiDictionary.Taiwan)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(WikiDictionary.Traditional)
                }
            });
        }

        /// <summary>
        /// 中文 --> 香港繁體、澳門繁體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToHongKongTraditional(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(WikiDictionary.HongKong)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(WikiDictionary.Traditional)
                }
            });
        }

        /// <summary>
        /// 中文 --> 中國簡體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToChinaSimplified(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(WikiDictionary.China)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(WikiDictionary.Simplified),
                }
            });
        }

        /// <summary>
        /// 中文 --> 新加坡簡體、馬來西亞簡體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToSingaporeSimplified(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(WikiDictionary.Singapore)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(WikiDictionary.Simplified),
                }
            });
        }
    }

    public static class WikiDictionary
    {
        /// <summary>
        /// 中文 --> 中國簡體
        /// </summary>
        public const string China = "zh2CN";

        /// <summary>
        /// 中文 --> 香港繁體、澳門繁體
        /// </summary>
        public const string HongKong = "zh2HK";

        /// <summary>
        /// 中文 --> 簡體
        /// </summary>
        public const string Simplified = "zh2Hans";

        /// <summary>
        /// 中文 --> 新加坡簡體
        /// </summary>
        public const string Singapore = "zh2SG";

        /// <summary>
        /// 中文 --> 臺灣正體
        /// </summary>
        public const string Taiwan = "zh2TW";

        /// <summary>
        /// 中文 --> 繁體
        /// </summary>
        public const string Traditional = "zh2Hant";
    }
}
