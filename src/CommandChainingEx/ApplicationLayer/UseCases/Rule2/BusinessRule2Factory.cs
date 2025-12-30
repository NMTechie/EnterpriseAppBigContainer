using ApplicationLayer.BusinessHandlers;
using ApplicationLayer.UseCases.Rule1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Rule2
{
    public class BusinessRule2Factory : IRuleFactory
    {
        public string Name => "BusinessRule2Implementation";

        public IRule Create()
        {
            return new BusinessRule2Implementation();
        }
    }
}
