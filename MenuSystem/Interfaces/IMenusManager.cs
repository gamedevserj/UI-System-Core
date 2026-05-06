using System.Threading.Tasks;

namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// Defines the contract for menus manager.
    /// </summary>
    public interface IMenusManager : IManager<IMenuController>
    {
        /// <summary>
        /// Shows the menu.
        /// </summary>
        /// <typeparam name="TMenuView">Type of menu view. Must implement <see cref="IMenuView"/>.</typeparam>
        /// <param name="stackingType">How should menu stack.</param>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task ShowMenu<TMenuView>(StackingType stackingType = StackingType.Add, bool instant = false)
            where TMenuView : IMenuView;

        /// <summary>
        /// Returns to previous menu.
        /// </summary>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task ReturnToPreviousMenu(bool instant = false);
    }
}
