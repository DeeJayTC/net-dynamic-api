export default [{
  path: '/ecommerce',
  redirect: 'ecommerce-products'
}, {
  path: '/ecommerce/list',
  name: 'ecommerce-list',
  component: () => import(/* webpackChunkName: "ecommerce-list" */ '@/pages/ecommerce/EcommercePage.vue')
}, {
  path: '/ecommerce/product-details',
  name: 'ecommerce-product-details',
  component: () => import(/* webpackChunkName: "ecommerce-product-details" */ '@/pages/ecommerce/ProductDetailsPage.vue')
}, {
  path: '/ecommerce/orders',
  name: 'ecommerce-orders',
  component: () => import(/* webpackChunkName: "ecommerce-orders" */ '@/pages/ecommerce/OrdersPage.vue')
}, {
  path: '/ecommerce/cart',
  name: 'ecommerce-cart',
  component: () => import(/* webpackChunkName: "ecommerce-cart" */ '@/pages/ecommerce/CartPage.vue')
}]
