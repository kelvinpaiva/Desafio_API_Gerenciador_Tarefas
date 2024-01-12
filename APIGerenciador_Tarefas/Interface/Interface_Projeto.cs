namespace APIGerenciador_Tarefas.Interface
{
    public interface Interface_Projeto
    {
        /// <summary>
        /// Interface do Cadastro de Projeto
        /// </summary>
        /// <param name="Titulo">Título do Projeto</param>
        /// <returns>True = Cadastrado com sucesso | False = Falha ao cadastrar</returns>
        public bool Cadastro_Projeto(string Titulo);
    }
}
