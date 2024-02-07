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

        public async Task<Pedido> GetPedidoByIdAsync(int Id)
        {
            try
            {
                var pedido = await _pedidoPersistence.GetPedidoByIdAsync(Id) ??
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

        public async Task<Pedido> GetPedidoByDateAsync(DateTime date)
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

        public async Task<Pedido> AddPedido(Pedido model, string ids)
        {
            try
            {
                var listaIds = _caminhaoService.GetListofIds(ids);

                var listaValida = await _caminhaoService.IdListIsValid(listaIds);

                if (!listaValida) {
                    throw new PedidoIdInvalidoException(Mensagens.pedidoIdInvalido);
                }

                _geralPersistence.Add<Pedido>(model);

                var pedidoId = _pedidoPersistence._context.Entry(model).Property(e => e.Id).CurrentValue;

                foreach (var item in listaIds)
                {
                    await _caminhaoService.UpdateCaminhaoPedido(item, pedidoId);
                }

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new PedidoNaoSalvoException(Mensagens.erroAoSalvarPedido);
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
                var pedido = await _pedidoPersistence.GetPedidoByIdAsync(Id) ??
                throw new PedidoNuloException(Mensagens.pedidoNulo);

                model.Id = pedido.Id;

                _geralPersistence.Update<Pedido>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                     throw new PedidoNaoSalvoException(Mensagens.erroAoSalvarPedido);
                }

                pedido = await _pedidoPersistence.GetPedidoByIdAsync(model.Id) ??
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

        public async Task<bool> DeletePedido(int Id)
        {
            try
            {
                var pedido = await _pedidoPersistence.GetPedidoByIdAsync(Id) ??
                throw new PedidoNuloException(Mensagens.pedidoNulo);

                _geralPersistence.Delete(pedido);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                     throw new ClienteNaoSalvoException(Mensagens.erroAoSalvarCliente);
                }

                return salvo;
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
    }
}