// <copyright file="SelectMenu.cs" company="Eugene Klimeshuk (Molnix888)">
// Copyright (c) Eugene Klimeshuk (Molnix888). All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Components.Web;

namespace DevTestHelperTools.Elements
{
    /// <summary>
    /// Base for defining select menu behavior.
    /// </summary>
    public class SelectMenu
    {
        private bool isOpened = false;

        /// <summary>
        /// Gets select menu arrow direction.
        /// </summary>
        public string SelectMenuIconClass => this.isOpened ? "up" : "down";

        /// <summary>
        /// Toggles select menu arrow direction.
        /// </summary>
        public void ToggleArrow() => this.isOpened = !this.isOpened;

        /// <summary>
        /// Toggles select menu arrow direction down.
        /// </summary>
        public void ToggleArrowClosed() => this.isOpened = false;

        /// <summary>
        /// Toggles select menu arrow direction on keys input.
        /// </summary>
        /// <param name="e">Keyboard event argument.</param>
        public void ToggleArrowOnKeys(KeyboardEventArgs e)
        {
            if ((this.isOpened && (e?.Key == "Escape" || e?.Key == "Enter")) || (!this.isOpened && e?.Key == " "))
            {
                this.ToggleArrow();
            }
        }
    }
}
