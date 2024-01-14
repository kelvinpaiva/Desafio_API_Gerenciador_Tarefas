using Microsoft.AspNetCore.Mvc;
using APIGerenciador_Tarefas.Interface;
using APIGerenciador_Tarefas.Models;

namespace APIGerenciador_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly Interface_Projeto _Projeto;

        public ProjetoController(Interface_Projeto projeto)
        {
            _Projeto = projeto;
        }

        /// <summary>
        /// Lista Todos os Projetos Cadastrados
        /// </summary>
        /// <returns>Lista de Projetos</returns>
        /// <response code="200">Lista de Objetos.</response>
        /// <response code="500">Falha ao Listar os Projetos.</response> 
        [HttpGet]
        public IActionResult Lista()
        {
            try
            {
                var lista = _Projeto.Listar_Projetos;
                return Ok(lista);
            }
            catch
            {
                return StatusCode(500, new { message = "Falha ao Cadastrar o Projeto" });
            }
        }

        /// <summary>
        /// Cadastro de Projeto
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Post
        ///     {
        ///        "Titulo do Projeto"
        ///     }
        ///
        /// </remarks>
        /// <param name="Projeto">Objeto do Projeto</param>
        /// <returns>Se o Projeto foi Cadastrado ou não.</returns>
        /// <response code="200">Cadastrado com sucesso.</response>
        /// <response code="500">Falha ao Cadastrar o Projeto.</response>   
        [HttpPost]
        public IActionResult Post([FromBody] ProProjeto Projeto)
        {
            try
            {
                _Projeto.Cadastro_Projeto(Projeto);
                return Ok();
            }
            catch 
            {
                return StatusCode(500, new { message = "Falha ao Cadastrar o Projeto" });
            }
        }

        /// <summary>
        /// Edita um Projeto Existente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Put
        ///     {
        ///        "Descrição do Projeto"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id do Registro</param>
        /// <param name="Projeto">Titulo do Projeto</param>
        /// <returns>Se o Projeto foi Editado ou não.</returns>
        /// <response code="200">Editado com sucesso.</response>
        /// <response code="500">Falha ao Editar o Projeto.</response>   
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProProjeto Projeto)
        {
            try
            {
                Projeto.Id = id;
                _Projeto.Editar_Projeto(Projeto);
                return Ok();
            }
            catch 
            {
                return StatusCode(500, new { message = "Falha ao Editar o Projeto" });
            }
        }

        /// <summary>
        /// Exclui o Projeto com o ID informado
        /// </summary>
        /// <param name="id">Id do Projeto</param>
        /// <param name="id_usuario">Id do Usuário</param>
        /// <returns>Se o Projeto foi excluído ou não.</returns>
        /// <response code="200">Excluido com sucesso.</response>
        /// <response code="300">Projeto tem Tarefas Pendentes.</response>
        /// <response code="500">Falha ao excluir o Projeto.</response>   
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, int id_usuario)
        {
            try
            {
                int retorno = _Projeto.Excluir_Projeto(id);
                if(retorno.Equals(3)) return StatusCode(300, new { message = "Não é possível excluir Projeto com Tarefas Pendentes!" });
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = "Falha ao Excluir o Projeto" });
            }
        }
    }
}
