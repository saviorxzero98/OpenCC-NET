# OpenCC-NET



## Introduction 

* 提供中文簡繁轉換
* 使用的字典檔案
    * [OpenCC](https://github.com/BYVoid/OpenCC)  (BYVoid([byvoid.kcp@gmail.com](mailto:byvoid.kcp@gmail.com)))
    * [MediaWiki](https://github.com/wikimedia/mediawiki)
    * [同文堂](https://github.com/tongwentang/tongwen-core)
    * [MeihuaCC](https://github.com/shyangs/Meihua-Chinese-Converter)
* 支援 .NET Core 2.0 以上、.NET Framework 4.6.1 以上



## Installation 

* 兩種安裝方法：
    1. 將 **OpenCC-NET** 專案加入到開發方案 (Solution) 中，並且將專案加入參考 (Reference)
    2. 從 Release 目錄取出 **OpenCC-NET** 專案編譯完成的 DLL 檔案，並且 DLL 檔案加入參考



## Usage 

### ■ OpenCC Converter

> 使用 OpenCC 字典檔轉換

```c#
var converter = new OpenChineseConverter();

// 簡體轉台灣正體
string twText = converter.ToTaiwanFromSimplifiedWithPhrases("这个意大利制造的鼠标");

// 簡體轉香港繁體
string hkText = converter.ToHongKongFromSimplified("这个意大利制造的鼠标");

// 台灣正體轉簡體
string cnText = converter.ToHongKongFromSimplified("這個義大利製造的滑鼠");
```



| Method name                       | Description                  |
| --------------------------------- | ---------------------------- |
| ToTaiwanFromSimplified            | 簡體 → 臺灣正體              |
| ToTaiwanFromSimplifiedWithPhrases | 簡體 → 臺灣正體 (含常用辭彙) |
| ToHongKongFromSimplified          | 簡體 → 香港繁體              |
| ToTraditionalFromSimplified       | 簡體 → 繁體                  |
| ToSimplifiedFromTaiwan            | 臺灣正體 → 簡體              |
| ToSimplifiedFromTaiwanWithPhrases | 臺灣正體 (含常用辭彙) → 簡體 |
| ToSimplifiedFromHongKong          | 香港繁體 → 簡體              |
| ToSimplifiedFromTraditional       | 繁體 → 簡體                  |
| ToTaiwanFromTraditional           | 繁體 → 臺灣正體              |
| ToHongKongFromTraditional         | 繁體 → 香港繁體              |



---

### ■ Wiki Converter

> 使用 MediaWiki 字典檔轉換

```c#
var converter = new WikiChineseConverter();

// 簡體轉台灣正體
string twText = converter.ToTaiwanTraditional("这个意大利制造的鼠标");

// 簡體轉香港繁體
string hkText = converter.ToHongKongTraditional("这个意大利制造的鼠标");

// 繁體轉中國簡體
string cnText = converter.ToChinaSimplified("這個義大利製造的滑鼠");
```



| Method name           | Description                         |
| --------------------- | ----------------------------------- |
| ToTaiwanTraditional   | 任意中文 → 臺灣正體                 |
| ToHongKongTraditional | 任意中文 → 香港繁體、澳門繁體       |
| ToChinaSimplified     | 任意中文 → 中國簡體                 |
| ToSingaporeSimplified | 任意中文 → 新加坡簡體、馬來西亞簡體 |



---



### ■ TongWen Converter

> 使用同文堂字典檔轉換

```c#
var converter = new TongWenChineseConverter();

// 簡體轉繁體
string twText = converter.ToTraditional("这个意大利制造的鼠标");

// 繁體轉簡體
string cnText = ToSimplified.ToChinaSimplified("這個義大利製造的滑鼠");
```



| Method name                    | Description                |
| ------------------------------ | -------------------------- |
| ToTraditional                  | 簡體 → 繁體                |
| ToTraditionalWithCustomPhrases | 簡體 → 繁體 (包含自訂辭彙) |
| ToSimplified                   | 繁體 → 簡體                |
| ToSimplifiedWithCustomPhrases  | 繁體 → 簡體 (包含自訂辭彙) |



* **新增自訂轉換辭彙**
    * 簡體轉繁體：在字典檔的 `S2TCustomPhrases` 的屬性中加入
    * 繁體轉簡體：在字典檔的 `T2SCustomPhrases` 的屬性中加入



---



### ■ MeiHuaCC Converter

> 使用MeiHuaCC字典檔轉換

```c#
var converter = new MeiHuaChineseConverter();

// 簡體轉繁體
string twText = converter.ToTraditional("这个意大利制造的鼠标");

// 繁體轉簡體
string cnText = ToSimplified.ToChinaSimplified("這個義大利製造的滑鼠");
```



| Method name                    | Description                |
| ------------------------------ | -------------------------- |
| ToTraditional                  | 簡體 → 繁體                |
| ToTraditionalWithCustomPhrases | 簡體 → 繁體 (包含自訂辭彙) |
| ToSimplified                   | 繁體 → 簡體                |
| ToSimplifiedWithCustomPhrases  | 繁體 → 簡體 (包含自訂辭彙) |



* **新增自訂轉換辭彙**
    * 簡體轉繁體：在字典檔的 `cn2tw_cp` 的屬性中加入
    * 繁體轉簡體：在字典檔的 `tw2cn_cp` 的屬性中加入