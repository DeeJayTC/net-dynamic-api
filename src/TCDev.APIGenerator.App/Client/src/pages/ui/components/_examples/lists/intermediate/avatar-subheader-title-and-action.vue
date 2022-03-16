<template>
  <v-card
    max-width="500"
    class="mx-auto"
  >
    <v-toolbar
      color="deep-purple accent-4"
      dark
    >
      <v-app-bar-nav-icon></v-app-bar-nav-icon>

      <v-toolbar-title>New Chat</v-toolbar-title>

      <v-spacer></v-spacer>

      <v-btn icon>
        <v-icon>mdi-magnify</v-icon>
      </v-btn>
    </v-toolbar>

    <v-list subheader>
      <v-subheader>Recent chat</v-subheader>

      <v-list-item
        v-for="item in items"
        :key="item.title"
        @click=""
      >
        <v-list-item-avatar>
          <v-img :src="item.avatar"></v-img>
        </v-list-item-avatar>

        <v-list-item-content>
          <v-list-item-title v-text="item.title"></v-list-item-title>
        </v-list-item-content>

        <v-list-item-icon>
          <v-icon :color="item.active ? 'deep-purple accent-4' : 'grey'">chat_bubble</v-icon>
        </v-list-item-icon>
      </v-list-item>
    </v-list>

    <v-divider></v-divider>

    <v-list subheader>
      <v-subheader>Previous chats</v-subheader>

      <v-list-item
        v-for="item in items2"
        :key="item.title"
        @click=""
      >
        <v-list-item-avatar>
          <v-img :src="item.avatar"></v-img>
        </v-list-item-avatar>

        <v-list-item-content>
          <v-list-item-title v-text="item.title"></v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-card>
</template>

<script>
export default {
  data: () => ({
    items: [
      { active: true, title: 'Jason Oner', avatar: '/images/avatars/avatar2.svg' },
      { active: true, title: 'Ranee Carlson', avatar: '/images/avatars/avatar1.svg' },
      { title: 'Cindy Baker', avatar: '/images/avatars/avatar3.svg' },
      { title: 'Ali Connors', avatar: '/images/avatars/avatar4.svg' }
    ],
    items2: [
      { title: 'Travis Howard', avatar: '/images/avatars/avatar5.svg' }
    ]
  })
}
</script>
