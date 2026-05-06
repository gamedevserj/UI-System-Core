using System;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using UISystem.Core.Views;

namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// Generic class for menu controllers.
    /// </summary>
    /// <typeparam name="TViewCreator">Type of view creator. Must implement <see cref="IViewCreator{TView}"/>.</typeparam>
    /// <typeparam name="TView">Type of view.Must implement <see cref="IMenuView"/>.</typeparam>
    internal abstract class MenuController<TViewCreator, TView>
        : Controller<TViewCreator, TView>, IMenuController
        where TViewCreator : IViewCreator<TView>
        where TView : IMenuView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuController{TViewCreator, TView}"/> class.
        /// </summary>
        /// <param name="viewCreator">View creator.</param>
        /// <param name="menusManager">Menus manager.</param>
        protected MenuController(TViewCreator viewCreator, IMenusManager menusManager)
        {
            ViewCreator = viewCreator;
            MenusManager = menusManager;
        }

        /// <inheritdoc/>
        public bool CanReturnToPreviousMenu { get; set; } = true; // when you want to temporarly disable retuning to previous menu, i.e. when player is rebinding keys

        /// <summary>
        /// Gets menus manager.
        /// </summary>
        protected IMenusManager MenusManager { get; private set; }

        /// <inheritdoc/>
        public override void Init()
        {
            if (!ViewCreator.IsViewValid)
            {
                View = ViewCreator.CreateView();
                SetupElements();
            }
        }

        /// <inheritdoc/>
        public virtual async Task Show(bool instant = false)
        {
            CanReceivePhysicalInput = false;
            await View.Show(instant);
            View.FocusElement();
            CanReceivePhysicalInput = true;
        }

        /// <inheritdoc/>
        public virtual async Task Hide(StackingType stackingType, bool instant = false)
        {
            CanReceivePhysicalInput = false;
            await View.Hide(instant);
        }

        /// <inheritdoc/>
        public virtual void ProcessStacking(StackingType stackingType)
        {
            if (stackingType == StackingType.Remove || stackingType == StackingType.Clear || stackingType == StackingType.Replace)
                DestroyView();
        }

        /// <inheritdoc/>
        public override void OnReturnButtonDown()
        {
            if (CanReturnToPreviousMenu)
                MenusManager.ReturnToPreviousMenu().SafeFireAndForget();
        }

        /// <inheritdoc/>
        protected override void DestroyView() => ViewCreator.DestroyView();

        /// <summary>
        /// Switches menu interactability (i.e. when showing popups).
        /// </summary>
        /// <param name="enable">Whether to enable or disable menu interactability.</param>
        protected void SwitchInteractability(bool enable)
        {
            View.SwitchInteractability(enable);
            if (enable)
                View.FocusElement();
        }
    }
}
