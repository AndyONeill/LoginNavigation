using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginNavigation
{
    public interface IInitiatedViewModel
    {
        Task Initiate();
    }
}
