using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.COMMON
{
    public enum StatusCode
    {
        Success = 200,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        InternalError = 500,
        NotImplemented = 501,
        UnknownError = 520
    }
}
