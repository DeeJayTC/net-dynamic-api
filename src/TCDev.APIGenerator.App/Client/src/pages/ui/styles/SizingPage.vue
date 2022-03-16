<template>
  <ui-demo title="Sizing" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/styles/display" target="_blank">Documentation</a> for Vuetify styles.</div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import HeightSnippet from '!!raw-loader!./_examples/sizing/height.vue'
import MinHeightSnippet from '!!raw-loader!./_examples/sizing/min-height.vue'
import MinWidthSnippet from '!!raw-loader!./_examples/sizing/min-width.vue'
import WidthSnippet from '!!raw-loader!./_examples/sizing/width.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Height',
        snippet: HeightSnippet
      },
      {
        title: 'Min Height',
        snippet: MinHeightSnippet
      },
      {
        title: 'Min Width',
        snippet: MinWidthSnippet
      },
      {
        title: 'Width',
        snippet: WidthSnippet
      }
    ]
  })
}
</script>
