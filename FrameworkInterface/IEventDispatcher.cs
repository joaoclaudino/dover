using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dover.Framework.Interface
{
    public interface IEventDispatcher
    {
        void UnregisterEvents();

        void RegisterEvents();
    }
}
