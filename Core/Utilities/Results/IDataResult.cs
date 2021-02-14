using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public interface IDataResult<T>: IResult//HANGİ TİPİ DÖNDÜRECEĞİNİ BANA SÖYLE
   {
        T Data { get; }
   }
}
