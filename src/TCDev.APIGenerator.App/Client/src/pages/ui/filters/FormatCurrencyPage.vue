<template>
  <ui-demo title="Format Currency" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import ExampleSnippet from '!!raw-loader!./_examples/format-currency/example.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Example',
        snippet: ExampleSnippet
      }
    ]
  })
}
</script>
