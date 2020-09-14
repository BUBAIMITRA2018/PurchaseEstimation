using Estimationtool.Data;
using EstimationTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimationTool.Service
{
    public class MockUserData : IUserStore<User>
    {
        List<User> listofusers;

        public MockUserData()
        {
            DataAcess dataacess = new DataAcess();
            listofusers = new List<User>();

            var users = dataacess.users.ToList();

            foreach (var user in users)
            {
                listofusers.Add(user);
            }


        }

       

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh)
        {
            return await Task.FromResult(listofusers);

        }
    }
}
