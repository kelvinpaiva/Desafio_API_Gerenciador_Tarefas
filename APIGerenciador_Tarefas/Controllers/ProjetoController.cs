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
        /// <param name="Titulo">Titulo do Projeto</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] string Titulo)
        {
            try
            {
                _Projeto.Cadastro_Projeto(Titulo);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }

        // PUT api/<ProjetoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjetoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
