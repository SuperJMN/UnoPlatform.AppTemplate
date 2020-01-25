using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public interface IMyService 
    {
        Task<List<Item>> GetItems();
    }
}