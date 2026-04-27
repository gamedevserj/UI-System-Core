using UISystem.Core.Views;

namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// Defines the contracto for menu view.
    /// </summary>
    /// <typeparam name="TInteractableElement">Type of interactable element.</typeparam>
    internal partial interface IMenuView<in TInteractableElement> : IView
    {
        /// <summary>
        /// Sets the element that was last interacted with.
        /// </summary>
        /// <param name="lastSelectedElement">Element that was last interacted with.</param>
        void SetLastSelectedElement(TInteractableElement lastSelectedElement);
    }
}
