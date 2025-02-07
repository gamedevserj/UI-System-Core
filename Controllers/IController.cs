using System;

namespace UISystem.Core
{
    public partial interface IController<TType> where TType : Enum
    {

        TType Type { get; }
        void Init();

    }
}
