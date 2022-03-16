<template>
  <ui-demo title="Position" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/styles/display" target="_blank">Documentation</a> for Vuetify styles.</div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import ExampleSnippet from '!!raw-loader!./_examples/position/example.vue'

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
