<template>
  <ui-demo title="List Item Groups" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/list-item-groups" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/list-item-groups/usage.vue'
import ActiveClassSnippet from '!!raw-loader!./_examples/list-item-groups/simple/active-class.vue'
import FlatSnippet from '!!raw-loader!./_examples/list-item-groups/simple/flat.vue'
import MandatorySnippet from '!!raw-loader!./_examples/list-item-groups/simple/mandatory.vue'
import MultipleSnippet from '!!raw-loader!./_examples/list-item-groups/simple/multiple.vue'
import SelectionControlsSnippet from '!!raw-loader!./_examples/list-item-groups/intermediate/selection-controls.vue'

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
        title: 'Active Class',
        snippet: ActiveClassSnippet
      },
      {
        title: 'Flat',
        snippet: FlatSnippet
      },
      {
        title: 'Mandatory',
        snippet: MandatorySnippet
      },
      {
        title: 'Multiple',
        snippet: MultipleSnippet
      },
      {
        title: 'Selection Controls',
        snippet: SelectionControlsSnippet
      }
    ]
  })
}
</script>
