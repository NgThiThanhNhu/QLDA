using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.COMMON
{
    public class CustomException
    {
        public static string ConvertExceptionToMessage(Exception ex, string message)
        {
            return message + " " + ex.Message;
        }
    }
}
