<template>
  <ui-demo title="Font Awesome" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import FontAwesomeSnippet from '!!raw-loader!./_examples/font-awesome/font-awesome.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Font Awesome',
        snippet: FontAwesomeSnippet
      }
    ]
  })
}
</script>
