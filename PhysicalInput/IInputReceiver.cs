namespace UISystem.Core.PhysicalInput
{
    /// <summary>
    /// Defines the contract for input receiver.
    /// </summary>
    public partial interface IInputReceiver
    {
        /// <summary>
        /// Gets a value indicating whether receiver can receive physical input.
        /// </summary>
        bool CanReceivePhysicalInput { get; }

        /// <summary>
        /// Action to perform when return button is pressed.
        /// </summary>
        void OnReturnButtonDown();

        /// <summary>
        /// Action to perform when pause button is pressed.
        /// </summary>
        void OnPauseButtonDown();
    }
}
