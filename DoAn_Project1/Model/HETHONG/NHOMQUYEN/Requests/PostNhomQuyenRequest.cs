using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BASE;

namespace Model.HETHONG.NHOMQUYEN.Requests
{
    public class PostNhomQuyenRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên gọi không được để trống")]
        public string? TenGoi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Thứ tự không được để trống")]
        public string? Icon { get; set; }
    }
}
