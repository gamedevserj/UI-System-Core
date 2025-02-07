using System;

namespace UISystem.Core.PopupSystem
{
    public partial interface IPopupsManager<TPopupType, TPopupResult>
        where TPopupType : Enum
        where TPopupResult : Enum
    {
        void Init(IPopupController<TPopupType, TPopupResult>[] controllers);
        void ShowPopup(TPopupType popupType, string message, Action<TPopupResult> onHideAction = null, bool instant = false);
        void HidePopup(TPopupResult result, bool instant = false);

    }
}
