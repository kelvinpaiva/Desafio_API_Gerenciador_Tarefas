namespace APIGerenciador_Tarefas.Models.DAO
{
    public class ProProjeto_DAO
    {
        /// <summary>
        /// Titulo do Projeto
        /// </summary>
        public string ProTitulo { get; set; } = null!;
        /// <summary>
        /// Id do Projeto
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id Usuário
        /// </summary>
        public int IdUsuario { get; set; }
    }
}
