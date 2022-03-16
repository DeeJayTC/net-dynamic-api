<template>
  <ui-demo title="Apex Charts" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import SplineSnippet from '!!raw-loader!./_examples/apex-charts/simple/spline.vue'
import RadialSnippet from '!!raw-loader!./_examples/apex-charts/simple/radial.vue'
import PieSnippet from '!!raw-loader!./_examples/apex-charts/simple/pie.vue'
import LineSnippet from '!!raw-loader!./_examples/apex-charts/simple/line.vue'
import ColumnSnippet from '!!raw-loader!./_examples/apex-charts/simple/column.vue'
import BarSnippet from '!!raw-loader!./_examples/apex-charts/simple/bar.vue'
import SparklinesSnippet from '!!raw-loader!./_examples/apex-charts/intermediate/sparklines.vue'
import TimelineSnippet from '!!raw-loader!./_examples/apex-charts/intermediate/timeline.vue'
import ScatterSnippet from '!!raw-loader!./_examples/apex-charts/intermediate/scatter.vue'
import CandesticksSnippet from '!!raw-loader!./_examples/apex-charts/complex/candesticks.vue'
import RadarSnippet from '!!raw-loader!./_examples/apex-charts/complex/radar.vue'
import MixedSnippet from '!!raw-loader!./_examples/apex-charts/complex/mixed.vue'
import HeatmapSnippet from '!!raw-loader!./_examples/apex-charts/complex/heatmap.vue'
import BubbleSnippet from '!!raw-loader!./_examples/apex-charts/complex/bubble.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Spline',
        snippet: SplineSnippet
      },
      {
        title: 'Radial',
        snippet: RadialSnippet
      },
      {
        title: 'Pie',
        snippet: PieSnippet
      },
      {
        title: 'Line',
        snippet: LineSnippet
      },
      {
        title: 'Column',
        snippet: ColumnSnippet
      },
      {
        title: 'Bar',
        snippet: BarSnippet
      },
      {
        title: 'Sparklines',
        snippet: SparklinesSnippet
      },
      {
        title: 'Timeline',
        snippet: TimelineSnippet
      },
      {
        title: 'Scatter',
        snippet: ScatterSnippet
      },
      {
        title: 'Candesticks',
        snippet: CandesticksSnippet
      },
      {
        title: 'Radar',
        snippet: RadarSnippet
      },
      {
        title: 'Mixed',
        snippet: MixedSnippet
      },
      {
        title: 'Heatmap',
        snippet: HeatmapSnippet
      },
      {
        title: 'Bubble',
        snippet: BubbleSnippet
      }
    ]
  })
}
</script>
