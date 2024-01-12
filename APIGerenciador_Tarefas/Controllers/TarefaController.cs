using Microsoft.AspNetCore.Mvc;
using APIGerenciador_Tarefas.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIGerenciador_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly Interface_Tarefa _Tarefa;

        public TarefaController(Interface_Tarefa Tarefa)
        {
            _Tarefa = Tarefa;
        }

        /// <summary>
        /// Lista Todas as Tarefas Cadastradas
        /// </summary>
        /// <returns>Lista de Tarefas</returns>
        /// <response code="200">Lista de Objetos.</response>
        /// <response code="500">Falha ao Listar as Tarefa.</response> 
        [HttpGet]
        public IActionResult Lista()
        {
            try
            {
                var lista = _Tarefa.Listar_Tarefas;
                return Ok(lista);
            }
            catch
            {
                return StatusCode(500, new { message = "Falha ao Listar as Tarefas" });
            }
        }

        /// <summary>
        /// Cadastro de Tarefa
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
        /// <param name="Titulo">Titulo da Tarefa</param>
        /// <returns>Se a Tarefa foi Cadastrado ou não.</returns>
        /// <response code="200">Cadastrado com sucesso.</response>
        /// <response code="500">Falha ao Cadastrar a Tarefa.</response>   
        [HttpPost]
        public IActionResult Post([FromBody] string Titulo)
        {
            try
            {
                _Tarefa.Cadastro_Tarefa(Titulo);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = "Falha ao Cadastrar a Tarefa" });
            }
        }

        /// <summary>
        /// Edita uma Tarefa Existente
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
        /// <param name="id">Id da Tarefa</param>
        /// <param name="Titulo">Titulo do Tarefa</param>
        /// <returns>Se o Tarefa foi Editado ou não.</returns>
        /// <response code="200">Editado com sucesso.</response>
        /// <response code="500">Falha ao Editar a Tarefa.</response>   
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string Titulo)
        {
            try
            {
                _Tarefa.Editar_Tarefa(id, Titulo);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = "Falha ao Editar o Projeto" });
            }
        }

        /// <summary>
        /// Exclui a Tarefa com o ID informado
        /// </summary>
        /// <param name="id">Id da Tarefa</param>
        /// <returns>Se a Tarefa foi excluída ou não.</returns>
        /// <response code="200">Excluido com sucesso.</response>
        /// <response code="500">Falha ao excluir a Tarefa.</response>   
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _Tarefa.Excluir_Projeto(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = "Falha ao Excluir o Projeto" });
            }
        }
    }
}
