using System;
using System.Collections.Generic;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core
{
    /// <summary>
    /// Common manager class.
    /// </summary>
    /// <typeparam name="TController">Type of controller that will be managed. Must implement <see cref="IController"/>.</typeparam>
    public abstract partial class Manager<TController> : IManager<TController>
        where TController : IController
    {
        /// <inheritdoc/>
        public event Action<IInputReceiver> ControllerSwitched;

        /// <summary>
        /// Gets or sets current controller.
        /// </summary>
        protected TController CurrentController { get; set; }

        /// <summary>
        /// Gets or sets available controllers.
        /// </summary>
        protected Dictionary<Type, TController> Controllers { get; set; } = new Dictionary<Type, TController>();

        /// <inheritdoc/>
        public void Init(TController[] controllers)
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                Controllers.Add(controllers[i].ViewType, controllers[i]);
            }
        }

        /// <summary>
        /// Calls an event when controller is switched.
        /// </summary>
        /// <param name="receiver">New controller that will receive input events.</param>
        protected void OnControllerSwitched(IInputReceiver receiver)
        {
            ControllerSwitched?.Invoke(receiver);
        }
    }
}
