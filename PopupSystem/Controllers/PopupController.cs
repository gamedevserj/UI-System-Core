using System;
using System.Threading.Tasks;
using UISystem.Core.Views;

namespace UISystem.Core.PopupSystem
{
    internal abstract partial class PopupController<TViewCreator, TView, TResult>
        : Controller<TViewCreator, TView>, IPopupController<TResult>
        where TViewCreator : IViewCreator<TView>
        where TView : IPopupView
        where TResult : Enum
    {

        protected Action<TResult> _onHideAction;

        protected readonly IPopupsManager<TResult> _popupsManager;

        public abstract TResult PressedReturnPopupResult { get; }

        public PopupController(TViewCreator viewCreator, IPopupsManager<TResult> popupsManager)
        {
            _viewCreator = viewCreator;
            _popupsManager = popupsManager;
        }

        public override void Init()
        {
            if (!_viewCreator.IsViewValid)
            {
                _view = _viewCreator.CreateView();
                SetupElements();
            }
        }

        public async Task Show(string message, Action<TResult> onHideAction, bool instant = false)
        {
            CanReceivePhysicalInput = false;
            _view.SetMessage(message);
            _onHideAction = onHideAction;
            await _view.Show(instant);
            CanReceivePhysicalInput = true;
            _view.FocusElement();
        }

        public async Task Hide(TResult result, bool instant = false)
        {
            CanReceivePhysicalInput = false;
            await _view.Hide(instant);
            _onHideAction?.Invoke(result);
            DestroyView();
        }
        protected override void DestroyView() => _viewCreator.DestroyView();

        public override void OnReturnButtonDown()
        {
            _popupsManager.HidePopup(PressedReturnPopupResult);
        }

    }
}