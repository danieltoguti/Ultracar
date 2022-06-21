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
    public class DadosPessoaisDB
    {
        public bool InserirDadosPessoais(DadosPessoais obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_dados_pessoais (idTipo, Nome, CPF,Email) VALUES (@idTipo, @Nome, @CPF, @Email);";
                    var produto = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarDadosPessoais(DadosPessoais obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_dados_pessoais SET idTipo=@idTipo, Nome=@Nome, CPF=@CPF, Email=@Email " +
                        "WHERE idDadosPessoais=@idDadosPessoais;";
                    var produto = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirDadosPessoais(int idDadosPessoais)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_dados_pessoais WHERE idDadosPessoais=@idDadosPessoais;";
                    var produto = connection.Execute(sQL, idDadosPessoais);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public DadosPessoais Pessoa(int idDadosPessoais)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {                  
                    var sQL = "SELECT * FROM tb_dados_pessoais WHERE idDadosPessoais=@idDadosPessoais;";                  
                    var pessoa = connection.QuerySingle<DadosPessoais>(sQL, new { idDadosPessoais });
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

        public List<DadosPessoais> ListaPessoas()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    DadosPessoais retorno = null;
                    var sQL = "SELECT * FROM tb_dados_pessoais;";
                    var pessoas = connection.Query<DadosPessoais>(sQL);
                    var Lista = new List<DadosPessoais>();
                    foreach (var item in pessoas)
                    {
                        retorno = item as DadosPessoais;
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

        public List<DadosPessoais> ListaFuncionario()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    DadosPessoais retorno = null;
                    var sQL = "SELECT * FROM tb_dados_pessoais Where idTipo=2;";
                    var pessoas = connection.Query<DadosPessoais>(sQL);
                    var Lista = new List<DadosPessoais>();
                    foreach (var item in pessoas)
                    {
                        retorno = item as DadosPessoais;
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

        public bool InserirEndereco(Endereco obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_endereco (idDadosPessoais, Descricao, CEP, Logradouro, Numero, Bairro, Cidade, UF) " +
                        "VALUES (@idDadosPessoais, @Descricao, @CEP, @Logradouro, @Numero, @Bairro, @Cidade, @UF);";
                    var produto = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarEndereco(Endereco obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_endereco SET idDadosPessoais=@idDadosPessoais, Descricao=@Descricao, CEP=@CEP, Logradouro=@Logradouro, " +
                        "Numero=@Numero, Bairro=@Bairro, Cidade=@Cidade, UF=@UF WHERE idDadosPessoais=@idDadosPessoais ";
                    var produto = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirEndereco(int idEndereco)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_endereco WHERE idEndereco=@idEndereco;";
                    var produto = connection.Execute(sQL, idEndereco);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public DadosPessoais RetornaEndereco(int idDadosPessoais)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT * FROM tb_endereco WHERE idDadosPessoais=@idDadosPessoais;";
                    var pessoa = connection.QuerySingle<DadosPessoais>(sQL, new { idDadosPessoais });
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

        public List<Endereco> RetornaEnderecos(int idDadosPessoais)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    Endereco retorno = null;
                    var sQL = "SELECT * FROM tb_endereco WHERE idDadosPessoais=@idDadosPessoais;";
                    var enderecos = connection.Query<Endereco>(sQL, new { idDadosPessoais });
                    var Lista = new List<Endereco>();
                    foreach (var item in enderecos)
                    {
                        retorno = item as Endereco;
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

        public bool InserirTipo(Tipo obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "Insert into tb_tipo (Descricao) VALUES (@Descricao);";
                    var produto = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool AtualizarTipo(Tipo obj)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "UPDATE tb_tipo SET Descricao=@Descricao WHERE idTipo=@idTipo;";
                    var produto = connection.Execute(sQL, obj);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public bool ExcluirTipo(int idTipo)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "DELETE FROM tb_tipo WHERE idTipo=@idTipo;";
                    var produto = connection.Execute(sQL, idTipo);
                }
                return true;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return false;
            }
        }

        public DadosPessoais RetornaTipo(int idTipo)
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    var sQL = "SELECT * FROM tb_endereco WHERE idDadosPessoais=@idDadosPessoais;";
                    var pessoa = connection.QuerySingle<DadosPessoais>(sQL, new { idTipo });
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

        public List<Tipo> RetornaTipos()
        {
            try
            {
                using (var connection = new MySqlConnection(Conexao.MySql()))
                //using (var connection = new NpgsqlConnection(Conexao.ConexaPost()))
                {
                    Tipo retorno = null;
                    var sQL = "SELECT * FROM tb_tipo;";
                    var tipos = connection.Query<Tipo>(sQL);
                    var Lista = new List<Tipo>();
                    foreach (var item in tipos)
                    {
                        retorno = item as Tipo;
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
