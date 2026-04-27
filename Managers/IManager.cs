using System;
using System.Collections.Generic;

namespace UISystem.Core
{
    /// <summary>
    /// Defines the contract for common manager classes.
    /// </summary>
    /// <typeparam name="TController">Type of controller that will be managed. Must implement <see cref="IController"/>.</typeparam>
    internal partial interface IManager<TController>
        where TController : IController
    {
        /// <summary>
        /// Initializes manager.
        /// </summary>
        /// <param name="controllers">Controllers that will be managed.</param>
        void Init(Dictionary<Type, TController> controllers);
    }
}
