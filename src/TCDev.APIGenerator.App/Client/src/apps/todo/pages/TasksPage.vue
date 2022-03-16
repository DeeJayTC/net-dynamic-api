<template>
  <todo-list :tasks="incompleteTasks" @edit-task="$emit('edit-task', $event)" />
</template>

<script>
import { mapGetters } from 'vuex'
import TodoList from '../components/TodoList'

export default {
  components: {
    TodoList
  },
  computed: {
    ...mapGetters('todo-app', ['incompleteTasks'])
  }
}
</script>
