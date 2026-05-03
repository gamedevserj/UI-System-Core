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
        public async Task ShowMenu<TMenuView>(StackingType stackingType = StackingType.Add, bool instant = false)
            where TMenuView : IMenuView
        {
            var type = typeof(TMenuView);
            if (CurrentController != null)
            {
                if (CurrentController.ViewType == type)
                    return;

                await CurrentController.Hide(stackingType, instant: instant);
            }

            await ChangeMenu(type, stackingType, instant);
        }

        /// <inheritdoc/>
        public async Task ReturnToPreviousMenu(bool instant = false)
        {
            if (_previousMenus.Count > 0)
            {
                var type = _previousMenus.Peek().ViewType;
                await CurrentController.Hide(StackingType.Remove, instant: instant);
                await ChangeMenu(type, StackingType.Remove, instant);
            }
        }

        private async Task ChangeMenu(Type menuType, StackingType stackingType, bool instant = false)
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
                    // no need to do anything, current controller will be replaced
                    break;
                default:
                    break;
            }

            CurrentController?.ProcessStacking(stackingType);
            CurrentController = controller;

            await CurrentController.Show(instant: instant);
            OnControllerSwitched(CurrentController);
        }
    }
}
