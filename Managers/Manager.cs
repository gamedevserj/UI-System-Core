using System;
using System.Collections.Generic;

namespace UISystem.Core
{
    /// <summary>
    /// Common manager class.
    /// </summary>
    /// <typeparam name="TController">Type of controller that will be managed. Must implement <see cref="IController"/>.</typeparam>
    public abstract partial class Manager<TController> : IManager<TController>
        where TController : IController
    {
        /// <summary>
        /// Gets or sets current controller.
        /// </summary>
        protected KeyValuePair<Type, TController>? CurrentController { get; set; }

        /// <summary>
        /// Gets or sets available controllers.
        /// </summary>
        protected Dictionary<Type, TController> Controllers { get; set; } = new Dictionary<Type, TController>();

        /// <summary>
        /// Initializes manager.
        /// </summary>
        /// <param name="controllers">Controllers that will be managed.</param>
        public void Init(Dictionary<Type, TController> controllers)
        {
            Controllers = controllers;
        }
    }
}
