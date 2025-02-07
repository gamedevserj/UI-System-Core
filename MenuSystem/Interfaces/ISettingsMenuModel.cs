namespace UISystem.Core.MenuSystem
{
    public partial interface ISettingsMenuModel : IMenuModel
    {

        bool HasUnappliedSettings { get; }

        void SaveSettings();
        void DiscardChanges();
        void ResetToDefault();

    }
}