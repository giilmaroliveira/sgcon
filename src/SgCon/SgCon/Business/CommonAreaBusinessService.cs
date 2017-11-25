using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SgConAPI.Business
{
    internal class CommonAreaBusinessService : BaseBusinessService<ICommonAreaRepository, CommonArea>, ICommonAreaBusinessService
    {
        private readonly ICommonAreaRepository _commonAreaRepository;
        public CommonAreaBusinessService(ICommonAreaRepository repository) : base(repository)
        {
            _commonAreaRepository = repository;
        }

        public CommonArea GetById(int id)
        {
            return Repository.Get(id);
        }

        public CommonArea CreateCommonArea(CommonArea model)
        {
            var result = Repository.Post(model);

            return result;
        }

        public CommonArea UpdateCommonArea(CommonArea model, int id)
        {
            var result = Repository.Update(model);

            return result;
        }

        public void DeleteCommonArea(int id)
        {
            Repository.Delete(id);
        }

        public IQueryable<CommonArea> GetAll(string filters)
        {
            var result = Repository.GetAll(issueFilterJson(filters));

            return result;
        }

        public IQueryable<CommonArea> GetByCondominiumId(int id)
        {
            var result = _commonAreaRepository.GetByCondominiumId(id);

            return result;
        }
    }
}
