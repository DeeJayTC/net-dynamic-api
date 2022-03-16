<template>
  <ui-demo title="Tabs" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/tabs" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/tabs/usage.vue'
import CenterActiveSnippet from '!!raw-loader!./_examples/tabs/simple/center-active.vue'
import VerticalSnippet from '!!raw-loader!./_examples/tabs/simple/vertical.vue'
import TabItemsSnippet from '!!raw-loader!./_examples/tabs/simple/tab-items.vue'
import PaginationSnippet from '!!raw-loader!./_examples/tabs/simple/pagination.vue'
import IconsSnippet from '!!raw-loader!./_examples/tabs/simple/icons.vue'
import GrowSnippet from '!!raw-loader!./_examples/tabs/simple/grow.vue'
import FixedTabsSnippet from '!!raw-loader!./_examples/tabs/simple/fixed-tabs.vue'
import RightSnippet from '!!raw-loader!./_examples/tabs/intermediate/right.vue'
import IconsAndTextSnippet from '!!raw-loader!./_examples/tabs/intermediate/icons-and-text.vue'
import DynamicSnippet from '!!raw-loader!./_examples/tabs/intermediate/dynamic.vue'
import ContentSnippet from '!!raw-loader!./_examples/tabs/intermediate/content.vue'
import AlignWithTitleSnippet from '!!raw-loader!./_examples/tabs/intermediate/align-with-title.vue'
import DynamicHeightSnippet from '!!raw-loader!./_examples/tabs/complex/dynamic-height.vue'
import OverflowToMenuSnippet from '!!raw-loader!./_examples/tabs/complex/overflow-to-menu.vue'
import DesktopSnippet from '!!raw-loader!./_examples/tabs/complex/desktop.vue'

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
        title: 'Center Active',
        snippet: CenterActiveSnippet
      },
      {
        title: 'Vertical',
        snippet: VerticalSnippet
      },
      {
        title: 'Tab Items',
        snippet: TabItemsSnippet
      },
      {
        title: 'Pagination',
        snippet: PaginationSnippet
      },
      {
        title: 'Icons',
        snippet: IconsSnippet
      },
      {
        title: 'Grow',
        snippet: GrowSnippet
      },
      {
        title: 'Fixed Tabs',
        snippet: FixedTabsSnippet
      },
      {
        title: 'Right',
        snippet: RightSnippet
      },
      {
        title: 'Icons And Text',
        snippet: IconsAndTextSnippet
      },
      {
        title: 'Dynamic',
        snippet: DynamicSnippet
      },
      {
        title: 'Content',
        snippet: ContentSnippet
      },
      {
        title: 'Align With Title',
        snippet: AlignWithTitleSnippet
      },
      {
        title: 'Dynamic Height',
        snippet: DynamicHeightSnippet
      },
      {
        title: 'Overflow To Menu',
        snippet: OverflowToMenuSnippet
      },
      {
        title: 'Desktop',
        snippet: DesktopSnippet
      }
    ]
  })
}
</script>
