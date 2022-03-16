<template>
  <div class="d-flex flex-grow-1 flex-row mt-2">
    <v-navigation-drawer
      v-model="drawer"
      :app="$vuetify.breakpoint.mdAndDown"
      :permanent="$vuetify.breakpoint.lgAndUp"
      floating
      class="elevation-1 rounded flex-shrink-0"
      :class="[$vuetify.rtl ? 'ml-3' : 'mr-3']"
      width="240"
    >
      <email-menu class="pa-2"></email-menu>
    </v-navigation-drawer>

    <div class="d-flex flex-grow-1 flex-column">
      <v-toolbar class="hidden-lg-and-up flex-grow-0 mb-2">
        <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
        <div class="title font-weight-bold">Email App</div>
      </v-toolbar>
      <router-view :key="$route.fullPath" class="flex-grow-1"></router-view>
    </div>
  </div>
</template>

<script>
import EmailMenu from './components/EmailMenu'

/*
|---------------------------------------------------------------------
| Email App Component
|---------------------------------------------------------------------
|
| Menu and layout for the email application
|
*/
export default {
  components: {
    EmailMenu
  },
  data() {
    return {
      // navigation drawer
      drawer: null
    }
  }
}
</script>
