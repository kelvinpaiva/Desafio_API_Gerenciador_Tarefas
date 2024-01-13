using APIGerenciador_Tarefas.Models;

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
        protected bool Grava_Log_Aplicacao(Object objeto, int Evento)
        {
            string log = "";
            try
            {
                if(objeto is ProProjeto)
                {
                    ProProjeto projeto = (ProProjeto)objeto;
                    if(Evento.Equals(1))
                    {
                        log+="Cadastro de Projeto: Usuário: "+ projeto.IdUsuario +" Título: "+ projeto.ProTitulo;
                    }
                    else if (Evento.Equals(2))
                    {
                        log += "Alteração do Projeto de Id: "+ projeto.Id +" Usuário: "+ projeto.IdUsuario +" Alterou o Título para:" + projeto.ProTitulo;
                    }
                    else
                    {
                        log += "Exclusão do Projeto Pelo Usuário: "+ projeto.IdUsuario +" de Id: " + projeto.Id + " e Título:" + projeto.ProTitulo;
                    }
                }
                else if (objeto is TarTarefa)
                {
                    TarTarefa tarefa = (TarTarefa)objeto;
                    if (Evento.Equals(1))
                    {
                        log += "Cadastro de Tarefa: Título: " + tarefa.TarTitulo;
                    }
                    else if (Evento.Equals(2))
                    {
                        log += "Alteração do Tarefa de Id: " + tarefa.Id + " Alterou o Título para:" + tarefa.TarTitulo;
                    }
                    else
                    {
                        log += "Exclusão do Tarefa de Id: " + tarefa.Id + " e Título:" + tarefa.TarTitulo;
                    }
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
