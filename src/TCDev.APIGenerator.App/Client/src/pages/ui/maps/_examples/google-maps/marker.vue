<template>
  <div>
    <gmap-map :center="center" :zoom="7" style="width: 100%; height: 500px">
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
          lat: 41.14961,
          lng: -7.31099
        }
      }]
    }
  }
}
</script>
