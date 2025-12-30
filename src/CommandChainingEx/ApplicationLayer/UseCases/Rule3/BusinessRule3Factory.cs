using ApplicationLayer.BusinessHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Rule3
{
    public class BusinessRule3Factory : IRuleFactory
    {
        public string Name => "BusinessRule3Implementation";

        public IRule Create()
        {
            return new BusinessRule3Implementation();
        }
    }
}
