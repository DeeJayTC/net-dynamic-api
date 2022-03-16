<template>
  <ui-demo title="Uppercase" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import ExampleSnippet from '!!raw-loader!./_examples/uppercase/example.vue'

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
