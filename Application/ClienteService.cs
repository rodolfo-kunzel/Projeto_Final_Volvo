using Domain;
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
                    throw new ClientesNaoEncontradosException(Mensagens.listaClientesVazia);
                }

                return clientes;
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

        public async Task<Cliente> GetClienteByIdAsync(int Id)
        {
            try
            {
                var cliente = await _clientePersistence.GetClienteByIdAsync(Id) ??
                throw new ClienteNuloException(Mensagens.clienteNulo);

                return cliente;
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

        public async Task<Cliente> AddCliente(Cliente model)
        {
            try
            {

                var cliente = await _clientePersistence.GetClienteByNumeroDocumentoAsync(model.NumeroDocumento);
                
                if (cliente != null) {
                    throw new ClienteRepetidoException(Mensagens.numeroDocumentoExistente);
                }

                _geralPersistence.Add<Cliente>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                    throw new ClienteNaoSalvoException(Mensagens.erroAoSalvarCliente);
                }
                
                cliente = await _clientePersistence.GetClienteByIdAsync(model.Id)??
                throw new ClienteNuloException(Mensagens.clienteNulo);

                return cliente;
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

        public async Task<Cliente> UpdateCliente(int Id, Cliente model)
        {
            try
            {
                var cliente = await _clientePersistence.GetClienteByIdAsync(Id) ?? 
                throw new ClienteNuloException(Mensagens.clienteNulo);

                model.Id = cliente.Id;
                _geralPersistence.Update<Cliente>(model);

                var salvo = await _geralPersistence.SaveChangesAsync();

                if (!salvo)
                {
                     throw new ClienteNaoSalvoException(Mensagens.erroAoSalvarCliente);
                }

                cliente = await _clientePersistence.GetClienteByIdAsync(model.Id)?? 
                throw new ClienteNuloException(Mensagens.clienteNulo);;

                return cliente;
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

        public async Task<bool> DeleteCliente(int Id)
        {
            try
            {
                var cliente = await _clientePersistence.GetClienteByIdAsync(Id) ?? 
                throw new ClienteNuloException(Mensagens.clienteNulo);

                _geralPersistence.Delete(cliente);

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