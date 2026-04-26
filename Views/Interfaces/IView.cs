using System;
using System.Threading.Tasks;

namespace UISystem.Core.Views
{
    internal partial interface IView
    {

        void Init();
        Task Show(Action onShown, bool instant = false);
        Task Hide(Action onHidden, bool instant = false);
        void DestroyView();
        void SwitchInteractability(bool enable);
        void FocusElement();

    }
}
