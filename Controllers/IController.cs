using System;

namespace UISystem.Core
{
    /// <summary>
    /// Defines the contract for common controllers.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Gets view type.
        /// </summary>
        Type ViewType { get; }

        /// <summary>
        /// Initializes controller.
        /// </summary>
        void Init();
    }
}
