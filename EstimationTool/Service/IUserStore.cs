using EstimationTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimationTool.Service
{
    public interface IUserStore<T>
    {
    Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false);



    }
}
