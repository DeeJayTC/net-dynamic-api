<template>
  <ui-demo title="Timelines" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/timelines" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/timelines/usage.vue'
import CardSnippet from '!!raw-loader!./_examples/timelines/simple/card.vue'
import IconsSnippet from '!!raw-loader!./_examples/timelines/simple/icons.vue'
import ReverseSnippet from '!!raw-loader!./_examples/timelines/simple/reverse.vue'
import SmallSnippet from '!!raw-loader!./_examples/timelines/simple/small.vue'
import AlertSnippet from '!!raw-loader!./_examples/timelines/intermediate/alert.vue'
import AvatarsSnippet from '!!raw-loader!./_examples/timelines/intermediate/avatars.vue'
import SlotSnippet from '!!raw-loader!./_examples/timelines/intermediate/slot.vue'
import AdvancedSnippet from '!!raw-loader!./_examples/timelines/complex/advanced.vue'
import ColorSnippet from '!!raw-loader!./_examples/timelines/complex/color.vue'

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
        title: 'Card',
        snippet: CardSnippet
      },
      {
        title: 'Icons',
        snippet: IconsSnippet
      },
      {
        title: 'Reverse',
        snippet: ReverseSnippet
      },
      {
        title: 'Small',
        snippet: SmallSnippet
      },
      {
        title: 'Alert',
        snippet: AlertSnippet
      },
      {
        title: 'Avatars',
        snippet: AvatarsSnippet
      },
      {
        title: 'Slot',
        snippet: SlotSnippet
      },
      {
        title: 'Advanced',
        snippet: AdvancedSnippet
      },
      {
        title: 'Color',
        snippet: ColorSnippet
      }
    ]
  })
}
</script>
