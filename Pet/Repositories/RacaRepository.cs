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
    public class RacaRepository : IRaca
    {
        PetContext conexao = new PetContext();
        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(Raca a, int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "UPDATE Raca " +
                "SET Descricao = @descricao, " +
                "WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public Raca BuscarPorID(int Id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @Id";
            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca Raca = new Raca();

            while (dados.Read())
            {
                Raca.IdRaca = Convert.ToInt32(dados.GetValue(0));
                Raca.Descricao = dados.GetValue(1).ToString();
                
            }

            conexao.Desconectar();

            return Raca;
        }

        public Raca Cadastrar(Raca a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public Raca Excluir(Raca a, int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE Raca " +
                "WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Desconectar();
            return a;
        }

        public List<Raca> ListarTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> Raca = new List<Raca>();

            while (dados.Read())
            {
                Raca.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        
                    }
                );
            }
            conexao.Desconectar();

            return Raca;
        }
    }
}
