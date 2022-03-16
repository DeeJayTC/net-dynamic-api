<template>
  <ui-demo title="Textarea" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/textarea" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/textarea/usage.vue'
import AutoGrowSnippet from '!!raw-loader!./_examples/textarea/simple/auto-grow.vue'
import BackgroundColorSnippet from '!!raw-loader!./_examples/textarea/simple/background-color.vue'
import BrowserAutocompleteSnippet from '!!raw-loader!./_examples/textarea/simple/browser-autocomplete.vue'
import ClearableSnippet from '!!raw-loader!./_examples/textarea/simple/clearable.vue'
import CounterSnippet from '!!raw-loader!./_examples/textarea/simple/counter.vue'
import IconSnippet from '!!raw-loader!./_examples/textarea/simple/icon.vue'
import NoResizeSnippet from '!!raw-loader!./_examples/textarea/simple/no-resize.vue'
import RowsSnippet from '!!raw-loader!./_examples/textarea/simple/rows.vue'
import SignupBoxSnippet from '!!raw-loader!./_examples/textarea/intermediate/signup-box.vue'

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
        title: 'Auto Grow',
        snippet: AutoGrowSnippet
      },
      {
        title: 'Background Color',
        snippet: BackgroundColorSnippet
      },
      {
        title: 'Browser Autocomplete',
        snippet: BrowserAutocompleteSnippet
      },
      {
        title: 'Clearable',
        snippet: ClearableSnippet
      },
      {
        title: 'Counter',
        snippet: CounterSnippet
      },
      {
        title: 'Icon',
        snippet: IconSnippet
      },
      {
        title: 'No Resize',
        snippet: NoResizeSnippet
      },
      {
        title: 'Rows',
        snippet: RowsSnippet
      },
      {
        title: 'Signup Box',
        snippet: SignupBoxSnippet
      }
    ]
  })
}
</script>
