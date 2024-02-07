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

        private readonly ILogger<ConcessionariaController> _logger;

        public ConcessionariaController(ConcessionariaService concessionariaService, ILogger<ConcessionariaController> logger)
        {
            _concessionariaService = concessionariaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var concessionarias = await _concessionariaService.GetAllConcessionariasAsync();

                return Ok(concessionarias);
            }
            catch (ConcessionariasNaoEncontradasException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound,
                   $"{Messages.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"{Messages.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Messages.concessionariaNula} Erro: {ex.Message}");
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
            catch (ConcessionariaNuloException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound,
                   $"{Messages.concessionariaNula} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"{Messages.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Messages.concessionariaNula} Erro: {ex.Message}");
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
            catch (ConcessionariaNuloException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound,
                   $"{Messages.concessionariaNula} Erro: {ex.Message}");
            }
            catch (ConcessionariaRepetidaException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"{Messages.erroDados} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"{Messages.erroDados} Erro: {ex.Message}");
            }
            catch (ConcessionariaNaoSalvaException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound,
                   $"{Messages.erroAoSalvarConcessionaria} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Messages.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Concessionaria model)
        {
            try
            {
                var concessionaria = await _concessionariaService.UpdateConcessionaria(id, model);

                return Ok(concessionaria);
            }
            catch (ConcessionariaNuloException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound,
                   $"{Messages.concessionariaNula} Erro: {ex.Message}");
            }
            catch (ConcessionariaNaoSalvaException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound,
                   $"{Messages.erroAoSalvarConcessionaria} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"{Messages.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Messages.concessionariaNula} Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var concessionaria = await _concessionariaService.GetConcessionariaByIdAsync(id);

                return (await _concessionariaService.DeleteConcessionaria(concessionaria.Id)) ?
                     Ok(new { message = Messages.concessionariaRemovidoSucesso }) :
                     throw new ConcessionariaNaoSalvaException(Messages.concessionariaRemovidoSucesso);
            }
            catch (ConcessionariaNuloException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound,
                   $"{Messages.concessionariaNula} Erro: {ex.Message}");
            }
            catch (ConcessionariaNaoSalvaException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound,
                   $"{Messages.erroAoSalvarConcessionaria} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"{Messages.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Messages.concessionariaNula} Erro: {ex.Message}");
            }
        }
    }
}