<template>
  <div class="board d-flex flex-grow-1 flex-row">

    <!-- board column -->
    <div v-for="column in columns" :key="column.key" class="board-column pa-2">
      <h5>{{ $t(`board.state.${column.key}`) }}</h5>
      <div class="board-column-actions">
        <v-btn icon small color="primary" @click="column.isAddVisible = !column.isAddVisible">
          <v-icon>mdi-plus</v-icon>
        </v-btn>
      </div>

      <!-- add new card form -->
      <v-card v-show="column.isAddVisible" class="pa-2 my-2">
        <v-text-field
          v-model="column.addTitle"
          :label="$t('common.title')"
          :placeholder="$t('board.titlePlaceholder')"
          autofocus
          @keyup.enter="_addCard(column)"
          @keyup.esc="column.isAddVisible = false"
        ></v-text-field>
        <div class="d-flex flex-md-row flex-column">
          <v-btn class="flex-grow-1 ma-1" small @click="column.isAddVisible = !column.isAddVisible">{{ $t('common.cancel') }}</v-btn>
          <v-btn class="flex-grow-1 ma-1" small color="primary" @click="addCard(column)">{{ $t('common.add') }}</v-btn>
        </div>
      </v-card>

      <!-- draggable cards -->
      <vue-draggable
        v-model="column.cards"
        :delay="sortDelay"
        v-bind="dragOptions"
        animation="250"
        class="board-group"
        group="cardsGroup"
        @change="column.callback"
      >
        <board-card
          v-for="card in column.cards"
          :key="card.id"
          :card="card"
          class="board-item my-2 pa-2"
          @delete="showDelete(card)"
          @edit="showEdit(card)"
        />
      </vue-draggable>

    </div>

    <!-- edit card dialog -->
    <v-dialog v-model="editDialog" width="600">
      <v-card>
        <v-card-title class="pa-2">
          <span>{{ $t('board.editCard') }}</span>
          <v-spacer></v-spacer>
          <v-btn icon @click="editDialog = false">
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </v-card-title>

        <v-divider></v-divider>

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
        </div>

        <v-divider></v-divider>

        <v-card-actions class="pa-2">
          <v-btn outlined @click="editDialog = false">{{ $t('common.cancel') }}</v-btn>
          <v-spacer></v-spacer>
          <v-btn color="primary" @click="save">{{ $t('common.save') }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <!-- delete card dialog -->
    <v-dialog v-model="deleteDialog" max-width="290">
      <v-card>
        <v-card-title class="headline">{{ $t('common.delete') }}</v-card-title>
        <v-card-text>{{ $t('board.deleteDescription') }}</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn @click="deleteDialog = false">{{ $t('common.cancel') }}</v-btn>
          <v-btn color="error" @click="_deleteCard()">{{ $t('common.delete') }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import { mapState, mapMutations } from 'vuex'
import VueDraggable from 'vuedraggable'
import BoardCard from '../components/BoardCard'

/*
|---------------------------------------------------------------------
| Board Page
|---------------------------------------------------------------------
|
| Kanban board page component with the logic to display and manage
| cards
|
*/
export default {
  components: {
    VueDraggable,
    BoardCard
  },
  data() {
    return {
      // time in milliseconds to define when the sorting should start
      sortDelay: 0,

      // board states
      states: ['TODO', 'INPROGRESS', 'TESTING', 'DONE'],
      columns: [],

      // edit variables
      editDialog: false,
      cardToEdit: null,
      title: '',
      description: '',

      // delete variables
      deleteDialog: false,
      cardToDelete: null
    }
  },
  computed: {
    ...mapState('board-app', ['cards']),
    dragOptions() {
      return {
        animation: 200,
        group: 'description',
        disabled: false,
        ghostClass: 'ghost'
      }
    }
  },
  watch: {
    cards: function(val) {
      return this.parse(val)
    }
  },
  created() {
    // prepare the columns based on the states available
    this.states.forEach((state, index) => {
      this.columns.push({
        key: state,
        cards: [],
        isAddVisible: false,
        callback: (evt) => this.changeState(evt, index)
      })
    })

    window.addEventListener('resize', this.handleResize)
    this.handleResize()
  },
  mounted() {
    return this.parse(this.cards)
  },
  methods: {
    ...mapMutations('board-app', ['addCard', 'updateCard', 'updateOrder', 'deleteCard']),
    // Assign cards to the respective column based on the state
    parse(cards) {
      if (!cards) return this.columns.map((col) => (col.cards = []))

      return this.columns.forEach((col) => {
        col.cards = cards
          .filter((card) => card.state === col.key)
          .sort((a, b) => a.order < b.order ? -1 : 0)
      })
    },
    handleResize() {
      if (window.innerWidth < 900) {
        this.sortDelay = 200
      } else {
        this.sortDelay = 0
      }
    },
    changeState: function(evt, colIndex) {
      if (evt.added || evt.moved) {
        const column = this.columns[colIndex]
        const state = column.key

        for (let i = 0; i < column.cards.length; i++) {
          column.cards[i].order = i
          column.cards[i].state = state
        }

        this._updateOrder()
      }
    },
    showEdit(card) {
      this.cardToEdit = card
      this.title = card.title
      this.description = card.description
      this.editDialog = true
    },
    save() {
      this.updateCard({
        ...this.cardToEdit,
        title: this.title,
        description: this.description
      })

      this.editDialog = false
    },
    showDelete(card) {
      this.cardToDelete = card
      this.deleteDialog = true
    },
    _deleteCard() {
      this.deleteDialog = false
      this.deleteCard(this.cardToDelete)
    },
    _addCard(column) {
      const { addTitle, key } = column

      this.addCard({
        state: key,
        title: addTitle,
        description: '',
        order: -1
      })

      for (let i = 0; i < column.cards.length; i++) {
        column.cards[i].order = i
      }

      this.$nextTick(this._updateOrder)

      column.addTitle = ''
    },
    _updateOrder() {
      let cards = []

      this.columns.forEach((col) => {
        cards = [
          ...cards,
          ...col.cards
        ]
      })

      this.updateOrder(cards)
    }
  }
}
</script>

<style lang="scss" scoped>
.ghost {
  opacity: 0.5;
  background: var(--v-primary-lighten1) !important;
}

.board {
  display: flex;
  overflow-x: scroll;

  .board-column {
    position: relative;
    display: flex;
    flex: 1;
    flex-direction: column;
    min-width: 180px;

    &-actions {
      position: absolute;
      top: 12px;
      right: 6px;
    }
  }

  .board-group {
    min-height: 100%;
  }

  .board-item {
    position: relative;
    min-height: 54px;
    transition: transform 0.2s;
    cursor: pointer;

    > a {
      display: block;
      padding: 8px;
    }

    &:hover {
      transform: translateY(-6px);
    }

    &.sortable-chosen {
      cursor: all-scroll;
    }
  }
}

.v-application--is-rtl {
  .board-column-actions {
    left: 6px;
    right: auto;
  }
}
</style>
