using OpenCC.NET.Toolkits;
using System.Collections.Generic;

namespace OpenCC.NET
{
    /// <summary>
    /// OpenCC
    /// </summary>
    public class OpenChineseConverter : AbstractChineseConverter
    {
        public const string DictionaryPath = "~\\Dictionaries\\opencc-dictionary.json";

        public OpenChineseConverter()
        {
            FilePathHelper helper = new FilePathHelper();

            // Get File Absolute Path
            string filePath = helper.GetAbsolutePath(DictionaryPath);

            // Load Dictionary
            LoadDictionary(filePath);
        }
        public OpenChineseConverter(string dictionaryPath)
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
        /// 簡體 --> 台灣正體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToTaiwanFromSimplified(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.STPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.STCharacters.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TWVariants.ToString())
                }
            });
        }

        /// <summary>
        /// 台灣正體 --> 簡體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToSimplifiedFromTaiwan(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TWVariantsRevPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.TWVariants.ToString(), true)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TSPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.TSCharacters.ToString())
                }
            });
        }


        /// <summary>
        /// 簡體 --> 台灣正體 (含常見辭彙)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToTaiwanFromSimplifiedWithPhrases(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.STPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.STCharacters.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TWPhrasesIT.ToString()),
                    GetDictionary(OpenCCDictonary.TWPhrasesName.ToString()),
                    GetDictionary(OpenCCDictonary.TWPhrasesOther.ToString()),
                    GetDictionary(OpenCCDictonary.TWVariants.ToString())
                }
            });
        }

        /// <summary>
        /// 台灣正體 --> 簡體 (含常見辭彙)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToSimplifiedFromTaiwanWithPhrases(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TWVariantsRevPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.TWVariants.ToString(), true)
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TWPhrasesIT.ToString(), true),
                    GetDictionary(OpenCCDictonary.TWPhrasesName.ToString(), true),
                    GetDictionary(OpenCCDictonary.TWPhrasesOther.ToString(), true),
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TSPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.TSCharacters.ToString())
                }
            });
        }


        /// <summary>
        /// 簡體 --> 香港繁體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToHongKongFromSimplified(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.STPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.STCharacters.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.HKVariantsPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.HKVariants.ToString())
                }
            });
        }

        /// <summary>
        /// 香港繁體 --> 簡體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToSimplifiedFromHongKong(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.HKVariantsRevPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.HKVariants.ToString())
                },
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TSPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.TSCharacters.ToString())
                }
            });
        }


        /// <summary>
        /// 簡體 --> 繁體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToTraditionalFromSimplified(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.STPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.STCharacters.ToString())
                }
            });
        }

        /// <summary>
        /// 繁體 --> 簡體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToSimplifiedFromTraditional(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TSPhrases.ToString()),
                    GetDictionary(OpenCCDictonary.TSCharacters.ToString())
                }
            });
        }


        /// <summary>
        /// 繁體 --> 台灣正體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToTaiwanFromTraditional(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.TWVariants.ToString())
                }
            });
        }

        /// <summary>
        /// 繁體 --> 香港繁體
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToHongKongFromTraditional(string text)
        {
            return ChainConvert(text, new List<List<Dictionary<string, string>>>()
            {
                new List<Dictionary<string, string>>()
                {
                    GetDictionary(OpenCCDictonary.HKVariants.ToString())
                }
            });
        }
    }

    public enum OpenCCDictonary
    {
        /// <summary>
        /// 香港繁體 (修正字)
        /// </summary>
        HKVariants,

        /// <summary>
        /// 香港繁體 (辭彙)
        /// </summary>
        HKVariantsPhrases,

        /// <summary>
        /// 香港繁體 (辭彙修正字)
        /// </summary>
        HKVariantsRevPhrases,

        /// <summary>
        /// 日本漢字 (修正字)
        /// </summary>
        JPVariants,

        /// <summary>
        /// 簡體 --> 繁體
        /// </summary>
        STCharacters,

        /// <summary>
        /// 簡體 (辭彙) --> 繁體 (辭彙)
        /// </summary>
        STPhrases,

        /// <summary>
        /// 繁體 --> 簡體
        /// </summary>
        TSCharacters,

        /// <summary>
        /// 繁體 (辭彙) --> 簡體 (辭彙)
        /// </summary>
        TSPhrases,

        /// <summary>
        /// 台灣正體 (IT辭彙)
        /// </summary>
        TWPhrasesIT,

        /// <summary>
        /// 台灣正體 (辭彙)
        /// </summary>
        TWPhrasesName,

        /// <summary>
        /// 台灣正體 (其他辭彙)
        /// </summary>
        TWPhrasesOther,

        /// <summary>
        /// 台灣正體 (修正字)
        /// </summary>
        TWVariants,

        /// <summary>
        /// 台灣正體 (辭彙修正字)
        /// </summary>
        TWVariantsRevPhrases,
    }
}
