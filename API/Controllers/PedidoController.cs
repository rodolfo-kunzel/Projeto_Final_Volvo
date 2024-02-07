using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(PedidoService pedidoService, ILogger<PedidoController> logger)
        {
            _pedidoService = pedidoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidos = await _pedidoService.GetAllPedidosAsync();

                return Ok(pedidos);
            }
            catch (PedidosNaoEncontradosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pedido = await _pedidoService.GetPedidoByIdAsync(id);

                return Ok(pedido);
            }
            catch (PedidosNaoEncontradosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpGet("ByDate/{data}")]
        public async Task<IActionResult> GetByData(DateTime data)
        {
            try
            {
                var pedido = await _pedidoService.GetPedidoByDateAsync(data);

                return Ok(pedido);
            }
            catch (PedidosNaoEncontradosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpPost("{idCaminhoes}")]
        public async Task<IActionResult> Post(Pedido model, string idCaminhoes)
        {
            try
            {
                var pedido = await _pedidoService.AddPedido(model, idCaminhoes);

                return Ok(pedido);
            }
            catch (PedidosNaoEncontradosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (PedidoNaoSalvoException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroAoSalvarPedido} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pedido model)
        {
            try
            {
                var pedido = await _pedidoService.UpdatePedido(id, model);

                return Ok(pedido);
            }
            catch (PedidosNaoEncontradosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (PedidoNaoSalvoException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroAoSalvarPedido} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
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
                var pedido = await _pedidoService.GetPedidoByIdAsync(id);

                return (await _pedidoService.DeletePedido(pedido.Id)) ?
                     Ok(new { message = Mensagens.pedidoRemovidoSucesso }) :
                     throw new PedidoNaoPodeSerDeletadoException(Mensagens.pedidoRemovidaErro);
            }
            catch (PedidosNaoEncontradosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
            }
            catch (PedidoNaoPodeSerDeletadoException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
            catch (PedidoNaoSalvoException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroAoSalvarPedido} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDePedido} Erro: {ex.Message}");
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