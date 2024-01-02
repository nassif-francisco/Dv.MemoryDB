using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dv.MemoryDB
{
    public interface IDvCell<T>
    {

        T Value { get; }
        //you can change the change type later to adjust the check
        //whether it is column or item check
        //void CheckType(Type T)
        //{
        //    if (!Enum.IsDefined(typeof(DvColumnType), T))
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }

    public interface IDvCell
    {

         
        //you can change the change type later to adjust the check
        //whether it is column or item check
        //void CheckType(Type T)
        //{
        //    if (!Enum.IsDefined(typeof(DvColumnType), T))
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
