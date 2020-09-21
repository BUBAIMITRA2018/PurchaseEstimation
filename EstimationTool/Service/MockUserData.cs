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
        DataAcess dataacess;

        public MockUserData()
        {
            dataacess = new DataAcess();
            listofusers = new List<User>();
            //User user = new User();
            //user.Id = 1;
            //user.Username = "Estimation";
            //user.Password = "sms@123";
            var users = dataacess.users.ToList();

            foreach (var user in users)
            {
                listofusers.Add(user);
            }


        }

        public async Task<bool> AddItemAsync(User item)
        {
            dataacess.users.Add(item);
            dataacess.SaveChangesAsync();
            return await Task.FromResult(true);

        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh)
        {
            return await Task.FromResult(listofusers);

        }
    }
}
