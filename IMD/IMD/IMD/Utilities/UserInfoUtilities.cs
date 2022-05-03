using IMD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IMD.Utilities
{
    public static class UserInfoUtilities
    {
        public async static Task<ObservableCollection<User>> GetUserInfos(Action<string> callback)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
                http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                try
                {
                    var response = await http.GetStringAsync($"{Constants.DomainAPI}/XemThongTins");
                    var result = JsonConvert.DeserializeObject<ObservableCollection<User>>(response);
                    return result;
                    
                }
                catch (Exception ee)
                {                   
                    callback("Đã có lỗi xảy ra! Vui lòng quay lại sau!");
                }
                return null;
            }
        }

        public async static Task<User> GetUserInfo(string uid, Action<string> callback)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
                http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                try
                {
                    var response = await http.GetStringAsync($"{Constants.DomainAPI}/XemThongTins/{uid}");
                    var result = JsonConvert.DeserializeObject<User>(response);
                    return result;

                }
                catch (Exception ee)
                {
                    callback("Đã có lỗi xảy ra! Vui lòng quay lại sau!");
                }
                return null;
            }
        }
        public async static Task<bool> UpdateUserInfo(User user, Action<string> callback)
        {
            using (HttpClient http = new HttpClient())
            {
                //http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
                //http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                try
                {
                    string dataJson = JsonConvert.SerializeObject(user);
                    StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                    var response = await http.PutAsync($"{Constants.DomainAPI}/XemThongTins/{user.Uid}", stringContent);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var responeContent = await response.Content.ReadAsStringAsync();
                        return true;
                    }
                    else
                    {
                        var responeContent = await response.Content.ReadAsStringAsync();
                        callback(responeContent);
                        return false;
                    }
                }
                catch (Exception ee)
                {
                    // res = Application.Current.Resources["txtCoLoi"] as string;
                }
            }

            return false;
        }

        public async static Task<bool> DeleteUserInfo(string uid, Action<string> callback)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
                http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                try
                {
                    var response = await http.DeleteAsync($"{Constants.DomainAPI}/XemThongTins/{uid}");
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        callback("Đã có lỗi xảy ra! Vui lòng quay lại sau!");
                    }

                }
                catch (Exception ee)
                {
                    callback("Đã có lỗi xảy ra! Vui lòng quay lại sau!");
                }
                return false;
            }
        }

        public async static Task<bool> CreateUserInfo(User user, Action<string> callback)
        {
            using (HttpClient http = new HttpClient())
            {
                //http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
                //http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                try
                {
                    string dataJson = JsonConvert.SerializeObject(user);
                    StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                    var response = await http.PostAsync($"{Constants.DomainAPI}/XemThongTins", stringContent);

                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        var responeContent = await response.Content.ReadAsStringAsync();
                        return true;
                    }
                    else
                    {
                        var responeContent = await response.Content.ReadAsStringAsync();
                        callback(responeContent);
                        return false;
                    }
                }
                catch (Exception ee)
                {
                    // res = Application.Current.Resources["txtCoLoi"] as string;
                }
            }

            return false;
        }

    }
}
