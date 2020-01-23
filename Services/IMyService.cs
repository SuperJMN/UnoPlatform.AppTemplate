using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IMyService 
    {
        Task<List<Item>> GetItems();
    }
}