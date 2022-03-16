<template>
  <ui-demo title="Grids" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/grids" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/grids/usage.vue'
import NestedGridSnippet from '!!raw-loader!./_examples/grids/advanced/nested-grid.vue'
import OffsetSnippet from '!!raw-loader!./_examples/grids/advanced/offset.vue'
import OrderFirstLastSnippet from '!!raw-loader!./_examples/grids/advanced/order-first-last.vue'
import OrderSnippet from '!!raw-loader!./_examples/grids/advanced/order.vue'
import OffsetBreakpointSnippet from '!!raw-loader!./_examples/grids/advanced/offset-breakpoint.vue'
import EqualSnippet from '!!raw-loader!./_examples/grids/simple/equal.vue'
import AutoSnippet from '!!raw-loader!./_examples/grids/simple/auto.vue'
import HorizontalAlignmentSnippet from '!!raw-loader!./_examples/grids/simple/horizontal-alignment.vue'
import NoGuttersSnippet from '!!raw-loader!./_examples/grids/simple/no-gutters.vue'
import OneColumnWidthSnippet from '!!raw-loader!./_examples/grids/simple/one-column-width.vue'
import SpacerSnippet from '!!raw-loader!./_examples/grids/simple/spacer.vue'
import VerticalAlignmentSnippet from '!!raw-loader!./_examples/grids/simple/vertical-alignment.vue'
import UniqueLayoutsSnippet from '!!raw-loader!./_examples/grids/intermediate/unique-layouts.vue'
import GrowShrinkSnippet from '!!raw-loader!./_examples/grids/intermediate/grow-shrink.vue'
import WrappingSnippet from '!!raw-loader!./_examples/grids/intermediate/wrapping.vue'
import MarginSnippet from '!!raw-loader!./_examples/grids/intermediate/margin.vue'
import RowColumnBreakpointSnippet from '!!raw-loader!./_examples/grids/intermediate/row-column-breakpoint.vue'
import VariableContentSnippet from '!!raw-loader!./_examples/grids/intermediate/variable-content.vue'

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
        title: 'Nested Grid',
        snippet: NestedGridSnippet
      },
      {
        title: 'Offset',
        snippet: OffsetSnippet
      },
      {
        title: 'Order First Last',
        snippet: OrderFirstLastSnippet
      },
      {
        title: 'Order',
        snippet: OrderSnippet
      },
      {
        title: 'Offset Breakpoint',
        snippet: OffsetBreakpointSnippet
      },
      {
        title: 'Equal',
        snippet: EqualSnippet
      },
      {
        title: 'Auto',
        snippet: AutoSnippet
      },
      {
        title: 'Horizontal Alignment',
        snippet: HorizontalAlignmentSnippet
      },
      {
        title: 'No Gutters',
        snippet: NoGuttersSnippet
      },
      {
        title: 'One Column Width',
        snippet: OneColumnWidthSnippet
      },
      {
        title: 'Spacer',
        snippet: SpacerSnippet
      },
      {
        title: 'Vertical Alignment',
        snippet: VerticalAlignmentSnippet
      },
      {
        title: 'Unique Layouts',
        snippet: UniqueLayoutsSnippet
      },
      {
        title: 'Grow Shrink',
        snippet: GrowShrinkSnippet
      },
      {
        title: 'Wrapping',
        snippet: WrappingSnippet
      },
      {
        title: 'Margin',
        snippet: MarginSnippet
      },
      {
        title: 'Row Column Breakpoint',
        snippet: RowColumnBreakpointSnippet
      },
      {
        title: 'Variable Content',
        snippet: VariableContentSnippet
      }
    ]
  })
}
</script>
