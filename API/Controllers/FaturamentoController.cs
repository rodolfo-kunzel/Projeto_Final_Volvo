using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaturamentoController : ControllerBase
    {
        private readonly FaturamentoService _faturamentoService;
        private readonly PedidoService _pedidoService;
        private readonly CaminhaoService _caminhaoService;

        private readonly ILogger<FaturamentoController> _logger;

        public FaturamentoController(FaturamentoService faturamentoService, PedidoService pedidoService,
                                    CaminhaoService caminhaoService, ILogger<FaturamentoController> logger)
        {
            _faturamentoService = faturamentoService;
            _pedidoService = pedidoService;
            _caminhaoService = caminhaoService;
            _logger = logger;
        }

        [HttpGet("Concessionaria/{id}")]
        public async Task<IActionResult> GetByConcessionariaId(int id)
        {
            try
            {
                var faturas = await _faturamentoService.GetFaturaByConcessionariaIdAsync(id);
                return Ok(faturas);
            }
            catch (FaturamentosNaoEncontradosException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDeFaturamento} Erro: {ex.Message}");
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

        [HttpGet("Concessionaria/{id}/{ano}/{mes}")]
        public async Task<IActionResult> GetByConcessionariaIdYearMonth(int id, int ano, int mes)
        {
            try
            {
                var fatura = await _faturamentoService.GetFaturaByConcIdYearMonthAsync(id, ano, mes);

                return Ok(fatura);
            }
            catch (FaturamentoNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDeFaturamento} Erro: {ex.Message}");
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


        [HttpPost("{idConcessionaria}")]
        public async Task<IActionResult> GenerateFatura(int idConcessionaria)
        {
            try
            {
                var faturaConcessionaria = await _faturamentoService.GetFaturaByConcIdYearMonthAsync(idConcessionaria, DateTime.Now.Year, DateTime.Now.Month);
                if (faturaConcessionaria != null) throw new FaturamentoRepetidoException(Mensagens.faturamentoRepetido);

                double faturamentoTotal = 0;
                foreach (var item in await _caminhaoService.GetSoldCaminhaoByConcessionariaIdAsync(idConcessionaria))
                {
                    faturamentoTotal += item.Valor;
                }
                //return Ok(await _caminhaoService.GetSoldCaminhaoByConcessionariaIdAsync(idConcessionaria));

                var fatura = await _faturamentoService.AddFatura(idConcessionaria, faturamentoTotal);

                return Ok(faturaConcessionaria);
            }
            catch (FaturamentoRepetidoException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroInesparo} Erro: {ex.Message}");
            }
            catch (FaturamentoNuloException ex) 
            {
                _logger.LogError(ex.Message);
                 return StatusCode(StatusCodes.Status404NotFound,
                    $"{Mensagens.erroNaBuscaDeFaturamento} Erro: {ex.Message}");
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

    }
}