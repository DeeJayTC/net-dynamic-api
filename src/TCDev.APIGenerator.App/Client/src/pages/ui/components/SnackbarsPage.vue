<template>
  <ui-demo title="Snackbars" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/snackbars" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/snackbars/usage.vue'
import AutoHeightSnippet from '!!raw-loader!./_examples/snackbars/simple/auto-height.vue'
import MultiLineSnippet from '!!raw-loader!./_examples/snackbars/simple/multi-line.vue'
import TimeoutSnippet from '!!raw-loader!./_examples/snackbars/simple/timeout.vue'
import VariantsSnippet from '!!raw-loader!./_examples/snackbars/simple/variants.vue'
import VerticalSnippet from '!!raw-loader!./_examples/snackbars/simple/vertical.vue'

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
        title: 'Auto Height',
        snippet: AutoHeightSnippet
      },
      {
        title: 'Multi Line',
        snippet: MultiLineSnippet
      },
      {
        title: 'Timeout',
        snippet: TimeoutSnippet
      },
      {
        title: 'Variants',
        snippet: VariantsSnippet
      },
      {
        title: 'Vertical',
        snippet: VerticalSnippet
      }
    ]
  })
}
</script>
