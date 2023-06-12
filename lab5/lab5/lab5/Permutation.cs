using System.Threading.Channels;

namespace lab5;

public class Permutation
{
 public static string Encript(string message, int k)
    {
        char[,] reading = new char[k,message.Length/k];
        int index = 0;
        for (int i = 0; i < message.Length/k; i++)
        {
            for (int j = 0; j < k; j++)
            {
                if (index < message.Length)
                { 
                    reading[j, i] = message[index++];
                }else
                {
                    break;
                }
            }

            if (index > message.Length)
            {
                break;
            }
        }
        for (int i = 0; i < reading.GetLength(0); i++)
        {
            for (int j = 0; j < reading.GetLength(1); j++)
            {
                Console.Write(reading[i, j] + " ");
            }
            Console.WriteLine();
        }
        string result = "";
        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < message.Length/k; j++)
            {
                result += reading[i, j];
            }
        }
       Console.WriteLine(result);
        return result;
    }
 public static string Decript(string message, int k)
 {
     char[,] reading = new char[k,message.Length/k];
     int index = 0;
     for (int i = 0; i < k; i++)
     {
         for (int j = 0; j < message.Length/k; j++)
         {
             if (index < message.Length)
             {
                 reading[i, j] = message[index++];
             }else
             {
                 break;
             }
         }

         if (index > message.Length)
         {
             break;
         }
     }
     for (int i = 0; i < reading.GetLength(0); i++)
     {
         for (int j = 0; j < reading.GetLength(1); j++)
         {
             Console.Write(reading[i, j] + " ");
         }
         Console.WriteLine();
     }
     string result = "";
     for (int i = 0; i < message.Length/k; i++)
     {
         for (int j = 0; j < k; j++)
         {
             result += reading[j, i];
         }
     }
     Console.WriteLine(result);
     return result;
 }
 
}