/*
|---------------------------------------------------------------------
| TODO Vuex Mutations
|---------------------------------------------------------------------
*/
export default {
  addTask: (state, task) => {
    state.tasks.push({
      id: '_' + Math.random().toString(36).substr(2, 9),
      ...task,
      completed: false
    })
  },
  updateTask: (state, task) => {
    const taskIdx = state.tasks.find((t) => t.id === task.id)

    Object.assign(taskIdx, task)
  },
  taskCompleted: (state, task) => {
    const taskIdx = state.tasks.findIndex((t) => t.id === task.id)

    state.tasks[taskIdx].completed = true
  },
  taskIncomplete: (state, task) => {
    const taskIdx = state.tasks.findIndex((t) => t.id === task.id)

    state.tasks[taskIdx].completed = false
  },
  deleteTask: (state, task) => {
    const taskIdx = state.tasks.findIndex((t) => t.id === task.id)

    if (taskIdx !== -1) state.tasks.splice(taskIdx, 1)
  }
}
