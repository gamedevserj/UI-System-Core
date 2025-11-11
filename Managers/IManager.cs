using System;
using System.Collections.Generic;

namespace UISystem.Core
{
    internal partial interface IManager<TController> where TController : IController
    {
        void Init(Dictionary<Type, TController> controllers);
    }
}