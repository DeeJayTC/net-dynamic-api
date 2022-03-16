<template>
  <ui-demo title="Ratings" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/ratings" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/ratings/usage.vue'
import ColorsSnippet from '!!raw-loader!./_examples/ratings/simple/colors.vue'
import LengthSnippet from '!!raw-loader!./_examples/ratings/simple/length.vue'
import SizesSnippet from '!!raw-loader!./_examples/ratings/simple/sizes.vue'
import CardSnippet from '!!raw-loader!./_examples/ratings/intermediate/card.vue'
import IncrementsSnippet from '!!raw-loader!./_examples/ratings/intermediate/increments.vue'
import SlotsSnippet from '!!raw-loader!./_examples/ratings/intermediate/slots.vue'
import AdvancedSnippet from '!!raw-loader!./_examples/ratings/complex/advanced.vue'

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
        title: 'Colors',
        snippet: ColorsSnippet
      },
      {
        title: 'Length',
        snippet: LengthSnippet
      },
      {
        title: 'Sizes',
        snippet: SizesSnippet
      },
      {
        title: 'Card',
        snippet: CardSnippet
      },
      {
        title: 'Increments',
        snippet: IncrementsSnippet
      },
      {
        title: 'Slots',
        snippet: SlotsSnippet
      },
      {
        title: 'Advanced',
        snippet: AdvancedSnippet
      }
    ]
  })
}
</script>
