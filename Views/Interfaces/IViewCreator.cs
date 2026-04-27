namespace UISystem.Core.Views
{
    /// <summary>
    /// Defines the contract for view creator.
    /// </summary>
    /// <typeparam name="TView">Type of view to create.</typeparam>
    internal partial interface IViewCreator<out TView>
    {
        /// <summary>
        /// Gets a value indicating whether view is valid.
        /// </summary>
        bool IsViewValid { get; }

        /// <summary>
        /// Creates the view.
        /// </summary>
        /// <returns>Instance of the view.</returns>
        TView CreateView();

        /// <summary>
        /// Destroys the view.
        /// </summary>
        void DestroyView();
    }
}
