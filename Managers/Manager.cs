using System;
using System.Collections.Generic;

namespace UISystem.Core
{
    public abstract partial class Manager<TController> : IManager<TController>
        where TController : IController
    {

        protected KeyValuePair<Type, TController>? _currentController;
        protected Dictionary<Type, TController> _controllers = new Dictionary<Type, TController>();

        public void Init(Dictionary<Type, TController> controllers)
        {
            _controllers = controllers;
        }

    }
}
