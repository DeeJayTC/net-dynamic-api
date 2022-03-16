export default [
  { icon: 'mdi-email-outline', key: 'menu.email', text: 'Email', link: '/apps/email' },
  { icon: 'mdi-forum-outline', key: 'menu.chat', text: 'Chat', link: '/apps/chat' },
  { icon: 'mdi-format-list-checkbox', key: 'menu.todo', text: 'Todo', link: '/apps/todo' },
  { icon: 'mdi-view-column-outline', key: 'menu.board', text: 'Kanban Board', link: '/apps/board' },
  { icon: 'mdi-store-outline', key: 'menu.ecommerce', text: 'Ecommerce', regex: /^\/ecommerce/,
    items: [
      { key: 'menu.ecommerceList', text: 'Products', link: '/ecommerce/list' },
      { key: 'menu.ecommerceProductDetails', text: 'Product Details', link: '/ecommerce/product-details' },
      { key: 'menu.ecommerceOrders', text: 'Orders', link: '/ecommerce/orders' },
      { key: 'menu.ecommerceCart', text: 'Cart', link: '/ecommerce/cart' }
    ]
  },
  { icon: 'mdi-account-multiple-outline', key: 'menu.users', text: 'Users', regex: /^\/users/,
    items: [
      { key: 'menu.usersList', text: 'List', link: '/users/list' },
      { key: 'menu.usersEdit', text: 'Edit', link: '/users/edit' }
    ]
  }
]
