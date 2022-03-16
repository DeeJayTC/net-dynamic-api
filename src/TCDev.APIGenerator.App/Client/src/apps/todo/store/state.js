import tasks from './content/tasks'

/*
|---------------------------------------------------------------------
| TODO Vuex State
|---------------------------------------------------------------------
*/
export default {
  tasks,

  // labels
  labels: [{
    id: 'work',
    title: 'Work',
    color: 'primary'
  }, {
    id: 'fun',
    title: 'Fun',
    color: 'blue'
  }, {
    id: 'groceries',
    title: 'Groceries',
    color: 'orange'
  }]
}
