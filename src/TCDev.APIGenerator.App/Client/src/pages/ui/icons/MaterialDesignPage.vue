<template>
  <ui-demo title="Material Design" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import MaterialDesignSnippet from '!!raw-loader!./_examples/material-design/material-design.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Material Design',
        snippet: MaterialDesignSnippet
      }
    ]
  })
}
</script>
