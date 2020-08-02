namespace DevTestHelperTools.Components.Common
{
    public partial class NavMenu
    {
        private bool _isCollapsed = true;

        public string NavMenuStateClass => _isCollapsed ? "collapsed" : "expanded";

        public void ToggleNavMenu() => _isCollapsed = !_isCollapsed;
    }
}
