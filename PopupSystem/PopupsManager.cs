using System;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.PopupSystem
{
    public partial class PopupsManager<TType, TResult> : Manager<IPopupController<TType, TResult>, TType>,
        IPopupsManager<TType, TResult>
        where TType : Enum
        where TResult : Enum
    {

        public static Action<IInputReceiver> OnControllerSwitch;

        public void ShowPopup(TType popupType, string message, Action<TResult> onHideAction = null, bool instant = false)
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