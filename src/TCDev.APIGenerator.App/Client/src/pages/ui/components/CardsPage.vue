<template>
  <ui-demo title="Cards" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/cards" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import OutlinedSnippet from '!!raw-loader!./_examples/cards/simple/outlined.vue'
import GridsSnippet from '!!raw-loader!./_examples/cards/intermediate/grids.vue'
import InfoCardSnippet from '!!raw-loader!./_examples/cards/intermediate/info-card.vue'
import IntermediateSnippet from '!!raw-loader!./_examples/cards/intermediate/intermediate.vue'
import MediaWithTextSnippet from '!!raw-loader!./_examples/cards/intermediate/media-with-text.vue'
import TwitterCardSnippet from '!!raw-loader!./_examples/cards/complex/twitter-card.vue'
import CustomActionsSnippet from '!!raw-loader!./_examples/cards/complex/custom-actions.vue'
import AdvancedSnippet from '!!raw-loader!./_examples/cards/complex/advanced.vue'
import DesertSnippet from '!!raw-loader!./_examples/cards/complex/desert.vue'
import HorizontalSnippet from '!!raw-loader!./_examples/cards/complex/horizontal.vue'
import LoadingSnippet from '!!raw-loader!./_examples/cards/complex/loading.vue'
import WeatherSnippet from '!!raw-loader!./_examples/cards/complex/weather.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Outlined',
        snippet: OutlinedSnippet
      },
      {
        title: 'Grids',
        snippet: GridsSnippet
      },
      {
        title: 'Info Card',
        snippet: InfoCardSnippet
      },
      {
        title: 'Intermediate',
        snippet: IntermediateSnippet
      },
      {
        title: 'Media With Text',
        snippet: MediaWithTextSnippet
      },
      {
        title: 'Twitter Card',
        snippet: TwitterCardSnippet
      },
      {
        title: 'Custom Actions',
        snippet: CustomActionsSnippet
      },
      {
        title: 'Advanced',
        snippet: AdvancedSnippet
      },
      {
        title: 'Desert',
        snippet: DesertSnippet
      },
      {
        title: 'Horizontal',
        snippet: HorizontalSnippet
      },
      {
        title: 'Loading',
        snippet: LoadingSnippet
      },
      {
        title: 'Weather',
        snippet: WeatherSnippet
      }
    ]
  })
}
</script>
