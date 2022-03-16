<template>
  <ui-demo title="Selection Controls" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/selection-controls" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/selection-controls/usage.vue'
import RadiosDirectionSnippet from '!!raw-loader!./_examples/selection-controls/simple/radios-direction.vue'
import CheckboxesArraySnippet from '!!raw-loader!./_examples/selection-controls/simple/checkboxes-array.vue'
import CheckboxesBooleanSnippet from '!!raw-loader!./_examples/selection-controls/simple/checkboxes-boolean.vue'
import CheckboxesColorsSnippet from '!!raw-loader!./_examples/selection-controls/simple/checkboxes-colors.vue'
import CheckboxesStatesSnippet from '!!raw-loader!./_examples/selection-controls/simple/checkboxes-states.vue'
import RadiosColorsSnippet from '!!raw-loader!./_examples/selection-controls/simple/radios-colors.vue'
import RadiosDefaultSnippet from '!!raw-loader!./_examples/selection-controls/simple/radios-default.vue'
import SwitchesStatesSnippet from '!!raw-loader!./_examples/selection-controls/simple/switches-states.vue'
import SwitchesArraySnippet from '!!raw-loader!./_examples/selection-controls/simple/switches-array.vue'
import SwitchesBooleanSnippet from '!!raw-loader!./_examples/selection-controls/simple/switches-boolean.vue'
import SwitchesColorsSnippet from '!!raw-loader!./_examples/selection-controls/simple/switches-colors.vue'
import SwitchesFlatSnippet from '!!raw-loader!./_examples/selection-controls/simple/switches-flat.vue'
import SwitchesInsetSnippet from '!!raw-loader!./_examples/selection-controls/simple/switches-inset.vue'
import LabelSlotSnippet from '!!raw-loader!./_examples/selection-controls/intermediate/label-slot.vue'
import CheckboxesInlineTextfieldSnippet from '!!raw-loader!./_examples/selection-controls/intermediate/checkboxes-inline-textfield.vue'

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
        title: 'Radios Direction',
        snippet: RadiosDirectionSnippet
      },
      {
        title: 'Checkboxes Array',
        snippet: CheckboxesArraySnippet
      },
      {
        title: 'Checkboxes Boolean',
        snippet: CheckboxesBooleanSnippet
      },
      {
        title: 'Checkboxes Colors',
        snippet: CheckboxesColorsSnippet
      },
      {
        title: 'Checkboxes States',
        snippet: CheckboxesStatesSnippet
      },
      {
        title: 'Radios Colors',
        snippet: RadiosColorsSnippet
      },
      {
        title: 'Radios Default',
        snippet: RadiosDefaultSnippet
      },
      {
        title: 'Switches States',
        snippet: SwitchesStatesSnippet
      },
      {
        title: 'Switches Array',
        snippet: SwitchesArraySnippet
      },
      {
        title: 'Switches Boolean',
        snippet: SwitchesBooleanSnippet
      },
      {
        title: 'Switches Colors',
        snippet: SwitchesColorsSnippet
      },
      {
        title: 'Switches Flat',
        snippet: SwitchesFlatSnippet
      },
      {
        title: 'Switches Inset',
        snippet: SwitchesInsetSnippet
      },
      {
        title: 'Label Slot',
        snippet: LabelSlotSnippet
      },
      {
        title: 'Checkboxes Inline Textfield',
        snippet: CheckboxesInlineTextfieldSnippet
      }
    ]
  })
}
</script>
