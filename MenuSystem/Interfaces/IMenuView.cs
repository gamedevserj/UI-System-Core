using UISystem.Core.Elements;
using UISystem.Core.Views;

namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// Defines the contract for menu view.
    /// </summary>
    internal partial interface IMenuView : IView
    {
        /// <summary>
        /// Sets the element that was last interacted with.
        /// </summary>
        /// <param name="lastSelectedElement">Element that was last interacted with.</param>
        void SetLastSelectedElement(IInteractableElement lastSelectedElement);
    }
}
