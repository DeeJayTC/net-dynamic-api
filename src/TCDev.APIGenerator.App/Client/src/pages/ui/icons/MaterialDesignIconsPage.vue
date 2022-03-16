<template>
  <ui-demo title="Material Design Icons" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import MaterialDesignIconsSnippet from '!!raw-loader!./_examples/material-design-icons/material-design-icons.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Material Design Icons',
        snippet: MaterialDesignIconsSnippet
      }
    ]
  })
}
</script>
