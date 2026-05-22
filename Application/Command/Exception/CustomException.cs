using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Exception
{
    public class CustomException : System.Exception
    {
        //public string message = "خطا";
        public CustomException(string ex):base(ex) {
        //this.message = ex;


        }


    
    }
}
