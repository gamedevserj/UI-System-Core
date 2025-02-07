namespace UISystem.Core.Views
{
    internal partial interface IViewCreator<TView>
    {

        bool IsViewValid { get; }
        TView CreateView();
        void DestroyView();

    }
}
