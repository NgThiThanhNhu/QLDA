using FE.Models;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using Newtonsoft.Json;

namespace FE.Controllers
{
   
    public class BaseController<T> : Controller
    {
        public BaseController()
        {

        }

        public ResponseData PostAPI<T>(string action, T model)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);
                    client.BaseAddress = new Uri("https://localhost:7078/api/");
                    var responseTask = client.PostAsJsonAsync(action, model);
                    responseTask.Wait();
                    response = ExecuteApiResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = Model.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống");
            }

            return response;
        }

        public ResponseData ExecuteApiResponse(Task<HttpResponseMessage> responseTask)
        {
            ResponseData response = new ResponseData();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readeTask = result.Content.ReadAsStringAsync();
                readeTask.Wait();
                if (readeTask == null)
                {
                    response.Status = false;
                    response.Message = "Lỗi hệ thống";

                }
                else
                {
                    string json = readeTask.Result;
                    var resultData = JsonConvert.DeserializeObject<MODELAPIBASIC>(json);
                    response.Message = resultData.Message;
                    if (!resultData.Success ||
                        resultData.StatusCode != Convert.ToInt32(Model.COMMON.StatusCode.Success))
                    {
                        response.Status = false;
                    }
                    else
                    {
                        response.Data = resultData.Result;
                    }
                }
            }
            else
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống";
            }
            return response;
        }
    }
}
