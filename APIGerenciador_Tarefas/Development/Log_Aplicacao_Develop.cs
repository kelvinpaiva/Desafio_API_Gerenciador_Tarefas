using APIGerenciador_Tarefas.Models;
using APIGerenciador_Tarefas.Models.DAO;

namespace APIGerenciador_Tarefas.Development
{
    public class Log_Aplicacao_Develop
    {
        /// <summary>
        /// Fuñção de gravar o Log da aplicação no Banco de Dados.
        /// </summary>
        /// <param name="objeto"> Objeto do Projeto.</param>
        /// <param name="Evento">1 - Cadastro, 2 - Alteração, 3 - Exclusão. </param>
        /// <returns>True = Gravado com sucesso, False = Falha na gravação. </returns>
        public bool Grava_Log_Aplicacao(Object objeto, int Evento)
        {
            LoaLogAplicacao Log_Aplicacao = new LoaLogAplicacao();
            try
            {
                if(objeto is ProProjeto_DAO)
                {
                    ProProjeto_DAO projeto = (ProProjeto_DAO)objeto;
                    Log_Aplicacao.IdUsuario = projeto.IdUsuario;
                    Log_Aplicacao.IdRegistro = projeto.Id;
                    Log_Aplicacao.LoaTipoLog = 1;
                    if(Evento.Equals(1))
                    {
                        Log_Aplicacao.LoaDescricaoLog = "Cadastro de Projeto: Usuário: " + projeto.IdUsuario +" Título: "+ projeto.ProTitulo;
                    }
                    else if (Evento.Equals(2))
                    {
                        Log_Aplicacao.LoaDescricaoLog = "Alteração do Projeto de Id: " + projeto.Id +" Usuário: "+ projeto.IdUsuario +" Alterou o Título para:" + projeto.ProTitulo;
                    }
                    else
                    {
                        Log_Aplicacao.LoaDescricaoLog = "Exclusão do Projeto Pelo Usuário: " + projeto.IdUsuario +" de Id: " + projeto.Id + " e Título:" + projeto.ProTitulo;
                    }
                }
                else if (objeto is TarTarefa)
                {
                    TarTarefa tarefa = (TarTarefa)objeto;
                    Log_Aplicacao.IdUsuario = tarefa.IdUsuario;
                    Log_Aplicacao.IdRegistro = tarefa.Id;
                    Log_Aplicacao.LoaTipoLog = 2;
                    if (Evento.Equals(1))
                    {
                        Log_Aplicacao.LoaDescricaoLog = "Cadastro de Tarefa: Título: " + tarefa.TarTitulo;
                    }
                    else if (Evento.Equals(2))
                    {
                        Log_Aplicacao.LoaDescricaoLog = "Alteração do Tarefa de Id: " + tarefa.Id + " Alterou o Título para:" + tarefa.TarTitulo;
                    }
                    else
                    {
                        Log_Aplicacao.LoaDescricaoLog = "Exclusão do Tarefa de Id: " + tarefa.Id + " e Título:" + tarefa.TarTitulo;
                    }
                }
                else if (objeto is LctLancamentoComentarioTarefa)
                {
                    LctLancamentoComentarioTarefa comentario = (LctLancamentoComentarioTarefa)objeto;

                    Log_Aplicacao.IdUsuario = comentario.IdUsuario;
                    Log_Aplicacao.IdRegistro = comentario.Id;
                    Log_Aplicacao.LoaTipoLog = 1;
                    if (Evento.Equals(1))
                    {
                        Log_Aplicacao.LoaDescricaoLog = "Cadastro de Comentário: Usuário: " + comentario.IdUsuario +" Título: " + comentario.LctComentario +" Id da Tarefa: "+ comentario.IdTar+".";
                    }
                    else if (Evento.Equals(2))
                    {
                        Log_Aplicacao.LoaDescricaoLog = "Alteração do Comentário de Id: " + comentario.Id + " Usuário: " + comentario.IdUsuario + " Título: " + comentario.LctComentario + " Id da Tarefa: " + comentario.IdTar + ".";
                    }
                    else
                    {
                        Log_Aplicacao.LoaDescricaoLog = "Exclusão do Comentário de Id: " + comentario.Id + " Usuário: " + comentario.IdUsuario + " Título: " + comentario.LctComentario + " Id da Tarefa: " + comentario.IdTar + ".";
                    }
                }
                using (var db = new wnbokcfxContext())
                {
                    db.LoaLogAplicacaos.Add(Log_Aplicacao);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }            
        }
    }
}
