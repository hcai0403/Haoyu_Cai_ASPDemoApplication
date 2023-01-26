using DAL_Layer;
using DAL_Layer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Layer
{
    public class BLL_Layer_Class
    {

        public DataSet GetUser_BLL()
        {
            return new DAL_Layer_Class().GetUser();
        }

        public int AddUser_BLL(User user)
        {
            return new DAL_Layer_Class().AddUser(user);
        }
    }
}
