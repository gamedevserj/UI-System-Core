using System;
using System.Collections.Generic;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// A class to manage menu controllers.
    /// </summary>
    public partial class MenusManager : Manager<IMenuController>, IMenusManager
    {
        private readonly Stack<KeyValuePair<Type, IMenuController>?> _previousMenus = new Stack<KeyValuePair<Type, IMenuController>?>();

        /// <summary>
        /// Event to perform when controller is switched.
        /// </summary>
        public event Action<IInputReceiver> OnControllerSwitch;

        /// <inheritdoc/>
        public void ShowMenu(Type menuType, StackingType stackingType = StackingType.Add, Action onNewMenuShown = null, bool instant = false)
        {
            if (CurrentController != null)
            {
                if (CurrentController?.Key == menuType)
                    return;

                CurrentController?.Value.Hide(
                    stackingType,
                    () => ChangeMenu(menuType, stackingType, onNewMenuShown, instant),
                    instant);
            }
            else
            {
                ChangeMenu(menuType, stackingType, onNewMenuShown, instant);
            }
        }

        /// <inheritdoc/>
        public void ReturnToPreviousMenu(Action onComplete = null, bool instant = false)
        {
            if (_previousMenus.Count > 0)
            {
                ShowMenu(_previousMenus.Peek()?.Key, StackingType.Remove, onComplete, instant);
            }
        }

        private void ChangeMenu(Type menuType, StackingType stackingType, Action onNewMenuShown = null, bool instant = false)
        {
            var controller = new KeyValuePair<Type, IMenuController>(menuType, Controllers[menuType]);
            controller.Value.Init();

            switch (stackingType)
            {
                case StackingType.Add:
                    _previousMenus.Push(CurrentController);
                    break;
                case StackingType.Remove:
                    _previousMenus.Pop();
                    break;
                case StackingType.Clear:
                    foreach (var menuController in _previousMenus)
                    {
                        menuController?.Value.ProcessStacking(stackingType);
                    }

                    _previousMenus.Clear();
                    break;
                case StackingType.Replace:
                    break;
                default:
                    break;
            }

            CurrentController?.Value.ProcessStacking(stackingType);
            CurrentController = controller;

            CurrentController?.Value.Show(
                () =>
                {
                    OnControllerSwitch?.Invoke(CurrentController?.Value);
                    onNewMenuShown?.Invoke();
                },
                instant);
        }
    }
}
