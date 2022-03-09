using AgendaCec.Data;
using AgendaCec.Extensions;
using AgendaCec.Models;
using AgendaCec.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaCec.Controllers
{
    public class LocalController : ControllerBase
    {
        [HttpGet("v1/locais")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var locais = await context
                .Locais
                .AsNoTracking()
                .ToListAsync();
                return Ok(new List<Local>(locais));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Local>>("05XE5 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/locais/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var local = await context
                .Locais
                .FirstOrDefaultAsync(x => x.Id == id);

                if (local == null)
                    return NotFound(new ResultViewModel<Local>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Local>(local));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Local>("05XE6 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/locais")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorLocalViewModel model,
            [FromServices] AgendaCecDataContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Local>(ModelState.GetErrors()));
            }
            try
            {
                var local = new Local
                {
                    Id = 0,
                    Nome = model.Nome,
                    Slug = model.Nome.ToLower().Replace(" ", "-"),
                    Informatizada = model.Informatizada,
                    Capacidade = model.Capacidade
                };
                await context.Locais.AddAsync(local);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{local.Id}", new ResultViewModel<Local>(local));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Local>("05XE9 - Não foi possível incluir o local"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Local>("05XE10 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/locais/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditorLocalViewModel model,
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var local = await context
                .Locais
                .FirstOrDefaultAsync(x => x.Id == id);

                if (local == null)
                    return NotFound(new ResultViewModel<Local>("Conteúdo não encontrado"));

                local.Nome = model.Nome;
                local.Slug = model.Nome.ToLower().Replace(" ", "-");
                local.Informatizada = model.Informatizada;
                local.Capacidade = model.Capacidade;

                context.Locais.Update(local);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Local>(local));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Local>("05XE8 - Não foi possível alterar o local"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Local>("05XE11 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/locais/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var local = await context
                .Locais
                .FirstOrDefaultAsync(x => x.Id == id);

                if (local == null)
                    return NotFound(new ResultViewModel<Local>("Conteúdo não encontrado"));

                context.Locais.Remove(local);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Local>(local));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Local>("05XE7 - Não foi possível excuir a categoria"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Local>("05XE12 - Falha interna no servidor"));
            }
        }
    }
}