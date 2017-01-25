using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace USG_tablet_UI
{
    class DatabaseHandler
    {

        string connetionString = null;
        SqlConnection connection;
        SqlCommand command;
        string sql = null;
        SqlDataReader dataReader;

        public DatabaseHandler()
        {
            connetionString = "Data Source=korfi.ddns.net;Initial Catalog=USG;User ID=uzytkownik;Password=haslo123!@#";
            connection = new SqlConnection(connetionString);
            
        }

        public List<Pacjent> getListaPacjentowFromDB()
        {
            List<Pacjent> listaPacjentow = new List<Pacjent>();
            try
            {     
                connection.Open();
                sql = "SELECT * FROM pacjenci";
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Pacjent p = new Pacjent((int)dataReader.GetValue(0), (string)dataReader.GetValue(1), (string)dataReader.GetValue(2));
                    listaPacjentow.Add(p);
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
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
                connection.Open();
                sql = "SELECT pacjenci.id, pacjenci.imie, pacjenci.nazwisko, badania.data, rodzajbadania.rodzaj FROM badania INNER JOIN pacjenci ON pacjenci.id = badania.pacjentID INNER JOIN rodzajbadania ON rodzajbadania.ID = badania.rodzajbadaniaID WHERE pacjenci.id=" + GlobalSettings.lastPacjentSelected.id;
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                { 
                    Pacjent p = new Pacjent((int)dataReader.GetValue(0), (string)dataReader.GetValue(1), (string)dataReader.GetValue(2));
                    Badanie b = new Badanie((DateTime)dataReader.GetValue(3), (string)dataReader.GetValue(4), p);
                    listaBadan.Add(b);
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
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
                connection.Open();
                sql = "SELECT * FROM rodzajbadania";
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string typ = (string)dataReader.GetValue(1);
                    listaTypow.Add(typ);
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            return listaTypow;
        }

        public void insertBadanieIntoDB(Pacjent p, string typ, string date)
        {
            connection.Open();
            string sql = "INSERT INTO badania(pacjentID,rodzajbadaniaID,data) VALUES (" + p.id + ",(SELECT id FROM rodzajbadania WHERE rodzaj='" + typ + "'),'" + date + "')";
            command = new SqlCommand(sql, connection);
            int rowsAffected = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }


    }
}
