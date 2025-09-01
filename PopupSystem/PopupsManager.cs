using System;
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
            _currentController = _controllers[popupType];
            _currentController.Init();
            _currentController.Show(message, (result) =>
            {
                OnControllerSwitch?.Invoke(null);
                onHideAction?.Invoke(result);
            }, instant);
            OnControllerSwitch?.Invoke(_currentController);
        }

        public void HidePopup(TResult result, bool instant = false)
        {
            _currentController?.Hide(result, instant);
            _currentController = null;
        }

    }
}