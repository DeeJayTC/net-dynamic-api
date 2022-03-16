<template>
  <v-dialog
    ref="composeDialog"
    v-model="dialog"
    :fullscreen="fullscreen || $vuetify.breakpoint.mdAndDown"
    :hide-overlay="!$vuetify.breakpoint.mdAndDown"
    no-click-animation
    persistent
    width="600"
    content-class="dialog-bottom"
  >
    <v-card>
      <v-card-title class="pa-2">
        {{ $t('email.compose') }}
        <v-spacer></v-spacer>
        <v-btn v-if="!$vuetify.breakpoint.mdAndDown" icon @click="fullscreen = !fullscreen">
          <v-icon>{{ fullscreen ? 'mdi-arrow-collapse' : 'mdi-arrow-expand' }}</v-icon>
        </v-btn>
        <v-btn icon @click="$emit('close-dialog')">
          <v-icon>mdi-close</v-icon>
        </v-btn>
      </v-card-title>

      <v-divider></v-divider>

      <email-editor></email-editor>
    </v-card>
  </v-dialog>
</template>

<script>
import EmailEditor from './EmailEditor'

/*
|---------------------------------------------------------------------
| Email Compose Component
|---------------------------------------------------------------------
|
| Compose dialog to wrap the email editor
|
*/
export default {
  components: {
    EmailEditor
  },
  props: {
    // Show compose dialog
    showCompose: {
      type: Boolean,
      default: false
    }
  },
  data () {
    return {
      dialog: false,
      fullscreen: false
    }
  },
  watch: {
    showCompose(val) {
      this.dialog = val
    },
    dialog() {
      this.$nextTick(this.$refs.composeDialog.showScroll)
    }
  },
  mounted() {
    this.dialog = this.showCompose
  }
}
</script>

<style lang="scss">
.dialog-bottom {
  position: fixed;
  bottom: 10px;
  right: 10px;
}
</style>
