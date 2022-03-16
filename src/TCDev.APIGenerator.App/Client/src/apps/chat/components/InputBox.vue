<template>
  <div class="d-flex position-relative">
    <v-text-field
      ref="input"
      v-model="input"
      dense
      outlined
      maxlength="150"
      :placeholder="`${$t('chat.message')} #${channel}`"
      class="font-weight-bold position-relative"
      hide-details
      append-icon
      @click="$emit('input-focus')"
      @keyup.enter="sendMessage"
    >
      <template v-slot:append>
        <emoji-picker @insert="insertEmoji"></emoji-picker>
      </template>
    </v-text-field>
    <v-btn
      fab
      small
      class="mx-1 primary"
      :disabled="!input"
      @click="sendMessage"
    ><v-icon small>mdi-send</v-icon></v-btn>
  </div>
</template>

<script>
/*
|---------------------------------------------------------------------
| Input Box Component
|---------------------------------------------------------------------
|
| Send messages and emojis to the channel
|
*/
import EmojiPicker from './EmojiPicker'

export default {
  components: {
    EmojiPicker
  },
  props: {
    // Current channel name
    channel: {
      type: String,
      default: ''
    }
  },
  data() {
    return {
      input: ''
    }
  },
  methods: {
    // Add selected emoji in input
    insertEmoji(emoji) {
      this.input += emoji
    },
    // Send message and clear input
    sendMessage() {
      if (!this.input) return

      this.$emit('send-message', this.input)
      this.input = ''
      this.$refs.input.focus()
    }
  }
}
</script>
