using Microsoft.AspNetCore.Mvc;
using APIGerenciador_Tarefas.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET api/<ProjetoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
        /// <param name="Titulo">Titulo do Projeto</param>
        /// <returns>Se o Projeto foi Cadastrado ou não.</returns>
        /// <response code="200">Cadastrado com sucesso.</response>
        /// <response code="500">Falha ao Cadastrar o Projeto.</response>   
        [HttpPost]
        public IActionResult Post([FromBody] string Titulo)
        {
            try
            {
                _Projeto.Cadastro_Projeto(Titulo);
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
        /// <param name="id">Id do Projeto</param>
        /// <param name="Titulo">Titulo do Projeto</param>
        /// <returns>Se o Projeto foi Editado ou não.</returns>
        /// <response code="200">Editado com sucesso.</response>
        /// <response code="500">Falha ao Editar o Projeto.</response>   
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string Titulo)
        {
            try
            {
                _Projeto.Editar_Projeto(id,Titulo);
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
        /// <returns>Se o Projeto foi excluído ou não.</returns>
        /// <response code="200">Excluido com sucesso.</response>
        /// <response code="300">Projeto tem Tarefas Pendentes.</response>
        /// <response code="500">Falha ao excluir o Projeto.</response>   
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _Projeto.Excluir_Projeto(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = "Falha ao Excluir o Projeto" });
            }
        }
    }
}
