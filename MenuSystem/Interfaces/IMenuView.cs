using UISystem.Core.Views;

namespace UISystem.Core.MenuSystem
{
    internal partial interface IMenuView<TInteractableElement> : IView
    {

        void SetLastSelectedElement(TInteractableElement lastSelectedElement);

    }
}