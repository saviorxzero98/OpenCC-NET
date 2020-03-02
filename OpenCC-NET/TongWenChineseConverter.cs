using OpenCC.NET.Toolkits;
using System.Collections.Generic;

namespace OpenCC.NET
{
    /// <summary>
    /// 同文堂
    /// </summary>
    public class TongWenChineseConverter : AbstractChineseConverter
    {
        public const string DictionaryPath = "~\\Dictionaries\\tongwen-dictionary.json";

        public TongWenChineseConverter()
        {
            FilePathHelper helper = new FilePathHelper();

            // Get File Absolute Path
            string filePath = helper.GetAbsolutePath(DictionaryPath);

            // Load Dictionary
            LoadDictionary(filePath);
        }
        public TongWenChineseConverter(string dictionaryPath)
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
                    GetDictionary(TongWenDictonary.S2TCharacters.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(TongWenDictonary.S2TPhrases.ToString())
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
                    GetDictionary(TongWenDictonary.S2TCustomPhrases.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(TongWenDictonary.S2TCharacters.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(TongWenDictonary.S2TPhrases.ToString())
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
                    GetDictionary(TongWenDictonary.T2SCharacters.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(TongWenDictonary.T2SPhrases.ToString())
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
                    GetDictionary(TongWenDictonary.T2SCustomPhrases.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(TongWenDictonary.T2SCharacters.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(TongWenDictonary.T2SPhrases.ToString())
                }
            });
        }
    }

    public enum TongWenDictonary
    {
        /// <summary>
        /// 簡體 --> 繁體
        /// </summary>
        S2TCharacters,

        /// <summary>
        /// 簡體 (自訂辭彙) --> 繁體 (自訂辭彙)
        /// </summary>
        S2TCustomPhrases,

        /// <summary>
        /// 簡體 (辭彙) --> 繁體 (辭彙)
        /// </summary>
        S2TPhrases,

        /// <summary>
        /// 繁體 --> 簡體
        /// </summary>
        T2SCharacters,

        /// <summary>
        /// 繁體 (自訂辭彙) --> 簡體 (自訂辭彙)
        /// </summary>
        T2SCustomPhrases,

        /// <summary>
        /// 繁體 (辭彙) --> 簡體 (辭彙)
        /// </summary>
        T2SPhrases
    }
}
