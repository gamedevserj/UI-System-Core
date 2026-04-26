using System;
using System.Threading.Tasks;
using UISystem.Core.PhysicalInput;

namespace UISystem.Core.MenuSystem
{
    public partial interface IMenuController : IController, IInputReceiver
    {

        bool CanReturnToPreviousMenu { get; set; }

        Task Hide(StackingType stackingType, Action onComplete = null, bool instant = false);
        Task Show(Action onComplete = null, bool instant = false);
        void ProcessStacking(StackingType stackingType);

    }
}