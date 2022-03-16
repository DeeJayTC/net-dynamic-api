export default {
  // apps quickmenu
  apps: [{
    icon: 'mdi-email-outline',
    text: 'Email',
    key: 'menu.email',
    subtitle: 'Inbox',
    subtitleKey: 'email.inbox',
    link: '/apps/email/inbox'
  }, {
    icon: 'mdi-format-list-checkbox',
    title: 'Tasks',
    key: 'menu.todo',
    subtitle: 'TODO',
    link: '/apps/todo'
  }, {
    icon: 'mdi-message-outline',
    title: 'Chat',
    key: 'menu.chat',
    subtitle: '#general',
    link: '/apps/chat/channel/general'
  }, {
    icon: 'mdi-view-column-outline',
    title: 'Board',
    key: 'menu.board',
    subtitle: 'Kanban',
    link: '/apps/board'
  }],

  // user dropdown menu
  user: [
    { icon: 'mdi-account-box-outline', key: 'menu.profile', text: 'Profile', link: '/users/edit' },
    { icon: 'mdi-email-outline', key: 'menu.email', text: 'Email', link: '/apps/email' },
    { icon: 'mdi-format-list-checkbox', key: 'menu.todo', text: 'Todo', link: '/apps/todo' },
    { icon: 'mdi-email-outline', key: 'menu.chat', text: 'Chat', link: '/apps/chat' },
    { icon: 'mdi-email-outline', key: 'menu.board', text: 'Board', link: '/apps/board' }
  ]
}
