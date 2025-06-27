using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using Test;

var client = new HttpClient();

var baseAddress = "http://api.alquran.cloud/v1/surah";



var response = await client.GetAsync(baseAddress);
var responseString = await response.Content.ReadAsStringAsync();
var dto = JsonSerializer.Deserialize<SurahDto>(responseString);



// Console.WriteLine(dto?.Code);
// Console.WriteLine(dto?.Status);

List<int?> numsList = new List<int?>();
for (int i = 0; i < dto?.Data.Count ; i++)
{
    numsList.Add(dto?.Data[i].Number);
}

//запрос и ввод номера суры
Console.WriteLine("Введите номер суры");        
string  surahNum = Console.ReadLine();

//флаг для проверки введенного: сура-строка или сура-число
bool surahNumValidFlag = false;                 

//проверка на суру-строку
while (surahNumValidFlag == false)              
{
    if (int.TryParse(surahNum, out int result))
    {
        
        if (numsList.Contains(result))
        {
            
            surahNumValidFlag = true;
        }
        else
        {
            Console.WriteLine("Неправильный номер. Введите номер суры от 1 до 114");
            surahNum = Console.ReadLine();
        }
    }
    else
    {
        Console.WriteLine("Неправильный номер. Введите номер суры от 1 до 114");
        surahNum = Console.ReadLine();
    }
}


var surahAdress = "https://api.alquran.cloud/v1/surah/" + surahNum + "/en.asad";

var responseSurah = await client.GetAsync(surahAdress);
var responseStringSurah = await responseSurah.Content.ReadAsStringAsync();
var countOfAyahs = JsonSerializer.Deserialize<Root>(responseStringSurah)!.Data.NumberOfAyahs;
var ayahs = JsonSerializer.Deserialize<Root>(responseStringSurah)?.Data.Ayahs;
for (int i = 1; i < countOfAyahs; i++)
{
    Console.WriteLine(ayahs[i].Text);
}


