using System;
using System.Threading.Tasks;

namespace UISystem.Core.Views
{
    internal partial interface IView
    {

        void Init();
        Task Show(bool instant = false);
        Task Hide(bool instant = false);
        void DestroyView();
        void SwitchInteractability(bool enable);
        void FocusElement();

    }
}
