<template>
  <ui-demo title="Combobox" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/combobox" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import ComboboxMultipleSnippet from '!!raw-loader!./_examples/combobox/simple/combobox-multiple.vue'
import DenseSnippet from '!!raw-loader!./_examples/combobox/simple/dense.vue'
import AdvancedSnippet from '!!raw-loader!./_examples/combobox/intermediate/advanced.vue'
import NoDataSnippet from '!!raw-loader!./_examples/combobox/intermediate/no-data.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Combobox Multiple',
        snippet: ComboboxMultipleSnippet
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
        title: 'No Data',
        snippet: NoDataSnippet
      }
    ]
  })
}
</script>
