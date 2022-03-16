<template>
  <ui-demo title="Paginations" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/paginations" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/paginations/usage.vue'
import CircleSnippet from '!!raw-loader!./_examples/paginations/simple/circle.vue'
import DisabledSnippet from '!!raw-loader!./_examples/paginations/simple/disabled.vue'
import IconsSnippet from '!!raw-loader!./_examples/paginations/simple/icons.vue'
import LimitSnippet from '!!raw-loader!./_examples/paginations/simple/limit.vue'
import LongSnippet from '!!raw-loader!./_examples/paginations/simple/long.vue'

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
        title: 'Circle',
        snippet: CircleSnippet
      },
      {
        title: 'Disabled',
        snippet: DisabledSnippet
      },
      {
        title: 'Icons',
        snippet: IconsSnippet
      },
      {
        title: 'Limit',
        snippet: LimitSnippet
      },
      {
        title: 'Long',
        snippet: LongSnippet
      }
    ]
  })
}
</script>
