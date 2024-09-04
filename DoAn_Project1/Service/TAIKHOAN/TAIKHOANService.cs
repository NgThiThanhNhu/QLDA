using AutoDependencyRegistration.Attributes;
using AutoMapper;
using Entity.DBContent;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Model.BASE;
using Model.COMMON;
using Model.HETHONG.MENU.Dtos;
using Model.HETHONG.TAIKHOAN.Dtos;
using Model.HETHONG.TAIKHOAN.Reuquest;
using Repository;
using Service.NHOMQUYEN;

namespace Service.TAIKHOAN
{
    [RegisterClassAsTransient]
    public class TAIKHOANService : ITAIKHOANService
    {
        private readonly IConfiguration _config;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private INHOMQUYENService _nhomquyenService;
        private IWebHostEnvironment _webHostEnvironment;

        public TAIKHOANService(IConfiguration config, IUnitOfWork unitOfWork, IMapper mapper, INHOMQUYENService nhomquyenService, IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _nhomquyenService = nhomquyenService;
            _webHostEnvironment = webHostEnvironment;
        }

        public BaseResponse<MODELTaiKhoanPhanQuyen> Login(LoginRequest request)
        {
            var response = new BaseResponse<MODELTaiKhoanPhanQuyen>();
            try
            {
                var data = new MODELTaiKhoanPhanQuyen();
                var taikhoan = _unitOfWork.GetRepository<Entity.DBContent.TAIKHOAN>()
                    .Find(x => x.UserName.ToLower() == request.UserName.ToLower());
                if (taikhoan == null)
                {
                    throw new Exception("Tài khoản hoặc mật khẩu không đúng");
                }

                var pass = Encrypt_Decrypt.EncodePassword(request.Password, taikhoan.MatKhauSalt);
                if (pass.Equals(taikhoan.MatKhau))
                {
                    throw new Exception("Tài khoản hoặc mật khẩu không đúng");
                }

                var token = Encrypt_Decrypt.GenerateJwtToken(new MODELTaiKhoan
                {
                    Id = Guid.Parse(taikhoan.Id.ToString()),
                    UserName = request.UserName

                }, _config);
                data.TaiKhoan = _mapper.Map<MODELTaiKhoan>(taikhoan);
                var vaitro = _unitOfWork.GetRepository<VAITRO>().Find(x => x.Id == data.TaiKhoan.VaiTroId);
                data.TaiKhoan.VaiTro = vaitro?.TenGoi;
                data.TaiKhoan.Guid = pass;
                data.TaiKhoan.AnhDaiDien = string.IsNullOrWhiteSpace(taikhoan.AnhDaiDien)
                    ? "Files/no-image.png"
                    : taikhoan.AnhDaiDien;
                data.TaiKhoan.Token = token;
                data.Menu = GetListMenu(new GetListMenuRequest { UserId = taikhoan.Id }).Data
                    .Select(x => new MODELMenuLogin()
                    {
                        Action = x.Action,
                        ControllerName = x.Controller,
                        NhomQuyenId = x.NhomQuyenId,
                        TenGoi = x.TenGoi,
                        Sort = x.Sort

                    }).ToList();
                data.PhanQuyen = GetPhanQuyen(new GetPhanQuyenRequest { UserId = taikhoan.Id }).Data;
                data.NhomQuyen = _nhomquyenService.GetList().Data.Where(x => x.IsActived = true)
                    .Select(x => new MODELNhomQuyenLogin
                    {
                        Id = x.Id,
                        Sort = x.Sort,
                        TenGoi = x.TenGoi,
                        Icon = x.Icon
                    }).ToList();
                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public BaseResponse<List<MODELPhanQuyen>> GetPhanQuyen(GetPhanQuyenRequest request)
        {
            var response = new BaseResponse<List<MODELPhanQuyen>>();
            try
            {
                var parameter = new[]
                {
                    new SqlParameter("@UserId", request.UserId)
                };
                response.Data = _unitOfWork.GetRepository<MODELPhanQuyen>().ExcuteStoredProcedure("", parameter).ToList();
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public BaseResponse<List<MODELMenu>> GetListMenu(GetListMenuRequest request)
        {
            var response = new BaseResponse<List<MODELMenu>>();
            try
            {
                var parameter = new[]
                {
                    new SqlParameter("@UserId", request.UserId)
                };
                response.Data = _unitOfWork.GetRepository<MODELMenu>().ExcuteStoredProcedure("", parameter).ToList();
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        private string UploadAvatar(string folderUpload, string oldImage)
        {
            string path = "";
            string folderUploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Files\\Temp\\UploadFile\\" + folderUpload);
            if (Directory.Exists(folderUploadPath))
            {
                string[] arrFiles = Directory.GetFiles(folderUploadPath);
                if (arrFiles.Count() > 0) // có tệp đính kèm 
                {
                    FileInfo info = new FileInfo(arrFiles[0]);
                    string fileName = Guid.NewGuid().ToString() + info.Extension;
                    string avatarPath = Path.Combine(_webHostEnvironment.WebRootPath, "Files\\AnhDaiDien");
                    //Kiêm tra thư mục đã tồn tại chưa
                    if (!Directory.Exists(avatarPath))
                    {
                        Directory.CreateDirectory(avatarPath);
                    }
                    //Xóa ảnh cũ nếu tồn tại
                    if (File.Exists(avatarPath + "\\" + oldImage))
                    {
                        File.Delete(avatarPath + "\\" + oldImage);
                    }
                    // copy ảnh mới
                    File.Move(arrFiles[0], avatarPath + "\\" + fileName, true);
                    path = "Files\\AnhDaiDien\\" + fileName;
                }
            }

            return path;
        }
    }
}

