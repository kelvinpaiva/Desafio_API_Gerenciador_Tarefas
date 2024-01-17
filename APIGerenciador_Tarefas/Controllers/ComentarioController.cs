using APIGerenciador_Tarefas.Models;
using Microsoft.AspNetCore.Http;
using APIGerenciador_Tarefas.Interface;
using Microsoft.AspNetCore.Mvc;
using APIGerenciador_Tarefas.Models.DAO;

namespace APIGerenciador_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly Interface_Comentario _Comentario;
            
        public ComentarioController(Interface_Comentario Comentario)
        {
            _Comentario = Comentario;
        }

        /// <summary>
        /// Valida e Cadastra um Comentário em uma tarefa.
        /// </summary>
        /// <param name="Comentario">Objeto do Comentário</param>
        /// <returns>Cadastrado ou não.</returns>
        /// <response code="200">Cadastrado com sucesso.</response>
        /// <response code="300">Comentário com um ou mais campos inválidos.</response> 
        /// <response code="400">Tarefa informada não cadastrada no banco de dados.</response>
        /// <response code="500">Falha ao Cadastrar o Projeto.</response> 
        [HttpPost]
        public IActionResult Post([FromBody] Comentario_DAO Comentario)
        {
            try
            {
                int retorno = _Comentario.Cadastra_Comentario_Tarefa(Comentario);
                if (retorno.Equals(3)) return StatusCode(300, new { message = "Comentário com um ou mais campos Inválidos." });
                if (retorno.Equals(4)) return StatusCode(400, new { message = "Tarefa informada não cadastrada no banco de dados." });
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = "Falha ao Cadastrar o Projeto" });
            }
        }
    }
}
