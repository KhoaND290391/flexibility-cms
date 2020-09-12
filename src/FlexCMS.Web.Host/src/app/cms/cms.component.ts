import { Component, OnInit, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';

import * as _ from 'lodash';
import { ContentDto, ContentServiceProxy } from '@shared/service-proxies/service-proxies';
import { ToastrService } from 'ngx-toastr';


@Component({
    selector: 'cms-component',
    templateUrl: './cms.component.html',
    styleUrls: ['./cms.custom.css'],
    animations: [appModuleAnimation()]
})

export class CmsComponent extends AppComponentBase implements OnInit {

    content: ContentDto = new ContentDto();
    contentId: number = 0;
    isReadOnly: boolean = true;
    saving: boolean = false;
    constructor(
        injector: Injector,
        private _contentService: ContentServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private router: Router,
        private toastr: ToastrService
    ) {
        super(injector);
       
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            var paramId =  params['contentId'];
            if(isNaN(paramId) || paramId <=  0) {
                this.loadEmptyContent();
            } else {
                this.contentId = Math.floor(paramId);
                this.loadContent(this.contentId);
            }
        });
    }

    loadContent(contentId) {
        this._contentService.getCMSContent(contentId)
            .subscribe((result: ContentDto) => {
                this.content = result;
                this.isReadOnly = true;
            });
    }
    loadEmptyContent() {
        this.contentId = 0;
        this.isReadOnly = false;
        this.content = new ContentDto({
            id: 0,
            pageName: "",
            pageContent: "",
        });
    }

    toggleReadOnly() {
        this.isReadOnly  = !this.isReadOnly ;
    }

    isValidToSave():boolean {
        return (this.content && this.content.pageName && this.content.pageName.trim().length > 0 && this.content.pageName.trim().length < 1024
            && this.content.pageContent && this.content.pageContent.trim().length > 0);
    }

    saveAll() {
        if(this.isValidToSave()) {
            this._contentService.insertOrUpdateCMSContent(this.content).subscribe((result: ContentDto) => {
                this._contentService.emitShouldGetAll(Date.now());
                if(result.id == this.content.id) {
                    this.toastr.success('Added new page successfully!', 'Added', {timeOut: 5000, positionClass: 'toast-bottom-right'});
                    this.toggleReadOnly();
                } else {
                    this.toastr.success('Saved changes successfully!', 'Saved', {timeOut: 5000, positionClass: 'toast-bottom-right'});
                    this.router.navigate([`/app/cms/${result.id}`]);
                }
                this.toastr.info('Menu bar was reloaded!', 'Updated Info', {timeOut: 5000, positionClass: 'toast-bottom-right'});
            });
        }
    }
}
