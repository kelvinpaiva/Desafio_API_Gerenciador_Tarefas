using APIGerenciador_Tarefas.Models;
using APIGerenciador_Tarefas.Interface;
using APIGerenciador_Tarefas.Models.DAO;

namespace APIGerenciador_Tarefas.Development
{
    public class Lancamento_Comentario_Develop : Interface_Comentario
    {
        /// <summary>
        /// Valida e Cadastra o Comentário da tarefa.
        /// </summary>
        /// <param name="Comentario">Objeto do Comentário</param>
        /// <returns>1 - Cadastrado com Sucesso. 2- Falha no Cadastro. 3 - Comentário incompleto. 4 - Comentário em tarefa inexistente.</returns>
        public int Cadastra_Comentario_Tarefa(Comentario_DAO Comentario)
        {
            LctLancamentoComentarioTarefa lancamento = new LctLancamentoComentarioTarefa();
            lancamento.IdTar = Comentario.IdTar;
            lancamento.LctComentario = Comentario.LctComentario;
            lancamento.IdUsuario = Comentario.IdUsuario;
            var valido = Valida_Comentario(lancamento);
            if (valido.Equals(2)) return 3;//Comentário faltando informação.
            if (valido.Equals(3)) return 4;//Comentário em tarefa inexistente.

            Log_Aplicacao_Develop log = new Log_Aplicacao_Develop();
            try
            {
                using (var db = new wnbokcfxContext())
                {
                    db.LctLancamentoComentarioTarefas.Add(lancamento);
                    db.SaveChanges();
                }
                log.Grava_Log_Aplicacao(lancamento, 1);
                return 1;//Válido
            }
            catch
            {
                return 2;//Inválido
            }
        }

        /// <summary>
        /// Valida se o Comentário está com todos os campos preenchidos.
        /// </summary>
        /// <param name="Comentario">Comentário a ser cadastrado.</param>
        /// <returns>1 - Válido, 2 - Inválido, 3 - Tarefa Inexistente.</returns>
        private int Valida_Comentario(LctLancamentoComentarioTarefa Comentario)
        {
            try
            {
                using (var db = new wnbokcfxContext())
                {
                    List<TarTarefa> ExisteTarefa = db.TarTarefas.Where(d => d.Id.Equals(Comentario.IdTar)).ToList();
                    if (ExisteTarefa.Count().Equals(0)) return 3;
                }
                
                if (Comentario.IdTar > 0 && !Comentario.LctComentario.Equals("") && Comentario.IdUsuario > 0)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            catch
            {
                return 2;
            }            
        }
    }
}
