<template>
  <v-combobox
    v-model="model"
    :filter="filter"
    :hide-no-data="!search"
    :items="items"
    :search-input.sync="search"
    :label="label"
    hide-selected
    hide-details
    append-icon=""
    solo
    flat
    full-width
    multiple
  >
    <template v-slot:append-outer>
      <slot></slot>
    </template>

    <template v-slot:selection="{ attrs, item, parent, selected }">
      <v-chip
        v-if="item === Object(item)"
        v-bind="attrs"
        class="font-weight-bold"
        color="primary lighten-5 primary--text"
        :input-value="selected"
        label
      >
        <span class="pr-2">
          {{ item.text }}
        </span>
        <v-icon
          small
          @click="parent.selectItem(item)"
        >close</v-icon>
      </v-chip>
    </template>

    <template v-slot:item="{ index, item }">
      <v-list-item-avatar>
        <img :src="item.avatar" />
      </v-list-item-avatar>

      <v-list-item-content>
        <v-list-item-title>{{ item.text }}</v-list-item-title>
        <v-list-item-subtitle>{{ item.email }}</v-list-item-subtitle>
      </v-list-item-content>
    </template>
  </v-combobox>
</template>

<script>
/*
|---------------------------------------------------------------------
| Email Input Component
|---------------------------------------------------------------------
|
| Add and remove emails input
|
*/
export default {
  props: {
    // Input label
    label: {
      type: String,
      default: ''
    },
    // Email addresses
    addresses: {
      type: Array,
      default: () => []
    }
  },
  data() {
    return {
      model: [],
      search: null
    }
  },
  computed: {
    items() {
      if (!this.search) return []

      return  [{
        text: 'Ubaldo Romaguera',
        email: 'ubaldo@notarealemailaddress.com',
        avatar: '/images/avatars/avatar1.svg'
      }, {
        text: 'Ruben Breitenberg',
        email: 'ruben@notarealemailaddress.com',
        avatar: '/images/avatars/avatar2.svg'
      }, {
        text: 'Blaze Carter',
        email: 'blaze@notarealemailaddress.com',
        avatar: '/images/avatars/avatar3.svg'
      }, {
        text: 'Bernita Lehner',
        email: 'bernita@notarealemailaddress.com',
        avatar: '/images/avatars/avatar4.svg'
      }]
    }
  },

  watch: {
    model (val, prev) {
      if (val.length === prev.length) return

      this.model = val.map((v) => {
        if (typeof v === 'string') {
          v = {
            text: v,
            email: v
          }

          this.items.push(v)
        }

        return v
      })

      this.search = ''
    }
  },

  mounted() {
    this.model = this.addresses
  },

  methods: {
    filter (item, queryText, itemText) {
      const hasValue = (val) => val !== null ? val : ''

      const text = hasValue(itemText)
      const query = hasValue(queryText)

      return text.toString()
        .toLowerCase()
        .indexOf(query.toString().toLowerCase()) > -1
    }
  }
}
</script>
