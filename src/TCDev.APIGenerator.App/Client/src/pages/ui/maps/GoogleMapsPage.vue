<template>
  <ui-demo title="Google Maps" :snippets="snippets"></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/google-maps/usage.vue'
import MarkerSnippet from '!!raw-loader!./_examples/google-maps/marker.vue'
import InfoWindowSnippet from '!!raw-loader!./_examples/google-maps/simple/info-window.vue'
import PolygonSnippet from '!!raw-loader!./_examples/google-maps/complex/polygon.vue'
import StreetViewSnippet from '!!raw-loader!./_examples/google-maps/complex/street-view.vue'

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
        title: 'Marker',
        snippet: MarkerSnippet
      },
      {
        title: 'Info Window',
        snippet: InfoWindowSnippet
      },
      {
        title: 'Polygon',
        snippet: PolygonSnippet
      },
      {
        title: 'Street View',
        snippet: StreetViewSnippet
      }
    ]
  })
}
</script>
