using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas
{
    public partial class TarTarefa
    {
        public TarTarefa()
        {
            LatLancamentoTarefas = new HashSet<LatLancamentoTarefa>();
        }

        public long Id { get; set; }
        public string TarTitulo { get; set; } = null!;
        public string TarDescricao { get; set; } = null!;
        public int TarPrioridade { get; set; }
        public DateTime TarDataCadastro { get; set; }
        public DateTime TarDataVencimento { get; set; }
        public short TarStatus { get; set; }

        public virtual ICollection<LatLancamentoTarefa> LatLancamentoTarefas { get; set; }
    }
}
