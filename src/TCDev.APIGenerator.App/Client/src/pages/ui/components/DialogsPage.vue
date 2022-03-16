<template>
  <ui-demo title="Dialogs" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/dialogs" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/dialogs/usage.vue'
import ModalSnippet from '!!raw-loader!./_examples/dialogs/simple/modal.vue'
import OverflowedSnippet from '!!raw-loader!./_examples/dialogs/simple/overflowed.vue'
import ScrollableSnippet from '!!raw-loader!./_examples/dialogs/simple/scrollable.vue'
import WithoutActivatorSnippet from '!!raw-loader!./_examples/dialogs/simple/without-activator.vue'
import FormSnippet from '!!raw-loader!./_examples/dialogs/intermediate/form.vue'
import FullscreenSnippet from '!!raw-loader!./_examples/dialogs/intermediate/fullscreen.vue'
import LoaderSnippet from '!!raw-loader!./_examples/dialogs/intermediate/loader.vue'
import AdvancedSnippet from '!!raw-loader!./_examples/dialogs/complex/advanced.vue'

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
        title: 'Modal',
        snippet: ModalSnippet
      },
      {
        title: 'Overflowed',
        snippet: OverflowedSnippet
      },
      {
        title: 'Scrollable',
        snippet: ScrollableSnippet
      },
      {
        title: 'Without Activator',
        snippet: WithoutActivatorSnippet
      },
      {
        title: 'Form',
        snippet: FormSnippet
      },
      {
        title: 'Fullscreen',
        snippet: FullscreenSnippet
      },
      {
        title: 'Loader',
        snippet: LoaderSnippet
      },
      {
        title: 'Advanced',
        snippet: AdvancedSnippet
      }
    ]
  })
}
</script>
