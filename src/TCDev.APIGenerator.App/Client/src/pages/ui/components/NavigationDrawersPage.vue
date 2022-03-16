<template>
  <ui-demo title="Navigation Drawers" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/navigation-drawers" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/navigation-drawers/usage.vue'
import ColoredSnippet from '!!raw-loader!./_examples/navigation-drawers/simple/colored.vue'
import ExpandOnHoverSnippet from '!!raw-loader!./_examples/navigation-drawers/simple/expand-on-hover.vue'
import MiniSnippet from '!!raw-loader!./_examples/navigation-drawers/simple/mini.vue'
import PermanentFloatingSnippet from '!!raw-loader!./_examples/navigation-drawers/simple/permanent-floating.vue'
import RightSnippet from '!!raw-loader!./_examples/navigation-drawers/simple/right.vue'
import TemporarySnippet from '!!raw-loader!./_examples/navigation-drawers/simple/temporary.vue'
import BackgroundSnippet from '!!raw-loader!./_examples/navigation-drawers/intermediate/background.vue'
import CombinedSnippet from '!!raw-loader!./_examples/navigation-drawers/intermediate/combined.vue'
import BottomDrawerSnippet from '!!raw-loader!./_examples/navigation-drawers/complex/bottom-drawer.vue'

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
        title: 'Colored',
        snippet: ColoredSnippet
      },
      {
        title: 'Expand On Hover',
        snippet: ExpandOnHoverSnippet
      },
      {
        title: 'Mini',
        snippet: MiniSnippet
      },
      {
        title: 'Permanent Floating',
        snippet: PermanentFloatingSnippet
      },
      {
        title: 'Right',
        snippet: RightSnippet
      },
      {
        title: 'Temporary',
        snippet: TemporarySnippet
      },
      {
        title: 'Background',
        snippet: BackgroundSnippet
      },
      {
        title: 'Combined',
        snippet: CombinedSnippet
      },
      {
        title: 'Bottom Drawer',
        snippet: BottomDrawerSnippet
      }
    ]
  })
}
</script>
