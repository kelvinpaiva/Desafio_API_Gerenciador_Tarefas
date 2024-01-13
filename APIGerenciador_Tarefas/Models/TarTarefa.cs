using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas.Models
{
    public partial class TarTarefa
    {
        public TarTarefa()
        {
            LatLancamentoTarefas = new HashSet<ProProjeto>();
        }

        public int Id { get; set; }
        public string TarTitulo { get; set; }
        public string TarDescricao { get; set; }
        public short TarPrioridade { get; set; }
        public DateOnly TarDataValidade { get; set; }
        public short TarStatus { get; set; }
        public int Id_Projeto { get; set; }

        public virtual ICollection<ProProjeto> LatLancamentoTarefas { get; set; }
    }
}
