using System.Collections.Generic;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;

namespace DutchTreat.Data
{
    public interface IDutchRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductsByCategory(string category);
    }
}