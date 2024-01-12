using APIGerenciador_Tarefas.Interface;
using APIGerenciador_Tarefas.Models;

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

        /// <summary>
        /// Edita um Projeto existente.
        /// </summary>
        /// <param name="id">Id do projeto</param>
        /// <param name="titulo"> Titulo do Projeto</param>
        /// <returns>True = Editado com sucesso | False = Falha ao Editar</returns>
        public bool Editar_Projeto(int id, string titulo)
        {
            try
            {
                using (var db = new wnbokcfxContext())
                {
                    var projeto = db.ProProjetos.
                        Single(b => b.Id == id);
                    projeto.ProTitulo = titulo;
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
        /// Exclui Projeto com o ID informado.
        /// </summary>
        /// <param name="id">Id do Projeto</param>
        /// <returns>True = Excluído com sucesso | False = Falha ao Excluir</returns>
        public bool Excluir_Projeto(int id)
        {
            try
            {
                using (var db = new wnbokcfxContext())
                {
                    var projeto = db.ProProjetos.Where(b => b.Id == id);
                    db.ProProjetos.Remove((ProProjeto)projeto);
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
    }
}
