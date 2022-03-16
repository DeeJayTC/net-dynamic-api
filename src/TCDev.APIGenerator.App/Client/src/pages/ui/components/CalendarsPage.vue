<template>
  <ui-demo title="Calendars" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/calendars" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/calendars/usage.vue'
import DailySnippet from '!!raw-loader!./_examples/calendars/simple/daily.vue'
import WeeklySnippet from '!!raw-loader!./_examples/calendars/simple/weekly.vue'
import NowlineSnippet from '!!raw-loader!./_examples/calendars/intermediate/nowline.vue'
import SlotsSnippet from '!!raw-loader!./_examples/calendars/intermediate/slots.vue'
import CategorySnippet from '!!raw-loader!./_examples/calendars/complex/category.vue'
import DragndropSnippet from '!!raw-loader!./_examples/calendars/complex/dragndrop.vue'
import EventsSnippet from '!!raw-loader!./_examples/calendars/complex/events.vue'

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
        title: 'Daily',
        snippet: DailySnippet
      },
      {
        title: 'Weekly',
        snippet: WeeklySnippet
      },
      {
        title: 'Nowline',
        snippet: NowlineSnippet
      },
      {
        title: 'Slots',
        snippet: SlotsSnippet
      },
      {
        title: 'Category',
        snippet: CategorySnippet
      },
      {
        title: 'Dragndrop',
        snippet: DragndropSnippet
      },
      {
        title: 'Events',
        snippet: EventsSnippet
      }
    ]
  })
}
</script>
