using ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationLayer.BusinessHandlers
{
    public interface IRuleFactory
    {
        string Name { get; }
        IRule Create();
    }
}
