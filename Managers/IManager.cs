using System;

namespace UISystem.Core
{
    internal partial interface IManager<TController> where TController : IController
    {
        void Init(TController[] controllers);
    }
}