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
                    $"{Mensagens.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.concessionariaNula} Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var concessionaria = await _concessionariaService.GetConcessionariaByIdAsync(id);

                return Ok(concessionaria);
            }
            catch (ConcessionariaNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.concessionariaNula} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.concessionariaNula} Erro: {ex.Message}");
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
                    $"{Mensagens.concessionariaNula} Erro: {ex.Message}");
            }
            catch (ConcessionariaRepetidaException ex)
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroDados} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroDados} Erro: {ex.Message}");
            }
            catch (ConcessionariaNaoSalvaException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroAoSalvarConcessionaria} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
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
                    $"{Mensagens.concessionariaNula} Erro: {ex.Message}");
            }
            catch (ConcessionariaNaoSalvaException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroAoSalvarConcessionaria} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.concessionariaNula} Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var concessionaria = await _concessionariaService.GetConcessionariaByIdAsync(id);

                return (await _concessionariaService.DeleteConcessionaria(concessionaria.Id)) ?
                     Ok(new { message = Mensagens.concessionariaRemovidoSucesso }) :
                     throw new ConcessionariaNaoPodeSerDeletadaException(Mensagens.concessionariaRemovidoSucesso);
            }
            catch (ConcessionariaNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.concessionariaNula} Erro: {ex.Message}");
            }
            catch (ConcessionariaNaoPodeSerDeletadaException ex)
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.concessionariaNula} Erro: {ex.Message}");
            }
            catch (ConcessionariaNaoSalvaException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeConcessionarias} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }
    }
}