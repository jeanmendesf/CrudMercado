using CrudMercado.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CrudMercado.Data.DAL.DAL
{
    public class FornecedorDAL 
    {

        string connectionString = @"Data Source = DESKTOP-9D3IEDO\SQLEXPRESS01;
                                  Initial Catalog = MercadoDB; Integrated Security=True";

        public IEnumerable<FornecedorEntity> GetAllFornecedores()
        {
            List<FornecedorEntity> lstFornecedor = new List<FornecedorEntity>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Cpf from dbo.Fornecedores", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    FornecedorEntity fornecedor = new FornecedorEntity();

                    fornecedor.Id = Convert.ToInt32(rdr["Id"]);
                    fornecedor.Nome = rdr["Nome"].ToString();
                    fornecedor.Cpf = rdr["Cpf"].ToString();

                    lstFornecedor.Add(fornecedor);
                }
                return lstFornecedor;
            }
        }



        public FornecedorEntity GetFornecedor(int? id)
        {
            FornecedorEntity fornecedor = new FornecedorEntity();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "Select * From dbo.Fornecedores where Id=" + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    fornecedor.Id = Convert.ToInt32(rdr["Id"]);
                    fornecedor.Nome = rdr["Nome"].ToString();
                    fornecedor.Cpf = rdr["Cpf"].ToString();
                }
                return fornecedor;
            }
        }



        public void AddFornecedor(FornecedorEntity fornecedor)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string ComandoSQL = "insert into dbo.Fornecedores(Nome, Cpf) Values (@Nome, @Cpf)";
                SqlCommand cmd = new SqlCommand(ComandoSQL, con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", fornecedor.Nome);
                cmd.Parameters.AddWithValue("@Cpf", fornecedor.Cpf);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        public void UpdateFornecedor(FornecedorEntity fornecedor)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string ComandoSQL = "Update dbo.Fornecedores set Nome = @Nome, Cpf = @Cpf where Id = @Id";
                SqlCommand cmd = new SqlCommand(ComandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", fornecedor.Id);
                cmd.Parameters.AddWithValue("@Nome", fornecedor.Nome);
                cmd.Parameters.AddWithValue("@Cpf", fornecedor.Cpf);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        public void DeleteFornecedor(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from dbo.Fornecedores where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
