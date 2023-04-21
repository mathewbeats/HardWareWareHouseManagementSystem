using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseManagementSystemsApi
{
    public interface IEntityAdiccionalPropperties
    {
        int Quantity { get; set; }

        decimal UnitValue { get; set; }  
    }
}
