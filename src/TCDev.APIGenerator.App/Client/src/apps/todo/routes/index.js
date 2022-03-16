export default [{
  path: '',
  redirect: 'tasks'
}, {
  path: 'tasks',
  name: 'apps-todo-tasks',
  component: () => import(/* webpackChunkName: "apps-todo-tasks" */ '@/apps/todo/pages/TasksPage.vue')
}, {
  path: 'completed',
  name: 'apps-todo-completed',
  component: () => import(/* webpackChunkName: "apps-todo-completed" */ '@/apps/todo/pages/CompletedPage.vue')
}, {
  path: 'label/:id',
  name: 'apps-todo-label',
  component: () => import(/* webpackChunkName: "apps-todo-label" */ '@/apps/todo/pages/LabelPage.vue')
}]
