using Microsoft.EntityFrameworkCore;
using ProyectoGYM.DOMAIN.Core.Entities;
using ProyectoGYM.DOMAIN.Core.Interfaces;
using ProyectoGYM.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGYM.DOMAIN.Infrastructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly GYMContext _context;
        public ProductosRepository(GYMContext context)
        {
            _context = context;
        }
        // Get All Productos

        public async Task<IEnumerable<TbProductos>> GetAll()
        {
            return await _context.TbProductos.ToListAsync();
        }
        // Get Productos by id
        public async Task<TbProductos> GetTById(int CodigoProd)
        {
            return await _context.TbProductos.Where(x => x.CodigoProd == CodigoProd).FirstOrDefaultAsync();
        }
        // Get All Productos by Stored Procedure
        public IEnumerable<TbProductos> GetAllBySP()
        {
            return _context.TbProductos.FromSqlInterpolated($"execute Get_all_Productos").ToList();
        }
        // Insert Productos
        public async Task<bool> Insert(TbProductos tbProductos)
        {
            await _context.TbProductos.AddAsync(tbProductos);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        // Update Prpoductos    
        public async Task<bool> Update(TbProductos tbProductos)
        {
            _context.TbProductos.Update(tbProductos);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        // Dete Productos
        public async Task<bool> Delete(int CodigoProd)
        {
            var TbProductos = await _context.TbProductos.FindAsync(CodigoProd);
            // Validate is null
            if (TbProductos == null)
                return false;
            _context.TbProductos.Remove(TbProductos);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

