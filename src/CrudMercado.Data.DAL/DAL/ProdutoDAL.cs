using CrudMercado.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CrudMercado.Data.DAL.DAL
{
    public class ProdutoDAL
    {
        string connectionString = @"Data Source = DESKTOP-9D3IEDO\SQLEXPRESS01;
                                  Initial Catalog = MercadoDB; Integrated Security=True";

        public IEnumerable<ProdutoEntity> GetAllProdutos()
        {
            List<ProdutoEntity> lstProduto = new List<ProdutoEntity>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Descricao, Preco from dbo.Produtos", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProdutoEntity produto = new ProdutoEntity();
                    produto.Id = Convert.ToInt32(rdr["Id"]);
                    produto.Nome = rdr["Nome"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.Preco = Convert.ToDecimal(rdr["Preco"]);
                    lstProduto.Add(produto);
                }
                return lstProduto;
            }
        }



        public ProdutoEntity GetProduto(int? id)
        {
            ProdutoEntity produto = new ProdutoEntity();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Produtos WHERE Id=" + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    produto.Id = Convert.ToInt32(rdr["Id"]);
                    produto.Nome = rdr["Nome"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.Preco = Convert.ToDecimal(rdr["Preco"]);
                }
                return produto;
            }
        }



        public void AddProduto (ProdutoEntity produto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string ComandoSQL = "INSERT INTO dbo.Produtos(Nome, Descricao, Preco) Values(@Nome, @Descricao, @Preco)";
                SqlCommand cmd = new SqlCommand(ComandoSQL, con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        public void UpdateProduto(ProdutoEntity produto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string ComandoSQL = "Update dbo.Produtos SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco where Id = @Id ";
                SqlCommand cmd = new SqlCommand(ComandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", produto.Id);
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        public void DeleteFornecedor(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string ComandoSQL = "DELETE from dbo.Produtos WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(ComandoSQL, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
