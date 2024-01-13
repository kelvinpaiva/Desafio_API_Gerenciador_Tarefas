using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas.Models
{
    public partial class ProProjeto
    {
        public ProProjeto()
        {
            TarTarefas = new HashSet<TarTarefa>();
        }

        public string? ProTitulo { get; set; }
        public int Id { get; set; }

        public virtual ICollection<TarTarefa> TarTarefas { get; set; }
    }
}
