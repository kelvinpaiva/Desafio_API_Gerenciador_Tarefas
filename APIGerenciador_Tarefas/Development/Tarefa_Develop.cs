using APIGerenciador_Tarefas.Models;
using APIGerenciador_Tarefas.Interface;
using APIGerenciador_Tarefas.Models.DAO;

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
        /// <param name="tarefa">Objeto da Tarefa</param>
        /// <returns>1 = Cadastrado com sucesso | 2 = Falha na Validação | 3 = Falha ao cadastrar | 4 = Limite de tarefas por Processo atingido. </returns>
        public int Cadastro_Tarefa(TarTarefa tarefa)
        {
            try
            {
                if (!Valida_Tarefa(tarefa))  return 2;
                if (!Pode_Adicionar_Tarefas((int)tarefa.IdPro!)) return 4;
                Log_Aplicacao_Develop log = new Log_Aplicacao_Develop();
                using (var db = new wnbokcfxContext())
                {
                   db.TarTarefas.Add(tarefa);
                   db.SaveChanges();
                }
                log.Grava_Log_Aplicacao(tarefa, 1);
                return 1;
            }
            catch
            {
                return 3;
            }
        }

        /// <summary>
        /// Edita um Tarefa existente.
        /// </summary>
        /// <param name="tarefa">Objeto da Tarefa</param>
        /// <returns>True = Editado com sucesso | 2 = Falha na Validação | False = Falha ao Editar</returns>
        public int Editar_Tarefa(TarTarefa tarefa)
        {
            try
            {
                if (!Valida_Tarefa(tarefa)) return 2;
                Log_Aplicacao_Develop log = new Log_Aplicacao_Develop();
                using (var db = new wnbokcfxContext())
                {
                    var Tar = db.TarTarefas.
                        Single(b => b.Id == tarefa.Id);
                    Tar.TarTitulo = tarefa.TarTitulo;
                    Tar.TarDescricao = tarefa.TarDescricao;
                    Tar.TarDataValidade = tarefa.TarDataValidade;
                    Tar.TarStatus = tarefa.TarStatus;
                    db.SaveChanges();
                }
                log.Grava_Log_Aplicacao(tarefa, 2);
                return 1;
            }
            catch
            {
                return 3;
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
                Log_Aplicacao_Develop log = new Log_Aplicacao_Develop();
                using (var db = new wnbokcfxContext())
                {
                    var Tarefa = db.TarTarefas.Where(b => b.Id == id);
                    db.TarTarefas.Remove((TarTarefa)Tarefa);
                    db.SaveChanges();
                    log.Grava_Log_Aplicacao(Tarefa, 3);
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
        /// <summary>
        /// Valida se o Objeto da tarefa tem todos os campos preenchidos.
        /// </summary>
        /// <param name="tarefa">Objeto da Tarefa</param>
        /// <returns>True = Objeto válido, False = Objeto Inválido</returns>
        private bool Valida_Tarefa(TarTarefa tarefa)
        {
            if (tarefa.TarTitulo!.Equals("") || tarefa.TarStatus!.Equals("") || tarefa.TarDataValidade!.Equals("") || tarefa.TarPrioridade!.Equals("") || tarefa.TarDescricao.Equals(""))
            {
                return false;
            }
            else
            { 
                return true; 
            }
        }
        /// <summary>
        /// Retorna se o projeto pode adicionar mais tarefas.
        /// </summary>
        /// <param name="id_projeto">Id do projeto</param>
        /// <returns>True = Pode adicionar, False = Não pode adicionar</returns>
        private bool Pode_Adicionar_Tarefas(int id_projeto)
        {
            using (var db = new wnbokcfxContext())
            {
                var projeto = db.ProProjetos.ToList();
                if (projeto.Count().Equals(20))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// Função que retorna a quantidade de tarefas realizadas nos últimos 30 dias.
        /// </summary>
        /// <returns>Retorna a quantidade de tarefas. Se der erro retorna -1;</returns>
        public Object Quantidade_Tarefas_Mensal()
        {
            try
            {
                using (var db = new wnbokcfxContext())
                {
                    var teste = db.TarTarefas.Where(t => t.TarDataValidade >= DateOnly.FromDateTime(DateTime.Now.AddDays(-30))).OrderBy(t => t.IdProNavigation.ProTitulo).OrderBy(t => t.TarDataValidade).Count();
                    List<Relacao_Usuario_Tarefas_Realizadas_DAO> relacao_Usuario_Tarefas = new List<Relacao_Usuario_Tarefas_Realizadas_DAO>();
                    return relacao_Usuario_Tarefas;
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
