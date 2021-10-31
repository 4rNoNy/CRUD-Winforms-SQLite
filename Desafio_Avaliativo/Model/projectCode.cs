using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Desafio_Avaliativo
{
    class projectCode
    {
        private static SQLiteConnection sqliteConnection;
        public projectCode()
        { }
        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection(@"data source=C:\Users\User\source\repos\Desafio_Avaliativo\DataBase\sms1.db; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        
        public static DataTable GetPessoas()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM pessoa";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPessoa(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM pessoa Where id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Add(Pessoa pessoa)
        {
            
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO pessoa(id, pcd, nome, sobrenome, datanascimento, altura ) VALUES (@id, @pcd, @nome, @sobrenome, @datanascimento, @altura)";
                    cmd.Parameters.AddWithValue("@id", pessoa.id);
                    cmd.Parameters.AddWithValue("@pcd", pessoa.pcd);
                    cmd.Parameters.AddWithValue("@nome", pessoa.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", pessoa.sobrenome);
                    cmd.Parameters.AddWithValue("@datanascimento", pessoa.datanascimento);
                    cmd.Parameters.AddWithValue("@altura", pessoa.altura);
                    cmd.ExecuteNonQuery();
                }
            
          
        }
        public static void Update(Pessoa pessoa)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (pessoa.id != null )
                    {
                        cmd.CommandText = "UPDATE pessoa SET pcd=@pcd, nome=@nome, sobrenome=@sobrenome, datanascimento=@datanascimento, altura=@altura WHERE id=@id";
                        cmd.Parameters.AddWithValue("@id", pessoa.id);
                        cmd.Parameters.AddWithValue("@pcd", pessoa.pcd);
                        cmd.Parameters.AddWithValue("@nome", pessoa.nome);
                        cmd.Parameters.AddWithValue("@sobrenome", pessoa.sobrenome);
                        cmd.Parameters.AddWithValue("@datanascimento", pessoa.datanascimento);
                        cmd.Parameters.AddWithValue("@altura", pessoa.altura);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM pessoa Where id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
