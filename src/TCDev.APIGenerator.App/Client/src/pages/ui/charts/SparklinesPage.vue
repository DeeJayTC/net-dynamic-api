<template>
  <ui-demo title="Sparklines" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/sparklines/usage.vue'
import FillSnippet from '!!raw-loader!./_examples/sparklines/simple/fill.vue'
import DashboardCardSnippet from '!!raw-loader!./_examples/sparklines/intermediate/dashboard-card.vue'
import HeartRateSnippet from '!!raw-loader!./_examples/sparklines/intermediate/heart-rate.vue'
import SalesCardSnippet from '!!raw-loader!./_examples/sparklines/intermediate/sales-card.vue'

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
        title: 'Fill',
        snippet: FillSnippet
      },
      {
        title: 'Dashboard Card',
        snippet: DashboardCardSnippet
      },
      {
        title: 'Heart Rate',
        snippet: HeartRateSnippet
      },
      {
        title: 'Sales Card',
        snippet: SalesCardSnippet
      }
    ]
  })
}
</script>
