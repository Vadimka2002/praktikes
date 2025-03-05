using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Program
    {
        static void Main( string[] args )
        {
           
            //string closedText = "ПРИМЕРМАРШРУТНОЙПЕРЕСТАНОВКИ"; // Закрытый текст
            string closedText = "ПРИМЕРМАРШРУТНОЙПЕРЕСТАНОВКИ"; // Закрытый текст ОНПРТЙКВПУИМРЕОНРШЕРРЕАТСА
            int blockLength = 7;
            int rows = ( int )Math.Ceiling( ( double )closedText.Length / blockLength );
            
            int[,] matrix = new int[ rows, blockLength ];

            //Заполняем матрицу из закрытого текста
            int textIndex = 0;
                       
            for ( int i = 0; i <= rows - 1; i++ )
            {
                if ( i % 2 != 0 )
                {
                    for ( int j = blockLength - 1; j >= 0; j-- )
                    {
                        matrix[ i, j ] = textIndex++;
                    }
                }
                else
                {
                    for ( int j = 0; j <= blockLength - 1; j++ )
                    {
                        matrix[ i, j ] = textIndex++;
                    }
                }
            }

            int[] p = new int[ closedText.Length  +blockLength];
            textIndex = 0;

            for ( int i = 0; i <= blockLength-1; i++)
            {
                if( i % 2 != 0 )
                {
                    for ( int j = 0; j <= rows-1; j++ )
                    {
                        p[textIndex] = matrix[ j, i ];
                        textIndex++;
                    }
                }
                else
                {
                    for ( int j = rows - 1; j >= 0; j-- )
                    {
                        p[ textIndex ] = matrix[ j, i ];
                        textIndex++;
                    }
                }
            }

            string text = string.Empty;
            Console.WriteLine( "Введите 1 если закодировать 2 если расскодировать:" );
            string ch = Console.ReadLine();
            int r = 0;
            char[] chars = new char[ closedText.Length ];
            char[] chars2 = new char[ closedText.Length ];
            if ( ch == "1" )
            {
                for ( int i = 0; i <= closedText.Length; i++ )
                {
                    if ( p[ i ] >= closedText.Length )
                    {/* text += "";*/ }
                    else
                    { text += closedText[ p[ i ] ]; 
                        chars[ r] = closedText[ p[ i ] ];
                        chars2[ p[ i ] ] = chars[ r ];
                        r++; 
                    }
                    
                }
            }
            if( ch == "2" )
            {
                for ( int i = 0; i <= closedText.Length; i++ )
                {
                    if ( p[ i ] >= closedText.Length )
                    {/* text += "";*/ }
                    else
                    {
                        text += closedText[ p[ i ] ];
                        chars[ p[i] ] = closedText[r ];
                        r++;
                    }

                }
               
            }

            

            Console.WriteLine( "Оригинальный текст:" );
            Console.WriteLine( text );
            Console.WriteLine( new string(chars));
            Console.ReadKey();
        }
    }
}
