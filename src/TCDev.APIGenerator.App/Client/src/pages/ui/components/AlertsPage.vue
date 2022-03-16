<template>
  <ui-demo title="Alerts" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/alerts" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import IconSnippet from '!!raw-loader!./_examples/alerts/simple/icon.vue'
import TypeSnippet from '!!raw-loader!./_examples/alerts/simple/type.vue'
import ColoredBorderSnippet from '!!raw-loader!./_examples/alerts/simple/colored-border.vue'
import DenseSnippet from '!!raw-loader!./_examples/alerts/simple/dense.vue'
import DismissibleSnippet from '!!raw-loader!./_examples/alerts/simple/dismissible.vue'
import BorderSnippet from '!!raw-loader!./_examples/alerts/simple/border.vue'
import OutlinedSnippet from '!!raw-loader!./_examples/alerts/simple/outlined.vue'
import ProminentSnippet from '!!raw-loader!./_examples/alerts/simple/prominent.vue'
import TextSnippet from '!!raw-loader!./_examples/alerts/simple/text.vue'
import TransitionSnippet from '!!raw-loader!./_examples/alerts/simple/transition.vue'
import TwitterSnippet from '!!raw-loader!./_examples/alerts/complex/twitter.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Icon',
        snippet: IconSnippet
      },
      {
        title: 'Type',
        snippet: TypeSnippet
      },
      {
        title: 'Colored Border',
        snippet: ColoredBorderSnippet
      },
      {
        title: 'Dense',
        snippet: DenseSnippet
      },
      {
        title: 'Dismissible',
        snippet: DismissibleSnippet
      },
      {
        title: 'Border',
        snippet: BorderSnippet
      },
      {
        title: 'Outlined',
        snippet: OutlinedSnippet
      },
      {
        title: 'Prominent',
        snippet: ProminentSnippet
      },
      {
        title: 'Text',
        snippet: TextSnippet
      },
      {
        title: 'Transition',
        snippet: TransitionSnippet
      },
      {
        title: 'Twitter',
        snippet: TwitterSnippet
      }
    ]
  })
}
</script>
