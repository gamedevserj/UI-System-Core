using System.Threading.Tasks;

namespace UISystem.Core.Transitions
{
    /// <summary>
    /// Defines the contract for view transition.
    /// </summary>
    public interface IViewTransition
    {
        /// <summary>
        /// Hides the view.
        /// </summary>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Hide(bool instant = false);

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Show(bool instant = false);
    }
}
