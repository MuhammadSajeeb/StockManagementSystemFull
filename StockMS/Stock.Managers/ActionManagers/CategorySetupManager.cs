using Stock.Core.Models;
using Stock.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Managers.ActionManagers
{
    public class CategorySetupManager
    {
        private CategorySetupRepository _CategorySetupRepository = new CategorySetupRepository();
        public decimal AlreadyExistCode()
        {
            return _CategorySetupRepository.AlreadyExistCode();
        }

        public Categories LastExistCode()
        {
            return _CategorySetupRepository.LastExistCode();
        }


    }
}
