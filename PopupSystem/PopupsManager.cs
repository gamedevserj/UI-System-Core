using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.PopupSystem
{
    /// <summary>
    /// A class to manage popup controllers.
    /// </summary>
    /// <typeparam name="TResult">Type of result available in popup.</typeparam>
    public partial class PopupsManager : Manager<IPopupController>, IPopupsManager
    {
        /// <inheritdoc/>
        public event Action<IInputReceiver> OnControllerSwitch;

        /// <inheritdoc/>
        public async Task ShowPopup(Type popupType, string message, Action<PopupResult> onHideAction = null, bool instant = false)
        {
            CurrentController = new KeyValuePair<Type, IPopupController>(popupType, Controllers[popupType]);
            CurrentController?.Value.Init();
            await CurrentController?.Value.Show(
                message,
                (result) =>
                {
                    OnControllerSwitch?.Invoke(null);
                    onHideAction?.Invoke(result);
                },
                instant);
            OnControllerSwitch?.Invoke(CurrentController?.Value);
        }

        /// <inheritdoc/>
        public async Task HidePopup(PopupResult result, bool instant = false)
        {
            await CurrentController?.Value.Hide(result, instant);
            CurrentController = null;
        }
    }
}
