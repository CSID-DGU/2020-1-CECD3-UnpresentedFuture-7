using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBTest
{
    class Program
    {
 
        static void Main(string[] args)
        {
            SQLDataBase MyDB = SQLDataBase.Instance;
            //MyDB.ExecuteMySQLQuery("SELECT * FROM `ARBoxing`.`score`");

            //MyDB.ExecuteMySQLQuery("INSERT INTO `ARBoxing`.`score` (`name`,`score`) VALUES ( 'GICEHOL', '1235' );");

            List<string>[] temp = MyDB.Select("SELECT * FROM `ARBoxing`.`score` ORDER BY `score` DESC;");

            for (int i = 0; i < temp[0].Count; i++)
            {
                foreach(string each in temp[i]){
                    Console.WriteLine(each);
                }
            }

            //string strConn = "Server=13.125.206.73;Database=ARBoxing;Uid=odyssey;Pwd=odysseyz;";
            //MySqlConnection conn = new MySqlConnection(strConn);
            //conn.Open();
            //selectScore();
            //Console.WriteLine("Fuck");
            //conn.Close();
        }

        public static void insertScore(string name,int score) {

            string strConn = "Server=13.125.206.73;Database=ARBoxing;Uid=odyssey;Pwd=odysseyz;";
            MySqlConnection conn = new MySqlConnection(strConn);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `ARBoxing`.`score` (`name`,`score`) VALUES ( '" + name+"', '"+score.ToString()+"');",conn);

            try { // 예외 처리
                // 만약 처리한 MYSQL에 정상적으로 들어갔다면 메시지를 보여준다.
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("정상적으로 전달");
                }
                else
                {
                    Console.WriteLine("비정상적");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void selectScore()
        {
            string strConn = "Server=13.125.206.73;Database=ARBoxing;Uid=odyssey;Pwd=odysseyz;";
            MySqlConnection conn = new MySqlConnection(strConn);
            MySqlCommand cmd = new MySqlCommand("SELECT FROM `ARBoxing`.`score` ORDER BY `score` ASC);", conn);

            try
            { // 예외 처리
                // 만약 처리한 MYSQL에 정상적으로 들어갔다면 메시지를 보여준다.
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("정상적으로 전달");
                }
                else
                {
                    Console.WriteLine("비정상적");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
}
