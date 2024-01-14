namespace APIGerenciador_Tarefas.Models.DAO
{
    public class Comentario_DAO
    {
        public int Id { get; set; }
        public int IdTar { get; set; }
        public string LctComentario { get; set; } = null!;
        public int IdUsuario { get; set; }
    }
}
