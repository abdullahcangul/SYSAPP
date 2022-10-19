import { Route } from '@angular/router';

export const routes:Route[] = [
  {
    path: 'home',
    loadChildren: () => import('./views/home/home.module').then(m => m.HomeModule),
    data: { animation: 'home' }
  },
  {
    path: 'dept',
    loadChildren: () => import('./views/dept/dept.module').then(m => m.DeptModule),
    data: { animation: 'home' }
  },
  {
    path: 'dues',
    loadChildren: () => import('./views/dues/dues.module').then(m => m.DuesModule),
    data: { animation: 'home' }
  },
  {
    path: 'owner',
    loadChildren: () => import('./views/owner/owner.module').then(m => m.OwnerModule),
    data: { animation: 'home' }
  }
];


