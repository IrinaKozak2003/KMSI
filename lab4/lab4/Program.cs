using System.Text;
using System.Threading.Channels;
using lab4;
using static lab4.Encription;

string textFromFile = "";
Encoding encoding = Encoding.UTF8; 
using (FileStream fstream = File.OpenRead(@"D:\\Универ\\3 year\\6 сем\\КМЗИ\\lab4\\lab4\\text.txt"))
{
    byte[] buffer = new byte[fstream.Length];
    await fstream.ReadAsync(buffer, 0, buffer.Length);
    textFromFile = Encoding.Default.GetString(buffer);
    Console.WriteLine(textFromFile+'\n'+"----------------------------------------------------"+'\n');
}

string encryptText = Encription.AffineEncrypt(textFromFile, 5, 7);
Console.WriteLine(encryptText+'\n'+"----------------------------------------------------"+'\n');
Console.WriteLine(Encription.AffineDecrypt(encryptText, 5,7));

Encription.CountOfSymbols(textFromFile);
Console.WriteLine("-----------------------------------------------------");
Encription.CountOfSymbols(encryptText);
