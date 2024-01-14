using APIGerenciador_Tarefas.Models;

namespace APIGerenciador_Tarefas.Interface
{
    public interface Interface_Projeto
    {
        /// <summary>
        /// Função para Cadastro de um Novo Projeto
        /// </summary>
        /// <param name="projeto">Objeto do Projeto</param>
        /// <returns>True = Cadastrado com sucesso | False = Falha ao cadastrar</returns>
        public bool Cadastro_Projeto(ProProjeto projeto);

        /// <summary>
        /// Edita um Projeto existente.
        /// </summary>
        /// <param name="projeto">Objeto do projeto</param>
        /// <returns>True = Editado com sucesso | False = Falha ao Editar</returns>
        public bool Editar_Projeto(ProProjeto projeto);

        /// <summary>
        /// Exclui Projeto com o ID informado.
        /// </summary>
        /// <param name="projeto">Objeto do Projeto</param>
        /// <returns>1 = Excluído com sucesso | 2 = Falha ao Excluir | 3 = Projeto com Tarefas pendentes.</returns>
        public int Excluir_Projeto(ProProjeto projeto);
        /// <summary>
        /// Lista todos os Projetos Cadastrados
        /// </summary>
        /// <returns>Lista de Projetos Cadastrados</returns>
        public List<ProProjeto> Listar_Projetos();
    }
}
