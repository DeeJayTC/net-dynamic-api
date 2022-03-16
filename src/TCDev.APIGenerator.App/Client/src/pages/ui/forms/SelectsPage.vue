<template>
  <ui-demo title="Selects" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/selects" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/selects/usage.vue'
import DisabledSnippet from '!!raw-loader!./_examples/selects/simple/disabled.vue'
import ReadonlySnippet from '!!raw-loader!./_examples/selects/simple/readonly.vue'
import CustomTextAndValueSnippet from '!!raw-loader!./_examples/selects/simple/custom-text-and-value.vue'
import DenseSnippet from '!!raw-loader!./_examples/selects/simple/dense.vue'
import MultipleSnippet from '!!raw-loader!./_examples/selects/simple/multiple.vue'
import IconsSnippet from '!!raw-loader!./_examples/selects/simple/icons.vue'
import LightSnippet from '!!raw-loader!./_examples/selects/simple/light.vue'
import SelectionAppearanceSnippet from '!!raw-loader!./_examples/selects/intermediate/selection-appearance.vue'
import SlotsSnippet from '!!raw-loader!./_examples/selects/intermediate/slots.vue'
import MenuPropsSnippet from '!!raw-loader!./_examples/selects/intermediate/menu-props.vue'

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
        title: 'Disabled',
        snippet: DisabledSnippet
      },
      {
        title: 'Readonly',
        snippet: ReadonlySnippet
      },
      {
        title: 'Custom Text And Value',
        snippet: CustomTextAndValueSnippet
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
        title: 'Icons',
        snippet: IconsSnippet
      },
      {
        title: 'Light',
        snippet: LightSnippet
      },
      {
        title: 'Selection Appearance',
        snippet: SelectionAppearanceSnippet
      },
      {
        title: 'Slots',
        snippet: SlotsSnippet
      },
      {
        title: 'Menu Props',
        snippet: MenuPropsSnippet
      }
    ]
  })
}
</script>
