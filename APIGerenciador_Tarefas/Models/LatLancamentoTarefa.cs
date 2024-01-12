using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas.Models
{
    public partial class LatLancamentoTarefa
    {
        public int Id { get; set; }
        public int? IdPro { get; set; }
        public int? IdTar { get; set; }

        public virtual ProProjeto? IdProNavigation { get; set; }
        public virtual TarTarefa? IdTarNavigation { get; set; }
    }
}
