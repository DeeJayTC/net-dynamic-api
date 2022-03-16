<template>
  <ui-demo title="Carousels" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/carousels" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import CustomIconsSnippet from '!!raw-loader!./_examples/carousels/simple/custom-icons.vue'
import CustomTransitionSnippet from '!!raw-loader!./_examples/carousels/simple/custom-transition.vue'
import CycleSnippet from '!!raw-loader!./_examples/carousels/simple/cycle.vue'
import HideControlsSnippet from '!!raw-loader!./_examples/carousels/simple/hide-controls.vue'
import HideDelimitersSnippet from '!!raw-loader!./_examples/carousels/simple/hide-delimiters.vue'
import ModelSnippet from '!!raw-loader!./_examples/carousels/intermediate/model.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Custom Icons',
        snippet: CustomIconsSnippet
      },
      {
        title: 'Custom Transition',
        snippet: CustomTransitionSnippet
      },
      {
        title: 'Cycle',
        snippet: CycleSnippet
      },
      {
        title: 'Hide Controls',
        snippet: HideControlsSnippet
      },
      {
        title: 'Hide Delimiters',
        snippet: HideDelimitersSnippet
      },
      {
        title: 'Model',
        snippet: ModelSnippet
      }
    ]
  })
}
</script>
