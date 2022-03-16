<template>
  <ui-demo title="Usage" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import ColorSnippet from '!!raw-loader!./_examples/usage/simple/color.vue'
import ButtonsSnippet from '!!raw-loader!./_examples/usage/intermediate/buttons.vue'
import ClickableSnippet from '!!raw-loader!./_examples/usage/intermediate/clickable.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Color',
        snippet: ColorSnippet
      },
      {
        title: 'Buttons',
        snippet: ButtonsSnippet
      },
      {
        title: 'Clickable',
        snippet: ClickableSnippet
      }
    ]
  })
}
</script>
