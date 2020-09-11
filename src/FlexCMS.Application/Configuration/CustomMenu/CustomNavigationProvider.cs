using Abp.Application.Navigation;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexCMS.Configuration.CustomMenu
{
    public class CustomNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
            .AddItem(
                new MenuItemDefinition(
                    "Tasks",
                    new LocalizableString("Tasks", "SimpleTaskSystem"),
                    url: "/Tasks",
                    icon: "fa fa-tasks"
                    )
            ).AddItem(
                new MenuItemDefinition(
                    "Reports",
                    new LocalizableString("Reports", "SimpleTaskSystem"),
                    url: "/Reports",
                    icon: "fa fa-bar-chart"
                    )
            ).AddItem(
                new MenuItemDefinition(
                    "Administration",
                    new LocalizableString("Administration", "SimpleTaskSystem"),
                    icon: "fa fa-cogs"
                    ).AddItem(
                        new MenuItemDefinition(
                            "UserManagement",
                            new LocalizableString("UserManagement", "SimpleTaskSystem"),
                            url: "/Administration/Users",
                            icon: "fa fa-users",
                            requiredPermissionName: "SimpleTaskSystem.Permissions.UserManagement"
                            )
                    ).AddItem(
                        new MenuItemDefinition(
                            "RoleManagement",
                            new LocalizableString("RoleManagement", "SimpleTaskSystem"),
                            url: "/Administration/Roles",
                            icon: "fa fa-star",
                            requiredPermissionName: "SimpleTaskSystem.Permissions.RoleManagement"
                            )
                    )
            );
        }
    }
}
