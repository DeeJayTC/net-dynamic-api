<template>
  <ui-demo title="Bottom Navigation" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/bottom-navigation" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/bottom-navigation/usage.vue'
import ColorSnippet from '!!raw-loader!./_examples/bottom-navigation/simple/color.vue'
import GrowSnippet from '!!raw-loader!./_examples/bottom-navigation/simple/grow.vue'
import HorizontalSnippet from '!!raw-loader!./_examples/bottom-navigation/simple/horizontal.vue'
import ShiftSnippet from '!!raw-loader!./_examples/bottom-navigation/simple/shift.vue'
import ToggleSnippet from '!!raw-loader!./_examples/bottom-navigation/simple/toggle.vue'
import HideOnScrollSnippet from '!!raw-loader!./_examples/bottom-navigation/intermediate/hide-on-scroll.vue'
import ScrollThresholdSnippet from '!!raw-loader!./_examples/bottom-navigation/intermediate/scroll-threshold.vue'

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
        title: 'Color',
        snippet: ColorSnippet
      },
      {
        title: 'Grow',
        snippet: GrowSnippet
      },
      {
        title: 'Horizontal',
        snippet: HorizontalSnippet
      },
      {
        title: 'Shift',
        snippet: ShiftSnippet
      },
      {
        title: 'Toggle',
        snippet: ToggleSnippet
      },
      {
        title: 'Hide On Scroll',
        snippet: HideOnScrollSnippet
      },
      {
        title: 'Scroll Threshold',
        snippet: ScrollThresholdSnippet
      }
    ]
  })
}
</script>
