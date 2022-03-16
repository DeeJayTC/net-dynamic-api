<template>
  <ui-demo title="Badges" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/badges" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import TabsSnippet from '!!raw-loader!./_examples/badges/simple/tabs.vue'
import HoverSnippet from '!!raw-loader!./_examples/badges/intermediate/hover.vue'
import CustomizationSnippet from '!!raw-loader!./_examples/badges/complex/customization.vue'
import DynamicSnippet from '!!raw-loader!./_examples/badges/complex/dynamic.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Tabs',
        snippet: TabsSnippet
      },
      {
        title: 'Hover',
        snippet: HoverSnippet
      },
      {
        title: 'Customization',
        snippet: CustomizationSnippet
      },
      {
        title: 'Dynamic',
        snippet: DynamicSnippet
      }
    ]
  })
}
</script>
