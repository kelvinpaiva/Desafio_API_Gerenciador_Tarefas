using APIGerenciador_Tarefas.Models;

namespace APIGerenciador_Tarefas.Interface
{
    public interface Interface_Tarefa
    {
        /// <summary>
        /// Função para Cadastro de uma Nova Tarefa
        /// </summary>
        /// <param name="Titulo">Título da Tarefa</param>
        /// <param name="descricao">Descrição da Tarefa</param>
        /// <param name="prioridade">Prioridade da Tarefa</param>
        /// <param name="Validade">Validade da Tarefa</param>
        /// <param name="status">Status da Tarefa</param>
        /// <returns>True = Cadastrado com sucesso | False = Falha ao cadastrar</returns>
        public bool Cadastro_Tarefa(string Titulo, string descricao, short prioridade, DateOnly Validade, short status);

        /// <summary>
        /// Edita um Tarefa existente.
        /// </summary>
        /// <param name="id">Id do Tarefa</param>
        /// <param name="Titulo">Título da Tarefa</param>
        /// <param name="descricao">Descrição da Tarefa</param>
        /// <param name="Validade">Validade da Tarefa</param>
        /// <param name="status">Status da Tarefa</param>
        /// <returns>True = Editado com sucesso | False = Falha ao Editar</returns>
        public bool Editar_Tarefa(int id, string Titulo, string descricao, DateOnly Validade, short status);

        /// <summary>
        /// Exclui Tarefa com o ID informado.
        /// </summary>
        /// <param name="id">Id do Tarefa</param>
        /// <returns>True = Excluído com sucesso | False = Falha ao Excluir</returns>
        public bool Excluir_Tarefa(int id);

        /// <summary>
        /// Lista todos os Tarefas Cadastrados
        /// </summary>
        /// <returns>Lista de Tarefas Cadastrados</returns>
        public List<TarTarefa> Listar_Tarefas();
    }
}
