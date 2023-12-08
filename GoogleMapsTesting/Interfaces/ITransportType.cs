using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsTesting.Interfaces
{
    public interface ITransportType
    {
        public void  SelectTransportType();
        public void GetRouteInformation(out string routeInfo);
        public bool VerifyIconInformation();
    }
}
