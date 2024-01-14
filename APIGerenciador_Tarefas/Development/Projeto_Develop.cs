using APIGerenciador_Tarefas.Interface;
using APIGerenciador_Tarefas.Models;

namespace APIGerenciador_Tarefas.Development
{
    public class Projeto_Develop : Interface_Projeto
    {
        public Projeto_Develop()
        {
        }

        /// <summary>
        /// Função para Cadastro de um Novo Projeto
        /// </summary>
        /// <param name="projeto">Objeto do Projeto</param>
        /// <returns>True = Cadastrado com sucesso | False = Falha ao cadastrar</returns>
        public bool Cadastro_Projeto(ProProjeto projeto)
        {
            try
            {
                Log_Aplicacao_Develop log = new Log_Aplicacao_Develop();
                using (var db = new wnbokcfxContext())
                {
                    db.ProProjetos.Add(projeto);
                    db.SaveChanges();
                }
                log.Grava_Log_Aplicacao(projeto, 1);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Edita um Projeto existente.
        /// </summary>
        /// <param name="projeto">Objeto do projeto</param>
        /// <returns>True = Editado com sucesso | False = Falha ao Editar</returns>
        public bool Editar_Projeto(ProProjeto projeto)
        {
            try
            {
                Log_Aplicacao_Develop log = new Log_Aplicacao_Develop();
                using (var db = new wnbokcfxContext())
                {
                    var proj = db.ProProjetos.
                        Single(b => b.Id == projeto.Id);
                    proj = projeto;
                    db.SaveChanges();
                }
                log.Grava_Log_Aplicacao(projeto, 2);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Exclui Projeto com o ID informado.
        /// </summary>
        /// <param name="projeto">Objeto do Projeto</param>
        /// <returns>1 = Excluído com sucesso | 2 = Falha ao Excluir | 3 = Projeto com Tarefas pendentes.</returns>
        public int Excluir_Projeto(ProProjeto projeto)
        {
            try
            {
                Log_Aplicacao_Develop log = new Log_Aplicacao_Develop();
                if (!Valida_Exclusao_Projeto(projeto.Id)) return 3;
                using (var db = new wnbokcfxContext())
                {
                    ProProjeto pro = (ProProjeto)db.ProProjetos.Where(b => b.Id == projeto.Id);
                    db.ProProjetos.Remove(pro);
                    db.SaveChanges();
                }
                log.Grava_Log_Aplicacao(projeto, 3);
                return 1;
            }
            catch
            {
                return 2;
            }
        }

        /// <summary>
        /// Lista todos os Projetos Cadastrados
        /// </summary>
        /// <returns>Lista de Projetos Cadastrados</returns>
        public List<ProProjeto> Listar_Projetos()
        {
            using (var db = new wnbokcfxContext())
            {
                var projeto = db.ProProjetos.ToList();
                return projeto;
            }
        }
        /// <summary>
        /// Confere se o Projeto tem Tarefas Pendentes, caso sim, não permite a exclusão do projeto.
        /// </summary>
        /// <param name="id_projeto">Id do Projeto</param>
        /// <returns>True = Pode excluir, False = Não pode excluir.</returns>
        private bool Valida_Exclusao_Projeto(int id_projeto)
        {
            using (var db = new wnbokcfxContext())
            {
                List<TarTarefa> tarefas = db.TarTarefas.Where(d => d.IdPro.Equals(id_projeto)).ToList();
                if (tarefas.Count().Equals(20)) return false;
            }
            return true;
        }
    }
}
