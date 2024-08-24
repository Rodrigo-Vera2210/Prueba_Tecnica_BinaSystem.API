using AutoMapper;
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

        public async Task<List<ClienteDTO>> Lista()
        {
            try
            {
                var listaCliente = await _clienteRepository.Consultar();

                return _mapper.Map<List<ClienteDTO>>(listaCliente.ToList());
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
