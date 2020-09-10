import { Component, OnInit, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';

import * as _ from 'lodash';
import { ContentDto, ContentServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './cms.component.html',
    animations: [appModuleAnimation()]
})

export class CmsComponent extends AppComponentBase implements OnInit {

    content: ContentDto = new ContentDto();
    contentId:number;

    constructor(
        injector: Injector,
        private _contentService: ContentServiceProxy,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.contentId = params['id'];
            this.loadContent();
        });
    }

   

    loadContent() {
        this._contentService.getCMSContent(this.contentId)
            .subscribe((result: ContentDto) => {
                this.content = result;
            });
    }

    backToContentsPage() {
        this._router.navigate(['app/events']);
    };
}
