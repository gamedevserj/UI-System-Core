using System;
using System.Collections.Generic;

namespace UISystem.Core
{
    public abstract partial class Manager<TController> : IManager<TController>
        where TController : IController
    {

        protected TController _currentController;
        protected Dictionary<Type, TController> _controllers = new Dictionary<Type, TController>();

        public void Init(TController[] controllers)
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                _controllers.Add(controllers[i].GetType(), controllers[i]);
            }
        }

    }
}
