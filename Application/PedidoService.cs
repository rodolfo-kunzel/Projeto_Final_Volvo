using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Persistence;

namespace Application
{

    public class PedidoService
    {
        private readonly GeralPersistence _geralPersistence;
        private readonly PedidoPersistence _pedidoPersistence;

        public PedidoService(GeralPersistence geralPersistence,
                                      PedidoPersistence pedidoPersistence)
        {
            _geralPersistence = geralPersistence;
            _pedidoPersistence = pedidoPersistence;
        }

        public async Task<Pedido[]> GetAllPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidoPersistence.GetAllPedidosAsync();
                return pedidos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido?> GetPedidoByIdAsync(int Id)
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
                var pedido = await _pedidoPersistence.GetPedidoByDateAsync(date);
                return pedido;
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
                return pedidos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido?> AddPedido(Pedido model)
        {
            try
            {
                _geralPersistence.Add<Pedido>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _pedidoPersistence.GetPedidoByIdAsync(model.Id);
                }
                return null;
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
                var pedido = await _pedidoPersistence.GetPedidoByIdAsync(Id)
                ?? throw new Exception("Pedido selecionada para update não encontrada!");

                model.Id = pedido.Id;
                _geralPersistence.Update<Pedido>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _pedidoPersistence.GetPedidoByIdAsync(model.Id);

                }
                return null;
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
                var pedido = await _pedidoPersistence.GetPedidoByIdAsync(Id)
                ?? throw new Exception("Pedido selecionada para exclusão não encontrada!");
                _geralPersistence.Delete(pedido);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}