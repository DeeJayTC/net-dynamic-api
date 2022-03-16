<template>
  <v-dialog v-model="dialog" width="600">
    <v-card>
      <v-card-title class="pa-2">
        {{ isEdit ? 'Edit Task' : 'Add Task' }}
        <v-spacer></v-spacer>
        <v-btn icon @click="dialog = false">
          <v-icon>mdi-close</v-icon>
        </v-btn>
      </v-card-title>

      <v-divider></v-divider>

      <!-- task form -->
      <div>
        <v-text-field
          v-model="title"
          class="px-2 py-1"
          solo
          flat
          :placeholder="$t('common.title')"
          autofocus
          hide-details
          @keyup.enter="save"
        ></v-text-field>

        <v-divider></v-divider>

        <v-textarea
          v-model="description"
          class="px-2 py-1"
          solo
          flat
          :placeholder="$t('common.description')"
          hide-details
        ></v-textarea>

        <v-select
          v-model="taskLabels"
          class="px-2 my-3"
          :menu-props="{ bottom: true, offsetY: true }"
          :items="labels"
          placeholder="Labels"
          item-value="id"
          hide-selected
          hide-details
          solo
          flat
          multiple
        >
          <template v-slot:selection="{ attrs, item, parent, selected }">
            <v-chip
              v-if="item === Object(item)"
              v-bind="attrs"
              class="font-weight-bold"
              :color="item.color"
              outlined
              :input-value="selected"
              label
            >
              <span class="pr-2">
                {{ item.title }}
              </span>
              <v-icon
                small
                @click="parent.selectItem(item)"
              >close</v-icon>
            </v-chip>
          </template>

          <template v-slot:item="{ index, item }">
            <v-chip
              :color="item.color"
              label
              outlined
              small
            >
              {{ item.title }}
            </v-chip>
          </template>
        </v-select>
      </div>

      <v-divider></v-divider>

      <v-card-actions class="pa-2">
        <v-btn outlined @click="close">{{ $t('common.cancel') }}</v-btn>
        <v-spacer></v-spacer>
        <v-btn color="primary" @click="save">{{ $t('common.save') }}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapState, mapMutations } from 'vuex'

/*
|---------------------------------------------------------------------
| TODO Compose Component
|---------------------------------------------------------------------
|
| Compose new tasks editor
|
*/
export default {
  data () {
    return {
      dialog: false,
      title: '',
      description: '',
      task: {},

      taskLabels: [],
      search: null
    }
  },
  computed: {
    ...mapState('todo-app', ['labels']),
    isEdit() {
      return this.task && this.task.id
    }
  },
  methods: {
    ...mapMutations('todo-app', ['updateTask', 'addTask']),
    open(task) {
      if (task) {
        this.task = task
        this.title = this.task.title
        this.description = this.task.description
        this.taskLabels = this.task.labels
      } else {
        this.task = {}
        this.title = ''
        this.description = ''
        this.taskLabels = []
      }

      this.dialog = true
    },
    close() {
      this.dialog = false
    },
    save() {
      const { title, description, taskLabels } = this
      const task = {
        title,
        description,
        labels: taskLabels
      }

      if (this.task.id) {
        this.updateTask({
          ...this.task,
          ...task
        })
      } else {
        this.addTask(task)
      }

      this.close()
    },
    filter (item, queryText, itemText) {
      const hasValue = (val) => val !== null ? val : ''

      const text = hasValue(item.title)
      const query = hasValue(queryText)

      return text.toString()
        .toLowerCase()
        .indexOf(query.toString().toLowerCase()) > -1
    }
  }
}
</script>
