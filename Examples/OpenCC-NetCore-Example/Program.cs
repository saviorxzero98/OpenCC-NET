using OpenCC.NET;
using System;
using System.Text;

namespace OpenCC.NetCore.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var opencc = new OpenChineseConverter();

            var twText = "這個小丑醜歸醜但很管用，這個滑鼠，長髮散發出香氣，列印中文為何出亂碼，阿拉伯聯合大公國，義大利，尚比亞";
            var cnText = "这个小丑丑归丑但很管用，这个鼠标，长发散发出香气，打印中文为何出乱码，阿拉伯联合酋长国，意大利，赞比亚";

            // 轉台灣正體
            var openccTWText = opencc.ToTaiwanFromSimplifiedWithPhrases(cnText);

            // 轉簡體
            var openccCNText = opencc.ToSimplifiedFromTaiwanWithPhrases(twText);

            // 顯示結果
            Console.WriteLine($"===== 原文 =====\n{cnText}\n===== 轉繁體 =====\n{openccTWText}");

            Console.WriteLine($"\n===== 原文 =====\n{twText}\n===== 轉簡體 =====\n{openccCNText}");

            Console.ReadLine();
        }
    }
}
