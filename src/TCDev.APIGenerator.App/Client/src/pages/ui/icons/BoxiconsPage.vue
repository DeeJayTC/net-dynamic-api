<template>
  <ui-demo title="Boxicons" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import BoxiconsSnippet from '!!raw-loader!./_examples/boxicons/boxicons.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Boxicons',
        snippet: BoxiconsSnippet
      }
    ]
  })
}
</script>
