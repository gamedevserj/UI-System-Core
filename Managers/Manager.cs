using System;
using System.Collections.Generic;

namespace UISystem.Core
{
    public abstract partial class Manager<TController, TType> : IManager<TController, TType>
        where TController : IController<TType>
        where TType : Enum
    {

        protected TController _currentController;
        protected Dictionary<TType, TController> _controllers = new Dictionary<TType, TController>();

        public void Init(TController[] controllers)
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                _controllers.Add(controllers[i].Type, controllers[i]);
            }
        }

    }
}
