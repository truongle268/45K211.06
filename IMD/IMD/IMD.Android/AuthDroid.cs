using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Forms;
using Android.Gms.Extensions;
[assembly: Dependency(typeof(IMD.Droid.AuthDroid))]

namespace IMD.Droid
{
    public class AuthDroid : IAuth
    {
        public bool IsSignIn()
        {
            var bsx = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
            return bsx != null;
        }

        public async Task<string> LoginWithUserAndPass(string bsx, string password)
        {
            bsx = bsx.ToUpper() + "@gmail.com";
            try
            {
                var Bsx = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(bsx, password);
                var uid = Bsx.User.Uid;
                return uid;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;

            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (Exception ee)
            {

            }
            return string.Empty;
        }

        public async Task<string> SigninWithUserAndPass(string bsx, string password)
        {
            bsx = bsx.ToUpper() + "@gmail.com";
            try
            {
                var newBsx = await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(bsx, password);
                var uid = newBsx.User.Uid;
                return uid;
            }
            catch(FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;

            }
            catch(FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (Exception ee)
            {

            }
            return string.Empty;
        }
    }
}