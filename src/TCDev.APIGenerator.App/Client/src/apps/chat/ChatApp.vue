<template>
  <div class="d-flex flex-grow-1 flex-row mt-2">
    <v-navigation-drawer
      v-model="drawer"
      :app="$vuetify.breakpoint.mdAndDown"
      :permanent="$vuetify.breakpoint.lgAndUp"
      floating
      :right="$vuetify.rtl"
      class="elevation-1 rounded flex-shrink-0"
      :class="[$vuetify.rtl ? 'ml-3' : 'mr-3']"
      width="240"
    >
      <div class="px-2 py-1">
        <div class="title font-weight-bold primary--text">Chat Template</div>
        <div class="overline">1.0.0</div>
      </div>

      <v-list dense>
        <v-subheader class="ml-1 overline">{{ $tc('chat.channel', 2) }}</v-subheader>
        <div class="mx-2 mb-2">
          <v-btn outlined block @click="showCreateDialog = true">
            <v-icon small left>mdi-plus</v-icon>
            {{ $t('chat.addChannel') }}
          </v-btn>
        </div>

        <!-- channels list -->
        <v-list-item v-for="channelItem in channels" :key="channelItem" :to="`/apps/chat/channel/${channelItem}`" exact>
          <v-list-item-content>
            <v-list-item-title># {{ channelItem }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <!-- channel view -->
    <v-card class="flex-grow-1">
      <router-view :key="$route.fullPath" :user="user" @toggle-menu="drawer = !drawer"></router-view>
    </v-card>

    <!-- create a new channel dialog -->
    <v-dialog v-model="showCreateDialog" max-width="400">
      <v-card>
        <v-card-title class="title">{{ $t('chat.addChannel') }}</v-card-title>
        <div class="pa-3">
          <v-text-field
            ref="channel"
            v-model="newChannel"
            :label="$tc('chat.channel', 1)"
            maxlength="20"
            counter="20"
            autofocus
            @keyup.enter="addChannel()"
          ></v-text-field>
        </div>
        <v-card-actions class="pa-2">
          <v-spacer></v-spacer>
          <v-btn @click="showCreateDialog = false">{{ $t('common.cancel') }}</v-btn>
          <v-btn :loading="isLoadingAdd" color="success" @click="addChannel()">{{ $t('common.add') }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
/*
|---------------------------------------------------------------------
| Chat App Main Layout Component
|---------------------------------------------------------------------
|
| Navigation drawer with channels for the chat application
|
*/
export default {
  data() {
    return {
      // navigation drawer
      drawer: null,

      // logged user
      user: {
        id: 12,
        name: 'John Cena',
        avatar: '/images/avatars/avatar1.svg'
      },

      // initial channels
      channels: ['general', 'production', 'qa', 'staging', 'random'],

      // create channel variables
      showCreateDialog: false,
      isLoadingAdd: false,
      newChannel: ''
    }
  },
  methods: {
    // Add and join the channel on creation
    addChannel() {
      if (!this.newChannel) {
        this.$refs.channel.focus()

        return
      }

      this.isLoadingAdd = true

      setTimeout(() => {
        this.isLoadingAdd = false
        this.channels.push(this.newChannel)
        this.showCreateDialog = false
        this.$router.push(`/apps/chat/channel/${this.newChannel}`)
        this.newChannel = ''
      }, 300)
    }
  }
}
</script>
