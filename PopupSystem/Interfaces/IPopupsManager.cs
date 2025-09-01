using System;

namespace UISystem.Core.PopupSystem
{
    public partial interface IPopupsManager<TPopupResult> where TPopupResult : Enum
    {
        void Init(IPopupController<TPopupResult>[] controllers);
        void ShowPopup(Type popupType, string message, Action<TPopupResult> onHideAction = null, bool instant = false);
        void HidePopup(TPopupResult result, bool instant = false);

    }
}
