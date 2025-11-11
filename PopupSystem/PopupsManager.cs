using System;
using System.Collections.Generic;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.PopupSystem
{
    public partial class PopupsManager<TResult> : Manager<IPopupController<TResult>>,
        IPopupsManager<TResult>
        where TResult : Enum
    {

        public static Action<IInputReceiver> OnControllerSwitch;

        public void ShowPopup(Type popupType, string message, Action<TResult> onHideAction = null, bool instant = false)
        {
            _currentController = new KeyValuePair<Type, IPopupController<TResult>>(popupType, _controllers[popupType]);
            _currentController?.Value.Init();
            _currentController?.Value.Show(message, (result) =>
            {
                OnControllerSwitch?.Invoke(null);
                onHideAction?.Invoke(result);
            }, instant);
            OnControllerSwitch?.Invoke(_currentController?.Value);
        }

        public void HidePopup(TResult result, bool instant = false)
        {
            _currentController?.Value.Hide(result, instant);
            _currentController = null;
        }

    }
}