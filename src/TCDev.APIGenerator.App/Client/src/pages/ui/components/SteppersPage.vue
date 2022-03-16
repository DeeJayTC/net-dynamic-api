<template>
  <ui-demo title="Steppers" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/steppers" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/steppers/usage.vue'
import LinearSnippet from '!!raw-loader!./_examples/steppers/simple/linear.vue'
import AlternateLabelsSnippet from '!!raw-loader!./_examples/steppers/simple/alternate-labels.vue'
import EditableSnippet from '!!raw-loader!./_examples/steppers/simple/editable.vue'
import ErrorSnippet from '!!raw-loader!./_examples/steppers/simple/error.vue'
import HorizontalSnippet from '!!raw-loader!./_examples/steppers/simple/horizontal.vue'
import AlternateErrorSnippet from '!!raw-loader!./_examples/steppers/simple/alternate-error.vue'
import NonEditableSnippet from '!!raw-loader!./_examples/steppers/simple/non-editable.vue'
import NonLinearSnippet from '!!raw-loader!./_examples/steppers/simple/non-linear.vue'
import OptionalSnippet from '!!raw-loader!./_examples/steppers/simple/optional.vue'
import VerticalErrorSnippet from '!!raw-loader!./_examples/steppers/simple/vertical-error.vue'
import VerticalSnippet from '!!raw-loader!./_examples/steppers/simple/vertical.vue'
import DynamicSnippet from '!!raw-loader!./_examples/steppers/intermediate/dynamic.vue'

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
        title: 'Linear',
        snippet: LinearSnippet
      },
      {
        title: 'Alternate Labels',
        snippet: AlternateLabelsSnippet
      },
      {
        title: 'Editable',
        snippet: EditableSnippet
      },
      {
        title: 'Error',
        snippet: ErrorSnippet
      },
      {
        title: 'Horizontal',
        snippet: HorizontalSnippet
      },
      {
        title: 'Alternate Error',
        snippet: AlternateErrorSnippet
      },
      {
        title: 'Non Editable',
        snippet: NonEditableSnippet
      },
      {
        title: 'Non Linear',
        snippet: NonLinearSnippet
      },
      {
        title: 'Optional',
        snippet: OptionalSnippet
      },
      {
        title: 'Vertical Error',
        snippet: VerticalErrorSnippet
      },
      {
        title: 'Vertical',
        snippet: VerticalSnippet
      },
      {
        title: 'Dynamic',
        snippet: DynamicSnippet
      }
    ]
  })
}
</script>
