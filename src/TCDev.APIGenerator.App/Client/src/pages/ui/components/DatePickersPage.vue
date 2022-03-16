<template>
  <ui-demo title="Date Pickers" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/date-pickers" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/date-pickers/usage.vue'
import DatePickerDateSnippet from '!!raw-loader!./_examples/date-pickers/simple/date-picker-date.vue'
import MonthWidthSnippet from '!!raw-loader!./_examples/date-pickers/simple/month-width.vue'
import MonthReadonlySnippet from '!!raw-loader!./_examples/date-pickers/simple/month-readonly.vue'
import MonthMultipleSnippet from '!!raw-loader!./_examples/date-pickers/simple/month-multiple.vue'
import MonthLightSnippet from '!!raw-loader!./_examples/date-pickers/simple/month-light.vue'
import MonthInternationalizationSnippet from '!!raw-loader!./_examples/date-pickers/simple/month-internationalization.vue'
import DateAllowedDatesSnippet from '!!raw-loader!./_examples/date-pickers/simple/date-allowed-dates.vue'
import DateButtonEventsSnippet from '!!raw-loader!./_examples/date-pickers/simple/date-button-events.vue'
import DateColorableSnippet from '!!raw-loader!./_examples/date-pickers/simple/date-colorable.vue'
import DateCurrentSnippet from '!!raw-loader!./_examples/date-pickers/simple/date-current.vue'
import DateIconsSnippet from '!!raw-loader!./_examples/date-pickers/simple/date-icons.vue'
import DateInternationalizationSnippet from '!!raw-loader!./_examples/date-pickers/simple/date-internationalization.vue'
import MonthIconsSnippet from '!!raw-loader!./_examples/date-pickers/simple/month-icons.vue'
import DateReadonlySnippet from '!!raw-loader!./_examples/date-pickers/simple/date-readonly.vue'
import DateWidthSnippet from '!!raw-loader!./_examples/date-pickers/simple/date-width.vue'
import ElevationSnippet from '!!raw-loader!./_examples/date-pickers/simple/elevation.vue'
import MonthAllowedMonthsSnippet from '!!raw-loader!./_examples/date-pickers/simple/month-allowed-months.vue'
import MonthColorableSnippet from '!!raw-loader!./_examples/date-pickers/simple/month-colorable.vue'
import MonthCurrentSnippet from '!!raw-loader!./_examples/date-pickers/simple/month-current.vue'
import DateDialogAndMenuSnippet from '!!raw-loader!./_examples/date-pickers/intermediate/date-dialog-and-menu.vue'
import MonthDialogAndMenuSnippet from '!!raw-loader!./_examples/date-pickers/intermediate/month-dialog-and-menu.vue'
import DateRangeSnippet from '!!raw-loader!./_examples/date-pickers/intermediate/date-range.vue'
import DateMultipleSnippet from '!!raw-loader!./_examples/date-pickers/intermediate/date-multiple.vue'
import DateFormattingSnippet from '!!raw-loader!./_examples/date-pickers/intermediate/date-formatting.vue'
import DateEventsSnippet from '!!raw-loader!./_examples/date-pickers/intermediate/date-events.vue'
import DateBirthdaySnippet from '!!raw-loader!./_examples/date-pickers/intermediate/date-birthday.vue'

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
        title: 'Date Picker Date',
        snippet: DatePickerDateSnippet
      },
      {
        title: 'Month Width',
        snippet: MonthWidthSnippet
      },
      {
        title: 'Month Readonly',
        snippet: MonthReadonlySnippet
      },
      {
        title: 'Month Multiple',
        snippet: MonthMultipleSnippet
      },
      {
        title: 'Month Light',
        snippet: MonthLightSnippet
      },
      {
        title: 'Month Internationalization',
        snippet: MonthInternationalizationSnippet
      },
      {
        title: 'Date Allowed Dates',
        snippet: DateAllowedDatesSnippet
      },
      {
        title: 'Date Button Events',
        snippet: DateButtonEventsSnippet
      },
      {
        title: 'Date Colorable',
        snippet: DateColorableSnippet
      },
      {
        title: 'Date Current',
        snippet: DateCurrentSnippet
      },
      {
        title: 'Date Icons',
        snippet: DateIconsSnippet
      },
      {
        title: 'Date Internationalization',
        snippet: DateInternationalizationSnippet
      },
      {
        title: 'Month Icons',
        snippet: MonthIconsSnippet
      },
      {
        title: 'Date Readonly',
        snippet: DateReadonlySnippet
      },
      {
        title: 'Date Width',
        snippet: DateWidthSnippet
      },
      {
        title: 'Elevation',
        snippet: ElevationSnippet
      },
      {
        title: 'Month Allowed Months',
        snippet: MonthAllowedMonthsSnippet
      },
      {
        title: 'Month Colorable',
        snippet: MonthColorableSnippet
      },
      {
        title: 'Month Current',
        snippet: MonthCurrentSnippet
      },
      {
        title: 'Date Dialog And Menu',
        snippet: DateDialogAndMenuSnippet
      },
      {
        title: 'Month Dialog And Menu',
        snippet: MonthDialogAndMenuSnippet
      },
      {
        title: 'Date Range',
        snippet: DateRangeSnippet
      },
      {
        title: 'Date Multiple',
        snippet: DateMultipleSnippet
      },
      {
        title: 'Date Formatting',
        snippet: DateFormattingSnippet
      },
      {
        title: 'Date Events',
        snippet: DateEventsSnippet
      },
      {
        title: 'Date Birthday',
        snippet: DateBirthdaySnippet
      }
    ]
  })
}
</script>
