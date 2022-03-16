<template>
  <ui-demo title="File Inputs" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/file-inputs" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import AcceptSnippet from '!!raw-loader!./_examples/file-inputs/simple/accept.vue'
import ChipsSnippet from '!!raw-loader!./_examples/file-inputs/simple/chips.vue'
import CounterSnippet from '!!raw-loader!./_examples/file-inputs/simple/counter.vue'
import CustomIconSnippet from '!!raw-loader!./_examples/file-inputs/simple/custom-icon.vue'
import DenseSnippet from '!!raw-loader!./_examples/file-inputs/simple/dense.vue'
import MultipleSnippet from '!!raw-loader!./_examples/file-inputs/simple/multiple.vue'
import SizeSnippet from '!!raw-loader!./_examples/file-inputs/simple/size.vue'
import SelectionSnippet from '!!raw-loader!./_examples/file-inputs/intermediate/selection.vue'
import ValidationSnippet from '!!raw-loader!./_examples/file-inputs/intermediate/validation.vue'
import AdvancedSnippet from '!!raw-loader!./_examples/file-inputs/complex/advanced.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Accept',
        snippet: AcceptSnippet
      },
      {
        title: 'Chips',
        snippet: ChipsSnippet
      },
      {
        title: 'Counter',
        snippet: CounterSnippet
      },
      {
        title: 'Custom Icon',
        snippet: CustomIconSnippet
      },
      {
        title: 'Dense',
        snippet: DenseSnippet
      },
      {
        title: 'Multiple',
        snippet: MultipleSnippet
      },
      {
        title: 'Size',
        snippet: SizeSnippet
      },
      {
        title: 'Selection',
        snippet: SelectionSnippet
      },
      {
        title: 'Validation',
        snippet: ValidationSnippet
      },
      {
        title: 'Advanced',
        snippet: AdvancedSnippet
      }
    ]
  })
}
</script>
