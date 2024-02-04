using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcessionariaController : ControllerBase
    {
        private readonly ConcessionariaService _concessionariaService;

        public ConcessionariaController(ConcessionariaService concessionariaService)
        {
            _concessionariaService = concessionariaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var concessionarias = await _concessionariaService.GetAllConcessionariasAsync();
                if (concessionarias == null) return NoContent();

                return Ok(concessionarias);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar concessionarias. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var concessionaria = await _concessionariaService.GetConcessionariaByIdAsync(id);
                if (concessionaria == null) return NoContent();

                return Ok(concessionaria);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar concessionaria. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Concessionaria model)
        {
            try
            {
                var concessionaria = await _concessionariaService.AddConcessionaria(model);
                if (concessionaria == null) return NoContent();

                return Ok(concessionaria);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar a concessionaria. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Concessionaria model)
        {
            try
            {
                var concessionaria = await _concessionariaService.UpdateConcessionaria(id, model);
                if (concessionaria == null) return NoContent();

                return Ok(concessionaria);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar a concessionaria. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var concessionaria = await _concessionariaService.GetConcessionariaByIdAsync(id);
                if (concessionaria == null) return NoContent();

                return (await _concessionariaService.DeleteConcessionaria(concessionaria.Id)) ?
                     Ok(new { message = "Concessionaria excluída com sucesso!" }) :
                     throw new Exception("Ocorreu um problema não específico ao tentar excluir a concessionaria.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir a concessionaria. Erro: {ex.Message}");
            }
        }
    }
}