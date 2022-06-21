using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltracarWebAPI.Classes;
using UltracarWebAPI.Models;

namespace UltracarWebAPI.Data
{
    public class DiagnosticoDB
    {
        public bool InserirDiagnostico(Diagnostico obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "INSERT INTO tb_diagnostico (idDadosPessoaisFuncionario, idCarroCliente, " +
                        "`Data`, DescricaoCliente, Situacao) VALUES (@idDadosPessoaisFuncionario, " +
                        "@idCarroCliente, NOW(), @DescricaoCliente, 'Aguardando a Realização do Serviço');";
                    var diagnostico = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarDiagnostico(Diagnostico obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_diagnostico SET idDadosPessoaisFuncionario=@idDadosPessoaisFuncionario, " +
                        "idCarroCliente=@idCarroCliente, idServicoContratado=@idServicoContratado, Data=@Data, " +
                        "DescricaoCliente=@DescricaoCliente, Situacao=@Situacao WHERE idDiagnostico=@idDiagnostico;";
                    var diagnostico = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirDiagnostico(int idDiagnostico)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_diagnostico WHERE idDiagnostico=@idDiagnostico;";
                    var diagnostico = connection.Execute(sQL, idDiagnostico);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public Diagnostico RetornaDiagnostico(int idDiagnostico)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT * FROM tb_diagnostico WHERE idDiagnostico=@idDiagnostico;";
                    var diagnostico = connection.QuerySingle<Diagnostico>(sQL, new { idDiagnostico });
                    connection.Close();
                    return diagnostico;
                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                return null;
            }
        }

        public List<Diagnostico> RetornaListaDiagnostico()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    Diagnostico retorno = null;
                    var sQL = "SELECT * FROM tb_diagnostico;";
                    var diagnosticos = connection.Query<Diagnostico>(sQL);
                    var Lista = new List<Diagnostico>();
                    foreach (var item in diagnosticos)
                    {
                        retorno = item as Diagnostico;
                        Lista.Add(item);
                    }
                    connection.Close();
                    return Lista;
                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                return null;
            }
        }
    }
}
