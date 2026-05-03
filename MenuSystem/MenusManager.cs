using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// A class to manage menu controllers.
    /// </summary>
    public partial class MenusManager : Manager<IMenuController>, IMenusManager
    {
        private readonly Stack<IMenuController> _previousMenus = new();

        /// <inheritdoc/>
        public async Task ShowMenu(Type menuType, StackingType stackingType = StackingType.Add, Action onNewMenuShown = null, bool instant = false)
        {
            if (CurrentController != null)
            {
                if (CurrentController.ViewType == menuType)
                    return;

                await CurrentController.Hide(
                    stackingType,
                    async () => await ChangeMenu(menuType, stackingType, onNewMenuShown, instant),
                    instant);
            }
            else
            {
                await ChangeMenu(menuType, stackingType, onNewMenuShown, instant);
            }
        }

        /// <inheritdoc/>
        public async Task ReturnToPreviousMenu(Action onComplete = null, bool instant = false)
        {
            if (_previousMenus.Count > 0)
            {
                await ShowMenu(_previousMenus.Peek().ViewType, StackingType.Remove, onComplete, instant);
            }
        }

        private async Task ChangeMenu(Type menuType, StackingType stackingType, Action onNewMenuShown = null, bool instant = false)
        {
            var controller = Controllers[menuType];
            controller.Init();

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
                        menuController.ProcessStacking(stackingType);
                    }

                    _previousMenus.Clear();
                    break;
                case StackingType.Replace:
                    break;
                default:
                    break;
            }

            CurrentController?.ProcessStacking(stackingType);
            CurrentController = controller;

            await CurrentController.Show(
                () =>
                {
                    OnControllerSwitched(CurrentController);
                    onNewMenuShown?.Invoke();
                },
                instant);
        }
    }
}
