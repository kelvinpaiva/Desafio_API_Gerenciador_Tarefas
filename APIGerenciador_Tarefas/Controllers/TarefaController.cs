using Microsoft.AspNetCore.Mvc;
using APIGerenciador_Tarefas.Interface;
using APIGerenciador_Tarefas.Models;

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
        /// <param name="tarefa">Objeto JSON da Tarefa</param>
        /// <returns>Se a Tarefa foi Cadastrado ou não.</returns>
        /// <response code="200">Cadastrado com sucesso.</response>
        /// <response code="300">Dados inválidos, revise as informações.</response>
        /// <response code="400">Projeto com limite de tarefas.</response>
        /// <response code="500">Falha ao Cadastrar a Tarefa.</response>   
        [HttpPost]
        public IActionResult Post([FromBody] TarTarefa tarefa)
        {
            try
            {
                int retorno = _Tarefa.Cadastro_Tarefa(tarefa);
                if (retorno.Equals(2)) return StatusCode(300, new { message = "Dados inválidos, revise as informações." });
                if (retorno.Equals(4)) return StatusCode(400, new { message = "Limite de Tarefas por projeto atingido." });
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
        /// <param name="tarefa">Objeto JSON da Tarefa</param>
        /// <returns>Se o Tarefa foi Editado ou não.</returns>
        /// <response code="200">Editado com sucesso.</response>
        /// <response code="300">Dados inválidos, revise as informações.</response>
        /// <response code="500">Falha ao Editar a Tarefa.</response>   
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TarTarefa tarefa)
        {
            try
            {
                int retorno = _Tarefa.Editar_Tarefa(tarefa);
                if (retorno.Equals(2)) return StatusCode(300, new { message = "Dados inválidos, revise as informações." });
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
                _Tarefa.Excluir_Tarefa(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = "Falha ao Excluir o Projeto" });
            }
        }

        /// <summary>
        /// Quantidade de tarefas realizadas nos últimos 30 dias
        /// Tipo Usuário: 0 - Comum, 1 - Gerente;
        /// </summary>
        /// <returns>Retorna a quantidade de tarefas realizadas nos últimos 30 dias.</returns>
        [HttpGet("{tipo_usuario}")]
        public IActionResult Quantidade_Tarefas_Realizadas(int tipo_usuario)
        {

            return Ok();
        }
    }
}
