using System.Text.Json.Serialization;

namespace Test
{
    public class SurahDto
    {
        [JsonPropertyName("code")]
        public long Code { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public List<Surah> Data { get; set; }
    }

    public class Surah
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("englishName")]
        public string EnglishName { get; set; }

        [JsonPropertyName("englishNameTranslation")]
        public string EnglishNameTranslation { get; set; }

        [JsonPropertyName("numberOfAyahs")]
        public long NumberOfAyahs { get; set; }

        [JsonPropertyName("revelationType")]
        public string RevelationType { get; set; }
    }
    
    public class Ayah
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("numberInSurah")]
        public int NumberInSurah { get; set; }
        
        [JsonPropertyName("juz")]
        public int Juz { get; set; }
        
        [JsonPropertyName("manzil")]
        public int Manzil { get; set; }
        
        [JsonPropertyName("page")]
        public int Page { get; set; }
        
        [JsonPropertyName("ruku")]
        public int Ruku { get; set; }
        
        [JsonPropertyName("hizbQuarter")]
        public int HizbQuarter { get; set; }
        
        [JsonPropertyName("sajda")]
        public bool Sajda { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("englishName")]
        public string EnglishName { get; set; }
        
        [JsonPropertyName("englishNameTranslation")]
        public string EnglishNameTranslation { get; set; }
        
        [JsonPropertyName("revelationType")]
        public string RevelationType { get; set; }
        
        [JsonPropertyName("numberOfAyahs")]
        public int NumberOfAyahs { get; set; }
        
        [JsonPropertyName("ayahs")]
        public List<Ayah> Ayahs { get; set; }
        
        [JsonPropertyName("edition")]
        public Edition Edition { get; set; }
    }

    public class Edition
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }
        
        [JsonPropertyName("language")]
        public string Language { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("englishName")]
        public string EnglishName { get; set; }
        
        [JsonPropertyName("format")]
        public string Format { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("direction")]
        public string Direction { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }
}