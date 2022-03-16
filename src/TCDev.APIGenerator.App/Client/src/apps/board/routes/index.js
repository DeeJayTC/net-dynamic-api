export default [{
  path: '',
  name: 'apps-todo-board',
  component: () => import(/* webpackChunkName: "apps-todo-board" */ '@/apps/board/pages/BoardPage.vue')
}]
