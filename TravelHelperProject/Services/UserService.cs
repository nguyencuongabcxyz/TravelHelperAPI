﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IUserService: ICommonService<ApplicationUser>
    {

    }
    public class UserService: CommonService<ApplicationUser,IUserRepository>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository):base(unitOfWork, userRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
