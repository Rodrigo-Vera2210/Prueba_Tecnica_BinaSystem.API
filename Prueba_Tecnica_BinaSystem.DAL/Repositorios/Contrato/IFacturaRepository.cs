using Prueba_Tecnica_BinaSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.DAL.Repositorios.Contrato
{
    public interface IFacturaRepository : IGenericRepository<Factura>
    {
        Task<Factura> Registrar(Factura factura);
    }
}
