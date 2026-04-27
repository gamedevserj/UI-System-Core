using System.Threading.Tasks;

namespace UISystem.Core.Views
{
    /// <summary>
    /// Defines the contract for view interface.
    /// </summary>
    internal partial interface IView
    {
        /// <summary>
        /// Initializes the view.
        /// </summary>
        void Init();

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Show(bool instant = false);

        /// <summary>
        /// Hides the view.
        /// </summary>
        /// <param name="instant">Whether transition should happen instantly.</param>
        Task Hide(bool instant = false);

        /// <summary>
        /// Destroys the view.
        /// </summary>
        void DestroyView();

        /// <summary>
        /// Switches view's interactability.
        /// </summary>
        /// <param name="enable">Whether view should be interactable.</param>
        void SwitchInteractability(bool enable);

        /// <summary>
        /// Focuses an element.
        /// </summary>
        void FocusElement();
    }
}
