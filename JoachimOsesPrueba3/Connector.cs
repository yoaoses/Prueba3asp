using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JoachimOsesPrueba3
{
    internal class Connector
    {
        private string _connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\yoaos\\source\\repos\\JoachimOsesPrueba3\\JoachimOsesPrueba3\\App_Data\\Database1.mdf;Integrated Security=True";
        private SqlConnection _conn;

        public string connString { get => _connString; set => _connString = value; }
        public SqlConnection conn { get => _conn; set => _conn = value; }

        public Connector()
        {
            this.conn = new SqlConnection(connString);
        }

        public void openConn()
        {
            try
            {
                if (this.conn.State != System.Data.ConnectionState.Open)
                {
                    this.conn.Open();
                    //MessageBox.Show("conexion Abierta");
                }
            }
            catch (Exception e)
            {
                
            }
        }
        public void closeConn()
        {
            try
            {
                if (this.conn.State != System.Data.ConnectionState.Closed)
                {
                    this.conn.Close();
                    //MessageBox.Show("conexion cerrada");
                }
            }
            catch (Exception e)
            {
               
            }
        }
    }
}