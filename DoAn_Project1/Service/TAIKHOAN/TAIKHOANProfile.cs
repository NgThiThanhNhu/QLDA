using AutoMapper;
using Model.HETHONG.TAIKHOAN.Dtos;
using Model.HETHONG.TAIKHOAN.Reuquest;

namespace Service.TAIKHOAN
{
    public class TAIKHOANProfile : Profile
    {
        public TAIKHOANProfile()
        {
            CreateMap<Entity.DBContent.TAIKHOAN, MODELTaiKhoan>();
            CreateMap<MODELTaiKhoan, Entity.DBContent.TAIKHOAN>();
            CreateMap<Entity.DBContent.TAIKHOAN, PostTaiKhoanRequest>();
            CreateMap<PostTaiKhoanRequest, Entity.DBContent.TAIKHOAN>();
        }
    }
}
