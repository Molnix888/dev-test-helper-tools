using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace DevTestHelperTools.Components.Elements
{
    /// <inheritdoc/>
    public class SelectMenu<TValue> : InputSelect<TValue>
    {
        private bool _isOpened;

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

        /// <inheritdoc/>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (builder != null)
            {
                var seq = 0;

                builder.OpenElement(seq, "select");
                builder.AddMultipleAttributes(++seq, AdditionalAttributes);
                builder.AddAttribute(++seq, "class", CssClass);
                builder.AddAttribute(++seq, "value", BindConverter.FormatValue(CurrentValueAsString));
                builder.AddAttribute(++seq, "onchange", EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString));
                builder.AddAttribute(++seq, "onclick", EventCallback.Factory.Create(this, ToggleArrow));
                builder.AddAttribute(++seq, "onfocusout", EventCallback.Factory.Create(this, ToggleArrowDown));
                builder.AddAttribute(++seq, "onkeydown", EventCallback.Factory.Create(this, ToggleArrowOnKeys));
                builder.AddAttribute(++seq, "onkeyup", EventCallback.Factory.Create(this, ToggleArrowOnKeys));
                builder.AddContent(++seq, ChildContent);
                builder.CloseElement();
                builder.OpenElement(++seq, "i");
                builder.AddAttribute(++seq, "class", $"fas fa-chevron-{ArrowStateClass}");
                builder.CloseElement();
            }
        }
    }
}
