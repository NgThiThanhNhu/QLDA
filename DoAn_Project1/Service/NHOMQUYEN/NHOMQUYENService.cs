using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoDependencyRegistration.Attributes;
using AutoMapper;
using Model.BASE;
using Model.HETHONG.NHOMQUYEN.Dtos;
using Repository;

namespace Service.NHOMQUYEN
{
    [RegisterClassAsTransient]
    public class NHOMQUYENService : INHOMQUYENService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public NHOMQUYENService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public BaseResponse<List<MODELNhomQuyen>> GetList()
        {
            var response = new BaseResponse<List<MODELNhomQuyen>>();
            try
            {
                var data = _unitOfWork.GetRepository<Entity.DBContent.PHANQUYEN_NHOMQUYEN>().GetAll()
                    .OrderBy(x => x.Sort);
                response.Data = _mapper.Map<List<MODELNhomQuyen>>(data);

            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }
        }
    }
}
