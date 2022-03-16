<template>
  <v-card
    max-width="500"
    class="mx-auto"
  >
    <v-toolbar
      color="indigo"
      dark
    >
      <v-app-bar-nav-icon></v-app-bar-nav-icon>

      <v-toolbar-title>Inbox</v-toolbar-title>

      <v-spacer></v-spacer>

      <v-btn icon>
        <v-icon>mdi-magnify</v-icon>
      </v-btn>

      <v-btn icon>
        <v-icon>mdi-dots-vertical</v-icon>
      </v-btn>
    </v-toolbar>
    <v-list>
      <v-list-item
        v-for="item in items"
        :key="item.title"
        @click=""
      >
        <v-list-item-icon>
          <v-icon v-if="item.icon" color="pink">mdi-star</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title v-text="item.title"></v-list-item-title>
        </v-list-item-content>

        <v-list-item-avatar>
          <v-img :src="item.avatar"></v-img>
        </v-list-item-avatar>
      </v-list-item>
    </v-list>
  </v-card>
</template>

<script>
export default {
  data () {
    return {
      items: [
        { icon: true, title: 'Jason Oner', avatar: '/images/avatars/avatar2.svg' },
        { title: 'Travis Howard', avatar: '/images/avatars/avatar1.svg' },
        { title: 'Ali Connors', avatar: '/images/avatars/avatar3.svg' },
        { title: 'Cindy Baker', avatar: '/images/avatars/avatar4.svg' }
      ]
    }
  }
}
</script>
