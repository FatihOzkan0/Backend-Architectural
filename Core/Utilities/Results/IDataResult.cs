using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult  //Success ve Message IResult içerdiği için onu implemente ederek alıyoruz.
    {
        T Data { get; }         //Veri döndüreceğim için bir de bana Data lazım.
    }
}
