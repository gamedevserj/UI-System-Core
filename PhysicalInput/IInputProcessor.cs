namespace UISystem.Core.PhysicalInput
{
    /// <summary>
    /// Defines the contract for input processor.
    /// </summary>
    /// <typeparam name="TInputEvent">Type of event to process.</typeparam>
    public interface IInputProcessor<in TInputEvent>
    {
        /// <summary>
        /// Processes input.
        /// </summary>
        /// <param name="input">Input event to process.</param>
        void ProcessInput(TInputEvent input);
    }
}
