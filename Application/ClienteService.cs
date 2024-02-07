using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

                if (clientes == null || clientes.Length == 0) {
                    throw new ClientesNaoEncontradosException(Messages.listaClientesVazia);
                }

                return clientes;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
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
                var cliente = await _clientePersistence.GetClienteByIdAsync(Id)??
                throw new ClienteNuloException(Messages.clienteNulo);

                return cliente;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
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
                
                if (cliente != null) {
                    throw new ClienteRepetidoException(Messages.numeroDocumentoExistente);
                }

                _geralPersistence.Add<Cliente>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new ClienteNaoSalvoException(Messages.erroAoSalvarCliente);
                }
                
                cliente = await _clientePersistence.GetClienteByIdAsync(model.Id)??
                throw new ClienteNuloException(Messages.clienteNulo);

                return cliente;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
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
                var cliente = await _clientePersistence.GetClienteByIdAsync(Id) ?? 
                throw new ClienteNuloException(Messages.clienteNulo);

                model.Id = cliente.Id;
                _geralPersistence.Update<Cliente>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                     throw new ClienteNaoSalvoException(Messages.erroAoSalvarCliente);
                }

                cliente = await _clientePersistence.GetClienteByIdAsync(model.Id)?? 
                throw new ClienteNuloException(Messages.clienteNulo);;

                return cliente;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
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
                var cliente = await _clientePersistence.GetClienteByIdAsync(Id)?? 
                throw new ClienteNuloException(Messages.clienteNulo);

                _geralPersistence.Delete(cliente);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                     throw new ClienteNaoSalvoException(Messages.erroAoSalvarCliente);
                }

                return salvo;
            }
            catch (SqlException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (DbUpdateException)
            {
                throw new AcessoDeDadosException(Messages.erroDados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}