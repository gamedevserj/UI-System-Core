using System;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using UISystem.Core.Views;

namespace UISystem.Core.PopupSystem
{
    /// <summary>
    /// Popup controller.
    /// </summary>
    /// <typeparam name="TViewCreator">Type of view creator. Must implement <see cref="IViewCreator{TView}"/>.</typeparam>
    /// <typeparam name="TView">Type of view. Must implement <see cref="IPopupView"/>.</typeparam>
    /// <typeparam name="TResult">Type of popup result. Must be of <see cref="Enum"/>.</typeparam>
    internal abstract partial class PopupController<TViewCreator, TView, TResult>
        : Controller<TViewCreator, TView>, IPopupController<TResult>
        where TViewCreator : IViewCreator<TView>
        where TView : IPopupView
        where TResult : Enum
    {
        private Action<TResult> _onHideAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="PopupController{TViewCreator, TView, TResult}"/> class.
        /// </summary>
        /// <param name="viewCreator">View creator.</param>
        /// <param name="popupsManager">Popups manager.</param>
        protected PopupController(TViewCreator viewCreator, IPopupsManager<TResult> popupsManager)
        {
            ViewCreator = viewCreator;
            PopupsManager = popupsManager;
        }

        /// <summary>
        /// Gets result chosen if pressed return button.
        /// </summary>
        public abstract TResult PressedReturnPopupResult { get; }

        /// <summary>
        /// Gets the popups manager.
        /// </summary>
        protected IPopupsManager<TResult> PopupsManager { get; private set; }

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
        public async Task Show(string message, Action<TResult> onHideAction, bool instant = false)
        {
            CanReceivePhysicalInput = false;
            View.SetMessage(message);
            _onHideAction = onHideAction;
            await View.Show(instant);
            CanReceivePhysicalInput = true;
            View.FocusElement();
        }

        /// <inheritdoc/>
        public async Task Hide(TResult result, bool instant = false)
        {
            CanReceivePhysicalInput = false;
            await View.Hide(instant);
            _onHideAction?.Invoke(result);
            DestroyView();
        }

        /// <inheritdoc/>
        public override void OnReturnButtonDown()
        {
            PopupsManager.HidePopup(PressedReturnPopupResult).SafeFireAndForget();
        }

        /// <inheritdoc/>
        protected override void DestroyView() => ViewCreator.DestroyView();
    }
}
