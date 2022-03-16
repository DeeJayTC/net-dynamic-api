<template>
  <ui-demo title="Overflow Buttons" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/overflow-buttons" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/overflow-buttons/usage.vue'
import CounterSnippet from '!!raw-loader!./_examples/overflow-buttons/simple/counter.vue'
import DisabledSnippet from '!!raw-loader!./_examples/overflow-buttons/simple/disabled.vue'
import EditableSnippet from '!!raw-loader!./_examples/overflow-buttons/simple/editable.vue'
import FilledSnippet from '!!raw-loader!./_examples/overflow-buttons/simple/filled.vue'
import DenseSnippet from '!!raw-loader!./_examples/overflow-buttons/simple/dense.vue'
import LoadingSnippet from '!!raw-loader!./_examples/overflow-buttons/simple/loading.vue'
import MenuPropsSnippet from '!!raw-loader!./_examples/overflow-buttons/simple/menu-props.vue'
import ReadonlySnippet from '!!raw-loader!./_examples/overflow-buttons/simple/readonly.vue'
import SegmentedSnippet from '!!raw-loader!./_examples/overflow-buttons/simple/segmented.vue'
import HintSnippet from '!!raw-loader!./_examples/overflow-buttons/simple/hint.vue'

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
        title: 'Counter',
        snippet: CounterSnippet
      },
      {
        title: 'Disabled',
        snippet: DisabledSnippet
      },
      {
        title: 'Editable',
        snippet: EditableSnippet
      },
      {
        title: 'Filled',
        snippet: FilledSnippet
      },
      {
        title: 'Dense',
        snippet: DenseSnippet
      },
      {
        title: 'Loading',
        snippet: LoadingSnippet
      },
      {
        title: 'Menu Props',
        snippet: MenuPropsSnippet
      },
      {
        title: 'Readonly',
        snippet: ReadonlySnippet
      },
      {
        title: 'Segmented',
        snippet: SegmentedSnippet
      },
      {
        title: 'Hint',
        snippet: HintSnippet
      }
    ]
  })
}
</script>
