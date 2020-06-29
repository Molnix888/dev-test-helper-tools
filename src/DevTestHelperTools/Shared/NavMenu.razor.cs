// <copyright file="NavMenu.razor.cs" company="Eugene Klimeshuk (Molnix888)">
// Copyright (c) Eugene Klimeshuk (Molnix888). All rights reserved.
// </copyright>

namespace DevTestHelperTools.Shared
{
    public partial class NavMenu
    {
        private bool _isCollapsed = true;

        public string NavMenuStateClass => _isCollapsed ? "collapsed" : "expanded";

        public void ToggleNavMenu() => _isCollapsed = !_isCollapsed;
    }
}
