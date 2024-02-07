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
        private readonly ILogger<ModeloCaminhaoService> _logger;

        public ModeloCaminhaoController(ModeloCaminhaoService modeloCaminhaoService, ILogger<ModeloCaminhaoService> logger)
        {
            _modeloCaminhaoService = modeloCaminhaoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var modeloCaminhoes = await _modeloCaminhaoService.GetAllModeloCaminhoesAsync();

                return Ok(modeloCaminhoes);
            }
            catch (ModelosCaminhoesNaoEncontradoException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDeModelosCaminhoes} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeModelosCaminhoes} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoService.GetModeloCaminhaoByIdAsync(id);

                return Ok(modeloCaminhao);
            }
            catch (ModeloCaminhaoNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.modeloCaminhaoNulo} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeModelosCaminhoes} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ModeloCaminhao model)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoService.AddModeloCaminhao(model);

                return Ok(modeloCaminhao);
            }
            catch (ModeloCaminhaoNuloException ex)
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.modeloCaminhaoNulo} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeModelosCaminhoes} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ModeloCaminhao model)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoService.UpdateModeloCaminhao(id, model);

                return Ok(modeloCaminhao);
            }
            catch (ModeloCaminhaoNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.modeloCaminhaoNulo} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeModelosCaminhoes} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var modeloCaminhao = await _modeloCaminhaoService.GetModeloCaminhaoByIdAsync(id);

                return (await _modeloCaminhaoService.DeleteModeloCaminhao(modeloCaminhao.Id)) ?
                     Ok(new { message = Mensagens.modeloCaminhaoRemovidoSucesso }) :
                     throw new ModeloCaminhaoNaoPodeSerDeletadoException(Mensagens.modeloCaminhaoRemovidoErro);
            }
            catch (ModeloCaminhaoNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.modeloCaminhaoNulo} Erro: {ex.Message}");
            }
            catch (ModeloCaminhaoNaoPodeSerDeletadoException ex)
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeModelosCaminhoes} Erro: {ex.Message}");
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