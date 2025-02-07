using System;

namespace UISystem.Core.Transitions
{
    public partial interface IViewTransition
    {

        void Hide(Action onHidden, bool instant);
        void Show(Action onShown, bool instant);

    }
}
