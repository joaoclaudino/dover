using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dover.Framework.Interface
{
    public interface IFormEventHandler
    {
        void UnRegisterForms();

        void RegisterForms(bool p = true);

        void RegisterFormLoadBefore(string FormType, dynamic form);

        void RegisterForm(string UniqueId, dynamic form);
    }
}
