using AutoMapper;
using Book_Keeper_DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.User;

namespace Book_keeper.Controllers
{
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly Repositories.User.IObjectRepo<Transaction> transactionRepo;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public TransactionController(IMapper mapper, IObjectRepo<Transaction> transactionRepo, IHttpClientFactory httpClientFactory, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _mapper = mapper;
            this.transactionRepo = transactionRepo;
            _httpClientFactory = httpClientFactory;
            this._userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllTranactionByUserId(int id)
        {


        }
    }
}
