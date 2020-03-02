using OpenCC.NET.Toolkits;
using System.Collections.Generic;

namespace OpenCC.NET
{
    /// <summary>
    /// MeuHuaCC
    /// </summary>
    public class MeiHuaChineseConverter : AbstractChineseConverter
    {
        public const string DictionaryPath = "~\\Dictionaries\\meihuacc-dictionary.json";

        public MeiHuaChineseConverter()
        {
            FilePathHelper helper = new FilePathHelper();

            // Get File Absolute Path
            string filePath = helper.GetAbsolutePath(DictionaryPath);

            // Load Dictionary
            LoadDictionary(filePath);
        }
        public MeiHuaChineseConverter(string dictionaryPath)
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
        /// 簡體 --> 繁體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToTraditional(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.S2TCharacters)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.S2TPhrases)
                }
            });
        }

        /// <summary>
        /// 簡體 --> 繁體 (含自訂辭彙)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToTraditionalWithCustomPhrases(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.S2TCustomPhrases)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.S2TCharacters)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.S2TPhrases)
                }
            });
        }

        /// <summary>
        /// 繁體 --> 簡體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToSimplified(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.T2SCharacters)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.T2SPhrases)
                }
            });
        }

        /// <summary>
        /// 繁體 --> 簡體 (含自訂辭彙)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToSimplifiedWithCustomPhrases(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.T2SCustomPhrases)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.T2SCharacters)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(MeiHuaCCDictonary.T2SPhrases)
                }
            });
        }
    }

    public static class MeiHuaCCDictonary
    {
        /// <summary>
        /// 簡體 --> 繁體
        /// </summary>
        public const string S2TCharacters = "cn2tw_c";

        /// <summary>
        /// 簡體 (自訂辭彙) --> 繁體 (自訂辭彙)
        /// </summary>
        public const string S2TCustomPhrases = "cn2tw_cp";

        /// <summary>
        /// 簡體 (辭彙) --> 繁體 (辭彙)
        /// </summary>
        public const string S2TPhrases = "cn2tw_p";

        /// <summary>
        /// 繁體 --> 簡體
        /// </summary>
        public const string T2SCharacters = "tw2cn_c";

        /// <summary>
        /// 繁體 (自訂辭彙) --> 簡體 (自訂辭彙)
        /// </summary>
        public const string T2SCustomPhrases = "tw2cn_cp";

        /// <summary>
        /// 繁體 (辭彙) --> 簡體 (辭彙)
        /// </summary>
        public const string T2SPhrases = "tw2cn_P";
    }
}
