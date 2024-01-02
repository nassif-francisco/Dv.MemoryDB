using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dv.MemoryDB
{
    public class DvCell<T> : IDvCell<T>
    {

        private T _value;

        public T Value
        {
            get { return _value; }

            set { _value = value; }
        }

        public DvCell(T value)
        {
            _value = value;
        }

    }

    public class DvCell : IDvCell
    {

        private object _value;

        public object Value
        {
            get { return _value; }

            set { _value = value; }
        }

        public DvCell(object value)
        {
            _value = value;
        }

    }
}
