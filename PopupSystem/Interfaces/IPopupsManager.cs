using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.PopupSystem
{
    /// <summary>
    /// Defines the contract for popups manager.
    /// </summary>
    /// <typeparam name="TPopupResult">Type of result that popup can process. Must be <see cref="Enum"/>.</typeparam>
    public partial interface IPopupsManager<TPopupResult>
        where TPopupResult : Enum
    {
        /// <summary>
        /// Event to perform when controller is switched.
        /// </summary>
        event Action<IInputReceiver> OnControllerSwitch;

        /// <summary>
        /// Initializes the manager.
        /// </summary>
        /// <param name="controllers">Controllers that will be managed.</param>
        void Init(Dictionary<Type, IPopupController<TPopupResult>> controllers);

        /// <summary>
        /// Shows the popup.
        /// </summary>
        /// <param name="popupType">Type of popup. Define a common PopupView class and use typeof() with inherited classes.</param>
        /// <param name="message">Popup message.</param>
        /// <param name="onHideAction">Action to perform when popup is hidden.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task ShowPopup(Type popupType, string message, Action<TPopupResult> onHideAction = null, bool instant = false);

        /// <summary>
        /// Hides the popup.
        /// </summary>
        /// <param name="result">Result that was selected in popup.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task HidePopup(TPopupResult result, bool instant = false);
    }
}
