using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models
{
    public enum OrderState
    {        
        Created,
               
        Processed,
                
        Delivering,
                
        Delivered,
               
        Cancelled
    }
}
