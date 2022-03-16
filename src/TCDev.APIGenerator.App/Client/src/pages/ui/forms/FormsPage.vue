<template>
  <ui-demo title="Forms" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/forms" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/forms/usage.vue'
import RulesSnippet from '!!raw-loader!./_examples/forms/simple/rules.vue'
import ValidationWithSubmitAndClearSnippet from '!!raw-loader!./_examples/forms/simple/validation-with-submit-and-clear.vue'

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
        title: 'Rules',
        snippet: RulesSnippet
      },
      {
        title: 'Validation With Submit And Clear',
        snippet: ValidationWithSubmitAndClearSnippet
      }
    ]
  })
}
</script>
