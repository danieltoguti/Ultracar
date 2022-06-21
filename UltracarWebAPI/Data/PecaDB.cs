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
    public class PecaDB
    {
        #region "Peca"
        public bool InserirPeca(Peca obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_peca (Nome, Preco) VALUES (@Nome, @Preco);";
                    var peca = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarPeca(Peca obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_peca SET Nome=@Nome, Preco=@Preco WHERE idPeca=@idPeca;";
                    var peca = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirPeca(int idPeca)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_peca WHERE idPeca=@idPeca;";
                    var peca = connection.Execute(sQL, idPeca);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public Peca RetornaPeca(int idPeca)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT * FROM tb_peca WHERE idPeca=@idPeca;";
                    var peca = connection.QuerySingle<Peca>(sQL, new { idPeca });
                    connection.Close();
                    return peca;
                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                return null;
            }
        }

        public List<Peca> RetornaListaPecas()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    Peca retorno = null;
                    var sQL = "SELECT * FROM tb_peca;";
                    var peca = connection.Query<Peca>(sQL);
                    var Lista = new List<Peca>();
                    foreach (var item in peca)
                    {
                        retorno = item as Peca;
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

        #region "Peca Carro"
        public bool InserirPecaCarro(PecaCarro obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_peca_carro (idCarro, idPeca) VALUES (@idCarro, @idPeca);";
                    var pecacarro = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarPecaCarro(PecaCarro obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_peca_carro SET idCarro=@idCarro, idPeca=@idCarro WHERE idPecaCarro=@idPecaCarro;";
                    var pecacarro = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirPecaCarro(int idPecaCarro)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_peca_carro WHERE idPecaCarro=@idPecaCarro;";
                    var carrocheckin = connection.Execute(sQL, idPecaCarro);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public PecaCarro RetornaPecaCarro(int idPecaCarro)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT * FROM tb_peca_carro WHERE idPecaCarro=@idPecaCarro;";
                    var pecacarro = connection.QuerySingle<PecaCarro>(sQL, new { idPecaCarro });
                    connection.Close();
                    return pecacarro;
                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                return null;
            }
        }

        public List<PecaCarro> RetornaListaPecaCarro()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    PecaCarro retorno = null;
                    var sQL = "SELECT * FROM tb_peca_carro;";
                    var pecacarros = connection.Query<PecaCarro>(sQL);
                    var Lista = new List<PecaCarro>();
                    foreach (var item in pecacarros)
                    {
                        retorno = item as PecaCarro;
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
