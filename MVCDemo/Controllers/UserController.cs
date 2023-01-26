using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL_Layer;
using System.Data;
using DAL_Layer.Model;

namespace MVCDemo.Controllers
{
    public class UserController : Controller
    {

        protected List<User> Users = new List<User>();
        // GET: User
        public ActionResult Index()
        {

            

            BLL_Layer_Class bll = new BLL_Layer_Class();
            DataSet ds = bll.GetUser_BLL();

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            var val = dr[0];

            var query = from p in dt.AsEnumerable()
                        select new
                        {
                            ID = p.Field<int>("UID"),
                            Name = p.Field<string>("Name"),
                            emailAddress = p.Field<string>("Email"),
                            password = p.Field<string>("Password")
                        };

            foreach (var item in query)
            {
                var emp = new User
                {
                    UID = item.ID,
                    userName = item.Name,
                    emailAddress = item.emailAddress,
                    password = item.password,
                };
                Users.Add(emp);
                 
               
            }

            return View(Users);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(User user)
        {
            if(ModelState.IsValid) {


                BLL_Layer_Class bll = new BLL_Layer_Class();
                var result = bll.AddUser_BLL(user);
                return RedirectToAction("index");
            }
            else
            {
                return View("Create");
            }

        }
    }


}