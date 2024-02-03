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
    public class MontadoraController : ControllerBase
    {
        private readonly MontadoraService _montadoraService;

        public MontadoraController(MontadoraService montadoraService)
        {
            _montadoraService = montadoraService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var montadoras = await _montadoraService.GetAllMontadorasAsync();
                if (montadoras == null) return NoContent();

                return Ok(montadoras);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar montadoras. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var montadora = await _montadoraService.GetMontadoraByIdAsync(id);
                if (montadora == null) return NoContent();

                return Ok(montadora);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar montadora. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Montadora model)
        {
            try
            {
                var montadora = await _montadoraService.AddMontadora(model);
                if (montadora == null) return NoContent();

                return Ok(montadora);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar a montadora. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Montadora model)
        {
            try
            {
                var montadora = await _montadoraService.UpdateMontadora(id, model);
                if (montadora == null) return NoContent();

                return Ok(montadora);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar a montadora. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var montadora = await _montadoraService.GetMontadoraByIdAsync(id);
                if (montadora == null) return NoContent();

                return (await _montadoraService.DeleteMontadora(montadora.Id)) ?
                     Ok(new { message = "Montadora excluída com sucesso!" }) :
                     throw new Exception("Ocorreu um problema não específico ao tentar excluir a montadora.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir a montadora. Erro: {ex.Message}");
            }
        }
    }
}