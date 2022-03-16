<template>
  <v-card class="min-w-0">
    <div class="email-app-top px-2 py-1 d-flex align-center">
      <v-checkbox :value="selectAll" :indeterminate="selectAlmostAll" @click.stop="onSelectAll(selectAll)"></v-checkbox>

      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn icon v-bind="attrs" v-on="on">
            <v-icon>mdi-menu-down</v-icon>
          </v-btn>
        </template>

        <v-list>
          <v-list-item v-for="item in menuSelection" :key="item.key" link @click="onMenuSelection(item.key)">
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>

      <v-btn v-show="selected.length === 0" icon :loading="isLoading" @click="$emit('refresh')">
        <v-icon>mdi-refresh</v-icon>
      </v-btn>

      <div v-show="selected.length > 0">
        <v-btn icon>
          <v-icon>bx-archive</v-icon>
        </v-btn>
        <v-btn icon>
          <v-icon>mdi-email-mark-as-unread</v-icon>
        </v-btn>
        <v-btn icon>
          <v-icon>bx-trash-alt</v-icon>
        </v-btn>
      </div>

      <v-spacer></v-spacer>

      <div class="caption mr-1">1 - 20 of 428</div>
      <v-btn icon disabled>
        <v-icon>mdi-chevron-left</v-icon>
      </v-btn>
      <v-btn icon>
        <v-icon>mdi-chevron-right</v-icon>
      </v-btn>
    </div>

    <v-divider></v-divider>

    <v-list class="py-0">
      <template v-for="(item, index) in emails">
        <v-list-item
          :key="item.title"
          :class="{
            'grey lighten-5': item.read && !$vuetify.theme.dark,
            'v-list-item--active primary--text': selected.indexOf(item.id) !== -1
          }"
          link
        >
          <v-list-item-action class="d-flex flex-row align-center">
            <v-checkbox v-model="selected" :value="item.id"></v-checkbox>

            <v-btn icon class="ml-1" @click="item.starred = !item.starred">
              <v-icon v-if="!item.starred" color="grey lighten-1">
                bx-star
              </v-icon>
              <v-icon v-else color="yellow darken-1">
                bx bxs-star
              </v-icon>
            </v-btn>
          </v-list-item-action>

          <v-list-item-content @click="$router.push(`/apps/email/inbox/${item.id}`)">
            <v-list-item-title v-text="item.subject"></v-list-item-title>
            <v-list-item-subtitle class="font-weight-bold" v-text="item.title"></v-list-item-subtitle>
            <v-list-item-subtitle v-text="item.content"></v-list-item-subtitle>
            <v-list-item-subtitle>
              <v-chip
                v-for="label in item.labels"
                :key="label"
                :color="getLabelColor(label)"
                class="font-weight-bold mt-1 mr-1"
                outlined
                small
              >
                {{ getLabelTitle(label) }}
              </v-chip>
            </v-list-item-subtitle>
          </v-list-item-content>

          <v-list-item-action>
            <v-list-item-action-text v-text="item.time"></v-list-item-action-text>
          </v-list-item-action>
        </v-list-item>

        <v-divider
          v-if="index + 1 < emails.length"
          :key="index"
        ></v-divider>
      </template>
      <template v-if="!isLoading && emails.length === 0">
        <div class="px-1 py-6 text-center">{{ $t('email.emptyList') }}</div>
      </template>
    </v-list>

    <v-overlay :value="isLoading" absolute>
      <v-progress-circular indeterminate size="32"></v-progress-circular>
    </v-overlay>
  </v-card>
</template>

<script>
/*
|---------------------------------------------------------------------
| Email List Component
|---------------------------------------------------------------------
|
| List to display emails
|
*/
export default {
  props: {
    emails: {
      type: Array,
      default: () => []
    },
    labels: {
      type: Array,
      default: () => []
    },
    isLoading: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      selectAll: false,
      selectAlmostAll: false,
      selected: [],
      menuSelection: [{
        title: 'All',
        key: 'all'
      }, {
        title: 'Read',
        key: 'read'
      }, {
        title: 'Unread',
        key: 'unread'
      }, {
        title: 'Starred',
        key: 'starred'
      }]
    }
  },
  watch: {
    selected(val) {
      // check selectAll intermediate state
      this.$nextTick(() => {
        if (this.selectAll) {
          if (val.length === 0) {
            this.selectAll = false
            this.selectAlmostAll = false
          } else {
            if (this.emails.length === val.length) {
              this.selectAlmostAll = false
            } else {
              this.selectAlmostAll = true
            }
          }
        }
      })
    }
  },
  methods: {
    onMenuSelection(key) {
      switch (key) {
      case 'all':
        this.selected = this.emails.map((i) => i.id)
        this.selectAll = true
        this.selectAlmostAll = false
      }
    },
    onSelectAll(selectAll) {
      if (this.selectAll) {
        this.selected = []
      } else {
        this.selected = this.emails.map((i) => i.id)
      }

      this.selectAlmostAll = false
      this.selectAll = !this.selectAll
    },
    getLabelColor(id) {
      const label = this.labels.find((l) => l.id === id)

      return label ? label.color : ''
    },
    getLabelTitle(id) {
      const label = this.labels.find((l) => l.id === id)

      return label ? label.title : ''
    }
  }
}
</script>

<style lang="scss" scoped>
.email-app-top {
  height: 82px;
}
</style>
