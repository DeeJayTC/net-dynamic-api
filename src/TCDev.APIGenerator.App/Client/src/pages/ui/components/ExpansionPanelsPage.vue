<template>
  <ui-demo title="Expansion Panels" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/expansion-panels" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/expansion-panels/usage.vue'
import AccordionSnippet from '!!raw-loader!./_examples/expansion-panels/simple/accordion.vue'
import DisabledSnippet from '!!raw-loader!./_examples/expansion-panels/simple/disabled.vue'
import FocusableSnippet from '!!raw-loader!./_examples/expansion-panels/simple/focusable.vue'
import InsetSnippet from '!!raw-loader!./_examples/expansion-panels/simple/inset.vue'
import PopoutSnippet from '!!raw-loader!./_examples/expansion-panels/simple/popout.vue'
import ReadonlySnippet from '!!raw-loader!./_examples/expansion-panels/simple/readonly.vue'
import CustomIconsSnippet from '!!raw-loader!./_examples/expansion-panels/intermediate/custom-icons.vue'
import ExternalSnippet from '!!raw-loader!./_examples/expansion-panels/intermediate/external.vue'
import AdvancedSnippet from '!!raw-loader!./_examples/expansion-panels/complex/advanced.vue'

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
        title: 'Accordion',
        snippet: AccordionSnippet
      },
      {
        title: 'Disabled',
        snippet: DisabledSnippet
      },
      {
        title: 'Focusable',
        snippet: FocusableSnippet
      },
      {
        title: 'Inset',
        snippet: InsetSnippet
      },
      {
        title: 'Popout',
        snippet: PopoutSnippet
      },
      {
        title: 'Readonly',
        snippet: ReadonlySnippet
      },
      {
        title: 'Custom Icons',
        snippet: CustomIconsSnippet
      },
      {
        title: 'External',
        snippet: ExternalSnippet
      },
      {
        title: 'Advanced',
        snippet: AdvancedSnippet
      }
    ]
  })
}
</script>
