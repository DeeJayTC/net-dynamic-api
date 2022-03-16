<template>
  <ui-demo title="Bottom Sheets" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/bottom-sheets" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import InsetSnippet from '!!raw-loader!./_examples/bottom-sheets/simple/inset.vue'
import ModelSnippet from '!!raw-loader!./_examples/bottom-sheets/simple/model.vue'
import PersistentSnippet from '!!raw-loader!./_examples/bottom-sheets/simple/persistent.vue'
import OpenInListSnippet from '!!raw-loader!./_examples/bottom-sheets/complex/open-in-list.vue'
import PlayerSnippet from '!!raw-loader!./_examples/bottom-sheets/complex/player.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Inset',
        snippet: InsetSnippet
      },
      {
        title: 'Model',
        snippet: ModelSnippet
      },
      {
        title: 'Persistent',
        snippet: PersistentSnippet
      },
      {
        title: 'Open In List',
        snippet: OpenInListSnippet
      },
      {
        title: 'Player',
        snippet: PlayerSnippet
      }
    ]
  })
}
</script>
