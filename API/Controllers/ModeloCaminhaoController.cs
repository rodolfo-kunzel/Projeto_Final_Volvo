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
    public class ModeloCaminhaoController : ControllerBase
    {
        private readonly ModeloCaminhaoService _modeloCaminhaoService;

        public ModeloCaminhaoController(ModeloCaminhaoService modeloCaminhaoService)
        {
            _modeloCaminhaoService = modeloCaminhaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var modeloCaminhoes = await _modeloCaminhaoService.GetAllModeloCaminhoesAsync();
                if (modeloCaminhoes == null) return NoContent();

                return Ok(modeloCaminhoes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar modeloCaminhoes. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoService.GetModeloCaminhaoByIdAsync(id);
                if (modeloCaminhao == null) return NoContent();

                return Ok(modeloCaminhao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar modeloCaminhao. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ModeloCaminhao model)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoService.AddModeloCaminhao(model);
                if (modeloCaminhao == null) return NoContent();

                return Ok(modeloCaminhao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar a modeloCaminhao. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ModeloCaminhao model)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoService.UpdateModeloCaminhao(id, model);
                if (modeloCaminhao == null) return NoContent();

                return Ok(modeloCaminhao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar a modeloCaminhao. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoService.GetModeloCaminhaoByIdAsync(id);
                if (modeloCaminhao == null) return NoContent();

                return (await _modeloCaminhaoService.DeleteModeloCaminhao(modeloCaminhao.Id)) ?
                     Ok(new { message = "ModeloCaminhao excluída com sucesso!" }) :
                     throw new Exception("Ocorreu um problema não específico ao tentar excluir a modeloCaminhao.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir a modeloCaminhao. Erro: {ex.Message}");
            }
        }
    }
}