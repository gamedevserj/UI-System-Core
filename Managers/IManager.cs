using System;

namespace UISystem.Core
{
    internal partial interface IManager<TController, TType> where TController : IController<TType> where TType : Enum
    {
        void Init(TController[] controllers);
    }
}