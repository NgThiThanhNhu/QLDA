using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.COMMON
{
     public static class CommonConst
    {

        public static int ExpireTime = 8; // Thời gian hết hạn chức thực là 8 giờ
        public static string _projectName = "QUẢN LÝ DỰ ÁN";
        public static string _footer = "@" + DateTime.Now.Year + " - Designed by Hiday";
        public static string[] _fileValid = new string[] { ".jpg", ".png", ".jpeg", ".pdf", ".rar", ".zip", ".doc", ".docx", ".xls", ".xlsx" };
        public static string _fileValidString = "Ảnh (jpg, png, jpeg), PDF, Tập tin nén (rar, zip), Văn bản (doc, docx, xls, xlsx)";
        public static string[] _fileHinhAnhValid = new string[] { ".jpg", ".png", ".jpeg" };
        public static string _fileHinhAnhValidString = "Ảnh (jpg, png, jpeg)";
        public static string[] _fileVideoValid = new string[] { ".avi", ".wmv", ".mp4" };
        public static string _fileVideoValidString = "Video (avi, wmv, mp4)";
        public static string[] _fileAudioValid = new string[] { ".mp3", ".mp4", ".wma", ".wav", ".m4a" };
        public static string _fileAudioValidString = "Audio (mp3, mp4, wma, wav, m4a)";
        public static string[] _fileTaiLieuValid = new string[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
        public static string _fileTaiLieuValidString = "PDF, Văn bản (doc, docx, xls, xlsx)";
        public static string[] _fileTaiLieuImportValid = new string[] { ".doc", ".docx", ".xls", ".xlsx" };
        public static string _fileTaiLieuImportValidString = "Văn bản (doc, docx, xls, xlsx)";
    }
}
