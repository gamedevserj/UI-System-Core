using System;

namespace UISystem.Core.Views
{
    /// <summary>
    /// Generic class for view creators.
    /// </summary>
    /// <typeparam name="TPrefab">Type of view prefab.</typeparam>
    /// <typeparam name="TView">Type of view.</typeparam>
    /// <typeparam name="TParent">Type of parent.</typeparam>
    internal abstract partial class ViewCreator<TPrefab, TView, TParent> : IViewCreator<TView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewCreator{TPrefab, TView, TParent}"/> class.
        /// </summary>
        /// <param name="prefab">View prefab.</param>
        /// <param name="parent">View parent.</param>
        protected ViewCreator(TPrefab prefab, TParent parent)
        {
            Prefab = prefab;
            Parent = parent;
        }

        /// <inheritdoc/>
        public Type ViewType => typeof(TView);

        /// <inheritdoc/>
        public abstract bool IsViewValid { get; }

        /// <summary>
        /// Gets or sets a view.
        /// </summary>
        protected TView View { get; set; }

        /// <summary>
        /// Gets the view prefab.
        /// </summary>
        protected TPrefab Prefab { get; private set; }

        /// <summary>
        /// Gets the view parent.
        /// </summary>
        protected TParent Parent { get; private set; }

        /// <inheritdoc/>
        public abstract TView CreateView();

        /// <inheritdoc/>
        public abstract void DestroyView();
    }
}
