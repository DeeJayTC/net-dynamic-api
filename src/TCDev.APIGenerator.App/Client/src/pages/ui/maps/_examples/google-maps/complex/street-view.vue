<template>
  <div>
    <gmap-street-view-panorama
      style="width: 100%; height: 500px"
      :position="{lat: 41.1490632, lng: -8.6112119}"
      :pov="pov"
      :zoom="1"
      @pano_changed="updatePano"
      @pov_changed="updatePov"
    />

    <ul class="mt-2">
      <li class="mt-1">Heading: {{ pov && pov.heading }} <v-btn @click="pov.heading = Math.random() * 360">Change</v-btn></li>
      <li class="mt-1">Pitch: {{ pov && pov.pitch }} <v-btn @click="pov.pitch = Math.random() * 180 - 90">Change</v-btn></li>
      <li class="mt-1"><v-btn @click="pov.pitch = Math.random() * 180 - 90, pov.heading = Math.random() * 360">Change Both</v-btn></li>
      <li class="mt-1">Pano ID: {{ pano }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      pov: {
        heading: 37.42719345090184,
        pitch: 5.303323462504011,
        zoom: 1
      },
      pano: null
    }
  },
  methods: {
    updatePov(pov) {
      this.pov = pov
    },
    updatePano(pano) {
      this.pano = pano
    }
  }
}
</script>
