using APIGerenciador_Tarefas.Models;

namespace APIGerenciador_Tarefas.Interface
{
    public interface Interface_Projeto
    {
        /// <summary>
        /// Interface do Cadastro de Projeto
        /// </summary>
        /// <param name="Titulo">Título do Projeto</param>
        /// <returns>True = Cadastrado com sucesso | False = Falha ao cadastrar</returns>
        public bool Cadastro_Projeto(string Titulo);

        /// <summary>
        /// Edita um Projeto existente.
        /// </summary>
        /// <param name="id">Id do projeto</param>
        /// <param name="titulo"> Titulo do Projeto</param>
        /// <returns>True = Editado com sucesso | False = Falha ao Editar</returns>
        public bool Editar_Projeto(int id, string titulo);

        /// <summary>
        /// Exclui Projeto com o ID informado.
        /// </summary>
        /// <param name="id">Id do Projeto</param>
        /// <returns>1 = Excluído com sucesso | 2 = Falha ao Excluir | 3 = Projeto com Tarefas pendentes.</returns>
        public int Excluir_Projeto(int id);
        /// <summary>
        /// Lista todos os Projetos Cadastrados
        /// </summary>
        /// <returns>Lista de Projetos Cadastrados</returns>
        public List<ProProjeto> Listar_Projetos();
    }
}
