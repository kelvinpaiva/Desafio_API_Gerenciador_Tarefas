using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas
{
    public partial class ProProjeto
    {
        public ProProjeto()
        {
            LatLancamentoTarefas = new HashSet<LatLancamentoTarefa>();
        }

        public long Id { get; set; }
        public string? ProTitulo { get; set; }

        public virtual ICollection<LatLancamentoTarefa> LatLancamentoTarefas { get; set; }
    }
}
