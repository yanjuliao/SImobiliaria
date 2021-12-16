using System;

namespace SJImobiliaria
{
    class EAbort : Exception
    {
        public EAbort(string message) : base(message) { }
    }
}
