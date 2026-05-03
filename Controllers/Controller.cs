using System;
using UISystem.Core.PhysicalInput;
using UISystem.Core.Views;

namespace UISystem.Core
{
    /// <summary>
    /// Common controller class. Is used for Menu and Popup controllers.
    /// </summary>
    /// <typeparam name="TViewCreator">Type of view creator.</typeparam>
    /// <typeparam name="TView">Type of view.</typeparam>
    internal abstract partial class Controller<TViewCreator, TView> : IController, IInputReceiver
        where TViewCreator : IViewCreator<TView>
        where TView : IView
    {
        /// <inheritdoc/>
        public Type ViewType => ViewCreator.ViewType;

        /// <summary>
        /// Gets or sets a value indicating whether controller can receive physical input (keyboard/joystick).
        /// </summary>
        public bool CanReceivePhysicalInput { get; protected set; } // to prevent input processing during transitions

        /// <summary>
        /// Gets or sets view creator.
        /// </summary>
        protected TViewCreator ViewCreator { get; set; }

        /// <summary>
        /// Gets or sets view.
        /// </summary>
        protected TView View { get; set; }

        /// <summary>
        /// Initializes controller.
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Action to perform when return button is pressed.
        /// </summary>
        public abstract void OnReturnButtonDown();

        /// <summary>
        /// Action to perform when pause button is pressed.
        /// </summary>
        public virtual void OnPauseButtonDown() // for in-game menu
        {
        }

        /// <summary>
        /// Destroys view.
        /// </summary>
        protected abstract void DestroyView();

        /// <summary>
        /// Sets up elements of the view.
        /// </summary>
        protected abstract void SetupElements();
    }
}
