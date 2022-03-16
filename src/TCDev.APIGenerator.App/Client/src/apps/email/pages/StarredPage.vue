<template>
  <email-list :is-loading="isLoading" :emails="starred" :labels="labels" @refresh="onRefresh" />
</template>

<script>
import { mapState, mapActions } from 'vuex'
import EmailList from '../components/EmailList'

export default {
  components: {
    EmailList
  },
  computed: {
    ...mapState('email-app', ['starred', 'isLoading', 'labels'])
  },
  mounted() {
    this.getStarred()
  },
  methods: {
    ...mapActions('email-app', ['getStarred']),
    onRefresh() {
      this.getStarred()
    }
  }
}
</script>
