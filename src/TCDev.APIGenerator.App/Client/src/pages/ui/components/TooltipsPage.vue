<template>
  <ui-demo title="Tooltips" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/tooltips" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/tooltips/usage.vue'
import AlignmentSnippet from '!!raw-loader!./_examples/tooltips/alignment.vue'
import VisibilitySnippet from '!!raw-loader!./_examples/tooltips/visibility.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Usage',
        snippet: UsageSnippet
      },
      {
        title: 'Alignment',
        snippet: AlignmentSnippet
      },
      {
        title: 'Visibility',
        snippet: VisibilitySnippet
      }
    ]
  })
}
</script>
