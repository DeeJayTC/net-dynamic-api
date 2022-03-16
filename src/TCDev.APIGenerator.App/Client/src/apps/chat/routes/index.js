export default [{
  path: '',
  redirect: 'channel/general'
}, {
  path: 'channel/:id',
  name: 'apps-chat-channel',
  component: () => import(/* webpackChunkName: "apps-chat-channel" */ '@/apps/chat/pages/ChannelPage.vue')
}]
