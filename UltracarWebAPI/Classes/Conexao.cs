using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltracarWebAPI.Classes
{
    public class Conexao
    {
        public static string MySql()
        {
            return @"Server=ultracar.mysql.uhserver.com;Database=ultracar;Uid=ultracar2022;Pwd=!Desafio2022++;";
        }

        public static string Postgres()
        {
            return @"Server=127.0.0.1;Port=5432;Database=bancoteste;Uid=postgres;Pwd=1234;";
        }
    }
}
