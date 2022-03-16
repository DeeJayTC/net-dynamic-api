/*
|---------------------------------------------------------------------
| TODO Vuex Getters
|---------------------------------------------------------------------
*/
export default {
  incompleteTasks({ tasks }) {
    return tasks.filter((t) => !t.completed)
  },
  completeTasks({ tasks }) {
    return tasks.filter((t) => t.completed)
  }
}
