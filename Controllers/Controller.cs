using System;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core
{
    internal abstract partial class Controller<TViewCreator, TView, TType> : IController<TType>, IInputReceiver
        where TType : Enum
    {

        protected TViewCreator _viewCreator;
        protected TView _view;

        public abstract TType Type { get; }
        public bool CanReceivePhysicalInput { get; protected set; } // to prevent input processing during transitions

        public abstract void Init();
        public abstract void OnReturnButtonDown();
        public virtual void OnPauseButtonDown() { } // for in-game menu
        protected abstract void DestroyView();
        protected abstract void SetupElements();

    }
}