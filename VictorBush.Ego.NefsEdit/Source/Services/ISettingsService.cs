﻿// See LICENSE.txt for license information.

namespace VictorBush.Ego.NefsEdit.Services
{
    /// <summary>
    /// Settings service.
    /// </summary>
    internal interface ISettingsService
    {
        /// <summary>
        /// Gets the quick extract directory.
        /// </summary>
        string QuickExtractDir { get; }

        /// <summary>
        /// Shows a dialog to choose the quick extract dir.
        /// </summary>
        /// <returns>True if the directory was chosen.</returns>
        bool ChooseQuickExtractDir();
    }
}
