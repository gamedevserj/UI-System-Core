namespace UISystem.Core.MenuSystem
{
    /// <summary>
    /// Defines the contract for settings menu model.
    /// </summary>
    public partial interface ISettingsMenuModel : IMenuModel
    {
        /// <summary>
        /// Gets a value indicating whether menu has unapplied settings.
        /// </summary>
        bool HasUnappliedSettings { get; }

        /// <summary>
        /// Saves settings.
        /// </summary>
        void SaveSettings();

        /// <summary>
        /// Discards unapplied settings.
        /// </summary>
        void DiscardChanges();

        /// <summary>
        /// Resets settings to default.
        /// </summary>
        void ResetToDefault();
    }
}
