using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IFilesUploader filesUploader;
        private readonly IOrderRepository ordersRepository;

        public AccountController( UserManager<User> userManager, SignInManager<User> signInManager, IFilesUploader filesUploader, IOrderRepository ordersRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.filesUploader = filesUploader;
            this.ordersRepository = ordersRepository;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel(){ ReturnUrl = returnUrl});
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, loginVM.RememberMe,false);
                if (result.Succeeded)
                {
                    if (loginVM.ReturnUrl != null)
                    {
                        return Redirect(loginVM.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }

            }
            return View(loginVM);
        }
        [Authorize]
        public async Task<IActionResult> LogoutAsync()
        {
           await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterUserViewModel() { ReturnUrl = returnUrl});
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAync(RegisterUserViewModel registerVM)
        {
            if (registerVM.Password == registerVM.FirstName)
            {
                ModelState.AddModelError("Name", "Имя и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = registerVM.FirstName,
                    Email = registerVM.Email,
                };

                var result = await userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Const.UserRoleName);
                    await signInManager.SignInAsync(user, false);

                    if (registerVM.ReturnUrl != null)
                    {
                        return Redirect(registerVM.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
                }


            }
            return View(registerVM);
        }

        [Authorize]
        public async Task<IActionResult> ProfileAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userProfileViewModel = user.MappingToUserProfileViewModel();
            return View(userProfileViewModel);
        }
        [Authorize] 
        public async Task<IActionResult> EditProfileAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userProfileViewModel = user.MappingToUserProfileViewModel();
            return View(userProfileViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfileAsync(UserProfileViewModel userProfileViewModel)
        {

            if (ModelState.IsValid)
            {
                var imagePath = filesUploader.SaveFile(userProfileViewModel.UploadedImage, Const.AvatarDirectory);
                var existingUser = await userManager.FindByNameAsync(User.Identity.Name);
                var user = userProfileViewModel.MappingToUser(existingUser, imagePath);
                await userManager.UpdateAsync(user);

                return RedirectToAction("Profile", "Account");
            }
            
           return View(userProfileViewModel);
           
        }

        [Authorize]
        public async Task<IActionResult> UserOrdersAsync()
        {
            var userId = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            var orders = await ordersRepository.TryGetByUserIdAsync(userId);
            return View(orders.MappingListOrderViewModel());
        }
    }
}
