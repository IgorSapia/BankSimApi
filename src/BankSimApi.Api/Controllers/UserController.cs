using AutoMapper;
using BankSimApi.Api.ViewModels;
using BankSimApi.Business.Interfaces;
using BankSimApi.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankSimApi.Api.Controllers
{
    [Route("api/users")]
    public class UserController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserRepository userRepository, IUserService userService, INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(await _userRepository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _userService.Create(_mapper.Map<User>(userViewModel));

            return CustomResponse(HttpStatusCode.Created, userViewModel);
        }

    }
}
