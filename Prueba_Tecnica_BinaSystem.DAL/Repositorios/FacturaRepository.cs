using Prueba_Tecnica_BinaSystem.DAL.Repositorios.Contrato;
using Prueba_Tecnica_BinaSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.DAL.Repositorios
{
    public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
    {
        private readonly Prueba_Tecnica_BinaSystem_Context _dbContext;

        public FacturaRepository(Prueba_Tecnica_BinaSystem_Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Factura> Registrar(Factura factura)
        {
            Factura facturaGenerada = new Factura();

            using (var transaction = _dbContext.Database.BeginTransaction()) 
            {
                try
                {
                    await _dbContext.Facturas.AddAsync(factura);
                    await _dbContext.SaveChangesAsync();
                    
                    foreach (Detalle detalle in factura.Detalles)
                    {
                        detalle.Subtotal = detalle.Cantidad * detalle.Precio;
                        detalle.IVA = detalle.Subtotal * (decimal)0.15;
                        detalle.IdFactura = factura.IdFactura;
                        _dbContext.Detalles.Update(detalle);
                        factura.Subtotal += detalle.Subtotal;
                        factura.TotalIVA += detalle.IVA;
                    }
                    await _dbContext.SaveChangesAsync();

                    factura.Total = factura.Subtotal + factura.TotalIVA;
                    _dbContext.Facturas.Update(factura);
                    await _dbContext.SaveChangesAsync();

                    facturaGenerada = factura;

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                return facturaGenerada;
            }
        }
    }
}
