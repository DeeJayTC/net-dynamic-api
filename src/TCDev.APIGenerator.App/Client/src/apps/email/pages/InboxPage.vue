<template>
  <email-list :is-loading="isLoading" :emails="inbox" :labels="labels" @refresh="onRefresh" />
</template>

<script>
import { mapState, mapActions } from 'vuex'
import EmailList from '../components/EmailList'

export default {
  components: {
    EmailList
  },
  computed: {
    ...mapState('email-app', ['inbox', 'isLoading', 'labels'])
  },
  watch: {
    '$route.hash'(val) {
      this.getEmails()
    }
  },
  mounted() {
    this.getEmails()
  },
  methods: {
    ...mapActions('email-app', ['getInbox']),
    onRefresh() {
      this.getEmails()
    },
    getEmails() {
      const { hash } = this.$route
      const label = hash ? hash.replace('#', '') : ''

      this.getInbox(label)
    }
  }
}
</script>
