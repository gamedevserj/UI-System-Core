using System;
using System.Threading.Tasks;

namespace UISystem.Core.PopupSystem
{
    /// <summary>
    /// A class to manage popup controllers.
    /// </summary>
    /// <typeparam name="TResult">Type of result available in popup.</typeparam>
    public partial class PopupsManager : Manager<IPopupController>, IPopupsManager
    {
        /// <inheritdoc/>
        public async Task ShowPopup(Type popupType, string message, Action<PopupResult> onHideAction = null, bool instant = false)
        {
            CurrentController = Controllers[popupType];
            CurrentController.Init();
            await CurrentController.Show(
                message,
                (result) =>
                {
                    OnControllerSwitched(null);
                    onHideAction?.Invoke(result);
                },
                instant);
            OnControllerSwitched(CurrentController);
        }

        /// <inheritdoc/>
        public async Task HidePopup(PopupResult result, bool instant = false)
        {
            await CurrentController.Hide(result, instant);
            CurrentController = null;
        }
    }
}
