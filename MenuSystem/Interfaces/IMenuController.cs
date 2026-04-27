using System;
using System.Threading.Tasks;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// Defines the contract for menu controller.
    /// </summary>
    public partial interface IMenuController : IController, IInputReceiver
    {
        /// <summary>
        /// Gets or sets a value indicating whether controller can return to previous menu.
        /// </summary>
        bool CanReturnToPreviousMenu { get; set; }

        /// <summary>
        /// Hides the view.
        /// </summary>
        /// <param name="stackingType">Type of stacking.</param>
        /// <param name="onComplete">Action to perform when view is hidden.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Hide(StackingType stackingType, Action onComplete = null, bool instant = false);

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <param name="onComplete">Action to perform when view is shown.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Show(Action onComplete = null, bool instant = false);

        /// <summary>
        /// Controls the view based on staicking type.
        /// </summary>
        /// <param name="stackingType">Type of stacking.</param>
        void ProcessStacking(StackingType stackingType);
    }
}
