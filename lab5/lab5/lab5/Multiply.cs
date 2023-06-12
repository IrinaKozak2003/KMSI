namespace lab5;

public interface Multiply
{
   static int[] ConvertToOrderedIndices(string key1)
    {
        char[] characters = new char[] {'a','ą','b','c','ć','d','e','ę','f','g','h','i','j','k',
            'l','ł','m','n','ń','o','ó','p','r','s','ś','t','u','w',
            'y','z','ź','ż'};
        int[] numKey1 = new int[key1.Length];

        
        
        for (int i = 0; i < key1.Length-1; i++)
        {
            for (int j = 0; j < characters.Length-1; j++)
            {
                if (key1[i] == characters[j])
                {
                    numKey1[i] = j;
                   
                }
                
            }
          
        }
        
       

        // Создаем копию исходного массива, который будем сортировать
        int[] sortedArr = (int[])numKey1.Clone();
        Array.Sort(sortedArr);

        // Создаем новый массив порядковых номеров
        int[] orderedIndices = new int[numKey1.Length];

        // Для каждого элемента исходного массива ищем его индекс в отсортированном массиве
        for (int i = 0; i < numKey1.Length; i++)
        {
            int index = Array.IndexOf(sortedArr, numKey1[i]);
            orderedIndices[i] = index;
        }

        return orderedIndices;
    }

   public static string[,] MessageToMatrix(string message, int key1Lenght, int key2Lenght)
   {
       string[,] matrix = new string[key1Lenght,key2Lenght];

       int index = 0;

       for (int i = 0; i < key1Lenght; i++)
       {
           for (int j = 0; j < key2Lenght; j++)
           {
               if (index < message.Length)
               {
                   matrix[i, j] = message.Substring(index, Math.Min( message.Length/(key1Lenght*key2Lenght-1), message.Length - index));
                   index += message.Length/(key1Lenght*key2Lenght-1);
               }
           }
       }

       return matrix;
   }
   public static string[,] MessageToMatrixDecrypt(string message, int key1Lenght, int key2Lenght)
   {
       string[,] matrix = new string[key1Lenght,key2Lenght];

       int index = 0;

       for (int i = 0; i < key1Lenght; i++)
       {
           for (int j = 0; j < key2Lenght; j++)
           {
               if (index < message.Length)
               {
                   int y = message.Length % (message.Length / (key1Lenght * key2Lenght - 1));
                   if (i == 0 && j == 0)
                   {
                       matrix[i, j] = message.Substring(0, y);
                       index = y;
                   }

                   else
                   {
                       matrix[i, j] = message.Substring(index,
                           Math.Min(message.Length / (key1Lenght * key2Lenght - 1), message.Length - index));
                       index += message.Length / (key1Lenght * key2Lenght - 1);
                   }
               }
           }
       }

       return matrix;
   }

   static public string Encript(string key1, string key2, string massage)
   {
       int[] NumKey1 = new int[key1.Length];
       int[] NumKey2 = new int[key2.Length];
      
       NumKey1 = ConvertToOrderedIndices(key1);
       NumKey2 = ConvertToOrderedIndices(key2);

       string[,] matrix = MessageToMatrix(massage, NumKey1.Length, NumKey2.Length);
       string[,] result = new string[NumKey1.Length, NumKey2.Length];

       for (int i = 0; i < NumKey1.Length; i++)
       {
           for (int j = 0; j < NumKey2.Length; j++)
           {
               result[NumKey1[i], NumKey2[j]] = matrix[i,j];
           }
       }

       string resultString = String.Empty;
       for (int i = 0; i < NumKey1.Length; i++)
       for (int k = 0; k < NumKey2.Length; k++)
       {
           resultString += result[i, k];
       }
       resultString = resultString.Replace("\0", "");
       int y=resultString.Length;
       return resultString;
   }
   static public string Decript(string key1, string key2, string massage)
   {
       int[] NumKey1 = new int[key1.Length];
       int[] NumKey2 = new int[key2.Length];
      
       NumKey1 = ConvertToOrderedIndices(key1);
       NumKey2 = ConvertToOrderedIndices(key2);

       string[,] matrix = MessageToMatrixDecrypt(massage, NumKey1.Length, NumKey2.Length);
       string[,] result = new string[NumKey1.Length, NumKey2.Length];

       for (int i = 0; i < NumKey1.Length; i++)
       {
           for (int j = 0; j < NumKey2.Length; j++)
           {
               result[i,j] = matrix[NumKey1[i],NumKey2[j]];
           }
       }

       string resultString = String.Empty;
       for (int i = 0; i < NumKey1.Length; i++)
       for (int k = 0; k < NumKey2.Length; k++)
       {
           resultString += result[i, k];
       }
       resultString = resultString.Replace("\0", "");
       return resultString;
   }

    /*public static string Encript(string key1, string key2, string msg)
    {
        
        int[] NumKey1 = new int[key1.Length];
        int[] NumKey2 = new int[key2.Length];
      
        NumKey1 = ConvertToOrderedIndices(key1);
        NumKey2 = ConvertToOrderedIndices(key2);
        string result = string.Empty;
        string[] msgInArray = new string[(msg.Length / NumKey1.Length) + 1];

     
        char[,] res = new char[msg.Length/key2.Length+1,NumKey1.Length+1];
            
        for (int i = 0; i < msg.Length/NumKey2.Length; i++)
        for (int k = 0, j = 0; k < NumKey1.Length; j < NumKey2.Length ; k++, j++)
        {
           
               // if (msgInArray[k].Length <= i && k==key2.Length-1) continue;
                res[NumKey2[j]+(5*i), NumKey1[k]] = msgInArray[i][k];
            
        
        }

        for (int i = 0; i < NumKey1.Length; i++)
        for (int k = 0; k < NumKey2.Length; k++)
        {
            result += res[i, k];
        }
        result = result.Replace("\0", "");
        return result;
        

    }*/
    /*public static string Decrypt(string key1, string key2, string msg)
    {

    int[] NumKey1 = new int[key1.Length];
    int[] NumKey2 = new int[key2.Length];
        
        
        NumKey1 = ConvertToOrderedIndices(key1);
        NumKey2 = ConvertToOrderedIndices(key2);

        string result = string.Empty;
        string[] msgInArray = new string[(msg.Length / key1.Length) + 1];


        for (int i = 0; i < (msg.Length / NumKey1.Length) + 1; i++)
        {
            if (msg.Length - i * NumKey1.Length <= NumKey1.Length)
            {
                msgInArray[i] = msg.Substring(i * NumKey1.Length);
                break;
            }
            else
            {
                msgInArray[i] = msg.Substring(i * NumKey1.Length, NumKey1.Length);
            }
        }
        char[,] res = new char[NumKey1.Length, NumKey2.Length];


        for (int i = 0; i < NumKey1.Length; i++)
        for (int k = 0; k < NumKey2.Length; k++)
        {
            res[i,k] = msgInArray[NumKey1[k]+(5*1)][NumKey2[i]];
        }

        for (int i = 0; i < NumKey1.Length; i++)
        for (int k = 0; k < NumKey2.Length; k++)
        {
            result += res[i, k];
        }

        result = result.Replace("\0", "");
        return result;

    }*/
}