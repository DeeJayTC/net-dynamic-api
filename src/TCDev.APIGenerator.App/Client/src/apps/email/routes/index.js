export default [{
  path: '',
  redirect: 'inbox'
}, {
  path: 'inbox',
  name: 'apps-email-inbox',
  component: () => import(/* webpackChunkName: "apps-email-inbox" */ '@/apps/email/pages/InboxPage.vue')
}, {
  path: 'sent',
  name: 'apps-email-sent',
  component: () => import(/* webpackChunkName: "apps-email-sent" */ '@/apps/email/pages/SentPage.vue')
}, {
  path: 'drafts',
  name: 'apps-email-drafts',
  component: () => import(/* webpackChunkName: "apps-email-drafts" */ '@/apps/email/pages/DraftsPage.vue')
}, {
  path: 'starred',
  name: 'apps-email-starred',
  component: () => import(/* webpackChunkName: "apps-email-starred" */ '@/apps/email/pages/StarredPage.vue')
}, {
  path: 'trash',
  name: 'apps-email-trash',
  component: () => import(/* webpackChunkName: "apps-email-trash" */ '@/apps/email/pages/TrashPage.vue')
}, {
  path: 'inbox/:id',
  name: 'apps-email-view',
  component: () => import(/* webpackChunkName: "apps-email-view" */ '@/apps/email/pages/ViewPage.vue')
}]
