using FetchCeudDependices.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FetchCeudDependices.Controllers
{
    public class NewController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            Country();
            var countries = Country();
            ViewBag.Country = new SelectList(countries, "Value", "Text");
            return View();

        }
        [HttpPost]
        public ActionResult Create(User obj)
        {
            BAL obj1 = new BAL();
            obj1.Save(obj);
            return View("Create");

        }
        [HttpGet]

        public IEnumerable<SelectListItem> Country()
        {

            User objE = new User();

            BAL objEmp = new BAL();
            DataSet ds = new DataSet();

            ds = objEmp.Country();

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["CountryId"].ToString() });
            }

            ViewBag.CountryId = list;
            return list; 

        }


        [HttpGet]
        public JsonResult State_Bind(int CountryId)
        {
            User objE = new User();

            BAL objEmp = new BAL();
            DataSet ds = new DataSet();
            objE.CountryId = CountryId;

            ds = objEmp.State(objE);

            List<SelectListItem> Statelist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Statelist.Add(new SelectListItem { Text = dr["StateIName"].ToString(), Value = dr["StateId"].ToString() });
            }
            return Json(Statelist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult City_Bind(int StateId)
        {
            User objE = new User();

            BAL objEmp = new BAL();
            DataSet ds = new DataSet();
            objE.StateId = StateId;

            ds = objEmp.City(objE);

            List<SelectListItem> Citylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Citylist.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["CityId"].ToString() });
            }
            return Json(Citylist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(User obj)
        {
            var countries = Country();
            ViewBag.Country = new SelectList(countries, "Value", "Text");
            BAL userupdate = new BAL();
            userupdate.UpdateUser(obj);
            refresh();
            return PartialView();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            User obj1 = new User();
            obj1.Id = id;
            BAL obj = new BAL();
            DataTable dt = new DataTable();
            dt = obj.FetchUserDetails(obj1);

            User objuser = new User();
            objuser.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            objuser.Name = dt.Rows[0]["Name"].ToString();
            objuser.Email = dt.Rows[0]["Email"].ToString();
            objuser.Age = Convert.ToInt32(dt.Rows[0]["Age"].ToString());
            objuser.Address = dt.Rows[0]["Address"].ToString();
            objuser.CountryName = dt.Rows[0]["CountryName"].ToString();
            objuser.StateIName = dt.Rows[0]["StateIName"].ToString();
            objuser.CityName = dt.Rows[0]["CityName"].ToString();
            objuser.Gender = dt.Rows[0]["Gender"].ToString();
            return PartialView("Update",objuser);
        }

        [HttpGet]
        public ActionResult List()
        {
            BAL user = new BAL();
            DataTable dt = new DataTable();
            dt = user.Fetch();
            User obj = new User();

            List<User> list = new List<User>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User objuser = new User();
                objuser.Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                objuser.Name = dt.Rows[i]["Name"].ToString();
                objuser.Email = dt.Rows[i]["Email"].ToString();
                objuser.Address = dt.Rows[i]["Address"].ToString();
                objuser.Age = Convert.ToInt32(dt.Rows[i]["Age"].ToString());
                objuser.CountryName = dt.Rows[i]["CountryName"].ToString();
                objuser.StateIName = dt.Rows[i]["StateIName"].ToString();
                objuser.CityName = dt.Rows[i]["CityName"].ToString();
                objuser.Gender = dt.Rows[i]["Gender"].ToString();
                list.Add(objuser);
            }
            obj.MyUsers = list;
            return View(obj);
        }


        public ActionResult Details(int id)
        {

            User objdetails = new User();
            objdetails.Id = id;
            BAL user = new BAL();
            DataTable dt = new DataTable();
            dt = user.FetchUserDetails(objdetails);


            List<User> list = new List<User>();
            User objuser = new User();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                objuser.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                objuser.Name = dt.Rows[0]["Name"].ToString();
                objuser.Email = dt.Rows[0]["Email"].ToString();
                objuser.Address = dt.Rows[0]["Address"].ToString();
                objuser.Age = Convert.ToInt32(dt.Rows[0]["Age"].ToString());
                objuser.Gender = dt.Rows[0]["Gender"].ToString();
                objuser.CountryName = dt.Rows[0]["CountryName"].ToString();
                objuser.StateIName = dt.Rows[0]["StateIName"].ToString();
                objuser.CityName = dt.Rows[0]["CityName"].ToString();
                list.Add(objuser);
            }
            objdetails.MyUsers = list;
            return PartialView("Details",objuser);
        }


        [HttpPost]
        public void refresh()
        {
            BAL user = new BAL();
            DataTable dt = new DataTable();
            dt = user.Fetch();
            User obj = new User();

            List<User> list = new List<User>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User objuser = new User();
                objuser.Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                objuser.Name = dt.Rows[i]["Name"].ToString();
                objuser.Email = dt.Rows[i]["Email"].ToString();
                objuser.Address = dt.Rows[i]["Address"].ToString();
                objuser.Age = Convert.ToInt32(dt.Rows[i]["Age"].ToString());
                objuser.CountryName = dt.Rows[i]["CountryName"].ToString();
                objuser.StateIName = dt.Rows[0]["StateIName"].ToString();
                objuser.CityName = dt.Rows[i]["CityName"].ToString();
                objuser.Gender = dt.Rows[0]["Gender"].ToString();
                list.Add(objuser);
            }
            obj.MyUsers = list;
        }


        [HttpPost]
        public ActionResult Delete(User obj)
        {
            BAL userdelete = new BAL();
            userdelete.DeleteUser(obj);
            refresh();
            return RedirectToAction("List");
        }




        [HttpGet]
        public ActionResult Delete(int id)
        {
            User obj2 = new User();
            obj2.Id = id;
            BAL obj = new BAL();
            DataTable dt = new DataTable();
            dt = obj.FetchUserDetails(obj2);

            User objuserdelete = new User();
            objuserdelete.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            objuserdelete.Name = dt.Rows[0]["Name"].ToString();
            objuserdelete.Email = dt.Rows[0]["Email"].ToString();
            objuserdelete.Age = Convert.ToInt32(dt.Rows[0]["Age"].ToString());
            objuserdelete.Address = dt.Rows[0]["Address"].ToString();
            objuserdelete.CountryName = dt.Rows[0]["CountryName"].ToString();
            objuserdelete.StateIName = dt.Rows[0]["StateIName"].ToString();
            objuserdelete.CityName = dt.Rows[0]["CityName"].ToString();
            objuserdelete.Gender = dt.Rows[0]["Gender"].ToString();
            return PartialView(objuserdelete);
        }
    }
   
}
