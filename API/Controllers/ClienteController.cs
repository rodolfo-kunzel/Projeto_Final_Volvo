using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ClienteService clienteService, ILogger<ClienteController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _clienteService.GetAllClientesAsync();

                return Ok(clientes);
            }
            catch (ClientesNaoEncontradosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDeClientes} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroNaBuscaDeClientes} Erro: {ex.Message}");
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
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                if (cliente == null) return NoContent();
                
                return Ok(cliente);
            }
            catch (ClienteNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.clienteNulo} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroDados} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente model)
        {
            try
            {
                var cliente = await _clienteService.AddCliente(model);

                return Ok(cliente);
            }
            catch (ClienteNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.clienteNulo} Erro: {ex.Message}");
            }
            catch (ClienteRepetidoException ex)
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroDados} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente model)
        {
            try
            {
                var cliente = await _clienteService.UpdateCliente(id, model);
                if (cliente == null) return NoContent();

                return Ok(cliente);
            }
            catch (ClienteNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.clienteNulo} Erro: {ex.Message}");
            }
            catch (ClienteNaoSalvoException ex) 
            { 
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroAoSalvarCliente} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroDados} Erro: {ex.Message}");
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
                var cliente = await _clienteService.GetClienteByIdAsync(id);

                return (await _clienteService.DeleteCliente(cliente.Id)) ?
                     Ok(new { message = Mensagens.clienteRemovidoSucesso }) :
                     throw new ClienteNaoPodeSerDeletadoException(Mensagens.clienteRemovidoErro);
            }
            catch (ClienteNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.clienteNulo} Erro: {ex.Message}");
            }
            catch (ClienteNaoPodeSerDeletadoException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
            catch (AcessoDeDadosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{Mensagens.erroDados} Erro: {ex.Message}");
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