<template>
  <ui-demo title="System Bars" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/system-bars" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/system-bars/usage.vue'
import ColorSnippet from '!!raw-loader!./_examples/system-bars/simple/color.vue'
import LightsOutSnippet from '!!raw-loader!./_examples/system-bars/simple/lights-out.vue'
import ThemesSnippet from '!!raw-loader!./_examples/system-bars/simple/themes.vue'
import WindowSnippet from '!!raw-loader!./_examples/system-bars/simple/window.vue'

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
        title: 'Lights Out',
        snippet: LightsOutSnippet
      },
      {
        title: 'Themes',
        snippet: ThemesSnippet
      },
      {
        title: 'Window',
        snippet: WindowSnippet
      }
    ]
  })
}
</script>
