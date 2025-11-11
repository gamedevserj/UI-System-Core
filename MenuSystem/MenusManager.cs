using System;
using System.Collections.Generic;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.MenuSystem
{
    public partial class MenusManager : Manager<IMenuController>, IMenusManager
    {

        public static Action<IInputReceiver> OnControllerSwitch;

        private readonly Stack<KeyValuePair<Type, IMenuController>?> _previousMenus = new Stack<KeyValuePair<Type, IMenuController>?>();

        public void ShowMenu(Type menuType, StackingType stackingType = StackingType.Add, Action onNewMenuShown = null, bool instant = false)
        {
            if (_currentController != null)
            {
                if (_currentController?.Key == menuType)
                    return;

                _currentController?.Value.Hide(
                    stackingType, 
                    () => ChangeMenu(menuType, stackingType, onNewMenuShown, instant), 
                    instant);
            }
            else
            {
                ChangeMenu(menuType, stackingType, onNewMenuShown, instant);
            }
        }

        public void ReturnToPreviousMenu(Action onComplete = null, bool instant = false)
        {
            if (_previousMenus.Count > 0)
            {
                ShowMenu(_previousMenus.Peek()?.Key, StackingType.Remove, onComplete, instant);
            }
        }

        private void ChangeMenu(Type menuType, StackingType stackingType, Action onNewMenuShown = null, bool instant = false)
        {
            var controller = new KeyValuePair<Type, IMenuController>(menuType, _controllers[menuType]);
            controller.Value.Init();

            switch (stackingType)
            {
                case StackingType.Add:
                    _previousMenus.Push(_currentController);
                    
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
            _currentController?.Value.ProcessStacking(stackingType);
            _currentController = controller;

            _currentController?.Value.Show(() =>
            {
                OnControllerSwitch?.Invoke(_currentController?.Value);
                onNewMenuShown?.Invoke();
            }, instant);
        }

    }
}
