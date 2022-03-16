<template>
  <div>
    <div class="mb-2">
      <v-btn @click="panTo">
        Pan To
      </v-btn>

      <v-btn @click="panToBounds">
        Pan To Bounds
      </v-btn>

      <v-btn @click="fitBounds">
        Fit Bounds
      </v-btn>
    </div>

    <gmap-map ref="mmm" :center="center" :zoom="7" style="width: 100%; height: 500px">
      <gmap-marker
        v-for="(m, index) in markers"
        :key="index"
        :position="m.position"
        :clickable="true"
        :draggable="true"
        @click="center=m.position"
      ></gmap-marker>
    </gmap-map>
  </div>
</template>

<script>
export default {
  data() {
    return {
      center: {
        lat: 41.14961,
        lng: -8.61099
      },
      markers: [{
        position: {
          lat: 41.14961,
          lng: -8.61099
        }
      }, {
        position: {
          lat: 41.94961,
          lng: -8.61099
        }
      }]
    }
  },

  methods: {
    fitBounds() {
      const b = new google.maps.LatLngBounds()

      b.extend({
        lat: 33.972,
        lng: 35.4054
      })
      b.extend({
        lat: 33.7606,
        lng: 35.64592
      })

      this.$refs.mmm.fitBounds(b)
    },
    panToBounds() {
      const b = new google.maps.LatLngBounds()

      b.extend({
        lat: 33.972,
        lng: 35.4054
      })
      b.extend({
        lat: 33.7606,
        lng: 35.64592
      })

      this.$refs.mmm.panToBounds(b)
    },
    panTo() {
      this.$refs.mmm.panTo({
        lat: 47.912867,
        lng: 106.910723
      })
    }
  }
}
</script>
