using ApplicationLayer.BusinessHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Rule1
{
    public class BusinessRule1Factory : IRuleFactory
    {
        public string Name => "BusinessRule1Implementation";

        public IRule Create()
        {
            return new BusinessRule1Implementation();
        }
    }
}
