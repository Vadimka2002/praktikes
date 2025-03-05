using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Open.Numeric.Primes;
using Open.Numeric.Primes.Extensions;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace lab2
{
    
    internal class Program
    {
        static void Main( string[] args )
        {
            void difihelman()
            {
                

                BigInteger p = FindNextPrime( 8 );
                Console.WriteLine( $"Найдено простое число: {p}" );

                BigInteger q = FindNextPrime( 8 );
                Console.WriteLine( $"Найдено простое число: {q}" );

                Random r = new Random( Environment.TickCount );
                
                BigInteger g;
                while ( true )
                {
                    g = new BigInteger( r.Next( 23 - 1 ) + 1 );
                    var var_t = BigInteger.ModPow( g, q, p );
                    if ( !var_t.IsOne )
                    {
                        Console.WriteLine( $"Число g = {g} можно использовать" );
                        break;
                    }
                    else
                        Console.WriteLine( $"Число g = {g} нельзя использовать" );
                }
                    
                // Абонент A
                
                BigInteger X_A = FindNextPrime( 8 );
                Console.WriteLine( $"Найдено простое число: {X_A}" );

                var Y_A = BigInteger.ModPow( g, X_A, p );
                Console.WriteLine( $"g^X_A = Y_A = {Y_A} /= 1" );

                // Абонент B
               
                BigInteger X_B = FindNextPrime( 8 );
                Console.WriteLine( $"Найдено простое число: {X_B}" );
                var Y_B = BigInteger.ModPow( g, X_B, p );
                Console.WriteLine( $"g^X_B = Y_B = {Y_B} /= 1" );

                // A <=> B Y_A и Y_B

                var Z_AB = BigInteger.ModPow( Y_B, X_A, p );
                Console.WriteLine( $"Сеансовый A=> B {Z_AB}" );

                var Z_BA = BigInteger.ModPow( Y_A, X_B, p );
                Console.WriteLine( $"Сеансовый B=> A {Z_BA}" );

                Console.ReadKey();
            }

            void rsa1()
            {
                BigInteger p = FindNextPrime( 8 );
                Console.WriteLine( $"Найдено простое число: {p}" );

                BigInteger q = FindNextPrime( 8 );
                Console.WriteLine( $"Найдено простое число: {q}" );

                // Вычисление n = p * q
                BigInteger _modulus = p * q;

                // Вычисление функции Эйлера φ(n) = (p-1)*(q-1)
                BigInteger phi = ( p - 1 ) * ( q - 1 );

                // Выбор открытой экспоненты e
                int _publicKey = 65537; // Часто используется значение 65537

                // Вычисление закрытой экспоненты d
                BigInteger _privateKey = 1/_publicKey % phi;//BigInteger.ModPow( _publicKey,1 -1, phi ); // d = e^(-1) mod φ(n)
                
                string message = "Hello, RSA!";
                BigInteger messageInt = new BigInteger( System.Text.Encoding.UTF8.GetBytes( message ) );

                //Console.WriteLine( $"Исходное сообщение: {message}" );
                Console.WriteLine( $"Исходное сообщение: {messageInt}" );

                // Шифрование
                BigInteger cipherText = BigInteger.ModPow( messageInt, _publicKey, _modulus );
                Console.WriteLine( $"Зашифрованное сообщение: {cipherText}" );

                // Дешифрование
                BigInteger decryptedMessage = BigInteger.ModPow( cipherText, _privateKey, _modulus );
                Console.WriteLine( decryptedMessage );
                string decryptedString = System.Text.Encoding.UTF8.GetString( decryptedMessage.ToByteArray() );
                Console.WriteLine( $"Дешифрованное сообщение: {decryptedString}" );              


                Console.ReadKey();

            }

            
            difihelman();
            //rsa1();
        }
      

        static bool IsPrime1( BigInteger number )
        {
            if ( number <= 1 )
                return false;
            if ( number == 2 )
                return true;
            if ( number % 2 == 0 )
                return false;

            for ( int i = 3; i <= BigIntegerSqrt(number); i += 2 )
            {
                if ( number % i == 0 )
                    return false;
            }

            return true;
        }
        static BigInteger BigIntegerSqrt( BigInteger value )
        {
            if ( value < 0 )
                throw new ArgumentException( "Квадратный корень из отрицательного числа не определен." );

            if ( value == 0 || value == 1 )
                return value;

            BigInteger x = value;
            BigInteger y = ( value / 2 ) + 1; // Начальное значение

            // Метод Ньютона
            while ( y < x )
            {
                x = y;
                y = ( value / y + y ) / 2; // Среднее значение
            }

            return x;
        }
        static BigInteger FindNextPrime( BigInteger startValue )
        {
            Random r = new Random( Environment.TickCount );
            BigInteger q = BigInteger.Abs( startValue ); // Убедимся, что стартовое значение положительное

            // Если стартовое значение простое, вернем его
            if ( IsPrime1( q ) )
            {
                return q;
            }

            // Генерация случайных чисел до тех пор, пока не найдем простое
            do
            {
                byte[] b = new byte[ 4 ];
                r.NextBytes( b );
                q = BigInteger.Abs( new BigInteger( b ) );

                Console.WriteLine( $"Сгенерированное число: {q}" );
            }
            while ( !IsPrime1( q ) );

            return q; // Возвращаем найденное простое число
        }
    }
}
