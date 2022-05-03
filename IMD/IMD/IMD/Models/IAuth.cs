using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMD.Models
{
    public interface IAuth
    {
        Task<string> LoginWithUserAndPass(string bsx, string password);
        Task<string> SigninWithUserAndPass(string bsx, string password);
        bool IsSignIn();

    }
}
