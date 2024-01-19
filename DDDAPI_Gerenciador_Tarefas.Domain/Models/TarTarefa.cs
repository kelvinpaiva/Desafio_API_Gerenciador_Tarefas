using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas.Models
{
    public partial class TarTarefa
    {
        public int Id { get; set; }
        public string TarTitulo { get; set; } = null!;
        public string TarDescricao { get; set; } = null!;
        public short TarPrioridade { get; set; }
        public DateOnly TarDataValidade { get; set; }
        public short TarStatus { get; set; }
        public int IdPro { get; set; }
        public int IdUsuario { get; set; }

        public virtual ProProjeto IdProNavigation { get; set; } = null!;
    }
}
