<template>
  <ui-demo title="Buttons" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/buttons" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import OutlinedSnippet from '!!raw-loader!./_examples/buttons/simple/outlined.vue'
import TileSnippet from '!!raw-loader!./_examples/buttons/simple/tile.vue'
import DepressedSnippet from '!!raw-loader!./_examples/buttons/simple/depressed.vue'
import DropdownSnippet from '!!raw-loader!./_examples/buttons/simple/dropdown.vue'
import FloatingSnippet from '!!raw-loader!./_examples/buttons/simple/floating.vue'
import IconSnippet from '!!raw-loader!./_examples/buttons/simple/icon.vue'
import BlockSnippet from '!!raw-loader!./_examples/buttons/simple/block.vue'
import RaisedSnippet from '!!raw-loader!./_examples/buttons/simple/raised.vue'
import RoundedSnippet from '!!raw-loader!./_examples/buttons/simple/rounded.vue'
import SizingSnippet from '!!raw-loader!./_examples/buttons/simple/sizing.vue'
import TextSnippet from '!!raw-loader!./_examples/buttons/simple/text.vue'
import LoadersSnippet from '!!raw-loader!./_examples/buttons/intermediate/loaders.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Outlined',
        snippet: OutlinedSnippet
      },
      {
        title: 'Tile',
        snippet: TileSnippet
      },
      {
        title: 'Depressed',
        snippet: DepressedSnippet
      },
      {
        title: 'Dropdown',
        snippet: DropdownSnippet
      },
      {
        title: 'Floating',
        snippet: FloatingSnippet
      },
      {
        title: 'Icon',
        snippet: IconSnippet
      },
      {
        title: 'Block',
        snippet: BlockSnippet
      },
      {
        title: 'Raised',
        snippet: RaisedSnippet
      },
      {
        title: 'Rounded',
        snippet: RoundedSnippet
      },
      {
        title: 'Sizing',
        snippet: SizingSnippet
      },
      {
        title: 'Text',
        snippet: TextSnippet
      },
      {
        title: 'Loaders',
        snippet: LoadersSnippet
      }
    ]
  })
}
</script>
