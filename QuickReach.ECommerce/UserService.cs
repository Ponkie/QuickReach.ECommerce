using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReach.ECommerce
{
    public class UserService
    {
        private readonly ILoginManager loginManager;
        private readonly IUserRepository userRepository;
        public UserService(ILoginManager loginManager,
            IUserRepository userRepository)
        {
            this.loginManager = loginManager;
            this.userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            var isValid = this.loginManager.Validate(user.Username, user.Password);

            if(!isValid)
            {
                throw new ApplicationException("Invalid user"); 
            }

            this.userRepository.Save(user);
        }
    }
}
