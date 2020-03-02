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

            DemoOpenCC();

            Console.ReadLine();
        }

        static void DemoOpenCC()
        {
            var converter = new OpenChineseConverter();

            var twText = "這個小丑醜歸醜但很管用，這個滑鼠，長髮散發出香氣，列印中文為何出亂碼，阿拉伯聯合大公國，義大利，尚比亞";
            var cnText = "这个小丑丑归丑但很管用，这个鼠标，长发散发出香气，打印中文为何出乱码，阿拉伯联合酋长国，意大利，赞比亚";

            // 轉台灣正體
            var openccTWText = converter.ToTaiwanFromSimplifiedWithPhrases(cnText);

            // 轉簡體
            var openccCNText = converter.ToSimplifiedFromTaiwanWithPhrases(twText);

            // 顯示結果
            Console.WriteLine($"===== 原文 =====\n{cnText}\n===== 轉臺灣正體 =====\n{openccTWText}");

            Console.WriteLine($"\n===== 原文 =====\n{twText}\n===== 轉簡體 =====\n{openccCNText}");
        }

        static void DemoWiki()
        {
            var converter = new WikiChineseConverter();

            var twText = "這個小丑醜歸醜但很管用，這個滑鼠，長髮散發出香氣，列印中文為何出亂碼，阿拉伯聯合大公國，義大利，尚比亞";
            var cnText = "这个小丑丑归丑但很管用，这个鼠标，长发散发出香气，打印中文为何出乱码，阿拉伯联合酋长国，意大利，赞比亚";

            // 轉台灣正體
            var openccTWText = converter.ToTaiwanTraditional(cnText);

            // 轉簡體
            var openccCNText = converter.ToChinaSimplified(twText);

            // 顯示結果
            Console.WriteLine($"===== 原文 =====\n{cnText}\n===== 轉臺灣正體 =====\n{openccTWText}");

            Console.WriteLine($"\n===== 原文 =====\n{twText}\n===== 轉中國簡體 =====\n{openccCNText}");
        }

        static void DemoTongWen()
        {
            var converter = new TongWenChineseConverter();

            var twText = "這個小丑醜歸醜但很管用，這個滑鼠，長髮散發出香氣，列印中文為何出亂碼，阿拉伯聯合大公國，義大利，尚比亞";
            var cnText = "这个小丑丑归丑但很管用，这个鼠标，长发散发出香气，打印中文为何出乱码，阿拉伯联合酋长国，意大利，赞比亚";

            // 轉台灣正體
            var openccTWText = converter.ToTraditionalWithCustomPhrases(cnText);

            // 轉簡體
            var openccCNText = converter.ToSimplifiedWithCustomPhrases(twText);

            // 顯示結果
            Console.WriteLine($"===== 原文 =====\n{cnText}\n===== 轉繁體 =====\n{openccTWText}");

            Console.WriteLine($"\n===== 原文 =====\n{twText}\n===== 轉簡體 =====\n{openccCNText}");
        }

        static void DemoMeiHua()
        {
            var converter = new MeiHuaChineseConverter();

            var twText = "這個小丑醜歸醜但很管用，這個滑鼠，長髮散發出香氣，列印中文為何出亂碼，阿拉伯聯合大公國，義大利，尚比亞";
            var cnText = "这个小丑丑归丑但很管用，这个鼠标，长发散发出香气，打印中文为何出乱码，阿拉伯联合酋长国，意大利，赞比亚";

            // 轉台灣正體
            var openccTWText = converter.ToTraditionalWithCustomPhrases(cnText);

            // 轉簡體
            var openccCNText = converter.ToSimplifiedWithCustomPhrases(twText);

            // 顯示結果
            Console.WriteLine($"===== 原文 =====\n{cnText}\n===== 轉繁體 =====\n{openccTWText}");

            Console.WriteLine($"\n===== 原文 =====\n{twText}\n===== 轉簡體 =====\n{openccCNText}");
        }
    }
}
