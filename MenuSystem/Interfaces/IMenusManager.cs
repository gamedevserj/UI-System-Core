using System;

namespace UISystem.Core.MenuSystem
{
    public partial interface IMenusManager<TMenuType>
        where TMenuType : Enum
    {

        void Init(IMenuController<TMenuType>[] controllers);
        void ShowMenu(TMenuType menuType, StackingType stackingType = StackingType.Add, Action onNewMenuShown = null, bool instant = false);
        void ReturnToPreviousMenu(Action onComplete = null, bool instant = false);

    }
}
