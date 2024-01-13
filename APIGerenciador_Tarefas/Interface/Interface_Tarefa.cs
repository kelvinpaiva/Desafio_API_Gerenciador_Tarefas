using APIGerenciador_Tarefas.Models;

namespace APIGerenciador_Tarefas.Interface
{
    public interface Interface_Tarefa
    {
        /// <summary>
        /// Função para Cadastro de uma Nova Tarefa
        /// </summary>
        /// <param name="tarefa">Objeto da Tarefa</param>
        /// <returns>1 = Cadastrado com sucesso | 2 = Falha na Validação | 3 = Falha ao cadastrar | 4 = Limite de tarefas por Processo atingido. </returns>
        public int Cadastro_Tarefa(TarTarefa tarefa);

        /// <summary>
        /// Edita um Tarefa existente.
        /// </summary>
        /// <param name="tarefa">Objeto da Tarefa</param>
        /// <returns>True = Editado com sucesso | 2 = Falha na Validação | False = Falha ao Editar</returns>
        public int Editar_Tarefa(TarTarefa tarefa);

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
