using System;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core
{
    /// <summary>
    /// Defines the contract for common manager classes.
    /// </summary>
    /// <typeparam name="TController">Type of controller that will be managed. Must implement <see cref="IController"/>.</typeparam>
    public interface IManager<in TController>
        where TController : IController
    {
        /// <summary>
        /// Event to perform when controller is switched.
        /// </summary>
        event Action<IInputReceiver> ControllerSwitched;

        /// <summary>
        /// Initializes manager.
        /// </summary>
        /// <param name="controllers">Controllers that will be managed.</param>
        void Init(TController[] controllers);
    }
}
