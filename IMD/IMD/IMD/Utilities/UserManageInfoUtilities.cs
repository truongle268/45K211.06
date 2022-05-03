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
    public static class UserManageInfoUtilities
    {
        public async static Task<ObservableCollection<User>> GetUserInfos(string url, Action<string> callback)
        {
            var uri = url + "XemThongTins";


            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
                http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                try
                {
                    var response = await http.GetStringAsync(uri);
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
    }

}
