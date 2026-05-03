using System;
using System.Threading.Tasks;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// Defines the contract for menus manager.
    /// </summary>
    public partial interface IMenusManager : IManager<IMenuController>
    {
        /// <summary>
        /// Shows the menu.
        /// </summary>
        /// <param name="menuType">Type of menu. Define a common MenuView class and use typeof() with inherited classes.</param>
        /// <param name="stackingType">How should menu stack.</param>
        /// <param name="onNewMenuShown">Action to perform when menu is shown.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task ShowMenu(Type menuType, StackingType stackingType = StackingType.Add, Action onNewMenuShown = null, bool instant = false);

        /// <summary>
        /// Returns to previous menu.
        /// </summary>
        /// <param name="onComplete">Action to perform when returned.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task ReturnToPreviousMenu(Action onComplete = null, bool instant = false);
    }
}
