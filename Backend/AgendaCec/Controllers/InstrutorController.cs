using AgendaCec.Data;
using AgendaCec.Extensions;
using AgendaCec.Models;
using AgendaCec.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaCec.Controllers
{
    public class InstrutorController : ControllerBase
    {
        [HttpGet("v1/instrutores")] //Rota

        public async Task<IActionResult> GetAsync(     //IActionResult, usamos quando existe um retorno
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var instrutores = await context
                .Instrutores
                .ToListAsync();
                return Ok(new ResultViewModel<List<Instrutor>>(instrutores));

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Instrutor>>("05XE5 - Falha interna no servidor"));

            }
        }
        [HttpGet("v1/instrutores/{id:int}")] //Rota
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var instrutor = await context
                .Instrutores
                .FirstOrDefaultAsync(x => x.Id == id);

                if (instrutor == null)
                    return NotFound(new ResultViewModel<Instrutor>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Instrutor>(instrutor));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Instrutor>("05XE6 - Falha interna no servidor"));
            }

        }
        [HttpPost("v1/instrutores")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorInstrutorViewModel model,
            [FromServices] AgendaCecDataContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Instrutor>(ModelState.GetErrors()));
            }
            try
            {
                var instrutor = new Instrutor
                {
                    Id = 0,
                    Nome = model.Nome,
                    Email = model.Email,
                    Slug = model.Email.ToLower().Replace("@", "-").Replace(".", "-"),
                    Apelido = model.Apelido,
                    Disponivel = model.Disponivel,
                    PilarId = model.PilarId
                };
                await context.Instrutores.AddAsync(instrutor); //Adicionando as informações
                await context.SaveChangesAsync(); //Salvando as informações 

                return Created($"v1/categories/{instrutor.Id}", new ResultViewModel<Instrutor>(instrutor));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Instrutor>("05XE9 - Não foi possível incluir o instrutor"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Instrutor>("05XE10 - Falha interna no servidor"));
            }

        }
    }
}