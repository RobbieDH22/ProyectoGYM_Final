using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoGYM.DOMAIN.Core.DTOs;
using ProyectoGYM.DOMAIN.Core.Entities;
using ProyectoGYM.DOMAIN.Core.Interfaces;

namespace ProyectoGYM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosRepository _productosRepository;
        private readonly IMapper _mapper;
        public ProductosController(IProductosRepository productosRepository, IMapper mapper)
        {
            _productosRepository = productosRepository;
            _mapper = mapper;
        }
        // GET: api/Productos
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var TbProductos = await _productosRepository.GetAll();
            var Productoslist = new List<ProductosDTO>();
            /* Convert Productos to Productoslist
            foreach (var productos in TbProductos)
            {
                Productoslist.Add(new ProductosDTO
                {
                    CodigoProd = productos.CodigoProd,
                    Nombre = productos.Nombre,
                    Descripcion = productos.Descripcion,
                    Stock = productos.Stock,
                    Precio = productos.Precio,
                    FechaIngreso = productos.FechaIngreso,
                    Estado = productos.Estado
                });
            
    }
            */
            Productoslist = _mapper.Map<List<ProductosDTO>>(TbProductos);

        return Ok(Productoslist);
        }
        // GET: api/Productos/GetTBycodigoProd/5
        [HttpGet("GetTById/{codigoProd}")]
        public async Task<IActionResult> GetTById(int codigoProd)
        {
            var productos = await _productosRepository.GetTById(codigoProd);
            // Validated is null
            if(productos == null)
                return NotFound();

            var ProductosDTO = _mapper.Map<ProductosDTO>(productos);
            return Ok(ProductosDTO);
        }

        // GET: api/Productos/GetByIdQueryParams?id=5
        [HttpGet("GetTByIdQueryParams")]
        public async Task<IActionResult> GetTGetTByIdQueryParamsById([FromQuery] int codigoProd)
        {
            var productos = await _productosRepository.GetTById(codigoProd);
            // Validated is null
            if (productos == null)
                return NotFound();
            var ProductosDTO = _mapper.Map<ProductosDTO>(productos);
            return Ok(ProductosDTO);
        }
        // POST: api/Prodcutos/Insert
        [HttpPost("Insert")]
         public async Task<IActionResult> Insert([FromBody] ProductosPostDTO ProductosDTO)
        {
            var productos = _mapper.Map<TbProductos>(ProductosDTO);
            var result = await _productosRepository.Insert(productos);
            return Ok(result);
        }
        // PUT: api/Productos/Update/{codigoProd}
        [HttpPut("Update/{codigoProd}")]
        public async Task<IActionResult> Upadate(int codigoProd, [FromBody] ProductosDTO productosDTO)
        { 
            if(codigoProd != productosDTO.CodigoProd)
                return BadRequest();
            var productos = _mapper.Map<TbProductos>(productosDTO);
            var result = await _productosRepository.Update(productos);
            return Ok(result);
        
        }
        // DELETE: api/Propuctos/Delete/{codigoProd}
        [HttpDelete("Delete/{codigoProd}")]
        public async Task<IActionResult> Detele(int codigoProd)
        {
            var productos = await _productosRepository.GetTById(codigoProd);
            if (productos == null)
                return NotFound();
            var result = await _productosRepository.Delete(codigoProd);
            return Ok(result);
        
        }
    }
}
