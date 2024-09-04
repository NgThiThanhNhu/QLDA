using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BASE;
using Model.HETHONG.NHOMQUYEN.Dtos;

namespace Service.NHOMQUYEN
{
    public interface INHOMQUYENService
    {
        BaseResponse<List<MODELNhomQuyen>> GetList();
    }
}
