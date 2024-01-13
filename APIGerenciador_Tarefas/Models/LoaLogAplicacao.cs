using System;
using System.Collections.Generic;

namespace APIGerenciador_Tarefas.Models
{
    public partial class LoaLogAplicacao
    {
        public int IdRegistro { get; set; }
        public string LoaDescricaoLog { get; set; } = null!;
        public int Id { get; set; }
        /// <summary>
        /// 1 - Projeto, 2 - Tarefa, 3 - Comentario
        /// </summary>
        public short LoaTipoLog { get; set; }
    }
}
