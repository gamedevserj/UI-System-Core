using System;
using System.Threading.Tasks;

namespace UISystem.Core.PopupSystem
{
    /// <summary>
    /// Defines the contract for popups manager.
    /// </summary>
    public partial interface IPopupsManager : IManager<IPopupController>
    {
        /// <summary>
        /// Shows the popup.
        /// </summary>
        /// <param name="popupType">Type of popup. Define a common PopupView class and use typeof() with inherited classes.</param>
        /// <param name="message">Popup message.</param>
        /// <param name="onHideAction">Action to perform when popup is hidden.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task ShowPopup(Type popupType, string message, Action<PopupResult> onHideAction = null, bool instant = false);

        /// <summary>
        /// Hides the popup.
        /// </summary>
        /// <param name="result">Result that was selected in popup.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task HidePopup(PopupResult result, bool instant = false);
    }
}
