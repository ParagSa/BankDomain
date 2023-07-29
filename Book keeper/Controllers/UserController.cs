using AutoMapper;
using Book_keeper.Models.View_Models;
using Book_keeper.Models.ViewModels;
using Book_Keeper_DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.User;
using System.Net.Http;

namespace Book_keeper.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly Repositories.User.IObjectRepo<User> userRepo;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public UserController(IMapper mapper, IObjectRepo<User> userRepo, IHttpClientFactory httpClientFactory,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _mapper = mapper;
            this.userRepo = userRepo;
            _httpClientFactory = httpClientFactory;
            this._userManager = userManager;
            this.signInManager = signInManager; 
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegisterUser()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserViewModel viewModel)
        {
            if(ModelState.IsValid) 
            {
                var identityUser = new IdentityUser
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,    

                };
                var identityResult = await _userManager.CreateAsync(identityUser, viewModel.Password);
                if (identityResult.Succeeded)
                {
                    var roleIdentityResult = await _userManager.AddToRoleAsync(identityUser, "User");
                    if (roleIdentityResult.Succeeded)
                    {
                        var user = await userRepo.RegisterObject(_mapper.Map<Book_Keeper_DomainModels.User>(viewModel));
                        if (user != null)
                        {
                            var httpClient = _httpClientFactory.CreateClient();
                            string baseUrl = "https://localhost:7199";


                            string url = $"{baseUrl}/send?email={user.Email}";


                            HttpResponseMessage response = await httpClient.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                Console.WriteLine("email sent");

                            }
                            else
                            {
                                Console.WriteLine("not sent");
                            }

                        }

                    }
                }
                
            }
           
            
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> LoginUser()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginViewModel loginViewModel)
        {
            var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.UserName,
                 loginViewModel.Password, false, false);
            if (signInResult != null && signInResult.Succeeded)
            {
                
                return RedirectToAction("Index", "Home");

            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }


    }
}
