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
    public class ServicoDB
    {
        #region "Servico"
        public bool InserirServico(Servico obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_servico (Nome, Preco) VALUES (@Nome, @Preco);";
                    var servico = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarServico(Servico obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_servico SET Nome=@Nome, Preco=@Preco WHERE idServico=@idServico;";
                    var servico = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirServico(int idServico)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_servico WHERE idServico=@idServico;";
                    var servico = connection.Execute(sQL, idServico);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public List<ServicoView> RetornaServicoPorId(int idCarro)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    ServicoView retorno = null;
                    var sQL = "SELECT c.idCarro, s.idServico, c.Marca, c.Modelo, s.Nome AS Servico, p.Nome AS Peca FROM tb_carro AS c " +
                        "INNER join tb_peca_carro AS pc ON pc.idCarro = c.idCarro " +
                        "INNER join tb_peca AS p ON p.idPeca = pc.idPeca " +
                        "INNER join tb_servico_peca AS sp ON sp.idPecaCarro = pc.idPecaCarro " +
                        "INNER join tb_servico AS s ON s.idServico = sp.idServico WHERE c.idCarro = @idCarro;";
                    var servico = connection.Query<ServicoView>(sQL, new { idCarro });
                    var Lista = new List<ServicoView>();
                    foreach (var item in servico)
                    {
                        retorno = item as ServicoView;
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

        public List<Servico> RetornaListaServico()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    Servico retorno = null;
                    var sQL = "SELECT * FROM tb_servico;";
                    var servico = connection.Query<Servico>(sQL);
                    var Lista = new List<Servico>();
                    foreach (var item in servico)
                    {
                        retorno = item as Servico;
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

        #endregion

        #region "Servico Contratado"
        public bool InserirServicoContratado(ServicoContratado obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_servico_contratado (idServico, idCarroCliente) " +
                        "VALUES (@idServico, @idCarroCliente);";
                    var servicocontratado = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarServicoContratado(ServicoContratado obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_servico_contratado SET idServico=@idServico, idCarroCliente=@idCarroCliente " +
                        "WHERE idServicoContratado=@idServicoContratado;";
                    var servicocontratado = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirServicoContratado(int idServicoContratado)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_servico_contratado WHERE idServicoContratado=@idServicoContratado;";
                    var servicocontratado = connection.Execute(sQL, new { idServicoContratado });
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public ServicoContratado RetornaServicoContratado(int idServicoContratado)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT * FROM tb_servico_contratado WHERE idServicoContratado=@idServicoContratado;";
                    var carrocliente = connection.QuerySingle<ServicoContratado>(sQL, new { idServicoContratado });
                    connection.Close();
                    return carrocliente;
                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                return null;
            }
        }

        public List<ServicoContratado> RetornaListaServicoContratado()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    ServicoContratado retorno = null;
                    var sQL = "SELECT * FROM tb_servico_contratado;";
                    var servicocontratado = connection.Query<ServicoContratado>(sQL);
                    var Lista = new List<ServicoContratado>();
                    foreach (var item in servicocontratado)
                    {
                        retorno = item as ServicoContratado;
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

        public List<ServicoContratadoView> RetornaListaServicoContratadoPorId(int idCarroCliente)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    ServicoContratadoView retorno = null;
                    var sQL = "SELECT sc.idServicoContratado, dp.Nome AS Cliente, cc.idCarroCliente, c.Modelo, c.Marca, c.AnoModelo, s.Nome AS Servico, s.Preco FROM tb_servico_contratado AS sc " +
                        "INNER JOIN tb_servico AS s ON s.idServico = sc.idServico " +
                        "INNER JOIN tb_carro_cliente AS cc ON cc.idCarroCliente = sc.idCarroCliente " +
                        "INNER JOIN tb_dados_pessoais AS dp ON dp.idDadosPessoais = cc.idDadosPessoais " +
                        "INNER JOIN tb_carro AS c ON c.idCarro = cc.idCarro Where sc.idCarroCliente = @idCarroCliente;";
                    var servicocontratado = connection.Query<ServicoContratadoView>(sQL, new { idCarroCliente });
                    var Lista = new List<ServicoContratadoView>();
                    foreach (var item in servicocontratado)
                    {
                        retorno = item as ServicoContratadoView;
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

        #endregion

        #region "Servico Peca"
        public bool InserirServicoPeca(ServicoPeca obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_servico_peca (idServico, idPecaCarro) VALUES (@idServico, @idPecaCarro);";
                    var servicoPeca = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarServicoPeca(ServicoPeca obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_servico_peca SET idServico=@idServico, idPecaCarro=@idPecaCarro " +
                        "WHERE idServicoPeca=@idServicoPeca;";
                    var servicopeca = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirServicoPeca(int idServicoPeca)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_servico_peca WHERE idServicoPeca=@idServicoPeca;";
                    var servicopeca = connection.Execute(sQL, idServicoPeca);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public ServicoPeca RetornaServicoPeca(int idServicoPeca)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT * FROM tb_servico_peca WHERE idServicoPeca=@idServicoPeca;";
                    var pessoa = connection.QuerySingle<ServicoPeca>(sQL, new { idServicoPeca });
                    connection.Close();
                    return pessoa;
                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                return null;
            }
        }

        public List<ServicoPeca> RetornaListaServicoPeca()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    ServicoPeca retorno = null;
                    var sQL = "SELECT * FROM tb_servico_peca;";
                    var servicopeca = connection.Query<ServicoPeca>(sQL);
                    var Lista = new List<ServicoPeca>();
                    foreach (var item in servicopeca)
                    {
                        retorno = item as ServicoPeca;
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
        #endregion
    }
}
