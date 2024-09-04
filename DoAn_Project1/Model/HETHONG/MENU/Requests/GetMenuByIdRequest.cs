using System.ComponentModel.DataAnnotations;
using Model.BASE;

namespace Model.HETHONG.MENU.Requests
{
    public class GetMenuByIdRequest : BaseRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ControllerName không được để trống")]
        public string ControllerName { get; set; }
    }
}
