import { CoreMenu } from '@core/types'

export const menu: CoreMenu[] = [
  {
    id: 'home',
    title: 'Home',
    translate: 'MENU.HOME',
    type: 'item',
    icon: 'home',
    url: 'pages/admin/home'
  },
  {
    id: 'owner',
    title: 'Owner',
    translate: 'MENU.OWNER',
    type: 'item',
    icon: 'user',
    url: 'pages/admin/owner'
  },
  {
    id: 'dues',
    title: 'Dues',
    translate: 'MENU.DUES',
    type: 'item',
    icon: 'home',
    url: 'pages/admin/dues'
  },
  {
    id: 'dept',
    title: 'Dept',
    translate: 'MENU.DEPT',
    type: 'item',
    icon: 'user',
    url: 'pages/admin/dept'
  },
]
