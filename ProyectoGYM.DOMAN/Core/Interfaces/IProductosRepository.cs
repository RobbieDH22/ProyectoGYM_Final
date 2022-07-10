using ProyectoGYM.DOMAIN.Core.Entities;

namespace ProyectoGYM.DOMAIN.Core.Interfaces
{
    public interface IProductosRepository
    {
        Task<bool> Delete(int CodigoProd);
        Task<IEnumerable<TbProductos>> GetAll();
        IEnumerable<TbProductos> GetAllBySP();
        Task<TbProductos> GetTById(int CodigoProd);
        Task<bool> Insert(TbProductos tbProductos);
        Task<bool> Update(TbProductos tbProductos);
    }
}