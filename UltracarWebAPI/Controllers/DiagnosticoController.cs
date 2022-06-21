using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltracarWebAPI.Models;

namespace UltracarWebAPI.Data
{
    [Route("api/[controller]")]
    public class DiagnosticoController : Controller
    {
        [HttpPost]
        [Route("registrardiagnostico")]
        public string InserirDiagnostico([FromBody] Diagnostico dados)
        {
            DiagnosticoDB diagnostico = new();
            if (diagnostico.InserirDiagnostico(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpPut]
        [Route("atualizardiagnostico")]
        public string AtualizarDiagnostico([FromBody] Diagnostico dados)
        {
            DiagnosticoDB diagnostico = new();
            if (diagnostico.AtualizarDiagnostico(dados))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpDelete]
        [Route("excluirdiagnostico/{id}")]
        public string ExcluirDiagnostico(int id)
        {
            DiagnosticoDB diagnostico = new();
            if (diagnostico.ExcluirDiagnostico(id))
            {
                return "Registrado com sucesso";
            }
            else
            {
                return "Falhou";
            }
        }

        [HttpGet]
        [Route("retornadiagnostico/{id}")]
        public Diagnostico RetornaDiagnostico(int id)
        {
            DiagnosticoDB diagnostico = new();
            return diagnostico.RetornaDiagnostico(id);
        }

        [HttpGet]
        [Route("retornalistadiagnostico")]
        public List<Diagnostico> RetornaListaDiagnosticos()
        {
            DiagnosticoDB diagnosticos = new();
            return diagnosticos.RetornaListaDiagnostico();
        }
    }
}
