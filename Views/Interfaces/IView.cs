using System;

namespace UISystem.Core.Views
{
    internal partial interface IView
    {

        void Init();
        void Show(Action onShown, bool instant = false);
        void Hide(Action onHidden, bool instant = false);
        void DestroyView();
        void SwitchFocusAvailability(bool enable);
        void FocusElement();

    }
}
