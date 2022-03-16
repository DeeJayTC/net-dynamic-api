import emailRoutes from '../apps/email/routes'
import chatRoutes from '../apps/chat/routes'
import todoRoutes from '../apps/todo/routes'
import boardRoutes from '../apps/board/routes'

export default [{
  path: '/apps/email',
  component: () => import(/* webpackChunkName: "apps-email" */ '@/apps/email/EmailApp.vue'),
  children: [
    ...emailRoutes
  ]
}, {
  path: '/apps/chat',
  component: () => import(/* webpackChunkName: "apps-chat" */ '@/apps/chat/ChatApp.vue'),
  children: [
    ...chatRoutes
  ]
}, {
  path: '/apps/todo',
  component: () => import(/* webpackChunkName: "apps-todo" */ '@/apps/todo/TodoApp.vue'),
  children: [
    ...todoRoutes
  ]
}, {
  path: '/apps/board',
  component: () => import(/* webpackChunkName: "apps-board" */ '@/apps/board/BoardApp.vue'),
  children: [
    ...boardRoutes
  ]
}]
