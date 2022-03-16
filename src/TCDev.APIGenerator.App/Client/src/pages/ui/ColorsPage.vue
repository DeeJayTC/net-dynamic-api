<template>
  <ui-demo title="Colors" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/styles/colors" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import ClassesSnippet from '!!raw-loader!./_examples/colors/classes.vue'
import TextClassesSnippet from '!!raw-loader!./_examples/colors/text-classes.vue'
import ColorPaletteSnippet from '!!raw-loader!./_examples/colors/simple/color-palette.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Classes',
        snippet: ClassesSnippet
      },
      {
        title: 'Text Classes',
        snippet: TextClassesSnippet
      },
      {
        title: 'Color Palette',
        snippet: ColorPaletteSnippet
      }
    ]
  })
}
</script>
