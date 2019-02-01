using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RentACar_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _userService;

        public AccountController(IAccountService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Managers()
        {
            var managers = _userService.GetManagers();
            return PartialView("_Managers", managers);
        }

        [ChildActionOnly]
        public ActionResult Customers()
        {
            var customers = _userService.GetCustomers();
            return PartialView("_Customers",customers);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginDTO userLoginDTO)
        {
            _userService.Login(userLoginDTO);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            _userService.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public  ActionResult Register(UserDTO userDTO)
        {
            if (ModelState.IsValid && !_userService.UserExists(userDTO.Username))
            {
                var userResult = _userService.AddUser(userDTO, userDTO.Password);
                if (userResult.Succeeded)
                {
                    var roleResult = _userService.AddUserToRole(userDTO.Username, "Customer");
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
            }

            return View(userDTO);
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
