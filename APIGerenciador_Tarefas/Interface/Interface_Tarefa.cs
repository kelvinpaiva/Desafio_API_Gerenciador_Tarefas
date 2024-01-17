using APIGerenciador_Tarefas.Models;
using APIGerenciador_Tarefas.Models.DAO;

namespace APIGerenciador_Tarefas.Interface
{
    public interface Interface_Tarefa
    {
        /// <summary>
        /// Função para Cadastro de uma Nova Tarefa
        /// </summary>
        /// <param name="tarefa">Objeto da Tarefa</param>
        /// <returns>1 = Cadastrado com sucesso | 2 = Falha na Validação | 3 = Falha ao cadastrar | 4 = Limite de tarefas por Processo atingido. </returns>
        public int Cadastro_Tarefa(TarTarefa_DAO tarefa);

        /// <summary>
        /// Edita um Tarefa existente.
        /// </summary>
        /// <param name="tarefa">Objeto da Tarefa</param>
        /// <returns>True = Editado com sucesso | 2 = Falha na Validação | False = Falha ao Editar</returns>
        public int Editar_Tarefa(TarTarefa_DAO tarefa);

        /// <summary>
        /// Exclui Tarefa com o ID informado.
        /// </summary>
        /// <param name="id">Id do Tarefa</param>
        /// <param name="id_usuario"></param>
        /// <returns>True = Excluído com sucesso | False = Falha ao Excluir</returns>
        public bool Excluir_Tarefa(int id, int id_usuario);

        /// <summary>
        /// Lista todos os Tarefas Cadastrados
        /// </summary>
        /// <returns>Lista de Tarefas Cadastrados</returns>
        public List<TarTarefa> Listar_Tarefas();
        /// <summary>
        /// Função que retorna a quantidade de tarefas realizadas nos últimos 30 dias.
        /// </summary>
        /// <returns>Retorna a quantidade de tarefas. Se der erro retorna -1;</returns>
        public Object Quantidade_Tarefas_Mensal(int tipo_usuario);
    }
}
