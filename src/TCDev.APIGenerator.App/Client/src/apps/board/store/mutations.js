/*
|---------------------------------------------------------------------
| Board Vuex Mutations
|---------------------------------------------------------------------
|
| Synchronous operations for board store
|
*/
export default {
  addCard: (state, card) => {
    state.cards.push({
      id: '_' + Math.random().toString(36).substr(2, 9),
      ...card
    })
  },
  updateOrder: (state, cards) => {
    state.cards = cards
  },
  updateCard: (state, card) => {
    const cardIdx = state.cards.find((t) => t.id === card.id)

    Object.assign(cardIdx, card)
  },
  deleteCard: (state, card) => {
    const cardIdx = state.cards.findIndex((t) => t.id === card.id)

    if (cardIdx !== -1) state.cards.splice(cardIdx, 1)
  }
}
