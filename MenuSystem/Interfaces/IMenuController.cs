using System.Threading.Tasks;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// Defines the contract for menu controller.
    /// </summary>
    public interface IMenuController : IController, IInputReceiver
    {
        /// <summary>
        /// Gets or sets a value indicating whether controller can return to previous menu.
        /// </summary>
        bool CanReturnToPreviousMenu { get; set; }

        /// <summary>
        /// Hides the view.
        /// </summary>
        /// <param name="stackingType">Type of stacking.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Hide(StackingType stackingType, bool instant = false);

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Show(bool instant = false);

        /// <summary>
        /// Controls the view based on staicking type.
        /// </summary>
        /// <param name="stackingType">Type of stacking.</param>
        void ProcessStacking(StackingType stackingType);
    }
}
