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
    public class CarroDB
    {
        #region "Carro"
        public bool InserirCarro(Carro obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_carro (Marca, Modelo, Cor, AnoFabricacao, AnoModelo) " +
                        "VALUES (@Marca, @Modelo, @Cor, @AnoFabricacao, @AnoModelo);";
                    var carro = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarCarro(Carro obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_carro SET Marca=@Marca, Modelo=@Modelo, Cor=@Cor, " +
                        "AnoFabricacao=@AnoFabricacao, AnoModelo=@AnoModelo " +
                        "WHERE idCarro=@idCarro;";
                    var carro = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirCarro(int idCarro)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_carro WHERE idCarro=@idCarro;";
                    var carro = connection.Execute(sQL, idCarro);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public Carro RetornaCarro(int idCarro)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT * FROM tb_carro WHERE idCarro=@idCarro;";
                    var carro = connection.QuerySingle<Carro>(sQL, new { idCarro });
                    connection.Close();
                    return carro;
                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                return null;
            }
        }

        public List<Carro> RetornaListaCarro()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    Carro retorno = null;
                    var sQL = "SELECT * FROM tb_carro;";
                    var carros = connection.Query<Carro>(sQL);
                    var Lista = new List<Carro>();
                    foreach (var item in carros)
                    {
                        retorno = item as Carro;
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

        #region "Carro Cliente"
        public bool InserirCarroCliente(CarroCliente obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_carro_cliente (idDadosPessoais, idCarro) " +
                        "VALUES (@idDadosPessoais, @idCarro);";
                    var carrocliente = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarCarroCliente(CarroCliente obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_carro_cliente SET idDadosPessoais=@idDadosPessoais, idCarro=@idCarro WHERE idCarroCliente=@idCarroCliente;";
                    var carrocliente = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirCarroCliente(int idCarroCliente)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_carro_cliente WHERE idCarroCliente=@idCarroCliente;";
                    var carrocliente = connection.Execute(sQL, idCarroCliente);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public CarroClienteView RetornaCarroCliente(int idCarroCliente)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT cc.idCarroCliente, cc.idCarro, dp.Nome as Proprietario, c.Marca, c.Modelo, c.Cor, " +
                        "c.AnoFabricacao, c.AnoModelo FROM tb_carro_cliente AS cc " +
                        "INNER JOIN tb_carro AS c ON c.idCarro = cc.idCarro " +
                        "INNER JOIN tb_dados_pessoais AS dp ON dp.idDadosPessoais=cc.idDadosPessoais " +
                        "WHERE cc.idCarroCliente=@idCarroCliente;";
                    var carrocliente = connection.QuerySingle<CarroClienteView>(sQL, new { idCarroCliente });
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

        public List<CarroCliente> RetornaCarrosCliente(int idCarroCliente)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    CarroCliente retorno = null;
                    var sQL = "SELECT * FROM tb_carro_cliente WHERE idCarroCliente=@idCarroCliente;";
                    var carrocliente = connection.Query<CarroCliente>(sQL, new { idCarroCliente });
                    var Lista = new List<CarroCliente>();
                    foreach (var item in carrocliente)
                    {
                        retorno = item as CarroCliente;
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

        public List<CarroClienteView> RetornaCarrosClientePorCliente(int idDadosPessoais)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    CarroClienteView retorno = null;
                    var sQL = "SELECT cc.idCarroCliente, cc.idCarro, dp.Nome as Proprietario, c.Marca, c.Modelo, c.Cor, " +
                        "c.AnoFabricacao, c.AnoModelo FROM tb_carro_cliente AS cc " +
                        "INNER JOIN tb_carro AS c ON c.idCarro = cc.idCarro " +
                        "INNER JOIN tb_dados_pessoais AS dp ON dp.idDadosPessoais=cc.idDadosPessoais " +
                        "WHERE cc.idDadosPessoais=@idDadosPessoais;";
                    var carrocliente = connection.Query<CarroClienteView>(sQL, new { idDadosPessoais });
                    var Lista = new List<CarroClienteView>();
                    foreach (var item in carrocliente)
                    {
                        retorno = item as CarroClienteView;
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

        #region "Carro Checkin"
        public bool InserirCarroCheckin(CarroCheckin obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_carro_checkin (idCarroCliente, Parte, DescricaoCheckList) " +
                        "VALUES (@idCarroCliente, @Parte, @DescricaoCheckList);";
                    var carrocheckin = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarCarroCheckin(CarroCheckin obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_carro_checking SET Parte=@Parte, Descricao=@Descricao WHERE idCarroCheckin=@idCarroCheckin;";
                    var carrocheckin = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirCarroCheckin(int idCarroCheckin)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_carro_checkin WHERE idCarroCheckin=@idCarroCheckin;";
                    var carrocheckin = connection.Execute(sQL, idCarroCheckin);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public CarroCheckin RetornaCarroCheckin(int idCarroCheckin)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT * FROM tb_carro_checkin WHERE idCarroCheckin=@idCarroCheckin;";
                    var pessoa = connection.QuerySingle<CarroCheckin>(sQL, new { idCarroCheckin });
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

        public List<CarroCheckin> RetornaCarrosCheckin()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    CarroCheckin retorno = null;
                    var sQL = "SELECT * FROM tb_carro_checkin;";
                    var tipos = connection.Query<CarroCheckin>(sQL);
                    var Lista = new List<CarroCheckin>();
                    foreach (var item in tipos)
                    {
                        retorno = item as CarroCheckin;
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
