using Microsoft.AspNetCore.Components.Web;

namespace DevTestHelperTools.Elements
{
    /// <summary>
    /// Base for defining select menu behavior.
    /// </summary>
    public class SelectMenu
    {
        private bool _isOpened = false;

        /// <summary>
        /// Gets select menu arrow direction.
        /// </summary>
        public string SelectMenuIconClass => _isOpened ? "up" : "down";

        /// <summary>
        /// Toggles select menu arrow direction.
        /// </summary>
        public void ToggleArrow() => _isOpened = !_isOpened;

        /// <summary>
        /// Toggles select menu arrow direction down.
        /// </summary>
        public void ToggleArrowClosed() => _isOpened = false;

        /// <summary>
        /// Toggles select menu arrow direction on keys input.
        /// </summary>
        /// <param name="e">Keyboard event argument.</param>
        public void ToggleArrowOnKeys(KeyboardEventArgs e)
        {
            if ((_isOpened && (e?.Key == "Escape" || e?.Key == "Enter")) || (!_isOpened && e?.Key == " "))
            {
                ToggleArrow();
            }
        }
    }
}
