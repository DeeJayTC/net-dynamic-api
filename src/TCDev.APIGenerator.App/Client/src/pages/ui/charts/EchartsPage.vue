<template>
  <ui-demo title="Echarts" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import BarSnippet from '!!raw-loader!./_examples/echarts/bar.vue'
import LineSnippet from '!!raw-loader!./_examples/echarts/line.vue'
import PieSnippet from '!!raw-loader!./_examples/echarts/pie.vue'
import PolarSnippet from '!!raw-loader!./_examples/echarts/polar.vue'
import RadarSnippet from '!!raw-loader!./_examples/echarts/radar.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Bar',
        snippet: BarSnippet
      },
      {
        title: 'Line',
        snippet: LineSnippet
      },
      {
        title: 'Pie',
        snippet: PieSnippet
      },
      {
        title: 'Polar',
        snippet: PolarSnippet
      },
      {
        title: 'Radar',
        snippet: RadarSnippet
      }
    ]
  })
}
</script>
