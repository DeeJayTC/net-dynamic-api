<template>
  <ui-demo title="Floating Action Buttons" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/floating-action-buttons" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/floating-action-buttons/usage.vue'
import DisplayAnimationSnippet from '!!raw-loader!./_examples/floating-action-buttons/simple/display-animation.vue'
import SmallSnippet from '!!raw-loader!./_examples/floating-action-buttons/simple/small.vue'
import SpeedDialSnippet from '!!raw-loader!./_examples/floating-action-buttons/intermediate/speed-dial.vue'
import LateralScreensSnippet from '!!raw-loader!./_examples/floating-action-buttons/complex/lateral-screens.vue'

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
        title: 'Display Animation',
        snippet: DisplayAnimationSnippet
      },
      {
        title: 'Small',
        snippet: SmallSnippet
      },
      {
        title: 'Speed Dial',
        snippet: SpeedDialSnippet
      },
      {
        title: 'Lateral Screens',
        snippet: LateralScreensSnippet
      }
    ]
  })
}
</script>
