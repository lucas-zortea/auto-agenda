using AgendaCec.Data;
using AgendaCec.Extensions;
using AgendaCec.Models;
using AgendaCec.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaCec.Controllers
{
    public class DisciplinaController : ControllerBase
    {
        [HttpGet("v1/disciplinas")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var disciplinas = await context
                .Disciplinas
                .AsNoTracking()
                .ToListAsync();
                return Ok(new List<Disciplina>(disciplinas));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Disciplina>>("05XE5 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/disciplinas/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var disciplina = await context
                .Disciplinas
                .FirstOrDefaultAsync(x => x.Id == id);

                if(disciplina == null)
                    return NotFound(new ResultViewModel<Disciplina>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Disciplina>(disciplina));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Disciplina>("05XE6 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/disciplinas")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorDisciplinaViewModel model,
            [FromServices] AgendaCecDataContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Disciplina>(ModelState.GetErrors()));
            }
            try
            {
                var disciplina = new Disciplina
                {
                    Id = 0,
                    Nome = model.Nome,
                    Slug = model.Nome.ToLower().Replace(" ", "-"),
                    AreaId = model.AreaId
                };
                await context.Disciplinas.AddAsync(disciplina);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{disciplina.Id}", new ResultViewModel<Disciplina>(disciplina));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Disciplina>("05XE9 - Não foi possível incluir a disciplina"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Disciplina>("05XE10 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/disciplinas/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditorDisciplinaViewModel model,
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var disciplina = await context
                .Disciplinas
                .FirstOrDefaultAsync(x => x.Id == id);

                if (disciplina == null)
                    return NotFound(new ResultViewModel<Disciplina>("Conteúdo não encontrado"));

                disciplina.Nome = model.Nome;
                disciplina.Slug = model.Nome.ToLower().Replace(" ", "-");
                disciplina.AreaId = model.AreaId;

                context.Disciplinas.Update(disciplina);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Disciplina>(disciplina));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Disciplina>("05XE8 - Não foi possível alterar a disciplina"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Disciplina>("05XE11 - Falha interna no servidor"));
            }
        }
    }
}