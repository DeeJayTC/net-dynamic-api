<template>
  <ui-demo title="Simple Tables" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/simple-tables" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/simple-tables/usage.vue'
import DarkSnippet from '!!raw-loader!./_examples/simple-tables/simple/dark.vue'
import DenseSnippet from '!!raw-loader!./_examples/simple-tables/simple/dense.vue'
import FixedHeaderSnippet from '!!raw-loader!./_examples/simple-tables/simple/fixed-header.vue'
import HeightSnippet from '!!raw-loader!./_examples/simple-tables/simple/height.vue'

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
        title: 'Dark',
        snippet: DarkSnippet
      },
      {
        title: 'Dense',
        snippet: DenseSnippet
      },
      {
        title: 'Fixed Header',
        snippet: FixedHeaderSnippet
      },
      {
        title: 'Height',
        snippet: HeightSnippet
      }
    ]
  })
}
</script>
