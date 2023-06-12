using System.Text;

namespace lab4;

public class Encription
{
    static char[] PolishAlphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPRSŚTUWYZŹŻ".ToCharArray();
    static int AlphabetLength = PolishAlphabet.Length;

    static int Mod(int a, int b)
    {
        int r = a % b;
        return r < 0 ? r + b : r;
    }

    static int ModInverse(int a, int b)
    {
        a = Mod(a, b);
        for (int x = 1; x < b; x++)
        {
            if (Mod(a * x, b) == 1)
            {
                return x;
            }
        }
        throw new Exception("Inverse does not exist");
    }

    static char Encrypt(char c, int a, int b)
    {
        int index = Array.IndexOf(PolishAlphabet, c);
        if (index == -1)
        {
            return c;
        }
        int newIndex = Mod((a * index + b), AlphabetLength);
        return PolishAlphabet[newIndex];
    }

    static char Decrypt(char c, int a, int b)
    {
        int index = Array.IndexOf(PolishAlphabet, c);
        if (index == -1)
        {
            return c;
        }
        int aInverse = ModInverse(a, AlphabetLength);
        int newIndex = Mod(aInverse * (index - b), AlphabetLength);
        return PolishAlphabet[newIndex];
    }

    public static string AffineEncrypt(string plaintext, int a, int b)
    {
        StringBuilder ciphertext = new StringBuilder();
        foreach (char c in plaintext)
        {
            ciphertext.Append(Encrypt(c, a, b));
        }
        return ciphertext.ToString();
    }

   public static string AffineDecrypt(string ciphertext, int a, int b)
    {
        StringBuilder plaintext = new StringBuilder();
        foreach (char c in ciphertext)
        {
            plaintext.Append(Decrypt(c, a, b));
        }

        return plaintext.ToString();
    }

   public static void CountOfSymbols(string message)
   {
       string alf = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPRSŚTUWYZŹŻ";
       int[] countOfSymbols = new int[alf.Length];
       for (int i = 0; i < alf.Length; i++)
       {
           countOfSymbols[i] = message.ToUpper().Count(symb => alf[i] == symb);
           
               Console.WriteLine(alf[i]+ "--" + countOfSymbols[i] );
           
       }
   } 
}