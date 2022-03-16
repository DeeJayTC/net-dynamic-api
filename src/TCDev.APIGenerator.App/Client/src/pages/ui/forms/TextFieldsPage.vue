<template>
  <ui-demo title="Text Fields" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/text-fields" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/text-fields/usage.vue'
import DenseSnippet from '!!raw-loader!./_examples/text-fields/simple/dense.vue'
import SoloSnippet from '!!raw-loader!./_examples/text-fields/simple/solo.vue'
import SingleLineSnippet from '!!raw-loader!./_examples/text-fields/simple/single-line.vue'
import ShapedSnippet from '!!raw-loader!./_examples/text-fields/simple/shaped.vue'
import PrefixesAndSuffixesSnippet from '!!raw-loader!./_examples/text-fields/simple/prefixes-and-suffixes.vue'
import PasswordSnippet from '!!raw-loader!./_examples/text-fields/simple/password.vue'
import BoxSnippet from '!!raw-loader!./_examples/text-fields/simple/box.vue'
import CharacterCounterSnippet from '!!raw-loader!./_examples/text-fields/simple/character-counter.vue'
import ClearableSnippet from '!!raw-loader!./_examples/text-fields/simple/clearable.vue'
import CustomColorsSnippet from '!!raw-loader!./_examples/text-fields/simple/custom-colors.vue'
import OutlinedSnippet from '!!raw-loader!./_examples/text-fields/simple/outlined.vue'
import DisabledAndReadonlySnippet from '!!raw-loader!./_examples/text-fields/simple/disabled-and-readonly.vue'
import HideDetailsSnippet from '!!raw-loader!./_examples/text-fields/simple/hide-details.vue'
import HintSnippet from '!!raw-loader!./_examples/text-fields/simple/hint.vue'
import IconSnippet from '!!raw-loader!./_examples/text-fields/simple/icon.vue'
import FullWidthWithCharacterCounterSnippet from '!!raw-loader!./_examples/text-fields/intermediate/full-width-with-character-counter.vue'
import ValidationSnippet from '!!raw-loader!./_examples/text-fields/intermediate/validation.vue'
import ProgressBarSnippet from '!!raw-loader!./_examples/text-fields/intermediate/progress-bar.vue'
import LabelSlotSnippet from '!!raw-loader!./_examples/text-fields/intermediate/label-slot.vue'
import IconSlotsSnippet from '!!raw-loader!./_examples/text-fields/intermediate/icon-slots.vue'
import IconEventsSnippet from '!!raw-loader!./_examples/text-fields/intermediate/icon-events.vue'
import CustomValidationSnippet from '!!raw-loader!./_examples/text-fields/complex/custom-validation.vue'

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
        title: 'Solo',
        snippet: SoloSnippet
      },
      {
        title: 'Single Line',
        snippet: SingleLineSnippet
      },
      {
        title: 'Shaped',
        snippet: ShapedSnippet
      },
      {
        title: 'Prefixes And Suffixes',
        snippet: PrefixesAndSuffixesSnippet
      },
      {
        title: 'Password',
        snippet: PasswordSnippet
      },
      {
        title: 'Box',
        snippet: BoxSnippet
      },
      {
        title: 'Character Counter',
        snippet: CharacterCounterSnippet
      },
      {
        title: 'Clearable',
        snippet: ClearableSnippet
      },
      {
        title: 'Custom Colors',
        snippet: CustomColorsSnippet
      },
      {
        title: 'Outlined',
        snippet: OutlinedSnippet
      },
      {
        title: 'Disabled And Readonly',
        snippet: DisabledAndReadonlySnippet
      },
      {
        title: 'Hide Details',
        snippet: HideDetailsSnippet
      },
      {
        title: 'Hint',
        snippet: HintSnippet
      },
      {
        title: 'Icon',
        snippet: IconSnippet
      },
      {
        title: 'Full Width With Character Counter',
        snippet: FullWidthWithCharacterCounterSnippet
      },
      {
        title: 'Validation',
        snippet: ValidationSnippet
      },
      {
        title: 'Progress Bar',
        snippet: ProgressBarSnippet
      },
      {
        title: 'Label Slot',
        snippet: LabelSlotSnippet
      },
      {
        title: 'Icon Slots',
        snippet: IconSlotsSnippet
      },
      {
        title: 'Icon Events',
        snippet: IconEventsSnippet
      },
      {
        title: 'Custom Validation',
        snippet: CustomValidationSnippet
      }
    ]
  })
}
</script>
