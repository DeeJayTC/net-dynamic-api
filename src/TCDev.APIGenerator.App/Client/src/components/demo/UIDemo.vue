<template>
  <div class="py-3 min-w-0 w-full">
    <div class="display-1">{{ title }}</div>
    <slot></slot>
    <v-breadcrumbs :items="breadcrumbs" class="pa-0 py-2"></v-breadcrumbs>

    <v-card v-for="(item, index) in snippets" :key="index" class="mt-2 pa-2">
      <code-preview :components="components" :code="item.snippet" :title="item.title" :show-code="index === 0" />
    </v-card>
  </div>
</template>

<script>
import CodePreview from './CodePreview'

export default {
  components: {
    CodePreview
  },
  props: {
    title: {
      type: String,
      default: ''
    },
    snippets: {
      type: Array,
      default: () => []
    },
    components: {
      type: Object,
      default: () => ({})
    }
  },
  data() {
    return {
      breadcrumbs: [{
        text: 'UI',
        disabled: false,
        href: '#'
      }, {
        text: this.title
      }]
    }
  }
}
</script>
