using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Persistence;

namespace Application
{

    public class ClienteService
    {
        private readonly GeralPersistence _geralPersistence;
        private readonly ClientePersistence _clientePersistence;

        public ClienteService(GeralPersistence geralPersistence,
                                      ClientePersistence clientePersistence)
        {
            _geralPersistence = geralPersistence;
            _clientePersistence = clientePersistence;
        }

        public async Task<Cliente[]> GetAllClientesAsync()
        {
            try
            {
                var clientes = await _clientePersistence.GetAllClientesAsync();
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> GetClienteByIdAsync(int Id)
        {
            try
            {
                var cliente = await _clientePersistence.GetClienteByIdAsync(Id);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> AddCliente(Cliente model)
        {
            try
            {
                var cliente = await _clientePersistence.GetClienteByNumeroDocumentoAsync(model.NumeroDocumento);
                if (cliente != null) throw new Exception("Numero de Documento já cadastrado!");
                _geralPersistence.Add<Cliente>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _clientePersistence.GetClienteByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> UpdateCliente(int Id, Cliente model)
        {
            try
            {
                var cliente = await _clientePersistence.GetClienteByIdAsync(Id)
                ?? throw new Exception("Cliente selecionada para update não encontrada!");

                model.Id = cliente.Id;
                _geralPersistence.Update<Cliente>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _clientePersistence.GetClienteByIdAsync(model.Id);

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCliente(int Id)
        {
            try
            {
                var cliente = await _clientePersistence.GetClienteByIdAsync(Id)
                ?? throw new Exception("Cliente selecionado para exclusão não encontrada!");
                _geralPersistence.Delete(cliente);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}