using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas.Models
{
    public partial class LctLancamentoComentarioTarefa
    {
        public int Id { get; set; }
        public int? IdTar { get; set; }
        public string? LctComentario { get; set; }
    }
}
