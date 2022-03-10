using AgendaCec.Data;
using AgendaCec.Extensions;
using AgendaCec.Models;
using AgendaCec.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AgendaCec.Controllers
{
    public class TurmaController : ControllerBase
    {
        [HttpGet("v1/Turmas ")] //Rota

        public async Task<IActionResult> GetAsync(     //IActionResult, usamos quando existe um retorno
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var Turma = await context
                .Turmas
                .ToListAsync();
                return Ok(new ResultViewModel<List<Turma>>(Turma));

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Turma>>("05XE5 - Falha interna no servidor"));

            }
        }
        [HttpGet("v1/Turmas /{id:int}")] //Rota
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AgendaCecDataContext context
        )
        {
            try
            {
                var Turma = await context
                .Turmas
                .FirstOrDefaultAsync(x => x.Id == id);

                if (Turma == null)
                    return NotFound(new ResultViewModel<Turma>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Turma>(Turma));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Turma>("05XE6 - Falha interna no servidor"));
            }

        }
        [HttpPost("v1/Turmas    ")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorTurmaViewModel model,
            [FromServices] AgendaCecDataContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Turma>(ModelState.GetErrors()));
            }
            try
            {
                var Turma = new Turma
                {
                    Id = 0,
                    Nome = model.Nome,
                    DataInicio = model.DataInicio,
                    DataFim = model.DataFim,
                    NumeroAlunos = model.NumeroAlunos,

                };
                await context.Turmas.AddAsync(Turma); //Adicionando as informações
                await context.SaveChangesAsync(); //Salvando as informações 

                return Created($"v1/categories/{Turma.Id}", new ResultViewModel<Turma>(Turma));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Turma>("05XE9 - Não foi possível incluir o Turma"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Turma>("05XE10 - Falha interna no servidor"));
            }

        }
    }
}