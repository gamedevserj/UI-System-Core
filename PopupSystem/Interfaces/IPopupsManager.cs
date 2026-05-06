using System;
using System.Threading.Tasks;

namespace UISystem.Core.PopupSystem
{
    /// <summary>
    /// Defines the contract for popups manager.
    /// </summary>
    public interface IPopupsManager : IManager<IPopupController>
    {
        /// <summary>
        /// Shows the popup.
        /// </summary>
        /// <typeparam name="TPopupView">Type of popup view. Must implement <see cref="IPopupView"/>.</typeparam>
        /// <param name="message">Popup message.</param>
        /// <param name="onHideAction">Action to perform when popup is hidden.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task ShowPopup<TPopupView>(string message, Action<PopupResult> onHideAction = null, bool instant = false)
            where TPopupView : IPopupView;

        /// <summary>
        /// Hides the popup.
        /// </summary>
        /// <param name="result">Result that was selected in popup.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task HidePopup(PopupResult result, bool instant = false);
    }
}
