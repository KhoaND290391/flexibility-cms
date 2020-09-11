import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';
import { ContentDto, ContentServiceProxy, ListResultDtoOfContentDto } from '@shared/service-proxies/service-proxies';
import { forEach } from 'lodash';
@Component({
    templateUrl: './sidebar-nav.component.html',
    selector: 'sidebar-nav',
    encapsulation: ViewEncapsulation.None
})
export class SideBarNavComponent extends AppComponentBase {
    loadedTimestamp: number = Date.now();
    lazyMenuItems: MenuItem[] = [];
    menuItems: MenuItem[] = [
        new MenuItem(this.l('HomePage'), '', 'home', '/app/home'),
        new MenuItem(this.l('Tenants'), 'Pages.Tenants', 'business', '/app/tenants'),
        new MenuItem(this.l('Users'), 'Pages.Users', 'people', '/app/users'),
        new MenuItem(this.l('Roles'), 'Pages.Roles', 'local_offer', '/app/roles'),
        new MenuItem(this.l('About'), '', 'info', '/app/about'),
        new MenuItem(this.l('Add Content Page'), '', 'add', '/app/cms/0')
    ];

    constructor(
        injector: Injector,
        private _contentService: ContentServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit() {
        this.loadLazyMenuItems();
        this._contentService.subscribeShouldGetAll().subscribe( e => {
            if (e > this.loadedTimestamp) {
                this.loadLazyMenuItems();
            }
        });
    }

    showMenuItem(menuItem): boolean {
        if (menuItem.permissionName) {
            return this.permission.isGranted(menuItem.permissionName);
        }

        return true;
    }

    showLazyMenuItem(lazyMenuItem: MenuItem): boolean {
        if (lazyMenuItem.permissionName) {
            return this.permission.isGranted(lazyMenuItem.permissionName);
        }
        return true;
    }

    loadLazyMenuItems(){
        this._contentService.getAll()
            .subscribe((result: ListResultDtoOfContentDto) => {
                if(result && result.items) {
                    //clear old lazyMenu cause this is result from GetALL
                    this.lazyMenuItems = [];
                    forEach<ContentDto>(result.items, (item) => {
                        this.lazyMenuItems.push(new MenuItem(this.l(item.pageName), '', '', `/app/cms/${item.id}`));
                    });
                }
                
                console.info(result);
            });

    }

    
}
