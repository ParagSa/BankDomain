using AutoMapper;
using Book_keeper.Models.ViewModels;
using Book_Keeper_DomainModels;
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
        public UserController(IMapper mapper, IObjectRepo<User> userRepo, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            this.userRepo = userRepo;
            _httpClientFactory = httpClientFactory;

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
                var user = await userRepo.RegisterObject(_mapper.Map<Book_Keeper_DomainModels.User>(viewModel));
                if(user != null)
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
           
            
            return View();

        }
    }
}
