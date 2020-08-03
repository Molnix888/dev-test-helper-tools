using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DevTestHelperTools.Components.Elements
{
    /// <summary>
    /// Base for building SelectMenu element.
    /// </summary>
    /// <typeparam name="T">Option value type.</typeparam>
    public partial class SelectMenu<T>
    {
        private bool _isOpened = false;

        /// <summary>
        /// Gets or sets additional attributes to SelectMenu.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IEnumerable<KeyValuePair<string, object>> Attributes { get; set; }

        /// <summary>
        /// Gets or sets Id attribute to SelectMenu.
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets value attribute to SelectMenu.
        /// </summary>
        [Parameter]
        public T OptionValue { get; set; }

        /// <summary>
        /// Gets or sets notification about Option parameter being changed.
        /// </summary>
        [Parameter]
        public EventCallback<T> OptionValueChanged { get; set; }

        /// <summary>
        /// Gets or sets the child content to be rendering inside the SelectMenu.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets select menu arrow direction.
        /// </summary>
        public string ArrowStateClass => _isOpened ? "up" : "down";

        /// <summary>
        /// Toggles select menu arrow direction.
        /// </summary>
        public void ToggleArrow() => _isOpened = !_isOpened;

        /// <summary>
        /// Toggles select menu arrow direction down.
        /// </summary>
        public void ToggleArrowDown()
        {
            if (_isOpened)
            {
                ToggleArrow();
            }
        }

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
