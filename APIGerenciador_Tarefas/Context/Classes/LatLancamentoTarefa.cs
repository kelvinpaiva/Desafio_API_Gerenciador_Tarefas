using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas
{
    public partial class LatLancamentoTarefa
    {
        public long Id { get; set; }
        /// <summary>
        /// Id do Projeto
        /// </summary>
        public long IdPro { get; set; }
        /// <summary>
        /// Id da Tarefa
        /// </summary>
        public long IdTar { get; set; }

        public virtual ProProjeto IdProNavigation { get; set; } = null!;
        public virtual TarTarefa IdTarNavigation { get; set; } = null!;
    }
}
