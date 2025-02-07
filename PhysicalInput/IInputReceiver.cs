namespace UISystem.Core.PhysicalInput
{
    public partial interface IInputReceiver
    {

        bool CanReceivePhysicalInput { get; }

        void OnReturnButtonDown();
        void OnPauseButtonDown();

    }
}
