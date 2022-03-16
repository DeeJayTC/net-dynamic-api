import inboxEmails from './content/inbox'
import starredEmails from './content/starred'

/*
|---------------------------------------------------------------------
| Email Vuex Actions
|---------------------------------------------------------------------
|
| For demo purposes the methods are synchronous, but a vuex action
| should be async like an ajax call to an API
|
*/
export default {
  getInbox: ({ commit }, label) => {
    if (label) {
      commit('loadInbox', inboxEmails.filter((email) => email.labels.indexOf(label) !== -1))
    } else {
      commit('loadInbox', inboxEmails)
    }
  },
  getStarred: ({ commit }) => {
    commit('loadStarred', starredEmails)
  }
}
