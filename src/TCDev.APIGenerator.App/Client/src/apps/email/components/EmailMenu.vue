<template>
  <div>
    <v-btn
      block
      large
      color="primary"
      class="mb-3"
      @click="showCompose = true"
    >{{ $t('email.compose') }}</v-btn>

    <v-list dense nav class="mt-2 pa-0">
      <v-list-item
        v-for="(item, index) in menu"
        :key="index"
        :to="item.link"
        active-class="primary--text"
        link
      >
        <v-list-item-icon>
          <v-icon small>{{ item.icon }}</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>{{ $t(item.label) }}</v-list-item-title>
        </v-list-item-content>

        <v-list-item-action v-if="item.count > 0">
          <v-badge
            inline
            color="primary"
            class="font-weight-bold"
            :content="item.count"
          >
          </v-badge>
        </v-list-item-action>
      </v-list-item>
    </v-list>

    <v-list dense nav class="mt-2 pa-0">
      <div class="overline pa-1 mt-2">{{ $t('email.labels') }}</div>

      <v-list-item
        v-for="(item, index) in labels"
        :key="index"
        :to="item.link"
        exact
        active-class="primary--text"
        link
      >
        <v-list-item-icon>
          <v-icon small :color="item.color">{{ item.icon }}</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>{{ $t(item.label) }}</v-list-item-title>
        </v-list-item-content>

        <v-list-item-action v-if="item.count > 0">
          <v-badge
            inline
            :content="item.count"
            :color="item.color"
            class="font-weight-bold"
          >
          </v-badge>
        </v-list-item-action>
      </v-list-item>
    </v-list>

    <email-compose :show-compose="showCompose" @close-dialog="showCompose = false" />
  </div>
</template>

<script>
import EmailCompose from './EmailCompose'

/*
|---------------------------------------------------------------------
| Email Menu Component
|---------------------------------------------------------------------
|
| Navigation for email boxes
|
*/
export default {
  components: {
    EmailCompose
  },
  data() {
    return {
      showCompose: false,
      menu: [{
        label: 'email.inbox',
        icon: 'bx bxs-inbox',
        link: '/apps/email/inbox',
        count: 3
      }, {
        label: 'email.sent',
        icon: 'bx-send',
        link: '/apps/email/sent'
      }, {
        label: 'email.drafts',
        icon: 'mdi-pencil-outline',
        link: '/apps/email/drafts'
      }, {
        label: 'email.starred',
        icon: 'mdi-star-outline',
        link: '/apps/email/starred',
        count: 1
      }, {
        label: 'email.trash',
        icon: 'mdi-delete-outline',
        link: '/apps/email/trash'
      }],
      labels: [{
        label: 'email.work',
        color: 'primary',
        icon: 'mdi-label-outline',
        link: '/apps/email/inbox#work'
      }, {
        label: 'email.invoice',
        color: 'green',
        icon: 'mdi-label-outline',
        link: '/apps/email/inbox#invoice'
      }]
    }
  }
}
</script>
