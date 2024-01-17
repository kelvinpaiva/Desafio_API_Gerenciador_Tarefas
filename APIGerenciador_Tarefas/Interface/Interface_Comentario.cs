using APIGerenciador_Tarefas.Models;
using APIGerenciador_Tarefas.Models.DAO;

namespace APIGerenciador_Tarefas.Interface
{
    public interface Interface_Comentario
    {
        /// <summary>
        /// Valida e Cadastra o Comentário da tarefa.
        /// </summary>
        /// <param name="Comentario">Objeto do Comentário</param>
        /// <returns>1 - Cadastrado com Sucesso. 2- Falha no Cadastro. 3 - Comentário incompleto. 4 - Comentário em tarefa inexistente.</returns>
        public int Cadastra_Comentario_Tarefa(Comentario_DAO Comentario);
    }
}
