using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {

            // 先ほどコピーした接続文字列を貼り付ける
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            // 実行するSELECT文
            var sql = "SELECT * FROM Test";

            // 接続のためのオブジェクトを生成
            // 実行後にオブジェクトのCloseが必要なため基本的にusing文で囲う
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                // SqlCommand：DBにSQL文を送信するためのオブジェクトを生成
                // SqlDataReader：読み取ったデータを格納するためのオブジェクトを生成
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    // 1行ごとに読み取る
                    while (reader.Read())
                    {
                        // 列名を指定して、読み取ったデータをコンソール上に表示（行ごとに改行して表示）
                        Console.WriteLine($"" +
                            $"{reader["Name"]}\t\t" +
                            $"{reader["Age"]}\t\t" +
                            $"{reader["Birthday"]}");
                    }
                }
            }

            Console.WriteLine("あああ");
            Console.ReadKey();

        }
    }
}
