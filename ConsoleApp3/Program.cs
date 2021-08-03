using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Program();
            //obj.UpdateTable(); //not work {Exception} ||{BACK}
            //obj.InsertToTable();
            //obj.DeleteRecordFromTable();
            //obj.UpdateTable();
            //obj.RetriveDateTable();
            // obj.SelectFromProcedure();
            //obj.FILEE();
            Console.WriteLine(DateTime.Now);
        }

        public void FILEE()
        {
            string write = "hello MF";
            File.WriteAllText("Gmail.txt", write);
            string read = File.ReadAllText("Gmail.txt");
            Console.WriteLine(read);
        }
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=nouhDB; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand(@"create table FourthTBL(id int not null,   
                name varchar(100), email varchar(50), join_date date)", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"OOPs, something went wrong. {e}");
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
        public void InsertToTable()
        {
            SqlConnection con = null; // Scope Of All This Func
            try
            {
                con = new SqlConnection("data source=.; database= nouhDB; integrated security=SSPI");
                SqlCommand cmd = new SqlCommand(@"insert into FirstTBL  
                    (id, name, email, join_date)values('102', 'nouh alashqar', 'nouh@gmail.com', '1/12/2017'),
                    ('103', 'nouh alashqar', 'nouh@example.com', '1/12/2017'),
                    ('104', 'nouh alashqar', 'nouh@example.com', '1/12/2017'),
                    ('105', 'nouh alashqar', 'nouh@example.com', '1/12/2017')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Insert to table Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Insert is error{ex}");
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.; database=nouhDB; integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("update FirstTBL Set name='Samer Alramahi' where name='nouh alashqar' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Update Successfullty");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Updated Error {ex}");
            }
            finally
            {
                con.Close();
            }
        }
        public void RetriveDateTable()
        {

            SqlConnection con = null;
            SqlConnection con2 = null;
            try
            {
                con = new SqlConnection("data source=.; database=nouhDB; integrated security=SSPI");
                con2 = new SqlConnection("data source=.; database=nouhDB; integrated security=SSPI");
                SqlCommand cm = new SqlCommand("Select * from FirstTBL", con);
                SqlCommand cm2 = new SqlCommand("Select name from FirstTBL", con2);
                con.Open();
                con2.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                SqlDataReader sdr2 = cm2.ExecuteReader();
                while (sdr.Read())
                {
                    Console.Write(sdr["id"] + " " + sdr["name"] + " " + sdr["email"] + " " + sdr["join_date"] + "\n"); // Displaying Record
                }
                //
                Console.WriteLine(" " + sdr.FieldCount + " " + sdr.IsClosed + " " + sdr.HasRows + " " + sdr.Depth + " " +
                  sdr.RecordsAffected + " " + sdr2.VisibleFieldCount);
                //________________________________________________________________________________________________________________________//
                sdr2.Read();

                Console.WriteLine("\n__FieldCount: " + sdr2.FieldCount + "\n__IsClosed:  " + sdr2.IsClosed +
                    "\n__HasRows : " + sdr2.HasRows + "\n__Depth: " + sdr2.Depth + "\n__RecordsAffected: " +
                    sdr2.RecordsAffected + "\n__VisibleFieldCount:" + sdr2.VisibleFieldCount + "\n__ClientConnectionId : " +
                    con2.ClientConnectionId + "\n__ConnectionString : " + con2.ConnectionString + "\n__DataSource: " +
                    con2.DataSource + "\n__ConnectionTimeout: " + con2.ConnectionTimeout + "\n__Database:  " + con2.Database +
                    "\n__PacketSize : " + con2.PacketSize + "\n__State: " + con2.State + "\n__ ServerVersion: " + con2.ServerVersion +
                    "\n__WorkstationId : " + con2.WorkstationId + "\n__ClientConnectionId : " + con2.ClientConnectionId +
                    "\n__FireInfoMessageEventOnUserErrors: " + con2.FireInfoMessageEventOnUserErrors
                    );

            }
            catch (Exception e)
            {
                Console.WriteLine($"OOPs, something went wrong.\n {e}");
            }
            finally
            {
                con.Close();
                con2.Close();
            }

        }
        public void DeleteRecordFromTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=. ; database=nouhDB; integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("delete from FirstTBL where id='101' OR id='102' OR id='103' OR id='104'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record deleted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error \n {e}");
            }
            finally
            {
                con.Close();
            }
        }
        public void SelectFromProcedure()
        {
            try
            {
                string ConnectionString = "data source=.; database=nouhDB2; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetStudents", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Id"] + ",  " + sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }
    }
}



