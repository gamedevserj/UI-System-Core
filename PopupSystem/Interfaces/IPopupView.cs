using UISystem.Core.Views;

namespace UISystem.Core.PopupSystem
{
    /// <summary>
    /// Defines the contract for popup view.
    /// </summary>
    public interface IPopupView : IView
    {
        /// <summary>
        /// Sets the popup message.
        /// </summary>
        /// <param name="message">Popup message.</param>
        void SetMessage(string message);
    }
}
