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
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidos = await _pedidoService.GetAllPedidosAsync();
                if (pedidos == null) return NoContent();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pedido = await _pedidoService.GetPedidoByIdAsync(id);
                if (pedido == null) return NoContent();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedido. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pedido model)
        {
            try
            {
                var pedido = await _pedidoService.AddPedido(model, model.ListaCaminhoes);
                if (pedido == null) return NoContent();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar a pedido. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pedido model)
        {
            try
            {
                var pedido = await _pedidoService.UpdatePedido(id, model);
                if (pedido == null) return NoContent();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar a pedido. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pedido = await _pedidoService.GetPedidoByIdAsync(id);
                if (pedido == null) return NoContent();

                pedido.StatusPedido = 2;

                if (await _pedidoService.UpdatePedido(pedido.Id, pedido) != null)
                {
                    if (await _pedidoService.CancelPedido(pedido.Id))
                    {
                        return Ok("Pedido cancelado com sucesso!");
                    }
                }

                throw new Exception("Ocorreu um problema não específico ao tentar excluir o pedido.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir a pedido. Erro: {ex.Message}");
            }
        }
    }
}