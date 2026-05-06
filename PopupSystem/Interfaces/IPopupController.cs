using System;
using System.Threading.Tasks;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.PopupSystem
{
    /// <summary>
    /// Defines the contract for popup controller.
    /// </summary>
    public interface IPopupController : IController, IInputReceiver
    {
        /// <summary>
        /// Hides popup.
        /// </summary>
        /// <param name="result">Type of result that was chosen.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Hide(PopupResult result, bool instant = false);

        /// <summary>
        /// Shows popup.
        /// </summary>
        /// <param name="message">Popup message.</param>
        /// <param name="onHideAction">Action to perform when popup is closed.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Show(string message, Action<PopupResult> onHideAction, bool instant = false);
    }
}
