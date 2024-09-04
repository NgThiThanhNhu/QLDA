using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BASE;

namespace Model.HETHONG.NHOMQUYEN.Dtos
{
    public class MODELNhomQuyen : MODELBase
    {
        public Guid Id { get; set; }
        public string TenGoi { get; set; }
        public string Icon { get; set; }
    }
}
