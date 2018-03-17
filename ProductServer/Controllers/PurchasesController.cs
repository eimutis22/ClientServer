using ProductServer.DAL;
using ProductServer.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductServer.Controllers
{
    [Authorize(Roles = "PurchasesManager")]
    [RoutePrefix("api/Purchases")]
    public class PurchasesController : ApiController
    {
        private SupplierProductRepository context;

        public PurchasesController()
        {
            context = new SupplierProductRepository(new ProductDbContext());
            //prodConfig = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            //supConfig = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>());
        }

        // For injection
        public PurchasesController(SupplierProductRepository ctx)
        {
            context = ctx;
        }

        [HttpGet]
        [Route("Suppliers")]
        public async Task<IList<Supplier>> GetSuppliers()
        {
            return await (context as ISupplierRepository).getEntities();
        }

        [HttpGet]
        [Route("Products")]
        public async Task<IList<Product>> GetProducts()
        {
            return await (context as IProductRepository).getEntities();
        }
    }
}
