import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ComponentsModule } from './components/_components.module';
import { ServiceModule } from './services/_service.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    ComponentsModule,
    ServiceModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
