using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas.Models
{
    public partial class ProProjeto
    {
        public ProProjeto()
        {
            LatLancamentoTarefas = new HashSet<LatLancamentoTarefa>();
        }

        public string? ProTitulo { get; set; }
        public int Id { get; set; }

        public virtual ICollection<LatLancamentoTarefa> LatLancamentoTarefas { get; set; }
    }
}
