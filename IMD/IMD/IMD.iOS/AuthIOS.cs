using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using IMD.iOS;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthIOS))]

namespace IMD.iOS
{
    public class AuthIOS : Models.IAuth
    {
        public bool IsSignIn()
        {
            var bsx = Auth.DefaultInstance.CurrentUser;
            return bsx != null;
        }

        public async Task<string> LoginWithUserAndPass(string bsx, string password)
        {
            try
            {
                var Bsx = await Auth.DefaultInstance.SignInWithPasswordAsync(bsx, password);
                return await Bsx.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public async Task<string> SigninWithUserAndPass(string bsx, string password)
        {
            try
            {
                var newBsx = await Auth.DefaultInstance.CreateUserAsync(bsx, password);
                return await newBsx.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}