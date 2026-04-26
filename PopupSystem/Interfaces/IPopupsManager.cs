using System;
using System.Collections.Generic;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.PopupSystem
{
    public partial interface IPopupsManager<TPopupResult> where TPopupResult : Enum
    {
        event Action<IInputReceiver> OnControllerSwitch;

        void Init(Dictionary<Type, IPopupController<TPopupResult>> controllers);
        void ShowPopup(Type popupType, string message, Action<TPopupResult> onHideAction = null, bool instant = false);
        void HidePopup(TPopupResult result, bool instant = false);

    }
}
