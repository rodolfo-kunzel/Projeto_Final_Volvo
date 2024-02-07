using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaminhaoController : ControllerBase
    {
        private readonly CaminhaoService _caminhaoService;
        private readonly ILogger<CaminhaoController> _logger;

        public CaminhaoController(CaminhaoService caminhaoService, ILogger<CaminhaoController> logger)
        {
            _caminhaoService = caminhaoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var caminhoes = await _caminhaoService.GetAllCaminhoesAsync();

                return Ok(caminhoes);
            }
            catch (CaminhoesNaoEncontradosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Messages.erroNaBuscaDeCaminhoes} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Messages.erroNaBuscaDeCaminhoes} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Messages.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var caminhao = await _caminhaoService.GetCaminhaoByIdAsync(id);
                if (caminhao == null) return NoContent();

                return Ok(caminhao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar caminhoes. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Caminhao model)
        {
            try
            {
                var caminhao = await _caminhaoService.AddCaminhao(model);
                if (caminhao == null) return NoContent();

                return Ok(caminhao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar a caminhao. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Caminhao model)
        {
            try
            {
                var caminhao = await _caminhaoService.UpdateCaminhao(id, model);
                if (caminhao == null) return NoContent();

                return Ok(caminhao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o caminhao. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var caminhao = await _caminhaoService.GetCaminhaoByIdAsync(id);
                if (caminhao == null) return NoContent();

                return await _caminhaoService.DeleteCaminhao(caminhao.Id) ?
                     Ok(new { message = "Caminhao excluído com sucesso!" }) :
                     throw new Exception("Ocorreu um problema não específico ao tentar excluir o caminhao.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir o caminhão. Erro: {ex.Message}");
            }
        }
    }
}