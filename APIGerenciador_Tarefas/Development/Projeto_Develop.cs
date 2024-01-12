using APIGerenciador_Tarefas.Interface;
using APIGerenciador_Tarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Net;
using System.Text;
using System.Xml;

namespace APIGerenciador_Tarefas.Development
{
    public class Projeto_Develop : Interface_Projeto
    {
        private readonly IConfiguration configuration;


        public Projeto_Develop(IConfiguration _configuration )
        {
            configuration = _configuration;
        }
        
        /// <summary>
        /// Função para Cadastro de um Novo Projeto
        /// </summary>
        /// <param name="Titulo">Título do Projeto</param>
        /// <returns>True = Cadastrado com sucesso | False = Falha ao cadastrar</returns>
        public bool Cadastro_Projeto(string Titulo)
        {
            try
            {
                using (var db = new wnbokcfxContext())
                {
                    db.ProProjetos.Add(new ProProjeto { ProTitulo = Titulo });
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
