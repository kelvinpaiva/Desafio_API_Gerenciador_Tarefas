namespace APIGerenciador_Tarefas.Models.DAO
{
    public class Relacao_Usuario_Tarefas_Realizadas_DAO
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public int id_usuario { get; set; }
        /// <summary>
        /// Quantidade de tarefas Realizadas.
        /// </summary>
        public int quantidade_tarefas { get; set; }
    }
}
