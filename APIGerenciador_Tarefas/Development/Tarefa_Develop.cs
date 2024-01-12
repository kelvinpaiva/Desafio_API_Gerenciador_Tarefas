﻿using APIGerenciador_Tarefas.Models;
using APIGerenciador_Tarefas.Interface;

namespace APIGerenciador_Tarefas.Development
{
    public class Tarefa_Develop : Interface_Tarefa
    {
        private readonly IConfiguration configuration;


        public Tarefa_Develop(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        /// <summary>
        /// Função para Cadastro de uma Nova Tarefa
        /// </summary>
        /// <param name="Titulo">Título da Tarefa</param>
        /// <param name="descricao">Descrição da Tarefa</param>
        /// <param name="prioridade">Prioridade da Tarefa</param>
        /// <param name="Validade">Validade da Tarefa</param>
        /// <param name="status">Status da Tarefa</param>
        /// <returns>True = Cadastrado com sucesso | False = Falha ao cadastrar</returns>
        public bool Cadastro_Tarefa(string Titulo, string descricao, short prioridade, DateOnly Validade, short status)
        {
            try
            {
                using (var db = new wnbokcfxContext())
                {
                    db.TarTarefas.Add(new TarTarefa { TarTitulo = Titulo ,TarDescricao = descricao, TarPrioridade = prioridade, TarDataValidade = Validade, TarStatus = status});
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Edita um Tarefa existente.
        /// </summary>
        /// <param name="id">Id do Tarefa</param>
        /// <param name="Titulo">Título da Tarefa</param>
        /// <param name="descricao">Descrição da Tarefa</param>
        /// <param name="Validade">Validade da Tarefa</param>
        /// <param name="status">Status da Tarefa</param>
        /// <returns>True = Editado com sucesso | False = Falha ao Editar</returns>
        public bool Editar_Tarefa(int id, string Titulo, string descricao, DateOnly Validade, short status)
        {
            try
            {
                using (var db = new wnbokcfxContext())
                {
                    var Tarefa = db.TarTarefas.
                        Single(b => b.Id == id);
                    Tarefa.TarTitulo = Titulo;
                    Tarefa.TarDescricao = descricao;
                    Tarefa.TarDataValidade = Validade;
                    Tarefa.TarStatus = status;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Exclui Tarefa com o ID informado.
        /// </summary>
        /// <param name="id">Id do Tarefa</param>
        /// <returns>True = Excluído com sucesso | False = Falha ao Excluir</returns>
        public bool Excluir_Tarefa(int id)
        {
            try
            {
                using (var db = new wnbokcfxContext())
                {
                    var Tarefa = db.TarTarefas.Where(b => b.Id == id);
                    db.TarTarefas.Remove((TarTarefa)Tarefa);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lista todos os Tarefas Cadastrados
        /// </summary>
        /// <returns>Lista de Tarefas Cadastrados</returns>
        public List<TarTarefa> Listar_Tarefas()
        {
            using (var db = new wnbokcfxContext())
            {
                var Tarefa = db.TarTarefas.ToList();
                return Tarefa;
            }
        }
    }
}