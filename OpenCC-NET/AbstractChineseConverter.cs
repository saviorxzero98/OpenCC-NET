using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenCC.NET
{
    public abstract class AbstractChineseConverter
    {
        protected Dictionary<string, List<List<string>>> Dictionaries { get; set; } = new Dictionary<string, List<List<string>>>();
        protected Dictionary<string, Dictionary<string, string>> CachedDictionaries { get; set; } = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// 讀取字典檔
        /// </summary>
        /// <param name="filePath"></param>
        protected void LoadDictionary(string filePath)
        {
            using (var r = new StreamReader(filePath))
            {
                try
                {
                    var data = r.ReadToEnd();


                    Dictionaries = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(data);
                }
                catch (Exception e)
                {

                }
            }
        }

        /// <summary>
        /// 取得字典
        /// </summary>
        /// <param name="name">字典名稱</param>
        /// <param name="isReverse">是否反向轉換</param>
        /// <returns></returns>
        protected Dictionary<string, string> GetDictionary(string name, bool isReverse = false)
        {
            string cacheName = (isReverse) ? $"R_{name}" : name;

            if (CachedDictionaries.ContainsKey(cacheName))
            {
                return CachedDictionaries[cacheName];
            }

            CachedDictionaries[cacheName] = Dictionaries[name].Aggregate(new Dictionary<string, string>(), (map, entry) =>
            {
                if (entry.Count >= 2)
                {
                    if (isReverse)
                    {
                        map[entry[1]] = entry[0];
                    }
                    else
                    {
                        map[entry[0]] = entry[1];
                    }
                }
                return map;
            });
            return CachedDictionaries[cacheName];
        }

        /// <summary>
        /// 多輪繁簡文字轉換
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ConversionChains"></param>
        /// <returns></returns>
        public string ChainConvert(string text, List<List<Dictionary<string, string>>> ConversionChains)
        {
            var output = ConversionChains.Aggregate(text, (map, dicts) =>
            {
                var dictionary = dicts.SelectMany(dict => dict)
                                      .ToDictionary(pair => pair.Key, pair => pair.Value);

                return Translate(map, dictionary);
            });

            return output;
        }

        /// <summary>
        /// 繁簡文字轉換
        /// </summary>
        /// <param name="text"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        protected string Translate(string text, Dictionary<string, string> dictionary)
        {
            var maxLength = dictionary.Keys.Aggregate(0, (l, word) => Math.Max(l, word.Length));

            List<string> translated = new List<string>();

            var length = text.Length;

            for (int i = 0; i < length; i++)
            {
                bool isFound = false;

                for (var j = maxLength; j > 0; j--)
                {
                    string target = text.Substring(i, Math.Min(length - i, j));

                    if (dictionary.ContainsKey(target))
                    {
                        i += j - 1;
                        translated.Add(dictionary[target]);
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    translated.Add(text.ToCharArray()[i].ToString());
                }
            }

            var output = string.Join(string.Empty, translated);
            return output;
        }
    }
}
