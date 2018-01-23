using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class add
    {
        public void addrow(int id, string task)
        {
            string connStr = "server=localhost;user=root;database=weeknote;password=1234;";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            string x = task;
            string query = "insert into note (ID, NAME) value ( "+id+",'" +task+"');";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }
        class remove
        {
            public void removerow(int id)
            {
                string connStr = "server=localhost;user=root;database=weeknote;password=1234;";
                // создаём объект для подключения к БД
                MySqlConnection conn = new MySqlConnection(connStr);
                // устанавливаем соединение с БД
                conn.Open();
                string query = "DELETE FROM note WHERE id = " + id + ";";
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                command.ExecuteNonQuery();
                // закрываем подключение к БД
                conn.Close();
            }
        }
        class update
     {
        public void updaterow(int id, string task)
        {
            string connStr = "server=localhost;user=root;database=weeknote;password=1234;";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            string query = "UPDATE note SET name = '"+task+"' WHERE id = " + id + ";";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }

      }


        class show
        {
            public void shownotes()
            {
                // строка подключения к БД
                string connStr = "server=localhost;user=root;database=weeknote;password=1234;";
                // создаём объект для подключения к БД
                MySqlConnection conn = new MySqlConnection(connStr);
                // устанавливаем соединение с БД
                conn.Open();
                // запрос
                string sql = "SELECT * from note";
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(sql, conn);
                // объект для чтения ответа сервера
                MySqlDataReader reader = command.ExecuteReader();
                // читаем результат
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
                }
                reader.Close(); // закрываем reader
                // закрываем соединение с БД
                conn.Close();
            }
        }

        class Program
        {

            static void Main()
            {
                
                Console.WriteLine("Выберите что нужно сделать?");
                Console.WriteLine("- [1] добавить запись");
                Console.WriteLine("- [2] удалить запись");
                Console.WriteLine("- [3] редактировать");
                Console.WriteLine("- [4] показать список");
                Console.WriteLine("- [5] выход из программы");

                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    add addrow = new add();
                    Console.WriteLine("напишите номер задачи и саму задачу");
                    int id = Convert.ToInt32(Console.ReadLine());
                    string task = Console.ReadLine();
                    addrow.addrow(id, task);
                    Program main = new Program();
                    Program.Main();
                }
                if (i == 2)
                {
                    remove removerow = new remove();
                    Console.WriteLine("напишите номер задачи которую нужно удалить");
                    int id = Convert.ToInt32(Console.ReadLine());
                    removerow.removerow(id);
                    Program main = new Program();
                    Program.Main();
                }
                if (i == 3)
                {
                    update updaterow = new update();
                    Console.WriteLine("напишите номер задачи которую надо обновить");
                    int id = Convert.ToInt32(Console.ReadLine());
                    string task = Console.ReadLine();
                    updaterow.updaterow(id, task);
                    Program main = new Program();
                    Program.Main();
                }

                if(i == 4)
                {
                    show show = new show();
                    show.shownotes();
                    Console.ReadLine();
                    Program main = new Program();
                    Program.Main();
                }
                if (i == 5)
                {
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("не указано действие");
                    Program main = new Program();
                    Program.Main();
                }
            }


        }

    }
}


