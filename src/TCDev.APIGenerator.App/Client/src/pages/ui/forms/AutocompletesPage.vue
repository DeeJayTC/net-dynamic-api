<template>
  <ui-demo title="Autocompletes" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/autocompletes" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import ApiSnippet from '!!raw-loader!./_examples/autocompletes/simple/api.vue'
import CustomfilterSnippet from '!!raw-loader!./_examples/autocompletes/simple/customFilter.vue'
import DenseSnippet from '!!raw-loader!./_examples/autocompletes/simple/dense.vue'
import AdvancedSnippet from '!!raw-loader!./_examples/autocompletes/intermediate/advanced.vue'
import AsynchronousSnippet from '!!raw-loader!./_examples/autocompletes/intermediate/asynchronous.vue'
import SlotsSnippet from '!!raw-loader!./_examples/autocompletes/intermediate/slots.vue'
import StateselectorSnippet from '!!raw-loader!./_examples/autocompletes/complex/stateSelector.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Api',
        snippet: ApiSnippet
      },
      {
        title: 'Customfilter',
        snippet: CustomfilterSnippet
      },
      {
        title: 'Dense',
        snippet: DenseSnippet
      },
      {
        title: 'Advanced',
        snippet: AdvancedSnippet
      },
      {
        title: 'Asynchronous',
        snippet: AsynchronousSnippet
      },
      {
        title: 'Slots',
        snippet: SlotsSnippet
      },
      {
        title: 'Stateselector',
        snippet: StateselectorSnippet
      }
    ]
  })
}
</script>
