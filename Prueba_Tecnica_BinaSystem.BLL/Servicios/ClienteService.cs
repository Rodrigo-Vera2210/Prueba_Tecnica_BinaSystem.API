using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato;
using Prueba_Tecnica_BinaSystem.DAL.Repositorios.Contrato;
using Prueba_Tecnica_BinaSystem.DTO;
using Prueba_Tecnica_BinaSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.BLL.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> Lista(string SearchTerm)
        {
            try
            {
                var listaCliente = await _clienteRepository.Consultar();

                if(!SearchTerm.IsNullOrEmpty()){
                    listaCliente = listaCliente.Where(
                        c => c.Identificacion.Contains(SearchTerm) ||
                             c.Nombre.Contains(SearchTerm));
                }

                listaCliente = listaCliente.Take(5);

                return _mapper.Map<List<ClienteDTO>>(listaCliente.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClienteDTO> Obtener(long id)
        {
            try
            {
                var clienteEncontrado = await _clienteRepository.Obtener(c => c.IdCliente == id);

                if (clienteEncontrado == null) throw new TaskCanceledException("Cliente no encontrado");

                return _mapper.Map<ClienteDTO>(clienteEncontrado);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ClienteDTO> Crear(ClienteDTO cliente)
        {
            try
            {
                var clienteCreado = await _clienteRepository.Crear(_mapper.Map<Cliente>(cliente));
                if (clienteCreado.IdCliente == 0) throw new TaskCanceledException("No se pudo crear");

                return _mapper.Map<ClienteDTO>(clienteCreado);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
