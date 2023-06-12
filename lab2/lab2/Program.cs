using System;
using System.IO;
using System.Linq;

namespace lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Lab2 func = new Lab2();
            char[] russianAlphabet = 
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м',
                'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
                'ы', 'ь', 'э', 'ю', 'я'
            };
            char[] latinAlphabet = 
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
            char[] binAlphabet = { '1', '0' };
            string filePathRus = @"D:\Универ\3 year\6 сем\КМЗИ\lab2\lab2\NewFile1.txt"; // здесь указывается путь к файлу
            string rusFileContents = File.ReadAllText(filePathRus);
                
            string filePathLat = @"D:\Универ\3 year\6 сем\КМЗИ\lab2\lab2\NewFile2.txt"; // здесь указывается путь к файлу
            string latFileContents = File.ReadAllText(filePathLat);
           
            Console.WriteLine( "Энтропия Шеннона для русского алфавита: "+ func.ShannonЕntropy(rusFileContents, russianAlphabet));
            Console.WriteLine( "Энтропия Шеннона для латинского алфавита: "+ func.ShannonЕntropy(latFileContents, latinAlphabet));
            string binRus = func.BinaryAlf(rusFileContents);
            string binLat = func.BinaryAlf(latFileContents);
            Console.WriteLine( "Энтропия Шеннона для русского алфавита  в бинарном виде: "+ func.ShannonЕntropy(binRus, binAlphabet));
            Console.WriteLine( "Энтропия Шеннона для латинского алфавита  в бинарном виде: "+ func.ShannonЕntropy(binLat, binAlphabet));

            string myFio = "Козак Ирина Сергеевна";
            string myFioEn = "Kozak Irina Sergeevna";
            string binRusFio = func.BinaryAlf(myFio);
            string binLatFio = func.BinaryAlf(myFioEn);
             
            Console.WriteLine( "Количество информации rus: "+ func.AmountOfInformation(myFio.Length, func.ShannonЕntropy(myFio, russianAlphabet)));
            Console.WriteLine( "Количество информации lat: "+ func.AmountOfInformation(myFioEn.Length, func.ShannonЕntropy(myFioEn, latinAlphabet)));

            Console.WriteLine( "Количество информации rus bin: "+ func.AmountOfInformation(binRusFio.Length, func.ShannonЕntropy(binRusFio, binAlphabet)));
            Console.WriteLine( "Количество информации lat bin: "+ func.AmountOfInformation(binLatFio.Length, func.ShannonЕntropy(binLatFio, binAlphabet)));

            Console.WriteLine( "Количество информации rus с ошибками 0.1: "+ func.AmountOfInformationWithMistake(myFio.Length,  0.1));
            Console.WriteLine( "Количество информации rus с ошибками 0.5"+ func.AmountOfInformationWithMistake(myFio.Length, 0.5));
            Console.WriteLine( "Количество информации rus с ошибками 1"+ func.AmountOfInformationWithMistake(myFio.Length,  1));
            Console.WriteLine( "Количество информации lat с ошибками 0.1"+ func.AmountOfInformationWithMistake(myFioEn.Length,  0.1));
            Console.WriteLine( "Количество информации lat с ошибками 0.5"+ func.AmountOfInformationWithMistake(myFioEn.Length, 0.5));
            Console.WriteLine( "Количество информации lat с ошибками 1"+ func.AmountOfInformationWithMistake(myFioEn.Length, 1));
        }
    }
}