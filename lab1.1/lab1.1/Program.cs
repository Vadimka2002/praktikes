using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Reflection;


namespace lab1._1
{
    internal class Program
    {
        static void Main( string[] args )
        {
            Console.Write( "Enter login: " );
            string[] login = Console.ReadLine( ).Split( '\'' );
            
            Console.Write( "Enter password: " );
            string[] password = Console.ReadLine().Split( '\'' );
            
            SHA256 sha256 = SHA256.Create();
            
            byte[] bytes = sha256.ComputeHash( Encoding.UTF8.GetBytes( password[0] ) );
            StringBuilder builder = new StringBuilder();

            foreach ( byte b in bytes )
            {
               builder.Append( b.ToString( "x2" ) ); 
            }

   

            String connectionString = "server=127.0.0.1; port=3305; " +
                "database=users; userid=sslclient; password=test; " +
                "SslMode=verifyca;" +
                "SslCa=C:/ProgramData/MySQL/MySQL Server 8.3/Data/ca.pem;" +
                "SslCert=C:/ProgramData/MySQL/MySQL Server 8.3/Data/client-cert.pem;" +
                "SslKey=C:/ProgramData/MySQL/MySQL Server 8.3/Data/client-key.pem;";
            MySqlConnection mySqlConnection =
                new MySqlConnection( connectionString );
            mySqlConnection.Open();
            String sqlQuery = $"SELECT * FROM `users` WHERE login = '{@login[0]}' AND password = '{builder.ToString()}';";
            MySqlDataAdapter mySqlDataAdapter =
                new MySqlDataAdapter( sqlQuery, mySqlConnection );
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill( dataTable );

            try
            {
                if ( dataTable.Rows[ 0 ].Field<string>( "login" ).Count() > 0 )
                {
                    Console.WriteLine( $"login: {dataTable.Rows[ 0 ].Field<string>( "login" )}" );
                    Console.WriteLine( $"password: {dataTable.Rows[ 0 ].Field<string>( "password" )}" );
                    Console.WriteLine( $"FIO: {dataTable.Rows[ 0 ].Field<string>( "FIO" )}" );
                    Console.WriteLine( $"roles: {dataTable.Rows[ 0 ].Field<string>( "roles" )}" );
                }               
            }
            catch ( ArgumentException e )
            {
                Console.WriteLine( $"Processing failed: {e.Message}" );
            }
            finally
            {
                Console.WriteLine( "Error enter" );
            }
            
            
            Console.ReadKey();
            mySqlConnection.Close();

            string EscapeSql( string input )
            {
                return input.Replace( "'", "''" );
            }
        }        
    }
}
  

