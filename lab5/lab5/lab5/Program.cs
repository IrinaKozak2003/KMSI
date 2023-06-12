// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
using lab5;


string textFromFile = "";
Encoding encoding = Encoding.UTF8;
using (FileStream fstream = File.OpenRead(@"D:\\Универ\\3 year\\6 сем\\КМЗИ\\lab5\\lab5\\lab5\\text.txt"))
{
    byte[] buffer = new byte[fstream.Length];
    await fstream.ReadAsync(buffer, 0, buffer.Length);
    textFromFile = Encoding.Default.GetString(buffer);
    Console.WriteLine(textFromFile + '\n' + "----------------------------------------------------" + '\n');
}

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
string encript_message = Permutation.Encript(textFromFile, 50);
stopwatch.Stop();
Console.WriteLine("Время выполнения: {0} мс", stopwatch.ElapsedMilliseconds);
Stopwatch stopwatch1 = new Stopwatch();
stopwatch1.Start();
Permutation.Decript(encript_message, 50);
stopwatch1.Stop();
Console.WriteLine("Время выполнения: {0} мс", stopwatch1.ElapsedMilliseconds);
/*  
Console.WriteLine("------------------------------------------------------------------------------------------------------------------"+'\n'+"--------------------------------------------------------------");
Stopwatch stopwatch3 = new Stopwatch();
stopwatch3.Start();

string encript_message1 = Multiply.Encript("koza","irena",textFromFile );

stopwatch3.Stop();
Console.WriteLine(encript_message1);
Console.WriteLine("Время выполнения: {0} мс", stopwatch3.ElapsedMilliseconds);
Stopwatch stopwatch4 = new Stopwatch();
stopwatch4.Start();
string mess =Multiply.Decrypt("koza","irena",encript_message1);
stopwatch4.Stop();
Console.WriteLine(mess);
Console.WriteLine("Время выполнения: {0} мс", stopwatch4.ElapsedMilliseconds);
*/
string test = Multiply.Encript("koza","irena", textFromFile);

        Console.WriteLine(test);
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine(Multiply.Decript("koza","irena", test));

string test1 = Multiply1.MessToSubstrings( textFromFile, "koza","irena");

Console.WriteLine(test1);
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine(Multiply1.MessToSubstringsDe(test1, "koza","irena"));

  