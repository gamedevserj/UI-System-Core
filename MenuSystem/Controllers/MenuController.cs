using System;
using System.Threading.Tasks;
using UISystem.Core.Views;

namespace UISystem.Core.MenuSystem
{
    internal abstract partial class MenuController<TViewCreator, TView, TInteractableElement>
        : Controller<TViewCreator, TView>, IMenuController
        where TViewCreator : IViewCreator<TView>
        where TView : IMenuView<TInteractableElement>
    {
        protected readonly IMenusManager _menusManager;

        // when you want to temporarly disable retuning to previous menu, i.e. when player is rebinding keys
        public bool CanReturnToPreviousMenu { get; set; } = true;

        protected MenuController(TViewCreator viewCreator, IMenusManager menusManager)
        {
            _viewCreator = viewCreator;
            _menusManager = menusManager;
        }

        public override void Init()
        {
            if (!_viewCreator.IsViewValid)
            {
                _view = _viewCreator.CreateView();
                SetupElements();
            }
        }

        public virtual async Task Show(Action onComplete = null, bool instant = false)
        {
            CanReceivePhysicalInput = false;
            await _view.Show(instant);
            onComplete?.Invoke();
            _view.FocusElement();
            CanReceivePhysicalInput = true;
        }

        public virtual async Task Hide(StackingType stackingType, Action onComplete = null, bool instant = false)
        {
            CanReceivePhysicalInput = false;
            await _view.Hide(instant);
            onComplete?.Invoke();
        }

        public virtual void ProcessStacking(StackingType stackingType)
        {
            switch (stackingType)
            {
                case StackingType.Add:
                    break;
                case StackingType.Remove:
                    DestroyView();
                    break;
                case StackingType.Clear:
                    DestroyView();
                    break;
                case StackingType.Replace:
                    DestroyView();
                    break;
                default:
                    break;
            }
        }
        protected override void DestroyView() => _viewCreator.DestroyView();

        // when showing popups
        protected void SwitchInteractability(bool enable)
        {
            _view.SwitchInteractability(enable);
            if (enable)
                _view.FocusElement();
        }

        public override void OnReturnButtonDown()
        {
            if (CanReturnToPreviousMenu)
                _menusManager.ReturnToPreviousMenu();
        }

    }
}