<template>
  <ui-demo title="Sliders" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/sliders" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import InverseLabelSnippet from '!!raw-loader!./_examples/sliders/simple/inverse-label.vue'
import VerticalSnippet from '!!raw-loader!./_examples/sliders/simple/vertical.vue'
import CustomColorsSnippet from '!!raw-loader!./_examples/sliders/simple/custom-colors.vue'
import CustomThumbSnippet from '!!raw-loader!./_examples/sliders/simple/custom-thumb.vue'
import DisabledSnippet from '!!raw-loader!./_examples/sliders/simple/disabled.vue'
import DiscreteSnippet from '!!raw-loader!./_examples/sliders/simple/discrete.vue'
import EditableNumericValueSnippet from '!!raw-loader!./_examples/sliders/simple/editable-numeric-value.vue'
import IconsSnippet from '!!raw-loader!./_examples/sliders/simple/icons.vue'
import TicksSnippet from '!!raw-loader!./_examples/sliders/simple/ticks.vue'
import MinMaxSnippet from '!!raw-loader!./_examples/sliders/simple/min-max.vue'
import RangeSnippet from '!!raw-loader!./_examples/sliders/simple/range.vue'
import ReadonlySnippet from '!!raw-loader!./_examples/sliders/simple/readonly.vue'
import StepSnippet from '!!raw-loader!./_examples/sliders/simple/step.vue'
import ThumbLabelSnippet from '!!raw-loader!./_examples/sliders/simple/thumb-label.vue'
import ThumbSnippet from '!!raw-loader!./_examples/sliders/simple/thumb.vue'
import ValidationSnippet from '!!raw-loader!./_examples/sliders/intermediate/validation.vue'
import MetronomeSnippet from '!!raw-loader!./_examples/sliders/intermediate/metronome.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Inverse Label',
        snippet: InverseLabelSnippet
      },
      {
        title: 'Vertical',
        snippet: VerticalSnippet
      },
      {
        title: 'Custom Colors',
        snippet: CustomColorsSnippet
      },
      {
        title: 'Custom Thumb',
        snippet: CustomThumbSnippet
      },
      {
        title: 'Disabled',
        snippet: DisabledSnippet
      },
      {
        title: 'Discrete',
        snippet: DiscreteSnippet
      },
      {
        title: 'Editable Numeric Value',
        snippet: EditableNumericValueSnippet
      },
      {
        title: 'Icons',
        snippet: IconsSnippet
      },
      {
        title: 'Ticks',
        snippet: TicksSnippet
      },
      {
        title: 'Min Max',
        snippet: MinMaxSnippet
      },
      {
        title: 'Range',
        snippet: RangeSnippet
      },
      {
        title: 'Readonly',
        snippet: ReadonlySnippet
      },
      {
        title: 'Step',
        snippet: StepSnippet
      },
      {
        title: 'Thumb Label',
        snippet: ThumbLabelSnippet
      },
      {
        title: 'Thumb',
        snippet: ThumbSnippet
      },
      {
        title: 'Validation',
        snippet: ValidationSnippet
      },
      {
        title: 'Metronome',
        snippet: MetronomeSnippet
      }
    ]
  })
}
</script>
