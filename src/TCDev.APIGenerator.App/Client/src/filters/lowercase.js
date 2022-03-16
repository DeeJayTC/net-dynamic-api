import Vue from 'vue'

Vue.filter('lowercase', (value) => {
  console.log(value)
  if (!value) return ''
  console.log(value)

  return value.toString().toLowerCase()
})
