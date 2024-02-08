using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{

    public class PedidoService
    {
        private readonly GeralPersistence _geralPersistence;
        private readonly PedidoPersistence _pedidoPersistence;
        private readonly CaminhaoService _caminhaoService;

        public PedidoService(GeralPersistence geralPersistence,
                                    PedidoPersistence pedidoPersistence,
                                    CaminhaoService caminhaoService)
        {
            _geralPersistence = geralPersistence;
            _pedidoPersistence = pedidoPersistence;
            _caminhaoService = caminhaoService;
        }

        public async Task<Pedido[]> GetAllPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidoPersistence.GetAllPedidosAsync();

                if (pedidos == null || pedidos.Length == 0) {
                    throw new PedidosNaoEncontradosException(Mensagens.listaPedidosVazia);
                }

                return pedidos;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> GetPedidoByIdAsync(int Id,  bool includeCliente = true,
                            bool includeCaminhoes = true)
        {
            try
            {
                var pedido = await _pedidoPersistence.GetPedidoByIdAsync(Id, includeCliente, includeCaminhoes) ??
                throw new PedidoNuloException(Mensagens.pedidoNulo);

                return pedido;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido?> GetPedidoByConcessionariaIdAsync(int Id)
        {
            try
            {
                var pedido = await _pedidoPersistence.GetPedidoByIdAsync(Id);
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido?> GetPedidoByDateAsync(DateTime date)
        {
            try
            {
                var pedido = await _pedidoPersistence.GetPedidoByDateAsync(date) ??
                throw new PedidoNuloException(Mensagens.pedidoNulo);

                return pedido;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido[]> GetPedidoByDateRangeAsync(DateTime minDate, DateTime maxDate)
        {
            try
            {
                var pedidos = await _pedidoPersistence.GetPedidoByDateRangeAsync(minDate, maxDate);

                if (pedidos == null || pedidos.Length == 0) {
                    throw new PedidosNaoEncontradosException(Mensagens.listaPedidosVazia);
                }

                return pedidos;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido?> AddPedido(Pedido model, List<int> idsCaminhao)
        {
            try
            {
                if (await _caminhaoService.IdListIsValid(idsCaminhao))
                {
                    _geralPersistence.Add<Pedido>(model);
                    var pedidoId = _pedidoPersistence._context.Entry(model).Property(e => e.Id).CurrentValue;

                    foreach (var item in idsCaminhao)
                    {
                        await _caminhaoService.UpdateCaminhaoPedido(item, pedidoId);
                    }

                    if (await _geralPersistence.SaveChangesAsync())
                    {
                        return await _pedidoPersistence.GetPedidoByIdAsync(model.Id);
                    }
                }

                var pedido = await _pedidoPersistence.GetPedidoByIdAsync(model.Id) ??
                throw new PedidoNuloException(Mensagens.pedidoNulo);

                return pedido;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido?> UpdatePedido(int Id, Pedido model)
        {
            try
            {
                if (model.StatusPedido == 1)
                {
                    model.DataEntrega = DateTime.Now;
                }

                if (model.ListaCaminhoes != null && model.StatusPedido == 0)
                {
                    foreach (var item in model.ListaCaminhoes)
                    {
                        await _caminhaoService.UpdateCaminhaoPedido(item, model.Id);
                    }
                }

                if (model.Caminhoes != null && model.StatusPedido == 2)
                {
                    foreach (var item in model.Caminhoes)
                    {
                        await _caminhaoService.UpdateCaminhaoPedido(item.Id, null);
                    }
                }
                model.Caminhoes = null;
                _geralPersistence.Update<Pedido>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                     throw new PedidoNaoSalvoException(Mensagens.erroAoSalvarPedido);
                }

                var pedidoRetorno = await _pedidoPersistence.GetPedidoByIdAsync(model.Id) ??
                throw new PedidoNuloException(Mensagens.pedidoNulo);

                return pedidoRetorno;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Mensagens.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CancelPedido(int Id)
        {
            try
            {
                var pedido = await _pedidoPersistence.GetPedidoByIdAsync(Id, false, false)
                ?? throw new Exception("Pedido selecionada para cancelamento não encontrada!");
                if (pedido.Caminhoes == null) throw new Exception("Pedido selecionada para cancelamento não possui caminhões!");

                foreach (var item in pedido.Caminhoes)
                {
                    await _caminhaoService.DeletePedidoIdFromCaminhao(item.Id);
                }
                return true;
                //return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}