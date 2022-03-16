/*
|---------------------------------------------------------------------
| Email Vuex Mutations
|---------------------------------------------------------------------
*/
export default {
  loadInbox: (state, emails) => {
    state.inbox = emails
  },
  loadStarred: (state, emails) => {
    state.starred = emails
  }
}
