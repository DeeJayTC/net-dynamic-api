<template>
  <ui-demo title="Inputs" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/inputs" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/inputs/usage.vue'
import ErrorSnippet from '!!raw-loader!./_examples/inputs/simple/error.vue'
import HintSnippet from '!!raw-loader!./_examples/inputs/simple/hint.vue'
import LoadingSnippet from '!!raw-loader!./_examples/inputs/simple/loading.vue'
import MultiErrorSnippet from '!!raw-loader!./_examples/inputs/simple/multi-error.vue'
import SuccessSnippet from '!!raw-loader!./_examples/inputs/simple/success.vue'
import HideDetailsSnippet from '!!raw-loader!./_examples/inputs/intermediate/hide-details.vue'
import RulesSnippet from '!!raw-loader!./_examples/inputs/intermediate/rules.vue'
import SlotEventsSnippet from '!!raw-loader!./_examples/inputs/intermediate/slot-events.vue'
import SlotsSnippet from '!!raw-loader!./_examples/inputs/intermediate/slots.vue'

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
        title: 'Error',
        snippet: ErrorSnippet
      },
      {
        title: 'Hint',
        snippet: HintSnippet
      },
      {
        title: 'Loading',
        snippet: LoadingSnippet
      },
      {
        title: 'Multi Error',
        snippet: MultiErrorSnippet
      },
      {
        title: 'Success',
        snippet: SuccessSnippet
      },
      {
        title: 'Hide Details',
        snippet: HideDetailsSnippet
      },
      {
        title: 'Rules',
        snippet: RulesSnippet
      },
      {
        title: 'Slot Events',
        snippet: SlotEventsSnippet
      },
      {
        title: 'Slots',
        snippet: SlotsSnippet
      }
    ]
  })
}
</script>
