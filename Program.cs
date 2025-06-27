using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using Test;

var client = new HttpClient();

var baseAddress = "http://api.alquran.cloud/v1/surah";



var response = await client.GetAsync(baseAddress);
var responseString = await response.Content.ReadAsStringAsync();
var dto = JsonSerializer.Deserialize<SurahDto>(responseString);



Console.WriteLine(dto?.Code);
Console.WriteLine(dto?.Status);

List<int?> numsList = new List<int?>();
for (int i = 0; i < dto?.Data.Count ; i++)
{
    numsList.Add(dto?.Data[i].Number);
}

foreach (var i in numsList)
{
    Console.WriteLine(i);
}
Console.WriteLine(numsList);
// int i = 1;
// bool flag = true;
// while(flag == true)
// {
// var sura = dto?.Data[i];
// if (sura == null)
// {
//     break;
// }
// else
// {
//     Console.WriteLine($"Number: {sura.Number}");
//     i += 1;
// }
//
//     Console.WriteLine($"NumberOfAyahs: {sura.NumberOfAyahs}");
//     Console.WriteLine($"RevelationType: {sura.RevelationType}");
//     Console.WriteLine($"Name: {sura.Name}");
//     Console.WriteLine($"EnglishName: {sura.EnglishName}");

//     Console.WriteLine($"EnglishNameTranslation: {sura.EnglishNameTranslation}");
//     Console.WriteLine("------------------------------------------------------");


//запрос и ввод номера суры
Console.WriteLine("Введите номер суры");        
string  surahNum = Console.ReadLine();

//флаг для проверки введенного: сура-строка или сура-число
bool surahNumValidFlag = false;                 

var surahAdress = "https://api.alquran.cloud/v1/surah/" + surahNum + "/en.asad";
Console.WriteLine(surahAdress);

var responseSurah = await client.GetAsync(surahAdress);
var responseStringSurah = await responseSurah.Content.ReadAsStringAsync();
var countOfAyahs = JsonSerializer.Deserialize<Data>(responseStringSurah)!.NumberOfAyahs;
var ayahs = JsonSerializer.Deserialize<Ayah>(responseStringSurah)?.Text;

Console.WriteLine(ayahs);
//проверка на суру-строку
while (surahNumValidFlag == false)              
{
    if (int.TryParse(surahNum, out int result))
    {
        
        if (numsList.Contains(result))
        {
            for (int i = 1; i <= countOfAyahs; i++)
            {
                Console.WriteLine(ayahs);
            }
            surahNumValidFlag = true;
        }
    }
    else
    {
        Console.WriteLine("Неправильный номер. Введите номер суры от 1 до 114");
        surahNum = Console.ReadLine();
    }
}



// //проверка на диапазон сур от 1 до 114
// while (Convert.ToUInt32(surahNum) > 115)        
// {
//     Console.WriteLine("Неправильный номер. Введите номер суры от 1 до 114");
//     surahNum = Console.ReadLine();
// }




