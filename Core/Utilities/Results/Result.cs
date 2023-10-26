using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success)   //Ben istiyorum ki kullanıcı hem true false alıp mesaj döndürsün hem de sadece isterse true,false döndürsün
        {                                                            //isterse mesaj girmesin bu yüzden 2 tane const yazıyorum. Yukarıda this ile tekrar success yaazmak yerine 
            Message = message;                                      //yukarıda ki success i aşağıdan al diyorum.
        }

        public Result(bool succes)
        {
            Success = succes;
        }
        public string Message { get; }

        public bool Success { get; }
    }
}
