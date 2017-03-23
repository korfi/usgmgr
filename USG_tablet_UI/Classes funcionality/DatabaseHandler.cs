using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace USG_tablet_UI
{
    class DatabaseHandler
    {

        SQLiteConnection dbConnection = null;
        string connectionString = null;
        string sql = null;
        SQLiteCommand command = null;
        SQLiteDataReader reader = null;

        public DatabaseHandler()
        {
            SQLiteConnection.CreateFile("USGdb.sqlite");
            connectionString = "Data Source=MyDatabase.sqlite;Version=3;";
            dbConnection = new SQLiteConnection(connectionString);
            dbConnection.Open();

            // poniżej znajduja sie zakomentowane komendy SQL sluzace do stworzenia bazy i zapelnienia jej danymi

            /*sql = "CREATE TABLE rodzajbadania (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, rodzaj varchar(50) NOT NULL);";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE pacjenci (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, imie varchar(50) NOT NULL, nazwisko varchar(50) NOT NULL);";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE badania (pacjentID INTEGER NOT NULL, rodzajbadaniaID INTEGER NOT NULL, data datetime NOT NULL, PRIMARY KEY (pacjentID, data), FOREIGN KEY (pacjentID) REFERENCES pacjenci(id), FOREIGN KEY (rodzajbadaniaID) REFERENCES rodzajbadania(id));";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();*/

            /*sql = "INSERT INTO pacjenci (id, imie, nazwisko) VALUES (1, 'Jan', 'Kowalski');";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO pacjenci (imie, nazwisko) VALUES ('Adam', 'Nowak');";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO pacjenci (imie, nazwisko) VALUES ('Jacek', 'Rzepa');";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO rodzajbadania (id, rodzaj) VALUES (1, 'USG');";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO rodzajbadania (rodzaj) VALUES ('Tomografia');";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO rodzajbadania (rodzaj) VALUES ('RTG');";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();*/
            
        }

        public List<Pacjent> getListaPacjentowFromDB()
        {
            List<Pacjent> listaPacjentow = new List<Pacjent>();
            try
            {   
                sql = "SELECT * FROM pacjenci";
                command = new SQLiteCommand(sql, dbConnection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pacjent p = new Pacjent(Convert.ToInt32((long)reader["id"]), (string)reader["imie"], (string)reader["nazwisko"]);
                    listaPacjentow.Add(p);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            return listaPacjentow;
        }

        public List<Badanie> getListaBadanFromDB()
        {
            List<Badanie> listaBadan = new List<Badanie>();
            try
            {
                sql = "SELECT pacjenci.id, pacjenci.imie, pacjenci.nazwisko, badania.data, rodzajbadania.rodzaj FROM badania INNER JOIN pacjenci ON pacjenci.id = badania.pacjentID INNER JOIN rodzajbadania ON rodzajbadania.ID = badania.rodzajbadaniaID WHERE pacjenci.id=" + GlobalSettings.lastPacjentSelected.id;
                command = new SQLiteCommand(sql, dbConnection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pacjent p = new Pacjent(Convert.ToInt32((long)reader["id"]), (string)reader["imie"], (string)reader["nazwisko"]);
                    Badanie b = new Badanie((DateTime)reader["data"], (string)reader["rodzaj"], p);
                    listaBadan.Add(b);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            return listaBadan;
        }

        public List<string> getListaTypowBadanFromDB()
        {
            List<string> listaTypow = new List<string>();
            try
            {
                sql = "SELECT * FROM rodzajbadania";
                command = new SQLiteCommand(sql, dbConnection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string typ = (string)reader["rodzaj"];
                    listaTypow.Add(typ);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            return listaTypow;
        }

        public void insertBadanieIntoDB(Pacjent p, string typ, string date)
        {
            string sql = "INSERT INTO badania(pacjentID,rodzajbadaniaID,data) VALUES (" + p.id + ",(SELECT id FROM rodzajbadania WHERE rodzaj='" + typ + "'),'" + date + "')";
            command = new SQLiteCommand(sql, dbConnection);
            int rowsAffected = command.ExecuteNonQuery();
        }


    }
}
