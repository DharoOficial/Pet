using Pet.Domains;
using Pet.Interfaces;
using Pet.Pet.Context.cs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Repositories
{
    public class TipoDePetRepository : ITipoDePet
    {
        PetContext conexao = new PetContext();
        SqlCommand cmd = new SqlCommand();
        public TipoDePet Alterar(TipoDePet e, int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "UPDATE TipoDePet " +
                "SET Descricao = @descricao, " +
                "WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descricao", e.Descricao);


            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return e;
        }

        public TipoDePet BuscarPorID(int Id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @Id";
            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet TipoDePet = new TipoDePet();

            while (dados.Read())
            {
                TipoDePet.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                TipoDePet.Descricao = dados.GetValue(1).ToString();

            }

            conexao.Desconectar();

            return TipoDePet;
        }

        public TipoDePet Cadastrar(TipoDePet e)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO TipoDePet (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", e.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return e;
        }

        public TipoDePet Excluir(TipoDePet e, int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE TipoDePet " +
                "WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Desconectar();
            return e;
        }

        public List<TipoDePet> ListarTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet";

            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoDePet> TipoDePet = new List<TipoDePet>();

            while (dados.Read())
            {
                TipoDePet.Add(
                    new TipoDePet()
                    {
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),

                    }
                );
            }
            conexao.Desconectar();

            return TipoDePet;
        }
    }
}
