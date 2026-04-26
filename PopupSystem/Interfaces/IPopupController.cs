using System;
using System.Threading.Tasks;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.PopupSystem
{
    public partial interface IPopupController<TResult> : IController, IInputReceiver where TResult : Enum
    {

        Task Hide(TResult result, bool instant = false);
        Task Show(string message, Action<TResult> onHideAction, bool instant = false);

    }
}