<template>
  <ui-demo title="Menus" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/menus" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/menus/usage.vue'
import DisabledSnippet from '!!raw-loader!./_examples/menus/simple/disabled.vue'
import RoundedSnippet from '!!raw-loader!./_examples/menus/simple/rounded.vue'
import AbsoluteSnippet from '!!raw-loader!./_examples/menus/simple/absolute.vue'
import CloseOnClickSnippet from '!!raw-loader!./_examples/menus/simple/close-on-click.vue'
import CloseOnContentClickSnippet from '!!raw-loader!./_examples/menus/simple/close-on-content-click.vue'
import CustomTransitionSnippet from '!!raw-loader!./_examples/menus/simple/custom-transition.vue'
import OffsetYSnippet from '!!raw-loader!./_examples/menus/simple/offset-y.vue'
import HoverSnippet from '!!raw-loader!./_examples/menus/simple/hover.vue'
import MenuActivatorTooltipSnippet from '!!raw-loader!./_examples/menus/simple/menu-activator-tooltip.vue'
import OffsetXSnippet from '!!raw-loader!./_examples/menus/simple/offset-x.vue'
import MenusSnippet from '!!raw-loader!./_examples/menus/intermediate/menus.vue'
import PopoverSnippet from '!!raw-loader!./_examples/menus/intermediate/popover.vue'
import AbsoluteWithoutActivatorSnippet from '!!raw-loader!./_examples/menus/intermediate/absolute-without-activator.vue'

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
        title: 'Rounded',
        snippet: RoundedSnippet
      },
      {
        title: 'Absolute',
        snippet: AbsoluteSnippet
      },
      {
        title: 'Close On Click',
        snippet: CloseOnClickSnippet
      },
      {
        title: 'Close On Content Click',
        snippet: CloseOnContentClickSnippet
      },
      {
        title: 'Custom Transition',
        snippet: CustomTransitionSnippet
      },
      {
        title: 'Offset Y',
        snippet: OffsetYSnippet
      },
      {
        title: 'Hover',
        snippet: HoverSnippet
      },
      {
        title: 'Menu Activator Tooltip',
        snippet: MenuActivatorTooltipSnippet
      },
      {
        title: 'Offset X',
        snippet: OffsetXSnippet
      },
      {
        title: 'Menus',
        snippet: MenusSnippet
      },
      {
        title: 'Popover',
        snippet: PopoverSnippet
      },
      {
        title: 'Absolute Without Activator',
        snippet: AbsoluteWithoutActivatorSnippet
      }
    ]
  })
}
</script>
