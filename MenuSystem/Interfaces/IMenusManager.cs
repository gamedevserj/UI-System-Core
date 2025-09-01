using System;

namespace UISystem.Core.MenuSystem
{
    public partial interface IMenusManager
    {

        void Init(IMenuController[] controllers);
        void ShowMenu(Type menuType, StackingType stackingType = StackingType.Add, Action onNewMenuShown = null, bool instant = false);
        void ReturnToPreviousMenu(Action onComplete = null, bool instant = false);

    }
}
