using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBTest
{
    class SQLDataBase
    {
        public MySqlConnection connection;
      
        // 생성자
        public SQLDataBase()
        {
            Initialize();
        }
        //private static 인스턴스 객체
        private static readonly Lazy<SQLDataBase> _instance = new Lazy<SQLDataBase>(() => new SQLDataBase());
        //public static 의 객체반환 함수
        public static SQLDataBase Instance { get { return _instance.Value; } }

        // MySQL DB셋팅 초기화
        private void Initialize()
        {
            Console.WriteLine("DataBse Initialize");

            string connectionString;
            connectionString = "Server=13.125.206.73;Database=ARBoxing;Uid=odyssey;Pwd=odysseyz;";

            connection = new MySqlConnection(connectionString);
        }

        // 데이터베이스 연결을 Open
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("DataBase연동 성공");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("데이터베이스 서버에 연결할 수 없습니다.");
                        break;

                    case 1045:
                        Console.WriteLine("유저 ID 또는 Password를 확인해주세요.");
                        break;
                }
                return false;
            }
        }

        // 데이터베이스 연결을 Close
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Insert, Delete, Update처럼 DataBase를 Write하는 기능은 아래 함수로 통일할 수 있다.
        public void ExecuteMySQLQuery(string userQuery)
        {
            string query = userQuery;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        // DataBase에서 원하는 요소를 Select.
        public List<string>[] Select(string query)
        {
            //string query = $"SELECT * FROM `ARBoxing`.`score`";

            List<string>[] selecter = new List<string>[3];

            for (int index = 0; index < selecter.Length; index++)
            {
                selecter[index] = new List<string>();
            }

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    // Column 갯수만큼 가져온다.
                    selecter[0].Add(dataReader["id"] + "");
                    selecter[1].Add(dataReader["score"] + "");
                    selecter[2].Add(dataReader["name"] + "");
                }

                dataReader.Close();

                this.CloseConnection();
                //return list to be displayed
                return selecter;
            }
            else
            {
                return selecter;
            }
        }

        // DataBase Table Row의 수를 Count
        public int Count()
        {
            string query = $"SELECT Count(*) FROM `ARBoxing`.`score`";
            int Count = -1;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                Count = int.Parse(cmd.ExecuteScalar() + "");

                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}
