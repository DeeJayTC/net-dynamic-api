<template>
  <vue-emoji-picker class="emoji-wrap" @emoji="(emoji) => $emit('insert', emoji)">
    <div
      slot="emoji-invoker"
      slot-scope="{ events: { click: clickEvent } }"
      class="emoji-invoker"
      @click.stop="clickEvent"
    >
      <svg height="24" viewBox="0 0 24 24" width="24" xmlns="http://www.w3.org/2000/svg">
        <path d="M0 0h24v24H0z" fill="none"/>
        <path d="M11.99 2C6.47 2 2 6.48 2 12s4.47 10 9.99 10C17.52 22 22 17.52 22 12S17.52 2 11.99 2zM12 20c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8zm3.5-9c.83 0 1.5-.67 1.5-1.5S16.33 8 15.5 8 14 8.67 14 9.5s.67 1.5 1.5 1.5zm-7 0c.83 0 1.5-.67 1.5-1.5S9.33 8 8.5 8 7 8.67 7 9.5 7.67 11 8.5 11zm3.5 6.5c2.33 0 4.31-1.46 5.11-3.5H6.89c.8 2.04 2.78 3.5 5.11 3.5z"/>
      </svg>
    </div>
    <div slot="emoji-picker" slot-scope="{ emojis }">
      <div class="emoji-picker secondary lighten-1 elevation-2">
        <div>
          <div v-for="(emojiGroup, category) in emojis" :key="category">
            <div class="text-uppercase overline">{{ category }}</div>
            <div class="emojis mb-2">
              <span
                v-for="(emoji, emojiName) in emojiGroup"
                :key="emojiName"
                :title="emojiName"
                @click="$emit('insert', emoji)"
              >{{ emoji }}</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </vue-emoji-picker>
</template>

<script>
import VueEmojiPicker from 'vue-emoji-picker'

/*
|---------------------------------------------------------------------
| Wrapper component for vue-emoji-picker
|---------------------------------------------------------------------
|
| Emoji picker menu for chat application
|
*/
export default {
  components: {
    VueEmojiPicker
  }
}
</script>

<style lang="scss" scoped>
.emoji-wrap {
  width: 20px;

  .emoji-invoker {
    position: absolute;
    top: 0.5rem;
    right: 0.5rem;
    width: 1.5rem;
    height: 1.5rem;
    border-radius: 50%;
    cursor: pointer;
    transition: all 0.2s;

    &:hover {
      transform: scale(1.1);
    }

    & > svg {
      fill: #888;
    }
  }

  .emoji-picker {
    right: 14px;
    bottom: 32px;
    position: absolute;
    z-index: 1;
    width: 12rem;
    height: 9rem;
    overflow: scroll;
    padding: 10px;
    border-radius: 6px;
    font-size: 1.5rem;

    .emojis {
      display: flex;
      flex-wrap: wrap;
      justify-content: space-between;

      &:after {
        content: "";
        flex: auto;
      }

      span {
        padding: 0.2rem;
        cursor: pointer;
        border-radius: 5px;

        &:hover {
          background: #ececec;
          cursor: pointer;
        }
      }
    }
  }
}
</style>
