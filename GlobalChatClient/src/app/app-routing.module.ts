import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatViewportComponent } from './component/chat-viewport/chat-viewport.component';
import { UserIdentificationComponent } from './component/user-identification/user-identification.component';

const routes: Routes = [  
  {
    path:'chatviewport',
    title:'Chat', 
    component: ChatViewportComponent
  },
  {
    path: 'useridentification',
    title: 'Identification',
    component: UserIdentificationComponent
  },
  {
    path: '**',
    redirectTo: 'useridentification',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
