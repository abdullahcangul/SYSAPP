import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CaDatatableComponent } from './ca-datatable.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule } from '@ngx-translate/core';
import { CardSnippetModule } from '@core/components/card-snippet/card-snippet.module';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { CoreCommonModule } from '@core/common.module';
import { CsvModule } from '@ctrl/ngx-csv';
import { DatatableServiceService } from 'app/core/services/datatable-service.service';


@NgModule({
  declarations: [
    CaDatatableComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    TranslateModule,
    CoreCommonModule,
    ContentHeaderModule,
    CardSnippetModule,
    NgxDatatableModule,
    CsvModule  
  ],
  exports:[CaDatatableComponent],
})
export class BaseDatatableModule { }
