using System.Web.Mvc;
using System.Collections.Generic;
using TestApplication.Models;
using System.Linq;
using TestApplication.Service;
using Data;

namespace TestApplication.Controllers
{
    public class UserController: Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<User> list = userService.GetUsers();
            IEnumerable<UserModel> users = list.Select(u => new UserModel
            {
                Name = u.Name,
                EmailAddress = u.EmailAddress,
                MobileNo = u.MobileNo,
                Id = u.Id
            });
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateEditUser(int? id)
        {
            UserModel model = new UserModel();
            if (id.HasValue && id != 0)
            {
                User userEntity = userService.GetUser(id.Value);
                model.Name = userEntity.Name;
                model.EmailAddress = userEntity.EmailAddress;
                model.MobileNo = userEntity.MobileNo;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditUser(UserModel model)
        {
            if (model.Id == 0)
            {
                User userEntity = new User
                {
                    Name = model.Name,
                    EmailAddress = model.EmailAddress,
                    MobileNo = model.MobileNo
                };
                userService.InsertUser(userEntity);
                if (userEntity.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                User userEntity = userService.GetUser(model.Id);
                userEntity.Name = model.Name;
                userEntity.EmailAddress = model.EmailAddress;
                userEntity.MobileNo = model.MobileNo;
                userService.UpdateUser(userEntity);
                if (userEntity.Id > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        public ActionResult DetailUser(int? id)
        {
            UserModel model = new UserModel();
            if (id.HasValue && id != 0)
            {
                User userEntity = userService.GetUser(id.Value);
                model.Id = userEntity.Id;
                model.Name = userEntity.Name;
                model.EmailAddress = userEntity.EmailAddress;
                model.MobileNo = userEntity.MobileNo;
            }
            return View(model);
        }

        public ActionResult DeleteUser(int id)
        {
            UserModel model = new UserModel();
            if (id != 0)
            {
                User userEntity = userService.GetUser(id);
                model.Name = userEntity.Name;
                model.EmailAddress = userEntity.EmailAddress;
                model.MobileNo = userEntity.MobileNo;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    User userEntity = userService.GetUser(id);
                    userService.DeleteUser(userEntity);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
 