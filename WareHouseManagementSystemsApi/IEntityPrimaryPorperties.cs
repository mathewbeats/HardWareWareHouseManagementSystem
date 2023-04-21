using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseManagementSystemsApi
{
    public interface IEntityPrimaryPorperties
    {
        int Id { get; set; }    
        string name { get; set; } 
         
        string Type { get; set; }   
    }
}
