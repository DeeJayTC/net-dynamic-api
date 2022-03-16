<template>
  <ui-demo title="Lists" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/lists" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/lists/usage.vue'
import DenseSnippet from '!!raw-loader!./_examples/lists/simple/dense.vue'
import DisabledSnippet from '!!raw-loader!./_examples/lists/simple/disabled.vue'
import FlatSnippet from '!!raw-loader!./_examples/lists/simple/flat.vue'
import RoundedSnippet from '!!raw-loader!./_examples/lists/simple/rounded.vue'
import ShapedSnippet from '!!raw-loader!./_examples/lists/simple/shaped.vue'
import ExpansionListsSnippet from '!!raw-loader!./_examples/lists/intermediate/expansion-lists.vue'
import IconTwoLinesAndActionSnippet from '!!raw-loader!./_examples/lists/intermediate/icon-two-lines-and-action.vue'
import NavSnippet from '!!raw-loader!./_examples/lists/intermediate/nav.vue'
import ActionWithTitleAndSubtitleSnippet from '!!raw-loader!./_examples/lists/intermediate/action-with-title-and-subtitle.vue'
import SubheadingsAndDividersSnippet from '!!raw-loader!./_examples/lists/intermediate/subheadings-and-dividers.vue'
import TitleSubtitleActionsAndActionTextSnippet from '!!raw-loader!./_examples/lists/intermediate/title-subtitle-actions-and-action-text.vue'
import ActionTitleAndSubtitleSnippet from '!!raw-loader!./_examples/lists/intermediate/action-title-and-subtitle.vue'
import AvatarSubheaderTitleAndActionSnippet from '!!raw-loader!./_examples/lists/intermediate/avatar-subheader-title-and-action.vue'
import AvatarThreeLinesSnippet from '!!raw-loader!./_examples/lists/intermediate/avatar-three-lines.vue'
import AvatarTitleAndActionSnippet from '!!raw-loader!./_examples/lists/intermediate/avatar-title-and-action.vue'
import CardListSnippet from '!!raw-loader!./_examples/lists/intermediate/card-list.vue'
import NestedSnippet from '!!raw-loader!./_examples/lists/intermediate/nested.vue'

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
        title: 'Dense',
        snippet: DenseSnippet
      },
      {
        title: 'Disabled',
        snippet: DisabledSnippet
      },
      {
        title: 'Flat',
        snippet: FlatSnippet
      },
      {
        title: 'Rounded',
        snippet: RoundedSnippet
      },
      {
        title: 'Shaped',
        snippet: ShapedSnippet
      },
      {
        title: 'Expansion Lists',
        snippet: ExpansionListsSnippet
      },
      {
        title: 'Icon Two Lines And Action',
        snippet: IconTwoLinesAndActionSnippet
      },
      {
        title: 'Nav',
        snippet: NavSnippet
      },
      {
        title: 'Action With Title And Subtitle',
        snippet: ActionWithTitleAndSubtitleSnippet
      },
      {
        title: 'Subheadings And Dividers',
        snippet: SubheadingsAndDividersSnippet
      },
      {
        title: 'Title Subtitle Actions And Action Text',
        snippet: TitleSubtitleActionsAndActionTextSnippet
      },
      {
        title: 'Action Title And Subtitle',
        snippet: ActionTitleAndSubtitleSnippet
      },
      {
        title: 'Avatar Subheader Title And Action',
        snippet: AvatarSubheaderTitleAndActionSnippet
      },
      {
        title: 'Avatar Three Lines',
        snippet: AvatarThreeLinesSnippet
      },
      {
        title: 'Avatar Title And Action',
        snippet: AvatarTitleAndActionSnippet
      },
      {
        title: 'Card List',
        snippet: CardListSnippet
      },
      {
        title: 'Nested',
        snippet: NestedSnippet
      }
    ]
  })
}
</script>
