using System.Threading.Tasks;

namespace UISystem.Core.Transitions
{
    public partial interface IViewTransition
    {

        Task Hide(bool instant = false);
        Task Show(bool instant = false);

    }
}
